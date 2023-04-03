//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class BinaryFormatters
    {
        class FilePathFormatter : BinaryFormatter<FilePath>
        {
            public override uint Decode(ReadOnlySpan<byte> src, uint offset, out FilePath dst)
            {
                var size = DecodeText(src, offset, out string _dst);
                dst = FS.path(_dst);
                return size;

            }

            public override uint Encode(FilePath src, uint offset, Span<byte> dst)
                => EncodeText(src.Format(), offset, dst);
        }
    }
}