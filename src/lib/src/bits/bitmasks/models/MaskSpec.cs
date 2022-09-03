//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    /// <summary>
    /// Defines a specification for producing classified bitmasks
    /// </summary>
    public readonly struct MaskSpec : IMaskSpec
    {
        [MethodImpl(Inline)]
        public MaskSpec(BitMaskKind m, NumericKind k, uint f, uint d)
        {
            M = m;
            K = k;
            F = f;
            D = d;
        }

        public BitMaskKind M {get;}

        public uint F {get;}

        public uint D {get;}

        public NumericKind K {get;}

        public string Format()
            => K.Format();

        public override string ToString()
            => Format();
    }
}