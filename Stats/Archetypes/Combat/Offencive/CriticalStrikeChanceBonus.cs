namespace SpiritWorlds.Data.Included {
  public static partial class Stats {
    public class CriticalStrikeChanceBonus : Types {
      CriticalStrikeChanceBonus() : base(
        "Critical Strike Chance Bonus",
        "CRT",
        "A bonus added to to critical hit percent chance.",
        upperBar: 5
      ) { }
    }
  }
}
