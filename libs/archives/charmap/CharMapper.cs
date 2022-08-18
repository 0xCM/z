//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    public sealed class CharMapper : AppService<CharMapper>
    {
        ReadOnlySeq<CharMapEntry<char>> Unmapped(FS.FilePath src, in CharMap<char> map)
            => Unmapped(src, TextEncodings.Asci);

        ReadOnlySeq<CharMapEntry<char>> Unmapped(FS.FilePath src, AsciPoints target)
        {
            var map = CharMaps.create(TextEncodings.Unicode, target);
            var flow = Running(string.Format("Searching {0} for unmapped characters", src.ToUri()));
            var unmapped = hashset<char>();
            using var reader = src.LineReader(TextEncodingKind.Utf8);
            while(reader.Next(out var line))
                CharMaps.unmapped(map, line.Data, unmapped);
            var pairs = unmapped.Map(x => CharMaps.entry((Hex16)x,x)).OrderBy(x => x.Source).ToSeq();
            Ran(flow, string.Format("Found {0} unmapped characters", pairs.Count));
            return pairs;
        }

        public void LogUnmapped(in CharMap<char> map, FS.FilePath src, FS.FilePath dst)
        {
            var unmapped = Unmapped(src, map);
            var pairs = unmapped.View.Map(CharMaps.format);
            var count = pairs.Length;
            using var writer = dst.Writer();
            for(var i=0; i<count; i++)
                writer.WriteLine(skip(pairs,i));
        }

        public void Emit(in CharMap<char> src, FS.FilePath dst)
        {
            var emitting = EmittingFile(dst);
            using var writer = dst.Writer();
            var mapcount = CharMaps.emit(src, writer);
            EmittedFile(emitting,mapcount);
        }
    }
}