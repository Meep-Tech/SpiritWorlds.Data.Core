namespace SpiritWorlds.Data.Included {
  public static partial class Stats {
    public class Clarity : StatusEffectResistance {
      Clarity() : base(
        "Clarity",
        "CLR",
        "How well you resist status effects that effect your perception of the world, like Charm, Fear, and Blindness. For some reason this doesn't help much with Madness though."
      ) { }
    }
  }
}
