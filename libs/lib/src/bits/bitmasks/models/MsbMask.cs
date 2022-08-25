//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    /// <summary>
    /// Defines a specification for producing MSB-oriented masks
    /// </summary>
    /// <typeparam name="F">The repetition frequency type</typeparam>
    /// <typeparam name="D">The bit density type</typeparam>
    /// <typeparam name="T">The mask data type</typeparam>
    public readonly struct MsbMask<F,D,T> : IMaskSpec<F,D,T>
        where F : unmanaged, ITypeNat
        where D : unmanaged, ITypeNat
        where T : unmanaged
    {
        public const BitMaskKind M = BitMaskKind.Msb;

        public F f => default;

        public D d => default;

        public T t => default;

        [MethodImpl(Inline)]
        public MsbMask<F,D,S> As<S>(S s = default)
            where S : unmanaged
                => default;

        BitMaskKind IMaskSpec.M
            => M;

        public string Format()
            => $"msb(f:{nat32u<F>()}, d:{nat32u<D>()}, t:{typeof(T).NumericKind().Format()})";

        public override string ToString()
            => Format();

        [MethodImpl(Inline)]
        public static implicit operator MaskSpec(MsbMask<F,D,T> src)
            => BitMasks.spec<F,D,T>(M);
    }
}