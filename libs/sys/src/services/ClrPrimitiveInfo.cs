//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public readonly record struct ClrPrimitiveInfo : IExpr
    {
        public readonly PrimalKind Kind;

        public readonly NativeTypeWidth Width;

        public readonly PolarityKind Sign;

        public readonly PrimalCode TypeCode;

        [MethodImpl(Inline)]
        public ClrPrimitiveInfo(PrimalKind kind, NativeTypeWidth width, PolarityKind sign, PrimalCode tc)
        {
            Kind = kind;
            Width = width;
            Sign = sign;
            TypeCode = tc;
        }

        public bool IsEmpty
        {
            [MethodImpl(Inline)]
            get => Kind == 0;
        }

        public bool IsNonEmpty
        {
            [MethodImpl(Inline)]
            get => Kind != 0;
        }

        public string Format()
            => Kind.ToString();

        public override string ToString()
            => Format();
    }
}