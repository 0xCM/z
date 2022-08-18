//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;
    using System.Runtime.Intrinsics;

    using static Root;

    /// <summary>
    /// Defines a 16-symbol permutation
    /// </summary>
    public readonly struct Perm16
    {
        public readonly Vector128<byte> Data;

        [MethodImpl(Inline)]
        public Perm16(Vector128<byte> src)
            => Data = src;
    }
}