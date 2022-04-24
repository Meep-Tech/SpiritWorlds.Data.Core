using Meep.Tech.Data;

namespace SpiritWorlds.Data.Included {

  /// <summary>
  /// Base class for included damage multipliers
  /// </summary>
  public class DamageTypeMultiplier : Data.Stats.DamageMultiplier, Archetype.IBuildOneForEach<DamageTypeMultiplier, DamageType> {

    ///<summary><inheritdoc/></summary>
    DamageType IBuildOneForEach<DamageTypeMultiplier, DamageType>.AssociatedEnum {
      get;
      set;
    }

    DamageTypeMultiplier(string name, string acronym, string description, int? upperBar = 25, int? lowerBar = null, int? defaultValue = null)
      : base(Constants.IdentityKeyPrefix, name, acronym, description, upperBar, lowerBar, defaultValue) {
    }

    DamageTypeMultiplier IBuildOneForEach<DamageTypeMultiplier, DamageType>.ConstructArchetypeFor(DamageType enumeration)
      => new(enumeration.Name, $"How much more {enumeration.Name} damage you deal; {enumeration.Description}", enumeration.LetterRepresentation + "DM");
  }
}