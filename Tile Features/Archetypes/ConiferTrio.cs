using System.Collections.Generic;
using System.Linq;
using Meep.Tech.Data;
using Meep.Tech.Collections.Generic;
using SpiritWorlds.Data;
using SpiritWorlds.Data.Components;

namespace SpiritWorlds.Data.Included {
  public static partial class Tiles {

    public static class Features {

      /// <summary>
      /// Three conifer trees
      /// </summary>

      public class ConiferTrio : Data.Entities.Tile.Feature.Type {

        public override string Description 
          => "Three Evergreen Trees! They may have fruit in them!";

        protected override Dictionary<string, IComponent> InitialComponents
          => _InitialComponents
            ??= base.InitialComponents
              .Append(PotentialItemDrops.Make(
                new(
                  // big wood drop (rare)
                  (parent, extraContext)
                    => new ValueStack<Item>(
                      Item.Types.Get<Data.Included.Items.Wood>().Make(),
                      extraContext?.Any(x => (x is Data.Components.Items.Tool.Type toolType) && (toolType == Included.Components.Items.Tools.Axe)) ?? false
                        ? parent?.GetComponent<Levels>().CurrentLevel == 1
                          ? 3
                          : parent?.GetComponent<Levels>().CurrentLevel == 2
                            ? 4
                            : 5
                        : parent?.GetComponent<Levels>().CurrentLevel == 1
                          ? 1
                          : 2
                      ),
                  (parent, extraContext)
                    => 0.75f
                ), // small wood drop (always)
                new(
                  (parent, extraContext)
                    => new ValueStack<Item>(
                      Item.Types.Get<Data.Included.Items.Wood>().Make(),
                      extraContext?.Any(x => (x is Data.Components.Items.Tool.Type toolType) && (toolType == Included.Components.Items.Tools.Axe)) ?? false
                        ? parent?.GetComponent<Levels>().CurrentLevel == 1
                          ? 2
                          : 3
                        : parent?.GetComponent<Levels>().CurrentLevel == 1
                          ? 1
                          : 2
                      ),
                  (parent, extraContext)
                    => 0
                ), // fruit drop (somewhat common)
                new(
                  (parent, extraContext)
                    => new ValueStack<Item>(
                      Item.Types.Get<Data.Included.Items.Spapple>().Make(),
                      parent is not null
                        ? Meep.Tech.Noise.RNG.Static.Next(1, 3)
                        : 1),
                  (parent, extraContext)
                    => 0.25f
                )
              ));

        ConiferTrio() : base(
          null, // TODO: this needs an id,
          false,
          true,
          toolEffectivnesMultipliers: new() { } // TODO: add these
        ) { }
      }
    }
  }
}
