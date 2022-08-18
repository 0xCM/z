//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Linq;

    /// <summary>
    /// Specifies closures over natural number types
    /// </summary>
    public class NaturalsAttribute : ClosuresAttribute
    {
        public NaturalsAttribute(params ulong[] values)
            : base(NatClosureKind.Individuals, values)
        {

        }
    }

    /// <summary>
    /// Specifies closures over pairs of natural number types
    /// </summary>
    public class NatPairsAttribute : ClosuresAttribute
    {
        protected NatPairsAttribute(NatClosureKind kind, params (ulong m, ulong n)[] values)
            : base(kind,values)
        {

        }

        static (ulong m, ulong n)[] split(params ulong[] src)
            => src.Select(x => ((ulong)(uint)x, x >> 32)).ToArray();

        public NatPairsAttribute(params ulong[] pairs)
            :this(NatClosureKind.ExplicitPairs, split(pairs))
        {

        }
    }
}