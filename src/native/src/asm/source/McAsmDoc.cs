//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    /// <summary>
    /// Represents an asm source document
    /// </summary>
    public class McAsmDoc
    {
        public FilePath Path {get;}

        ConstLookup<LineNumber,AsmDirective> _Directives;

        ConstLookup<LineNumber,AsmBlockLabel> _BlockLabels;

        ConstLookup<LineNumber,AsmSourceLine> _SourceLines;

        ConstLookup<LineNumber,AsmInstRef> _Instructions;

        ConstLookup<LineNumber,AsmSourceLine> _Encodings;

        ConstLookup<LineNumber,AsmSourceLine> _Syntax;

        ConstLookup<LineNumber,AsmSourceLine> _DocLines;

        McAsmDoc( )
        {


        }

        public McAsmDoc(FilePath src,
            ConstLookup<LineNumber,AsmDirective> directives,
            ConstLookup<LineNumber,AsmBlockLabel> labels,
            ConstLookup<LineNumber,AsmSourceLine> sources,
            ConstLookup<LineNumber,AsmInstRef> instructions,
            ConstLookup<LineNumber,AsmSourceLine> encodings,
            ConstLookup<LineNumber,AsmSourceLine> syntax,
            ConstLookup<LineNumber,AsmSourceLine> doc
            )
        {
            Path = src;
            _Directives = directives;
            _BlockLabels = labels;
            _SourceLines = sources;
            _Instructions = instructions;
            _Encodings = encodings;
            _Syntax = syntax;
            _DocLines = doc;
        }

        public ConstLookup<LineNumber,AsmDirective> Directives
        {
            [MethodImpl(Inline)]
            get => _Directives;
        }

        public ConstLookup<LineNumber,AsmBlockLabel> BlockLabels
        {
            [MethodImpl(Inline)]
            get => _BlockLabels;
        }

        public ConstLookup<LineNumber,AsmSourceLine> SourceLines
        {
            [MethodImpl(Inline)]
            get => _SourceLines;
        }

        public ConstLookup<LineNumber,AsmSourceLine> Encodings
        {
            [MethodImpl(Inline)]
            get => _Encodings;
        }

        public ConstLookup<LineNumber,AsmSourceLine> Syntax
        {
            [MethodImpl(Inline)]
            get => _Syntax;
        }

        public ConstLookup<LineNumber,AsmSourceLine> DocLines
        {
            [MethodImpl(Inline)]
            get => _DocLines;
        }

        public ConstLookup<LineNumber,AsmInstRef> Instructions
        {
            [MethodImpl(Inline)]
            get => _Instructions;
        }

        public static McAsmDoc Empty => new ();
    }
}