using System;
using System.Collections.Generic;
using System.Text;

namespace SpiritWorlds.Data.Included {
  public static partial class Items {

    /// <summary>
    /// A fruit.
    /// </summary>
    public class Spapple : Item.Type {

      public override int? MaxQuantityPerStack 
        => 100;

      public override string Description 
        => "A strange smelling, yet juicy looking fruit!";

      // TOOD: make id
      public Spapple(Identity id) 
        : base(id) {}
    }
  }
}
