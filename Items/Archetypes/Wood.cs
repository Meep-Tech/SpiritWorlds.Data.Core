using System;
using System.Collections.Generic;
using System.Text;

namespace SpiritWorlds.Data.Included {
  public static partial class Items {

    /// <summary>
    /// A peice of wood.
    /// </summary>
    public class Wood : Item.Type {

      public override int? MaxQuantityPerStack 
        => 100;

      public override string Description 
        => "A hunk of Wood that can be used for crafting and other things.";

      // TOOD: make id
      public Wood(Identity id) 
        : base(id) {}
    }
  }
}
