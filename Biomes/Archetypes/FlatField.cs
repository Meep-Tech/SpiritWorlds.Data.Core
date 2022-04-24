namespace SpiritWorlds.Data.Included {
  public static partial class Biomes {
    public class FlatField : Biome.Type {

      /// <summary>
      /// The Id For a Flat Field Biome. Just makes grass at a height of 1
      /// </summary>
      public static new Identity Id {
        get;
      } = new Identity("Flat Field");

      FlatField()
        : base(Id) { }

      protected override Tile.Column.Stack GenerateTileStack(Tile.Key tileLocationKey, Biome currentBiome)
        => Tile.Column.Stack.Make(
          (0, (Tiles.Grass.Id, currentBiome.BaseHeight))
        );
    }
  }
}
