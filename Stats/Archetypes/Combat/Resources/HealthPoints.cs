namespace SpiritWorlds.Data.Included {
  public static partial class Stats {
    public class HealthPoints : Types {
      HealthPoints() : base(
        "Health Points",
        "HP",
        "Your pool of health points. If this hits zero you loose!",
        upperBar: 100
      ) { }
    }
  }
}
