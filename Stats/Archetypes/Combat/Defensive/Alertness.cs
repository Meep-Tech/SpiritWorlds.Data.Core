namespace SpiritWorlds.Data.Included {
  public static partial class Stats {
    public class Alertness : StatusEffectResistance {
      Alertness() : base(
      "Alertness",
      "ALR",
      "How well you resist status effects that slow you, like Sleep and Slowness. Also gives a chance to avoid sneak attacks from behind."
    ) { }
    }
  }
}
