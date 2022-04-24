using Meep.Tech.Collections.Generic;
using Meep.Tech.Data;
using Meep.Tech.Data.Configuration;
using SpiritWorlds.Data.Components;
using System.Collections.Generic;
using static SpiritWorlds.Data.Stats;
using static SpiritWorlds.Data.Stats.Sheets;

namespace SpiritWorlds.Data.Included {
  public static partial class Stats {
    public static partial class Sheets {

      [Loader.Settings.Dependency(typeof(CoreStats))]
      public class DamageResistances : Stat.Sheet.Type {
        protected DamageResistances()
          : base(
              new Identity("Damage Resistances"),
              "The stats that dictate how much of each kind of damage your resist per hit.",
              defaultFixedStats: null,
              derivedStats: new() {
                {
                  Stat.Types.Get<DamageTypeResistance>().For(DamageType.General),
                  DerivedStat.FromExisting(
                    (__, stats) => {
                      (Stat p, _) = stats;
                      return Stat.Types.Get<DamageTypeResistance>().For(DamageType.General)
                        .Make(p.CurrentValue / 2);
                    },
                    Stat.Types.Get<Endurance>()
                  )
                }
              }) 
        {
          // add in damage resistance stats loaded from enums.
          var loadedDamageTypeResistanceStats = new Dictionary<Stat.Type, DerivedStat>();
          foreach (var damageType in DamageType.All) {
            var damageResistanceArchetype = Stat.Types.Get<DamageTypeResistance>().For(damageType);
            if (!DefaultDerivedStats.ContainsKey(damageResistanceArchetype) && damageType.DefaultDamageResistanceStat.HasValue) {
              loadedDamageTypeResistanceStats.Add(damageResistanceArchetype, damageType.DefaultDamageResistanceStat.Value);
            }
          }

          AdditionalDerivedStats = loadedDamageTypeResistanceStats;
        }

        /// <summary>
        /// Used to make a new default stat sheet.
        /// </summary>
        public static new Stat.Sheet Make()
          => Stat.Sheet.Types
            .Get<DamageResistances>()
              .Make<Stat.Sheet>();

        #region Archetype Config Settings

        protected override Dictionary<string, object> DefaultTestParams
          => new() {
            { nameof(CoreStats), DamageMultipliers._testCoreStats }
          };

        #endregion
      }
    }
  }
}
