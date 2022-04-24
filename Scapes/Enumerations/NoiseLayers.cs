using Meep.Tech.Noise;
using System;

namespace SpiritWorlds.Data.Included {
  public static partial class Tiles {
    public static partial class Boards {

      /// <summary>
      /// Included scape noise layers
      /// </summary>
      public class NoiseLayers : Tile.Board.NoiseLayer {

        /// <summary>
        /// the basic height map used to get the average heights of each biome circumcenter.
        /// </summary>
        public static NoiseLayers HeightMap { get; }
          = new("Basic Height Map");

        /// <summary>
        /// the basic mositure map.
        /// </summary>
        public static NoiseLayers HumidityMap { get; }
          = new("Basic Humidity Map");

        /// <summary>
        /// the basic temp map.
        /// </summary>
        public static NoiseLayers TemperatureMap { get; }
          = new("Basic Temperature Map");

        NoiseLayers(string nameKey, Func<FastNoise> noiseGeneratorOverride = null)
          : base($"Included." + nameKey, noiseGeneratorOverride) { }
      }
    }
  }
}