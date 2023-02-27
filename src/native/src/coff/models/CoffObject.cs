//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    [StructLayout(LayoutKind.Sequential, Pack=1)]
    public readonly record struct CoffObject
    {
        public readonly FilePath Path;

        public readonly BinaryCode Data;

        public CoffObject(FilePath path, BinaryCode data)
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
            => slice(Data.View,(uint)address, size);

        [MethodImpl(Inline)]
        public ReadOnlySpan<byte> Bytes(MemoryRange range)
            => slice(Data.View,(uint)range.Min, range.ByteCount);

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
                    dst.AppendLine(skip(lines,i));
                else
                    dst.Append(skip(lines,i));
            }
            return dst.Emit();
        }

        public override string ToString()
            => Format();
            
        public static CoffObject Empty
            => new CoffObject(FilePath.Empty, BinaryCode.Empty);
    }
}