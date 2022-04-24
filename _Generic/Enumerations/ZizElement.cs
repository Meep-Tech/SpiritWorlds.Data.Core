using Meep.Tech.Data;

namespace SpiritWorlds.Data.Included {

  /// <summary>
  /// The elements of the magic known as Ziz
  /// </summary>
  public class ZizElement : Enumeration<ZizElement> {

    /// <summary>
    /// The element of burning and flames 
    /// </summary>
    public static ZizElement Fire { get; }
      = new ZizElement(nameof(Fire));
    
    /// <summary>
    /// The element of water/cold
    /// </summary>
    public static ZizElement Water { get; }
      = new ZizElement(nameof(Water));
    
    /// <summary>
    /// The element of earth and living things in spirit worlds.
    /// </summary>
    public static ZizElement Earth { get; }
      = new ZizElement(nameof(Earth));
    
    /// <summary>
    /// The element of the air/wind/sky
    /// </summary>
    public static ZizElement Air { get; }
      = new ZizElement(nameof(Air));
    
    /// <summary>
    /// The element of the void and shadows
    /// </summary>
    public static ZizElement Dark { get; }
      = new ZizElement(nameof(Air));
    
    /// <summary>
    /// The element of light and radiation
    /// </summary>
    public static ZizElement Light { get; }
      = new ZizElement(nameof(Air));
    
    /// <summary>
    /// the pure ziz element. Also represents lightning and electricity
    /// </summary>
    public static ZizElement Ziz { get; }
      = new ZizElement(nameof(Air));

    protected ZizElement(string uniqueNameForZizElement)
      : base(uniqueNameForZizElement) { }

  }
}