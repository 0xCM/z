//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class BinaryFormatters
    {
        class StringFormatter : BinaryFormatter<string>
        {            
            public override uint Encode(string src, uint offset, Span<byte> dst)
                => EncodeText(src, offset, dst);

            public override uint Decode(ReadOnlySpan<byte> src, uint offset, out string dst)
                => DecodeText(src, offset, out dst);
        }
    }
}