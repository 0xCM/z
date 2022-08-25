//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.llvm
{
    using Asm;

    using static core;

    public class AsmSyntaxTreeParser
    {
        const string SourceMarker = "# Source:";

        const string StatementMarker = "     ";

        readonly List<AsmInlineComment> Comments;

        FilePath CurrentSource;

        FilePath PriorSource;

        uint LineCount;

        bool ParsingSource;

        bool ParsingBlock;

        bool ParsingStatement;

        AsmBlockLabel CurrentBlockLabel;

        AsmBlockLabel PriorBlockLabel;

        AsmExpr CurrentStatementText;

        AsmExpr PriorStatementText;

        public AsmSyntaxTreeParser()
        {
            Comments = new();
        }

        void Init()
        {
            CurrentSource = FilePath.Empty;
            PriorSource = FilePath.Empty;
            Comments.Clear();
            LineCount = 0;
            CurrentBlockLabel = AsmBlockLabel.Empty;
            PriorBlockLabel= AsmBlockLabel.Empty;
            CurrentStatementText = EmptyString;
            PriorStatementText = EmptyString;
            ParsingSource = false;
            ParsingBlock = false;
            ParsingStatement = false;

        }

        bool ParseBlockLabel(string src)
            => AsmBlockLabel.parse(src, out CurrentBlockLabel);

        bool ParseComment(string src)
        {
            if(AsmInlineComment.parse(src, out var c))
            {
                Comments.Add(c);
                return true;
            }
            else
            {
                return false;
            }

        }

        bool ParseSource(string src)
        {
            var j = text.index(src, SourceMarker);
            if(j >= 0)
            {
                var path = FS.path(text.right(src, j + SourceMarker.Length).Trim());
                if(CurrentSource.IsNonEmpty)
                {
                    CurrentSource = path;
                }
                else
                {
                    PriorSource = CurrentSource;
                    CurrentSource = path;
                }
                return true;
            }
            else
            {
                return false;
            }
        }

        bool ParseStatement(string src)
        {
            var k = text.index(src, StatementMarker);
            if(k >= 0)
            {
                var statement = text.right(src, k + StatementMarker.Length);
                if(nonempty(statement))
                {

                    return true;
                }
            }
            return false;
        }

        void EndSourceParse()
        {

        }

        void EndStatmentParse()
        {

        }

        void EndBlockParse()
        {


        }

        Outcome Parse(Index<TextLine> lines)
        {
            var result = Outcome.Success;
            LineCount = lines.Count;
            for(var i=0; i<LineCount; i++)
            {
                ref readonly var line = ref lines[i];
                ref readonly var content = ref line.Content;

                var j = text.index(content, SourceMarker);

                if(ParseSource(content))
                {
                    if(!CurrentSource.Equals(PriorSource))
                    {
                        EndSourceParse();
                    }
                }
                else if(ParseBlockLabel(content))
                {
                    if(!CurrentBlockLabel.Equals(PriorBlockLabel))
                    {
                        EndBlockParse();
                    }
                }
                else if(ParseComment(content))
                {
                    continue;
                }
                else if(ParseStatement(content))
                {

                }

            }
            return result;
        }
    }
}