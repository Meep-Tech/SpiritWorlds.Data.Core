namespace SpiritWorlds.Data.Included {
  public static partial class Scapes {
    public static partial class Features {

      /// <summary>
      /// A narrow and shallow winding river down a slope with minimal branches if any
      /// </summary>
      public class NarrowRiver : Board.Feature.Type {

        /// <summary>
        /// The Id for a narrow river scape feature
        /// </summary>
        public static new Identity Id {
          get;
        } = new Identity("Narrow River");

        public NarrowRiver() 
          : base(Id) {}
      }
    }
  }
}
