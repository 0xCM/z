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
        public static void located(IDbArchive src, IHeapReceiver<FS.FilePath> receiver)
            => iter(src.Files(FileKind.LocatedHex), file => located(file, receiver), PllExec);   

        public static void located(FS.FilePath src, IHeapReceiver<FS.FilePath> receiver)
            => receiver.Receive(src, Heaps.located(src));               

        public static void located(FS.FilePath src, Receiver<HexCsvRow> dst)
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