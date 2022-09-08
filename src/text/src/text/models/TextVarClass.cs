//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public enum TextVarClass : byte
    {
        None = 0,

        Fenced = 1,

        Prefixed = 2,

        PrefixedFence = Fenced | Prefixed
    }
}