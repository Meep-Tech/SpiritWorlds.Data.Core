using Meep.Tech.Data;

namespace SpiritWorlds.Data.Included {

  public partial class DamageTypes {

    /// <summary>
    /// Potential targets for the included damage types.
    /// </summary>
    public class Targets : Enumeration<Targets> {

      /// <summary>
      /// Target the body for physical damage
      /// </summary>
      public static Targets Body {
        get;
      } = new Targets(nameof(Body));

      /// <summary>
      /// Target the mind for mental/thought damage
      /// </summary>
      public static Targets Mind {
        get;
      } = new Targets(nameof(Mind));

      /// <summary>
      /// Target the spirit for magical/ziz/elemental damage
      /// </summary>
      public static Targets Spirit {
        get;
      } = new Targets(nameof(Spirit));

      protected Targets(string uniqueName) 
        : base(uniqueName) {}
    }
  }
}
