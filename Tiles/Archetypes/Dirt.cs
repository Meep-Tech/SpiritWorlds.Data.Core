namespace SpiritWorlds.Data.Included {
  public static partial class Tiles {

    /// <summary>
    /// A simple dirt tile.
    /// </summary>
    public class Dirt : Tile.Type {

      /// <summary>
      /// A simple grass tile.
      /// </summary>
      public static new Identity Id {
        get;
      } = new Identity("Dirt");

      Dirt() 
        : base(Id) {}
    }
  }
}
