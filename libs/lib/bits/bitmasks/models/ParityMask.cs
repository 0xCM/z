//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    /// <summary>
    /// Defines a specification for producing parity masks
    /// </summary>
    /// <typeparam name="F">The repetition frequency type</typeparam>
    /// <typeparam name="D">The bit density type</typeparam>
    /// <typeparam name="T">The mask data type</typeparam>
    public readonly struct ParityMask<F,D,T> : IMaskSpec<F,D,T>
        where F : unmanaged, ITypeNat
        where D : unmanaged, ITypeNat
        where T : unmanaged
    {
        public const BitMaskKind M = BitMaskKind.Parity;

        public F f => default;

        public D d => default;

        public T t => default;

        [MethodImpl(Inline)]
        public ParityMask<F,D,S> As<S>(S s = default)
            where S : unmanaged
                => default;

        BitMaskKind IMaskSpec.M => M;


        public override string ToString()
            => (this as ITextual).Format();

        [MethodImpl(Inline)]
        public static implicit operator MaskSpec(ParityMask<F,D,T> src)
            => BitMasks.spec<F,D,T>(M);
    }
}