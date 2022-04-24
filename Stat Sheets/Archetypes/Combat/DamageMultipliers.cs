using Meep.Tech.Collections.Generic;
using Meep.Tech.Data;
using Meep.Tech.Data.Configuration;
using System.Collections.Generic;
using static SpiritWorlds.Data.Stats;
using static SpiritWorlds.Data.Stats.Sheets;

namespace SpiritWorlds.Data.Included {
  public static partial class Stats {
    public static partial class Sheets {

      [Loader.Settings.Dependency(typeof(CoreStats))]
      public class DamageMultipliers : Stat.Sheet.Type {
        protected DamageMultipliers()
          : base(
            new Identity("Damage Multipliers"),
            "These stats dictate how much additional damage percentage is added onto damage of certain types when you attack enemeis",
            defaultFixedStats: null,
            derivedStats: new() {
              {
                Stat.Types.Get<DamageTypeMultiplier>().For(DamageType.General),
                DerivedStat.FromExisting(
                  (__, stats) => {
                    (Stat p, _) = stats;
                    return Stat.Types.Get<DamageTypeMultiplier>().For(DamageType.General)
                      .Make(p.CurrentValue / 2);
                  },
                  Stat.Types.Get<Potency>()
                )
              }, {
                Stat.Types.Get<CriticalStrikeChanceBonus>(),
                DerivedStat.ScaledFromExisting(
                  value => Stat.Types.Get<CriticalStrikeChanceBonus>().Make(value/10),
                  (Stat.Types.Get<DamageTypeMultiplier>().For(DamageType.General),
                    0.30f), 
                  (Archetypes<Finesse>._,
                    0.35f),
                  (Archetypes<Vision>._,
                    0.35f)
                )
              }
            }
          ) 
        {
          // add in damage multiplier stats loaded from enums.
          var loadedDamageTypeMultiplierStats = new Dictionary<Stat.Type, DerivedStat>();
          foreach(var damageType in DamageType.All) {
            var damageMultiplierArchetype = Stat.Types.Get<DamageTypeMultiplier>().For(damageType);
            if (!DefaultDerivedStats.ContainsKey(damageMultiplierArchetype) && damageType.DefaultDamageMultiplierStat.HasValue) {
              loadedDamageTypeMultiplierStats.Add(damageMultiplierArchetype, damageType.DefaultDamageMultiplierStat.Value);
            }
          }

          AdditionalDerivedStats = loadedDamageTypeMultiplierStats;
        }

        /// <summary>
        /// Used to make a new default stat sheet.
        /// </summary>
        public static new Stat.Sheet Make()
          => Stat.Sheet.Types
            .Get<DamageMultipliers>()
              .Make<Stat.Sheet>();

        #region Archetype Config Settings

        internal static Stat.Sheet _testCoreStats
          = Data.Stats.Sheets.CoreStats.Make();

        protected override Dictionary<string, object> DefaultTestParams
          => new() {
            { nameof(CoreStats), _testCoreStats }
          };

        #endregion
      }
    }
  }
}