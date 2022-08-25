//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    /// <summary>
    /// Defines a specification for producing an index-oriented mask
    /// </summary>
    /// <typeparam name="N">The byte-relative bit index</typeparam>
    /// <typeparam name="T">The mask data type</typeparam>
    public readonly struct IndexMask<N,T> : IMaskSpec<T>
        where N : unmanaged, ITypeNat
        where T : unmanaged
    {
        public const string RenderPattern = "n(f:{0}, t:{1})";

        public const BitMaskKind M = BitMaskKind.Index;

        public N n => default;

        BitMaskKind IMaskSpec.M
            => M;

        public string Format()
            => string.Format(RenderPattern, nat64u<N>(), NumericKinds.kind<T>().Format());

        public override string ToString()
            => Format();
    }
}
