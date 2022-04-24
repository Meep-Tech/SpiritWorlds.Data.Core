using System;

namespace SpiritWorlds.Data.Included {
  public static partial class Biomes {

    /// <summary>
    /// Gentle grassy hills made from perilin noise.
    /// </summary>
    public class PerlinHills : Biome.Type {

      /// <summary>
      /// The Id For a Perlin Hills Biome.
      /// </summary>
      public static new Identity Id {
        get;
      } = new Identity("Perlin Hills");

      PerlinHills()
        : base(Id) { }

      protected override Tile.Column.Stack GenerateTileStack(Tile.Key tileLocationKey, Biome currentBiome) {
        int hillHeight 
          = (int)Math.Round(
            currentBiome.BaseHeight
              + currentBiome.Board.NoiseLayers[Tiles.Boards.NoiseLayers.HeightMap].GetPerlin(tileLocationKey.X, tileLocationKey.Z));

        return Tile.Column.Stack.Make(
          // from the bottom to right before the top is dirt
          (null, (
           Tiles.Dirt.Id,
           hillHeight - 1
          )),
          // top it off with grass
          (hillHeight, (
            Tiles.Grass.Id,
            null
          )));
      }
    }
  }
}
