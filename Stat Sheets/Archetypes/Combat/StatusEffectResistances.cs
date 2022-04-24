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
      public class StatusEffectResistances : Stat.Sheet.Type {
        protected StatusEffectResistances()
          : base(
              new Identity("Status Effect Resistances"),
              "The stats that dictate how well you resist each type of status effect.",
              defaultFixedStats: null,
              derivedStats: new() {
                {
                  Stat.Types.Get<Immunity>(),
                  DerivedStat.ScaledFromExisting<Immunity>(
                    value => value / 2,
                    (Archetypes<Endurance>._,
                        0.80f),
                    (Archetypes<Vision>._,
                        0.10f),
                    (Archetypes<Potency>._,
                        0.10f)
                  )
                }, {
                  Stat.Types.Get<Alertness>(),
                  DerivedStat.ScaledFromExisting<Alertness>(
                    value => value / 2,
                    (Archetypes<Finesse>._,
                      0.50f),
                    (Archetypes<Vision>._,
                      0.30f),
                    (Archetypes<Potency>._,
                      0.20f)
                  )
                }, {
                  Stat.Types.Get<Clarity>(),
                  DerivedStat.ScaledFromExisting<Clarity>(
                    value => value / 2,
                    (Archetypes<Vision>._,
                      0.80f),
                    (Archetypes<Finesse>._,
                      0.20f)
                  )
                }, {
                  Stat.Types.Get<Toughness>(),
                  DerivedStat.ScaledFromExisting<Toughness>(
                    value => value / 2,
                    (Archetypes<Endurance>._,
                      0.70f
                    ), (Archetypes<Potency>._,
                      0.30f
                    )
                  )
                }, {
                  Stat.Types.Get<Vacuousness>(),
                  DerivedStat.ScaledFromExisting<Vacuousness>(
                    value => value / 2,
                    (Archetypes<Endurance>._,
                      0.30f
                    ), (Archetypes<Vision>._,
                      -0.50f
                    ), (Archetypes<Potency>._,
                      -0.20f
                    ), (Archetypes<Finesse>._,
                      -0.20f
                    )
                  )
                }, {
                  Stat.Types.Get<Poise>(),
                  DerivedStat.ScaledFromExisting<Poise>(
                    value => value / 2,
                    (Archetypes<Endurance>._,
                      0.75f
                    ), (Archetypes<Potency>._,
                      0.25f
                    )
                  )
                }
              }) { }

        /// <summary>
        /// Used to make a new default stat sheet.
        /// </summary>
        public static new Stat.Sheet Make()
          => Stat.Sheet.Types
            .Get<StatusEffectResistances>()
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
