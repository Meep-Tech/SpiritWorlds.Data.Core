namespace SpiritWorlds.Data.Included {
  public static partial class Stats {
    public class Toughness : StatusEffectResistance {
      Toughness() : base(
        "Toughness",
        "TUF",
        "How well you resist status effects that effect your skin, like Burn, Frostbite, and Raw."
      ) { }
    }
  }
}
