//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

partial class NativeSigs
{
    [Flags]
    public enum ModifierKind : byte
    {
        None,

        Pointer = Pow2x8.P2ᐞ00,

        Const = Pow2x8.P2ᐞ01,

        Ref = Pow2x8.P2ᐞ02,

        In = Pow2x8.P2ᐞ03,

        Out = Pow2x8.P2ᐞ04,

        Unsigned = Pow2x8.P2ᐞ05,
    }    
}
