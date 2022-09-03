//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    [StructLayout(LayoutKind.Sequential, Pack=1)]
    public unsafe readonly struct TokenExpr
    {
        public readonly uint Id;

        readonly MemoryAddress Address;

        public readonly uint Length;

        [MethodImpl(Inline)]
        public TokenExpr(uint id, MemoryAddress location, uint length)
        {
            Id = id;
            Address = location;
            Length = length;
        }

        public ReadOnlySpan<char> Chars
        {
            [MethodImpl(Inline)]
            get => cover(Address.Pointer<char>(), Length);
        }

        public string Format()
            => text.format(Chars);

        public override string ToString()
            => Format();
    }
}