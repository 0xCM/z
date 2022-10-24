//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.llvm
{
    using static sys;

    partial class LlvmDataCalcs
    {
        public Index<LineRelations> CalcDefRelations(ReadOnlySpan<TextLine> src)
        {
            var dst = list<LineRelations>();
            var record = LineRelations.Empty;
            for(var i=0; i<src.Length; i++)
            {
                if(ParseDefRelations(skip(src,i), out record))
                    dst.Add(record);
           }
            return dst.ToArray();
        }

        static bool ParseDefRelations(in TextLine line, out LineRelations dst)
        {
            const string Marker = "def ";
            dst = LineRelations.Empty;
            var content = line.Content;
            var result = false;
            var name = EmptyString;
            var j = text.index(content, Marker);
            if(j >= 0)
            {
                var k = text.index(content, Chars.LBrace);
                if(k>=0)
                {
                    name = text.trim(text.inside(content, j + Marker.Length - 1, k));
                    if(nonempty(name))
                    {
                        Lineage.parse(content, out var a);
                        dst = new (line.LineNumber, name, a);
                        result = true;
                    }
                }
            }

            return result;
        }
    }
}