using Meep.Tech.Data;

namespace SpiritWorlds.Data.Included.Components {
  public static partial class Entities {

    /// <summary>
    /// A component containing the basic combat stats used in spiritworlds.
    /// </summary>
    public class CombatStats : Data.Components.Entities.CombatStats {

      /// <summary>
      /// Combat resource stats
      /// </summary>
      public override Stat.Sheet Resources {
        get;
      } = Stats.Sheets.CombatResources.Make();

      /// <summary>
      /// Offencive combat stats
      /// </summary>
      public override Stat.Sheet DamageMultipliers {
        get;
      } = Stats.Sheets.DamageMultipliers.Make();

      /// <summary>
      /// Defensive combat stats
      /// </summary>
      public override Stat.Sheet DamageResistances {
        get;
      } = Stats.Sheets.DamageResistances.Make();

      /// <summary>
      /// Defensive combat stats
      /// </summary>
      public override Stat.Sheet StatusEffectResistances {
        get;
      } = Stats.Sheets.StatusEffectResistances.Make();

      CombatStats(IBuilder<Data.Components.Entities.CombatStats> builder) 
        : base(builder) {}

      /*#region Xbam Configuration

      internal static Stat.Sheet _testCoreStats
        = Stats.Sheets.CoreStats.Make();

      static CombatStats() {
        Components<CombatStats>.BuilderFactory
          = new IComponent<CombatStats>.BuilderFactory(new Archetype<CombatStats, IComponent<CombatStats>.BuilderFactory>.Identity("Combat Stats")) {
            DefaultTestParams = new() {
              { nameof(Stats.Sheets.CoreStats), _testCoreStats }
            }
          };
      }

      #endregion*/
    }
  }
}