//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public readonly struct AsmBlockSpec : IAsmSourcePart
    {
        public static string format(in AsmBlockSpec src)
        {
            var dst = text.buffer();

            if(src.Comment.IsNonEmpty)
                dst.AppendLine(src.Comment.Format());

            if(src.Label.IsNonEmpty)
                dst.AppendLine(src.Label);


            if(src.Content.IsNonEmpty)
            {
                var count = src.Content.Count;
                for(var i=0; i<count; i++)
                    dst.IndentLine(4, src.Content[i].Format());
            }

            return dst.Emit();
        }

        public readonly AsmComment Comment;

        public readonly AsmBlockLabel Label;

        public readonly Index<AsmInstruction> Content;

        [MethodImpl(Inline)]
        public AsmBlockSpec(AsmComment comment, AsmBlockLabel label, Index<AsmInstruction> content)
        {
            Comment = comment;
            Label = label;
            Content = content;
        }

        public bool IsEmpty
        {
            [MethodImpl(Inline)]
            get => Content.IsEmpty;
        }

        public bool IsNonEmpty
        {
            [MethodImpl(Inline)]
            get => Content.IsNonEmpty;
        }

        public AsmCellKind PartKind
            => AsmCellKind.Block;

        public string Format()
            => format(this);

        public override string ToString()
            => Format();
    }
}