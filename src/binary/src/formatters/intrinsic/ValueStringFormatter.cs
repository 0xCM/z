//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class BinaryFormatters
    {
        class ValueStringFormatter : BinaryFormatter<@string>
        {            
            public override uint Encode(@string src, uint offset, Span<byte> dst)
                => EncodeText(src, offset, dst);

            public override uint Decode(ReadOnlySpan<byte> src, uint offset, out @string dst)
            {
                var size = DecodeText(src, offset, out string _dst);
                dst = _dst;
                return size;
            }
        }
    }
}