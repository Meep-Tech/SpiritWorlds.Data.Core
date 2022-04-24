using System.Collections.Generic;

namespace SpiritWorlds.Data.Included {

  /// <summary>
  /// Indicates a damage type has a specific target.
  /// Targets can be used for effects, flavor, etc.
  /// </summary>
  public interface ITargetedDamageType {

    /// <summary>
    /// The target of this damage type.
    /// </summary>
    DamageTypes.Targets Target { get; }
  }

  /// <summary>
  /// Indicates a damage type that has associated Ziz Elements
  /// </summary>
  internal interface IElementalDamageType {

    /// <summary>
    /// The ziz elements asociated with this damage type
    /// </summary>
    IReadOnlyCollection<ZizElement> AssociatedZizElements {
      get;
    }
  }

  /// <summary>
  /// Included damage types
  /// TODO: mele and ranged are related to attack types, not damage types
  /// </summary>
  public abstract partial class DamageTypes : DamageType, ITargetedDamageType {

    ///<summary><inheritdoc/></summary>
    public Targets Target {
      get;
    }

    protected DamageTypes(
      string keyPrefix,
      string uniqueName,
      string description,
      char letterRepresentation,
      Targets target,
      DerivedStat? defaultDamageMultiplierStat = null, 
      DerivedStat? defaultDamageResistanceStat = null
    ) : base(Constants.IdentityKeyPrefix + keyPrefix, uniqueName, description, letterRepresentation, defaultDamageMultiplierStat, defaultDamageResistanceStat) { Target = target; }
  }
}
