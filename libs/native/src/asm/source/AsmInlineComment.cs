//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    public readonly struct AsmInlineComment : IAsmSourcePart
    {
        [Parser]
        public static bool parse(ReadOnlySpan<char> src, out AsmInlineComment dst)
        {
            var count = src.Length;
            var marker = AsmCommentMarker.None;
            var buffer = text.buffer();
            for(var i=0; i<count; i++)
            {
                ref readonly var c = ref skip(src,i);
                switch(c)
                {
                    case (char)AsmCommentMarker.Semicolon:
                    case (char)AsmCommentMarker.Hash:
                        if(marker == 0)
                            marker = (AsmCommentMarker)c;
                        else
                            buffer.Append(c);
                    break;
                    default:
                        if(marker !=0)
                            buffer.Append(c);
                    break;
                }
            }
            var found = marker != 0;
            if(found)
                dst = new AsmInlineComment(marker, buffer.Emit());
            else
                dst = AsmInlineComment.Empty;
            return found;
        }

        public static AsmInlineComment array(ReadOnlySpan<byte> src)
            => new AsmInlineComment(AsmCommentMarker.Hash, HexFormatter.array(src));

        public AsmCommentMarker Marker {get;}

        public string Content {get;}

        [MethodImpl(Inline)]
        public AsmInlineComment(AsmCommentMarker marker, string content)
        {
            Marker = marker;
            Content = content;
        }

        public bool IsEmpty
        {
            [MethodImpl(Inline)]
            get => empty(Content);
        }

        public bool IsNonEmpty
        {
            [MethodImpl(Inline)]
            get => nonempty(Content);
        }

        public AsmCellKind PartKind
        {
            [MethodImpl(Inline)]
            get => AsmCellKind.InlineComment;
        }

        public string Format()
            => text.empty(Content) ? EmptyString : string.Format("{0} {1}", (char)Marker, Content);

        public override string ToString()
            => Format();

        public static implicit operator string(AsmInlineComment src)
            => src.Format();

        public static AsmInlineComment Empty
        {
            [MethodImpl(Inline)]
            get => new AsmInlineComment(0,EmptyString);
        }
    }
}