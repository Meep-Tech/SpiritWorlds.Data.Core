using Meep.Tech.Collections.Generic;
using Meep.Tech.Data;

namespace SpiritWorlds.Data.Included {

  public abstract partial class DamageTypes {
    /// <summary>
    /// The base class for physical damage types
    /// </summary>
    public class Physical : DamageTypes {

      /// <summary>
      /// General physical Damage
      /// </summary>
      public new static Physical General {
        get;
      } = new Physical(
        nameof(General),
        "General Physical Damage to the Body.",
        'P',
        defaultDamageMultiplierStat: DerivedStat.ScaledFromExisting(
          value => Stat.Types.Get<DamageTypeMultiplier>().For(General).Make(value),
          (Stat.Types.Get<DamageTypeMultiplier>().For(DamageType.General), 0.80f),
          (Stat.Types.Get<Data.Stats.Finesse>(), 0.20f)
        ),
        defaultDamageResistanceStat: DerivedStat.ScaledFromExisting(
          value => Stat.Types.Get<DamageTypeResistance>().For(General).Make(value),
          (Stat.Types.Get<DamageTypeResistance>().For(DamageType.General), 0.65f),
          (Stat.Types.Get<Data.Stats.Finesse>(), 0.20f),
          (Stat.Types.Get<Data.Stats.Potency>(), 0.15f)
        )
      );

      /// <summary>
      /// Heavy/Blunt/Striking Damage
      /// </summary>
      public static Physical Heavy {
        get;
      } = new Physical(
        nameof(Heavy),
        "Heavy damage, usually caused by brute force and blunt weapons.",
        'H',
        defaultDamageMultiplierStat: DerivedStat.ScaledFromExisting(
          value => Stat.Types.Get<DamageTypeMultiplier>().For(Heavy).Make(value),
          (Stat.Types.Get<DamageTypeMultiplier>().For(General), 0.80f),
          (Stat.Types.Get<Data.Stats.Potency>(), 0.20f)
        ),
        defaultDamageResistanceStat: DerivedStat.ScaledFromExisting(
          value => Stat.Types.Get<DamageTypeResistance>().For(Quick).Make(value),
          (Stat.Types.Get<DamageTypeResistance>().For(General), 0.80f),
          (Stat.Types.Get<Data.Stats.Potency>(), 0.20f)
        )
      );

      /// <summary>
      /// Quick/Slashing Damage
      /// </summary>
      public static Physical Quick {
        get;
      } = new Physical(
        nameof(Quick),
        "Quick damage, usually caused by light slashing weapons.",
        'Q',
        defaultDamageMultiplierStat: DerivedStat.ScaledFromExisting(
          value => Stat.Types.Get<DamageTypeMultiplier>().For(Quick).Make(value),
          (Stat.Types.Get<DamageTypeMultiplier>().For(General), 0.70f),
          (Stat.Types.Get<Data.Stats.Finesse>(), 0.30f)
        ),
        defaultDamageResistanceStat: DerivedStat.ScaledFromExisting(
          value => Stat.Types.Get<DamageTypeResistance>().For(Quick).Make(value),
          (Stat.Types.Get<DamageTypeResistance>().For(General), 0.75f),
          (Stat.Types.Get<Data.Stats.Finesse>(), 0.25f)
        )
      );

      /// <summary>
      /// Persice/Peircing/Techncial Damage
      /// </summary>
      public static Physical Precise {
        get;
      } = new Physical(
        nameof(Precise),
        "Precise damage, usually caused by sharp and tipped weapons.",
        'X',
        defaultDamageMultiplierStat: DerivedStat.ScaledFromExisting(
          value => Stat.Types.Get<DamageTypeMultiplier>().For(Precise).Make(value),
          (Stat.Types.Get<DamageTypeMultiplier>().For(General), 0.70f),
          (Stat.Types.Get<Data.Stats.Vision>(), 0.30f)
        ),
        defaultDamageResistanceStat: DerivedStat.ScaledFromExisting(
          value => Stat.Types.Get<DamageTypeResistance>().For(Precise).Make(value),
          (Stat.Types.Get<DamageTypeResistance>().For(General), 0.75f),
          (Stat.Types.Get<Data.Stats.Vision>(), 0.25f)
        )
      );

      /// <summary>
      /// Ranged Physical Damage
      /// </summary>
      public static Physical Ranged {
        get;
      } = new Physical(
        nameof(Ranged), 
        "Ranged damage, usually caused by arrows and thrown weapons.",
        '@',
        defaultDamageMultiplierStat: DerivedStat.ScaledFromExisting(
          value => Stat.Types.Get<DamageTypeMultiplier>().For(Ranged).Make(value),
          (Stat.Types.Get<DamageTypeMultiplier>().For(General), 0.60f),
          (Stat.Types.Get<Data.Stats.Finesse>(), 0.35f),
          (Stat.Types.Get<Data.Stats.Vision>(), 0.15f)
        ),
        defaultDamageResistanceStat: DerivedStat.ScaledFromExisting(
          value => Stat.Types.Get<DamageTypeResistance>().For(Quick).Make(value),
          (Stat.Types.Get<DamageTypeResistance>().For(General), 0.60f),
          (Stat.Types.Get<Data.Stats.Finesse>(), 0.25f),
          (Stat.Types.Get<Data.Stats.Vision>(), 0.15f)
        )
      );

      protected Physical(string uniqueName, string description, char letterRepresentation, DerivedStat? defaultDamageMultiplierStat = null, DerivedStat? defaultDamageResistanceStat = null) 
        : base("Physical.", uniqueName, description, letterRepresentation, Targets.Body, defaultDamageMultiplierStat, defaultDamageResistanceStat) {}
    }
  }
}
