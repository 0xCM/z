//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public readonly struct EndianLittle : IEndianKind<EndianLittle>
    {
        [MethodImpl(Inline)]
        public static implicit operator EndianKind<EndianLittle>(EndianLittle src)
            => default(EndianKind<EndianLittle>);

        public EndianKind Id
            => EndianKind.Little;
    }

    public readonly struct EndianBig : IEndianKind<EndianBig>
    {
        [MethodImpl(Inline)]
        public static implicit operator EndianKind<EndianBig>(EndianBig src)
            => default(EndianKind<EndianBig>);

        public EndianKind Id
            => EndianKind.Bit;
    }
}