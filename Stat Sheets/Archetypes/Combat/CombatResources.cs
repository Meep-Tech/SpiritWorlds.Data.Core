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
      public class CombatResources : Stat.Sheet.Type {

        protected CombatResources()
          : base(
            new Identity("Resources"),
            "These stats are used as resources in combat.",
            defaultFixedStats: null,
            derivedStats: new() {
              {
                Stat.Types.Get<HealthPoints>(),
                DerivedStat.FromExisting(
                    (sheet, stats) => {
                      (Stat e, (Stat p, (Stat v, (Stat f, _)))) = stats;
                      return Stat.Types.Get<HealthPoints>().Make(
                        e.CurrentValue * 8
                          + p.CurrentValue * 4
                          + v.CurrentValue * 2
                          + f.CurrentValue
                      );
                    },
                    Stat.Types.Get<Endurance>(),
                    Stat.Types.Get<Potency>(),
                    Stat.Types.Get<Vision>(),
                    Stat.Types.Get<Finesse>()
                  )
                }, {
                Stat.Types.Get<StaminaPoints>(),
                new DerivedStat(
                  new Stat.Type[] {
                    Stat.Types.Get<Finesse>(),
                    Stat.Types.Get<Endurance>(),
                    Stat.Types.Get<Vision>(),
                    Stat.Types.Get<Potency>()
                  },
                  sheet
                    => Stat.Types.Get<StaminaPoints>().MakeDepleteable(
                      ((sheet?.Dependencies[Stat.Sheet.Types.Get<CoreStats>()]
                          .Get(Archetypes<Finesse>._).CurrentValue * 8)
                        + (sheet?.Dependencies[Stat.Sheet.Types.Get<CoreStats>()]
                          .Get(Archetypes<Endurance>._).CurrentValue * 4)
                        + (sheet?.Dependencies[Stat.Sheet.Types.Get<CoreStats>()]
                          .Get(Archetypes<Vision>._).CurrentValue * 2)
                        + (sheet?.Dependencies[Stat.Sheet.Types.Get<CoreStats>()]
                          .Get(Archetypes<Potency>._).CurrentValue))
                      / 4)
                )
              }, {
                Stat.Types.Get<ZizPool>(),
                new DerivedStat(
                  new Stat.Type[] {
                    Stat.Types.Get<Vision>(),
                    Stat.Types.Get<Potency>(),
                    Stat.Types.Get<Endurance>(),
                    Stat.Types.Get<Finesse>()
                  },
                  sheet
                    => Stat.Types.Get<ZizPool>().MakeDepleteable(
                      ((sheet?.Dependencies[Stat.Sheet.Types.Get<CoreStats>()]
                          .Get(Archetypes<Vision>._).CurrentValue * 8)
                        + (sheet?.Dependencies[Stat.Sheet.Types.Get<CoreStats>()]
                          .Get(Archetypes<Potency>._).CurrentValue * 4)
                        + (sheet?.Dependencies[Stat.Sheet.Types.Get<CoreStats>()]
                          .Get(Archetypes<Endurance>._).CurrentValue * 2)
                        + (sheet?.Dependencies[Stat.Sheet.Types.Get<CoreStats>()]
                          .Get(Archetypes<Finesse>._).CurrentValue))
                      / 2)
                )
              }
            }
          ) { }

        /// <summary>
        /// Used to make a new default stat sheet.
        /// </summary>
        public static new Stat.Sheet Make()
          => Stat.Sheet.Types
            .Get<CombatResources>()
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