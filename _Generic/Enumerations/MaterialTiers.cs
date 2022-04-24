using Meep.Tech.Collections.Generic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpiritWorlds.Data.Included {
  public class MaterialTiers : MaterialTier {

    /// <summary>
    /// A tier made of wood.
    /// Usually pretty basic.
    /// </summary>
    public static MaterialTiers Wood { get; }
        = new MaterialTiers(nameof(Wood), Item.Types.Get<Items.Wood>().AsSingleItemEnumerable().Cast<Item.Type>().ToList());

    internal MaterialTiers(string uniqueNameForTier, IList<Item.Type> associatedMaterials = null) 
      : base("Included.", uniqueNameForTier, associatedMaterials) {}
    }
}
