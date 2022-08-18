//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    /// <summary>
    /// Defines a sequence of hex values
    /// </summary>
    public readonly ref struct HexString
    {
        public readonly ReadOnlySpan<char> Data;

        [MethodImpl(Inline)]
        public HexString(ReadOnlySpan<char> src)
        {
            Data = src;
        }

        public string Format()
            => sys.@string(Data);

        [MethodImpl(Inline)]
        public static implicit operator HexString(string src)
            => new HexString(src);

        [MethodImpl(Inline)]
        public static implicit operator HexString(ReadOnlySpan<char> src)
            => new HexString(src);
    }
}