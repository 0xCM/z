//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.llvm
{
    using static core;

    partial class LlvmDataCalcs
    {
        public static void CalcClassRelations(ReadOnlySpan<TextLine> src, List<LineRelations> dst)
        {
            var record = LineRelations.Empty;
            for(var i=0; i<src.Length; i++)
            {
                if(ParseClassRelations(skip(src,i), out record))
                    dst.Add(record);
           }
        }

        public Index<LineRelations> CalcClassRelations(ReadOnlySpan<TextLine> src)
        {
            var dst = list<LineRelations>();
            var record = LineRelations.Empty;
            for(var i=0; i<src.Length; i++)
            {
                if(ParseClassRelations(skip(src,i), out record))
                    dst.Add(record);
           }

            return dst.ToArray();
        }

        static bool ParseClassRelations(in TextLine src, out LineRelations dst)
        {
            const string Marker = "class ";
            dst = LineRelations.Empty;
            var content = src.Content;
            var j = text.index(content, Marker);
            var parameters = EmptyString;
            var name = EmptyString;
            var result = false;
            if(j >= 0)
            {
                var k = text.index(content, Chars.LBrace);
                if(k>=0)
                {
                    var lt = text.index(content,Chars.Lt);
                    if(lt >=0)
                    {
                        name = text.trim(text.inside(content, j + Marker.Length - 1, lt));
                        var bounds = text.enclosed(content,0, (Chars.Lt, Chars.Gt));
                        parameters = text.inside(content, bounds.Left - 1, bounds.Right + 1).Replace(Chars.Pipe,Chars.Caret);
                    }
                    else
                        name = text.trim(text.inside(content, j + Marker.Length - 1, k));

                    if(nonempty(name))
                    {
                        dst = new LineRelations();
                        dst.SourceLine = src.LineNumber;
                        dst.Name = name;
                        Lineage.parse(content, out dst.Ancestors);
                        dst.Parameters = parameters;
                        result = true;
                    }
                }
            }

            return result;
        }
    }
}