namespace SpiritWorlds.Data.Included {
  public static partial class Stats {
    public class StaminaPoints : Types {
      StaminaPoints() : base(
        "Stamina Points",
        "SP",
        "Your pool of stamina points. You spend these to do things in combat. They replenesh each turn",
        upperBar: 10
      ) { }
    }
  }
}