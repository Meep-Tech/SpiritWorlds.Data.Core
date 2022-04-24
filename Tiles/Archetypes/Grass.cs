namespace SpiritWorlds.Data.Included {
  public static partial class Tiles {

    /// <summary>
    /// A simple grass tile.
    /// </summary>
    public class Grass : Tile.Type {

      /// <summary>
      /// A simple grass tile.
      /// </summary>
      public static new Identity Id {
        get;
      } = new Identity("Grass");

      Grass() 
        : base(Id) {}
    }
  }
}
