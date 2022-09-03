//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.llvm
{
    using static core;

    public readonly struct RecordFieldParser
    {
        public static Index<RecordField> parse(ReadOnlySpan<TextLine> src, LineMap<string> map)
        {
            var result = Outcome.Success;
            var count = map.CountLines();
            var buffer = alloc<RecordField>(count);
            var k = 0;
            for(var i=0u; i<map.IntervalCount; i++)
                parse(src, map[i], ref k, buffer);
            return buffer;
        }

        public static Outcome parse(string src, out RecordField dst)
        {
            var result = Outcome.Success;
            dst = default;
            var parts = src.Split(Z0.Chars.Pipe).Map(x => x.Trim());
            var count = parts.Length;
            if(count < 4)
                return (false, Tables.FieldCountMismatch.Format(4, count));

            dst.RecordName = skip(parts,0);
            dst.DataType = skip(parts,1);
            dst.Name = skip(parts,2);
            dst.Value = skip(parts,3);
            return result;
        }

        static void parse(ReadOnlySpan<TextLine> src, in LineInterval<string> interval, ref int k, Span<RecordField> dst)
        {
            ref readonly var min = ref interval.MinLine;
            ref readonly var max = ref interval.MaxLine;
            var length = interval.LineCount;
            var offset = min - 1;
            for(var j=offset; j<length+offset; j++)
            {
                ref readonly var line = ref skip(src,j);
                var content = line.Content.Trim();
                ref var field = ref seek(dst, k++);
                field.RecordName = text.trim(interval.Id);
                if(SQ.index(content, Chars.Space, out var i0))
                {
                    field.DataType = text.trim(text.left(content,i0));
                    var namedValue = text.right(content,i0);
                    if(SQ.index(namedValue, Chars.Space, out var i1))
                    {
                        field.Name = text.trim(text.left(namedValue,i1));
                        if(SQ.index(namedValue, Chars.Eq, out var i2))
                        {
                            if(SQ.index(namedValue, Chars.Semicolon, out var i3))
                                field.Value = text.trim(text.inside(namedValue, i2, i3).Replace(Chars.Pipe,Chars.Caret));
                        }
                    }
                }
            }
        }
    }
}