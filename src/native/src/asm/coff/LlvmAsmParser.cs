//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using Asm;

    using static sys;

    using C = AsmLineClass;

    class LlvmAsmParser : IFileParser<LlvmAsmParser,FileRef,McAsmDoc>, IFileParser<McAsmDoc>
    {
        Dictionary<LineNumber,AsmDirective> Directives;

        Dictionary<LineNumber,AsmBlockLabel> BlockLabels;

        List<LineNumber> BlockOffsets;

        Dictionary<LineNumber,AsmSourceLine> SourceLines;

        Dictionary<LineNumber,AsmInstRef> Instructions;

        Dictionary<LineNumber,AsmSourceLine> Encodings;

        Dictionary<LineNumber,AsmSourceLine> Syntax;

        Dictionary<LineNumber,AsmSourceLine> DocLines;

        const string InstructionMarker = "<MCInst #";

        const string EncodingMarker = "encoding: ";

        uint DocSeq;

        FileRef DocSource;

        public McAsmDoc ParseMcAsmDoc(in FileRef src)
        {
            DocSource = src;
            var result = Outcome.Success;
            var data = FS.readlines(DocSource.Path).View;
            var count = (uint)data.Length;
            DocSeq = 0;
            LabelSeq = 0;
            Label = AsmBlockLabel.Empty;
            BlockLabels = new();
            BlockOffsets = new();
            SourceLines = new();
            Directives = new();
            Instructions = new();
            Encodings = new();
            Syntax = new();
            DocLines = new();

            for(var i=0u; i<count; i++)
                Parse(skip(data,i));

            return new McAsmDoc(DocSource, Directives, BlockLabels, SourceLines, Instructions, Encodings, Syntax, DocLines);
        }

        public Outcome Parse(FileRef src, out McAsmDoc dst)
        {
            var result = Outcome.Success;
            try
            {
                dst = ParseMcAsmDoc(src);
            }
            catch(Exception e)
            {
                result = e;
                dst = McAsmDoc.Empty;
            }
            return result;
        }

        AsmBlockLabel Label;

        uint LabelSeq;

        LineNumber LabelLine;

        AsmLineClass LineClass;

        LineNumber LineNumber;

        string LineContent;

        [MethodImpl(Inline)]
        static bool IsLabel(string src)
            => text.xedni(src, Chars.Colon) == src.Length - 1;

        [MethodImpl(Inline)]
        static bool IsDirective(string src)
            => text.index(src, Chars.Dot) == 0;

        public static AsmLineClass lineclass(string src)
        {
            var content = text.trim(src);

            if(text.empty(content))
                return C.Empty;

            if(IsLabel(content))
                return C.Label;

            if(IsDirective(content))
                return C.Directive;

            return C.AsmSource;
        }

        void Parse(in TextLine src)
        {
            LineClass = lineclass(src.Content);
            LineContent = src.Content.Replace(Chars.Tab, Chars.Space).Trim();
            LineNumber = src.LineNumber;
            if(LineClass != AsmLineClass.Label)
                DocLines.Add(LineNumber, new AsmSourceLine(LineNumber, LineClass, AsmBlockLabel.Empty, LineContent));
            switch(LineClass)
            {
                case C.Label:
                    if(AsmBlockLabel.parse(LineContent, out Label))
                    {
                        LabelSeq++;
                        LabelLine = LineNumber;
                        BlockLabels.Add(LineNumber, Label);
                        BlockOffsets.Add(LabelLine);
                        var line = new AsmSourceLine(LabelLine, LineClass, Label, EmptyString);
                        SourceLines.Add(LineNumber, line);
                        DocLines.Add(LineNumber, line);
                    }
                break;

                case C.Directive:
                    if(AsmDirectives.parse(LineContent, out var directive))
                    {
                        Directives.Add(LineNumber, directive);
                    }
                break;

                case C.AsmSource:
                    if(AsmInlineComment.parse(LineContent, out var asmcomment))
                    {
                        var statement = text.left(LineContent, (char)asmcomment.Marker).Trim();
                        if(statement.Length != 0)
                            statement = RpOps.Spaced4 + statement;

                        var comment = asmcomment.Content;
                        if(comment.Contains(InstructionMarker))
                        {
                            var i = text.index(comment, InstructionMarker) + InstructionMarker.Length;
                            var inst = text.remove(text.slice(comment,i), Chars.Gt);
                            var j = text.whitespace(inst);
                            if(j != NotFound)
                            {
                                Instructions.Add(LineNumber, new AsmInstRef(DocSource.DocId, DocSeq, LineNumber, text.right(inst,j)));
                            }
                            else
                            {
                                Instructions.Add(LineNumber, new AsmInstRef(DocSource.DocId, DocSeq, LineNumber, inst));
                            }
                            DocSeq++;
                        }

                        if(comment.Contains(EncodingMarker))
                        {
                            SourceLines.Add(LineNumber, new AsmSourceLine(LineNumber, LineClass, Label, statement));
                            Encodings.Add(LineNumber, new AsmSourceLine(LineNumber, LineClass, Label, "#" + RP.Spaced2 + comment));
                        }
                        else if(comment.Contains(InstructionMarker) && statement.Length != 0)
                        {
                            SourceLines.Add(LineNumber, new AsmSourceLine(LineNumber, LineClass, Label, statement));
                            Syntax.Add(LineNumber, new AsmSourceLine(LineNumber, LineClass, Label, "#" + RP.Spaced2 + comment));
                        }
                        else
                            SourceLines.Add(LineNumber, new AsmSourceLine(LineNumber, LineClass, Label, statement, comment));
                    }
                    else
                        SourceLines.Add(LineNumber, new AsmSourceLine(LineNumber, LineClass, Label, RP.Spaced4 + LineContent));
                break;
            }
        }
    }
}