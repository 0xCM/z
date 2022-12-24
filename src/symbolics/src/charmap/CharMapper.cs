//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    [ApiHost]
    public sealed class CharMapper
    {
        [Op]
        static ReadOnlySeq<CharMapEntry<char>> unmapped(IWfChannel channel, FilePath src, in CharMap<char> map)
            => umapped(channel, src, TextEncodings.Asci);

        [Op]
        static ReadOnlySeq<CharMapEntry<char>> umapped(IWfChannel channel, FilePath src, AsciPoints target)
        {
            var map = CharMaps.create(TextEncodings.Unicode, target);
            var flow = channel.Running(string.Format("Searching {0} for unmapped characters", src.ToUri()));
            var unmapped = hashset<char>();
            using var reader = src.LineReader(TextEncodingKind.Utf8);
            while(reader.Next(out var line))
                CharMaps.unmapped(map, line.Data, unmapped);
            var pairs = unmapped.Map(x => CharMaps.entry((Hex16)x,x)).OrderBy(x => x.Source).ToSeq();
            channel.Ran(flow, string.Format("Found {0} unmapped characters", pairs.Count));
            return pairs;
        }

        [Op]
        public static void unmapped(IWfChannel channel, in CharMap<char> map, FilePath src, FilePath dst)
        {
            var unmapped = CharMapper.unmapped(channel, src, map);
            var pairs = unmapped.View.Map(CharMaps.format);
            var count = pairs.Length;
            using var writer = dst.Writer();
            for(var i=0; i<count; i++)
                writer.WriteLine(skip(pairs,i));
        }

        [Op]
        public static void emit(IWfChannel channel, in CharMap<char> src, FilePath dst)
        {
            var emitting = channel.EmittingFile(dst);
            using var writer = dst.Writer();
            channel.EmittedFile(emitting, CharMaps.emit(src, writer));
        }
    }
}