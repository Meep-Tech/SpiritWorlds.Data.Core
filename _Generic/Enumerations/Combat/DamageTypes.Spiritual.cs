using Meep.Tech.Collections.Generic;
using Meep.Tech.Data;
using System.Collections.Generic;
using System.Linq;

namespace SpiritWorlds.Data.Included {

  public abstract partial class DamageTypes {

    /// <summary>
    /// The base class for spiritual damage types.
    /// There is one for each Ziz element as well.
    /// </summary>
    public class Spiritual : DamageTypes, IElementalDamageType {

      /// <summary>
      /// General spirital damage.
      /// </summary>
      public new static Spiritual General {
        get;
      } = new Spiritual(
        nameof(General),
        "General Spiritual or Elemental Damage",
        default,
        new(),
        defaultDamageMultiplierStat: DerivedStat.ScaledFromExisting(
          value => Stat.Types.Get<DamageTypeMultiplier>().For(General).Make(value),
          (Stat.Types.Get<DamageTypeMultiplier>().For(DamageType.General), 0.60f),
          (Stat.Types.Get<Data.Stats.Potency>(), 0.25f),
          (Stat.Types.Get<Data.Stats.Vision>(), 0.15f)
        ),
        defaultDamageResistanceStat: DerivedStat.ScaledFromExisting(
          value => Stat.Types.Get<DamageTypeResistance>().For(General).Make(value),
          (Stat.Types.Get<DamageTypeResistance>().For(DamageType.General), 0.60f),
          (Stat.Types.Get<Data.Stats.Vision>(), 0.20f),
          (Stat.Types.Get<Data.Stats.Potency>(), 0.20f)
        )
      );

      /// <summary>
      /// Fire damage
      /// </summary>
      public static Spiritual Fire {
        get;
      } = new Spiritual(
        nameof(Fire),
        "Burning damage from flames and heat.",
        'F',
        ZizElement.Fire.AsSingleItemEnumerable().ToHashSet(),
        defaultDamageMultiplierStat: DerivedStat.ScaledFromExisting(
          value => Stat.Types.Get<DamageTypeMultiplier>().For(Fire).Make(value),
          (Stat.Types.Get<DamageTypeMultiplier>().For(General), 0.65f),
          (Stat.Types.Get<Data.Stats.Potency>(), 0.35f)
        ),
        defaultDamageResistanceStat: DerivedStat.ScaledFromExisting(
          value => Stat.Types.Get<DamageTypeResistance>().For(Fire).Make(value),
          (Stat.Types.Get<DamageTypeResistance>().For(General), 0.70f),
          (Stat.Types.Get<Data.Stats.Finesse>(), 0.15f),
          (Stat.Types.Get<Data.Stats.Potency>(), 0.15f)
        )
      );

      /// <summary>
      /// Cold damage
      /// </summary>
      public static Spiritual Cold {
        get;
      } = new Spiritual(
        nameof(Cold),
        "Frost and freezing damage from ice and sapping waters.",
        'C',
        ZizElement.Water.AsSingleItemEnumerable().ToHashSet(),
        defaultDamageMultiplierStat: DerivedStat.ScaledFromExisting(
          value => Stat.Types.Get<DamageTypeMultiplier>().For(Cold).Make(value),
          (Stat.Types.Get<DamageTypeMultiplier>().For(General), 0.55f),
          (Stat.Types.Get<Data.Stats.Vision>(), 0.45f)
        ),
        defaultDamageResistanceStat: DerivedStat.ScaledFromExisting(
          value => Stat.Types.Get<DamageTypeResistance>().For(Cold).Make(value),
          (Stat.Types.Get<DamageTypeResistance>().For(General), 0.70f),
          (Stat.Types.Get<Data.Stats.Endurance>(), 0.15f),
          (Stat.Types.Get<Data.Stats.Vision>(), 0.15f)
        )
      );

      /// <summary>
      /// Corrosive and unhealthy damage
      /// </summary>
      public static Spiritual Acid {
        get;
      } = new Spiritual(
        nameof(Acid),
        "Corrosive and unhealthy damage from things like acids and poisions.",
        'A',
        ZizElement.Earth.AsSingleItemEnumerable().ToHashSet(),
        defaultDamageMultiplierStat: DerivedStat.ScaledFromExisting(
          value => Stat.Types.Get<DamageTypeMultiplier>().For(Acid).Make(value),
          (Stat.Types.Get<DamageTypeMultiplier>().For(General), 0.65f),
          (Stat.Types.Get<Data.Stats.Endurance>(), 0.35f)
        ),
        defaultDamageResistanceStat: DerivedStat.ScaledFromExisting(
          value => Stat.Types.Get<DamageTypeResistance>().For(Acid).Make(value),
          (Stat.Types.Get<DamageTypeResistance>().For(General), 0.70f),
          (Stat.Types.Get<Data.Stats.Finesse>(), 0.15f),
          (Stat.Types.Get<Data.Stats.Endurance>(), 0.15f)
        )
      );

      /// <summary>
      /// Force and sound damage
      /// </summary>
      public static Spiritual Sonic {
        get;
      } = new Spiritual(
        nameof(Sonic),
        "Force and sound damage that can cause internal problems.",
        'S',
        ZizElement.Air.AsSingleItemEnumerable().ToHashSet(),
        defaultDamageMultiplierStat: DerivedStat.ScaledFromExisting(
          value => Stat.Types.Get<DamageTypeMultiplier>().For(Sonic).Make(value),
          (Stat.Types.Get<DamageTypeMultiplier>().For(General), 0.65f),
          (Stat.Types.Get<Data.Stats.Vision>(), 0.175f),
          (Stat.Types.Get<Data.Stats.Finesse>(), 0.175f)
        ),
        defaultDamageResistanceStat: DerivedStat.ScaledFromExisting(
          value => Stat.Types.Get<DamageTypeResistance>().For(Sonic).Make(value),
          (Stat.Types.Get<DamageTypeResistance>().For(General), 0.70f),
          (Stat.Types.Get<Data.Stats.Finesse>(), 0.15f),
          (Stat.Types.Get<Data.Stats.Vision>(), 0.15f)
        )
      );

      /// <summary>
      /// Lightning and ziz damage
      /// </summary>
      public static Spiritual Electric {
        get;
      } = new Spiritual(
        nameof(Electric),
        "Lightning and electrical damage.",
        'E',
        ZizElement.Ziz.AsSingleItemEnumerable().ToHashSet(),
        defaultDamageMultiplierStat: DerivedStat.ScaledFromExisting(
          value => Stat.Types.Get<DamageTypeMultiplier>().For(Electric).Make(value),
          (Stat.Types.Get<DamageTypeMultiplier>().For(General), 0.65f),
          (Stat.Types.Get<Data.Stats.Potency>(), 0.175f),
          (Stat.Types.Get<Data.Stats.Vision>(), 0.175f)
        ),
        defaultDamageResistanceStat: DerivedStat.ScaledFromExisting(
          value => Stat.Types.Get<DamageTypeResistance>().For(Electric).Make(value),
          (Stat.Types.Get<DamageTypeResistance>().For(General), 0.55f),
          (Stat.Types.Get<Data.Stats.Finesse>(), 0.25f),
          (Stat.Types.Get<Data.Stats.Potency>(), 0.10f),
          (Stat.Types.Get<Data.Stats.Vision>(), 0.10f)
        )
      );

      /// <summary>
      /// Radiation and light damage
      /// </summary>
      public static Spiritual Radiant {
        get;
      } = new Spiritual(
        nameof(Radiant),
        "Damage from light and radiation. Usuaully good against undead and unholy beings.",
        'R',
        ZizElement.Light.AsSingleItemEnumerable().ToHashSet(),
        defaultDamageMultiplierStat: DerivedStat.ScaledFromExisting(
          value => Stat.Types.Get<DamageTypeMultiplier>().For(Radiant).Make(value),
          (Stat.Types.Get<DamageTypeMultiplier>().For(General), 0.50f),
          (Stat.Types.Get<Data.Stats.Endurance>(), 0.25f),
          (Stat.Types.Get<Data.Stats.Vision>(), 0.25f)
        ),
        defaultDamageResistanceStat: DerivedStat.ScaledFromExisting(
          value => Stat.Types.Get<DamageTypeResistance>().For(Radiant).Make(value),
          (Stat.Types.Get<DamageTypeResistance>().For(General), 0.70f),
          (Stat.Types.Get<Data.Stats.Endurance>(), 0.15f),
          (Stat.Types.Get<Data.Stats.Vision>(), 0.15f)
        )
      );

      /// <summary>
      /// Dark and void damage
      /// </summary>
      public static Spiritual Void {
        get;
      } = new Spiritual(
        nameof(Void),
        "Damage from exposure to things that shouldn't be.",
        'V',
        ZizElement.Dark.AsSingleItemEnumerable().ToHashSet(),
        defaultDamageMultiplierStat: DerivedStat.ScaledFromExisting(
          value => Stat.Types.Get<DamageTypeMultiplier>().For(Void).Make(value),
          (Stat.Types.Get<DamageTypeMultiplier>().For(General), 0.40f),
          (Stat.Types.Get<Data.Stats.Vision>(), 0.40f),
          (Stat.Types.Get<Data.Stats.Finesse>(), 0.52f)
        ),
        defaultDamageResistanceStat: DerivedStat.ScaledFromExisting(
          value => Stat.Types.Get<DamageTypeResistance>().For(Void).Make(value),
          (Stat.Types.Get<DamageTypeResistance>().For(General), 0.70f),
          (Stat.Types.Get<Data.Stats.Finesse>(), 0.15f),
          (Stat.Types.Get<Data.Stats.Potency>(), 0.15f)
        )
      );

      ///<summary><inheritdoc/></summary>
      public IReadOnlyCollection<ZizElement> AssociatedZizElements {
        get;
      }

      protected Spiritual(string uniqueName, string description, char letterRepresentation, HashSet<ZizElement> zizElements, DerivedStat? defaultDamageMultiplierStat = null, DerivedStat? defaultDamageResistanceStat = null) 
        : base("Spiritual.", uniqueName, description, letterRepresentation, Targets.Spirit, defaultDamageMultiplierStat, defaultDamageResistanceStat) { AssociatedZizElements = zizElements; }
    }
  }
}
