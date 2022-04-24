namespace SpiritWorlds.Data.Included {
  public static partial class Stats {
    public class Immunity : StatusEffectResistance {
      Immunity() : base(
        "Immunity",
        "IMU",
        "How well you resist poisions, venoms, rots, and diseases."
      ) { }
    }
  }
}
