namespace SpiritWorlds.Data.Included {
  public static partial class Stats {
    /// <summary>
    /// The base type for included status effect resistances
    /// </summary>
    public abstract class StatusEffectResistance : Data.Stats.StatusEffectResistance {
      public StatusEffectResistance(
         string name,
         string acronym,
         string description,
         int? upperBar = 25,
         int? lowerBar = null,
         int? defaultValue = null
        ) : base(
         Constants.IdentityKeyPrefix,
         name,
         acronym,
         description,
         upperBar,
         lowerBar,
         defaultValue
       ) { }
    }
  }
}
