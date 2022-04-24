namespace SpiritWorlds.Data.Included {

  public abstract partial class DamageTypes {

    /// <summary>
    /// The base class for mental damage types
    /// </summary>
    public class Mental : DamageTypes {

      /// <summary>
      /// General mental damage
      /// </summary>
      public new static Mental General {
        get;
      } = new Mental(nameof(General), "General Thought Damage to the Mind.", default);

      /// <summary>
      /// Active Mental Damage
      /// </summary>
      public static Mental Active {
        get;
      } = new Mental(nameof(Active), "Active Mental Damage, Used to overwhelm a target and drive them to insanity.", '+');

      /// <summary>
      /// Passive Mental Damage
      /// </summary>
      public static Mental Passive {
        get;
      } = new Mental(nameof(Active), "Passive Mental Damage, Used to incidiously weaken a foe's faculties, driving them into a stupor", '-');

      protected Mental(string uniqueName, string description, char letterRepresentation, DerivedStat? defaultDamageMultiplierStat = null, DerivedStat? defaultDamageResistanceStat = null) 
        : base("Mental.", uniqueName, description, letterRepresentation, Targets.Mind, defaultDamageMultiplierStat, defaultDamageResistanceStat) {}
    }
  }
}
