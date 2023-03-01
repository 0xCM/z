//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;
    
    public class MatchGenerator : Channeled<MatchGenerator>
    {
        public void GenMatcher(IDbArchive root, string scope)
        {
            var input = root.Targets(scope).Path(FS.file("matcher-a", FS.Txt));
            var lines = input.ReadNumberedLines();
            var LineCount = lines.Length;
            var histo = dict<char,uint>();
            var LineLengths = alloc<uint>(LineCount);
            var Terms = dict<string,uint>();
            for(var i=0; i<LineCount; i++)
            {
                ref readonly var line = ref lines[i];
                var content = line.Content.Trim();
                Terms[content] = (uint)content.Length;
                var term = span(content);
                var length = (uint)content.Length;
                seek(LineLengths,i) = length;

                for(var j=0; j<length; j++)
                {
                    ref readonly var c = ref skip(term,j);
                    if(histo.TryGetValue(c, out var n))
                        histo[c] = n + 1;
                    else
                        histo[c] = 1;
                }
            }

            var targets = root.Targets("targets");
            var counts = histo.Map(x => (x.Key,x.Value)).OrderBy(x => x.Key);
            void EmitTargets()
            {
                var dst = targets.Path(input.FileName.ChangeExtension(FS.ext("hist")));
                var emitting = Channel.EmittingFile(dst);
                using var writer = dst.Utf8Writer();
                for(var i=0; i<counts.Length; i++)
                {
                    ref readonly var bucket = ref skip(counts,i);
                    writer.WriteLine(string.Format("{0} | {1}", bucket.Key, bucket.Value));
                }
                Channel.EmittedFile(emitting, counts.Length);
            }

            void EmitTerms()
            {
                var sorted = Terms.Map(x => (x.Key, x.Value)).OrderBy(x => x.Value);
                var max = gmath.max(sorted.Select(x => x.Value).ToReadOnlySpan());
                var dst = targets.Path(input.FileName.ChangeExtension(FS.ext("terms")));
                var emitting = Channel.EmittingFile(dst);
                using var writer = dst.Utf8Writer();
                var s0 = text.slot(0, math.negate((short)(max)));
                var s1 = text.slot(1);
                var pattern = string.Concat(s0," | ", s1);
                iter(sorted, s => writer.WriteLine(string.Format(pattern, s.Key, s.Value)));
                Channel.EmittedFile(emitting, sorted.Length);
            }

            void EmitBuckets()
            {
                var buckets = Buckets.bucketize(lines.Select(x => x.Content.Trim()));
                Channel.Write(buckets.Format());
            }
        }
    }
}