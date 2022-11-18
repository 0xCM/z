//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    public interface IHeapReceiver<S>
    {
        void Receive(in S src, in MemoryHeap dst);
    }

    partial class ApiCode
    {
        public static void located(IDbArchive src, IHeapReceiver<FilePath> receiver)
            => iter(src.Files(FileKind.LocatedHex), file => located(file, receiver), PllExec);   

        public static void located(FilePath src, IHeapReceiver<FilePath> receiver)
            => receiver.Receive(src, located(src));               

        /// <summary>
        /// Reconsitiutes a <see cref='MemoryHeap'/> from a representation serialized  as <see cref='FileKind.LocatedHex'/>
        /// </summary>
        /// <param name="src"></param>
        public static MemoryHeap located(FilePath src)
        {
            var data = span<byte>(src.Size);
            var offsets = list<Address32>();
            using var reader = src.AsciLineReader();
            var line = AsciLineCover.Empty;
            var offset = 0u;
            var rebased = Address32.Zero;
            var result = true;
            var @base = MemoryAddress.Zero;
            while(reader.Next(out line) && result)
            {                    
                var codes = line.Codes;
                var i = SQ.index(codes, Chars.Space);
                if(i > 0)
                {
                    var left = SQ.left(codes,i);
                    result = Hex.parse(left, out ulong address);
                    if(!result)
                        sys.@throw(AppMsg.ParseFailure.Format("Location", left.Format()));

                    if(@base == 0)
                        @base = address;

                    var right = SQ.right(codes,i);
                    var size = Hex.parse(right, ref offset, data);
                    if(size)
                    {
                        offsets.Add(rebased);
                        rebased += size.Data;
                    }
                    else
                        sys.@throw(AppMsg.ParseFailure.Format("Hex", right.Format()));
                }

            }
            return new MemoryHeap(@base, data, offsets.ToArray());
        }

        public static void located(FilePath src, Receiver<HexCsvRow> dst)
        {
            var pos = 0u;
            using var reader = src.AsciReader();
            var size = src.Size;
            var record = HexCsvRow.Empty;
            var @continue = true;
            while(@continue)
                @continue = read(reader, ref pos, dst);
        }

        static bool read(StreamReader src, ref uint pos, Receiver<HexCsvRow> dst)
        {
            var line = src.ReadLine();
            if(line == null)
                return false;

            pos++;

            var parts = text.split(line, FieldDelimiter);
            if(parts.Length != 2)
                return false;

            AddressParser.parse(skip(parts,0), out MemoryAddress location);
            Hex.code(skip(parts,1), out BinaryCode cde);

            return true;
        }
    }
}