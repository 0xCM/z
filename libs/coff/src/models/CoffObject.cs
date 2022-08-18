//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [StructLayout(LayoutKind.Sequential, Pack=1)]
    public readonly struct CoffObject
    {
        public readonly FS.FilePath Path;

        public readonly BinaryCode Data;

        public CoffObject(FS.FilePath path, BinaryCode data)
        {
            Path = path;
            Data = data;
        }

        public ByteSize Size
        {
            [MethodImpl(Inline)]
            get => Data.Size;
        }

        [MethodImpl(Inline)]
        public ReadOnlySpan<byte> Bytes(Address32 address, ByteSize size)
            => core.slice(Data.View,(uint)address, size);

        [MethodImpl(Inline)]
        public ReadOnlySpan<byte> Bytes(MemoryRange range)
            => core.slice(Data.View,(uint)range.Min, range.ByteCount);

        public ref readonly byte this[uint i]
        {
            [MethodImpl(Inline)]
            get => ref Data[i];
        }

        public ref readonly byte this[int i]
        {
            [MethodImpl(Inline)]
            get => ref Data[i];
        }

        public string Format()
        {
            var dst = text.buffer();
            var formatter = HexDataFormatter.create(0,32,true);
            var lines = formatter.FormatLines(Data.Storage);
            var count = lines.Length;
            for(var i=0; i<count; i++)
            {
                if(i != count - 1)
                    dst.AppendLine(core.skip(lines,i));
                else
                    dst.Append(core.skip(lines,i));
            }
            return dst.Emit();
        }

        public static CoffObject Empty
            => new CoffObject(FS.FilePath.Empty, BinaryCode.Empty);
    }
}