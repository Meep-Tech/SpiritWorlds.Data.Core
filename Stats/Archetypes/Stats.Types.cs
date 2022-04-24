﻿namespace SpiritWorlds.Data.Included {
  public static partial class Stats {
    public abstract partial class Types : Stat.Type {
      protected Types(
        string name,
        string acronym,
        string description,
        int? upperBar = null, // default: 50
        int? lowerBar = null, // default: 0
        int? defaultValue = null // default: 1
      ) : base(
        Constants.IdentityKeyPrefix,
        name,
        acronym,
        description,
        upperBar,
        lowerBar,
        defaultValue
      ) { }
    }
  }
}
