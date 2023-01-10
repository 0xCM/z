//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    [Free, ApiHost]
    public class PeTables : IDisposable
    {
        readonly PEReader Reader;

        [MethodImpl(Inline)]
        public PeTables(PEReader src)
        {
            Reader = src;
        }


        public ReadOnlySeq<PeSectionHeader> Headers()
            => PeReader.headers(Reader);

        public void Dispose()
            => Reader.Dispose();

        public static string UserString(MetadataReader reader, UserStringHandle handle)
            => reader.GetUserString(handle);

        public static TableIndex? index(Handle handle)
        {
            if(MetadataTokens.TryGetTableIndex(handle.Kind, out var table))
                return table;
            else
                return null;
        }

        [Op]
        public static PeTables open(FilePath src)
            => new PeTables(new PEReader(File.OpenRead(src.Name)));

        [MethodImpl(Inline), Op]
        public static Address32 offset(MetadataReader reader, UserStringHandle handle)
            => (Address32)reader.GetHeapOffset(handle);

        public const string OffsetPatternText = "{0,-60} | {1,-16}";

        [MethodImpl(Inline)]
        static string[] labels(PeFieldOffset src)
            => typeof(PeFieldOffset).DeclaredInstanceFields().Select(x => x.Name);

        [MethodImpl(Inline)]
        static string format(PeFieldOffset src)
            => RP.format(OffsetPatternText, src.Name, src.Value);

        [Op]
        public static void save(ReadOnlySpan<PeFieldOffset> src, FilePath dst)
        {
            using var writer = dst.Writer();
            var l = labels(default(PeFieldOffset));
            writer.WriteLine(RP.format(OffsetPatternText, l[0], l[1]));
            for(var i=0u; i<src.Length; i++)
                writer.WriteLine(format(skip(src,i)));
        }

    }
}