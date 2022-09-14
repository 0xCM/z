//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    using I = System.Reflection.Metadata.Ecma335.TableIndex;

    [Free, ApiHost]
    public partial class PeTables : IDisposable
    {
        [MethodImpl(Inline)]
        internal static ReadOnlySpan<R> empty<R>()
            => ReadOnlySpan<R>.Empty;

        readonly PEReader Reader;

        readonly FilePath Source;

        [MethodImpl(Inline)]
        internal PeTables(PEReader src, FilePath path)
        {
            Reader = src;
            Source = path;
        }

        public void Dispose()
            => Reader.Dispose();

        public static string UserString(MetadataReader reader, UserStringHandle handle)
            => reader.GetUserString(handle);

        internal static TableIndex? index(Handle handle)
        {
            if(MetadataTokens.TryGetTableIndex(handle.Kind, out var table))
                return table;
            else
                return null;
        }

        public ReadOnlySeq<PeSectionHeader> Headers()
            => PeReader.headers(Reader,Source);

        [Op]
        public static PeTables open(FilePath src)
        {
            var reader = new PEReader(File.OpenRead(src.Name));
            return new PeTables(reader, src);
        }

        [MethodImpl(Inline), Op]
        public static Address32 offset(MetadataReader reader, UserStringHandle handle)
            => (Address32)reader.GetHeapOffset(handle);

        public const string OffsetPatternText = "{0,-60} | {1,-16}";

        [MethodImpl(Inline)]
        static string[] labels(PeFieldOffset src)
            => typeof(PeFieldOffset).DeclaredInstanceFields().Select(x => x.Name);

        [MethodImpl(Inline)]
        static string format(PeFieldOffset src)
            => RpOps.format(OffsetPatternText, src.Name, src.Value);

        [Op]
        public static void save(ReadOnlySpan<PeFieldOffset> src, FilePath dst)
        {
            using var writer = dst.Writer();
            var l = labels(default(PeFieldOffset));
            writer.WriteLine(RpOps.format(OffsetPatternText, l[0], l[1]));
            for(var i=0u; i<src.Length; i++)
                writer.WriteLine(format(skip(src,i)));
        }

        [MethodImpl(Inline), Op]
        public static int ConstantCount(in PeStream state)
            => state.Reader.GetTableRowCount(I.Constant);
    }
}