//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class NativeTypes
    {
        public static NativeUnion union(Label name, NativeTypeSeq members)
            => new NativeUnion(name, members);
    }
}