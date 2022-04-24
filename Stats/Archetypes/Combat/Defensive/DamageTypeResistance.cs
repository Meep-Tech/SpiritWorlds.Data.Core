using Meep.Tech.Data;

namespace SpiritWorlds.Data.Included {

  /// <summary>
  /// splay archetyped class for included damage resistances
  /// </summary>
  public class DamageTypeResistance : Data.Stats.DamageResistance, Archetype.IBuildOneForEach<DamageTypeResistance, DamageType> {

    ///<summary><inheritdoc/></summary>
    DamageType IBuildOneForEach<DamageTypeResistance, DamageType>.AssociatedEnum {
      get;
      set;
    }

    DamageTypeResistance(string name, string acronym, string description, int? upperBar = 25, int? lowerBar = null, int? defaultValue = null)
      : base(Constants.IdentityKeyPrefix, name, acronym, description, upperBar, lowerBar, defaultValue) {
    }

    DamageTypeResistance IBuildOneForEach<DamageTypeResistance, DamageType>.ConstructArchetypeFor(DamageType enumeration)
      => new(enumeration.Name, $"How much less {enumeration.Name} damage you take; {enumeration.Description}", enumeration.LetterRepresentation + "DR");
  }
}