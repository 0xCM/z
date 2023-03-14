//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{    
    [StructLayout(LayoutKind.Sequential,Pack=1)]
    public ref struct EncodedValue<T>
    {
        public readonly T Value;

        public readonly ReadOnlySpan<byte> Encoded;

        public readonly ushort Alignment;

        public readonly ushort PrefixSize;

        public readonly ushort SuffixSize;

        public EncodedValue(T value, ReadOnlySpan<byte> encoded, ushort alignment, ushort prefix, ushort suffix)
        {
            Value = value;
            Encoded = encoded;
            Alignment = alignment;
            PrefixSize = prefix;
            SuffixSize = suffix;
        }
    }
}