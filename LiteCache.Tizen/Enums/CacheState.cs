using System;
using System.Collections.Generic;
using System.Text;

namespace LiteCache.Tizen.Enums
{
    [Flags]
    public enum CacheState
    {
        None,
        Expired,
        Active
    }
}
