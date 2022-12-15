//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    public sealed class CharMapper : AppService<CharMapper>
    {
        ReadOnlySeq<CharMapEntry<char>> Unmapped(FilePath src, in CharMap<char> map)
            => Unmapped(src, TextEncodings.Asci);

        ReadOnlySeq<CharMapEntry<char>> Unmapped(FilePath src, AsciPoints target)
        {
            var map = CharMaps.create(TextEncodings.Unicode, target);
            var flow = Channel.Running(string.Format("Searching {0} for unmapped characters", src.ToUri()));
            var unmapped = hashset<char>();
            using var reader = src.LineReader(TextEncodingKind.Utf8);
            while(reader.Next(out var line))
                CharMaps.unmapped(map, line.Data, unmapped);
            var pairs = unmapped.Map(x => CharMaps.entry((Hex16)x,x)).OrderBy(x => x.Source).ToSeq();
            Channel.Ran(flow, string.Format("Found {0} unmapped characters", pairs.Count));
            return pairs;
        }

        public void LogUnmapped(in CharMap<char> map, FilePath src, FilePath dst)
        {
            var unmapped = Unmapped(src, map);
            var pairs = unmapped.View.Map(CharMaps.format);
            var count = pairs.Length;
            using var writer = dst.Writer();
            for(var i=0; i<count; i++)
                writer.WriteLine(skip(pairs,i));
        }

        public void Emit(in CharMap<char> src, FilePath dst)
        {
            var emitting = Channel.EmittingFile(dst);
            using var writer = dst.Writer();
            var mapcount = CharMaps.emit(src, writer);
            Channel.EmittedFile(emitting,mapcount);
        }
    }
}