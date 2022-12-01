//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    using static sys;

    public readonly struct AsmFormatter
    {
        public static void render(ReadOnlySpan<byte> block, ReadOnlySpan<IceInstruction> instructions, ITextBuffer dst)
        {
            Address16 offset = z16;
            var count = instructions.Length;
            dst.AppendLine(asm.comment(block.FormatHex()));
            for(var i=0; i<count; i++)
            {
                ref readonly var instruction = ref skip(instructions,i);
                var size = instruction.InstructionSize;
                var code = slice(block, offset, size);
                dst.AppendLineFormat("{0,-6} {1,-46} # {2,-2} | {3}", offset, instruction.FormattedInstruction, size, code.FormatHex());
                offset += size;
            }
        }

        public static string header(in MemberEncoding src)
        {
            const string PageBreak = "#" + CharText.Space + RpOps.PageBreak160;
            const AsmCommentMarker CommentMarker = AsmCommentMarker.Hash;
            const sbyte Pad = -14;
            var dst = text.buffer();
            dst.AppendLine(PageBreak);
            dst.AppendLine(new AsmInlineComment(CommentMarker, $"{src.Sig}::{src.Uri}"));
            dst.AppendLine(AsmInlineComment.array(src.Data).Format());
            dst.AppendLine(new AsmInlineComment(CommentMarker, text.attrib(Pad, nameof(src.Token.EntryAddress), "0x" + src.Token.EntryAddress.Location.ToString("x"))));
            dst.AppendLine(new AsmInlineComment(CommentMarker, text.attrib(Pad, nameof(src.Token.TargetAddress), "0x" + src.Token.TargetAddress.Location.ToString("x"))));
            dst.Append(PageBreak);
            return dst.Emit();
        }

        public static string header(in ApiEncoded src)
        {
            const string PageBreak = "#" + CharText.Space + RpOps.PageBreak160;
            const AsmCommentMarker CommentMarker = AsmCommentMarker.Hash;
            const sbyte Pad = -14;
            var dst = text.buffer();
            dst.AppendLine(PageBreak);
            dst.AppendLine(new AsmInlineComment(CommentMarker, $"{src.Sig}::{src.Uri}"));
            dst.AppendLine(AsmInlineComment.array(src.Code).Format());
            dst.AppendLine(new AsmInlineComment(CommentMarker, text.attrib(Pad, nameof(src.Token.EntryAddress), "0x" + src.Token.EntryAddress.Location.ToString("x"))));
            dst.AppendLine(new AsmInlineComment(CommentMarker, text.attrib(Pad, nameof(src.Token.TargetAddress), "0x" + src.Token.TargetAddress.Location.ToString("x"))));
            dst.Append(PageBreak);
            return dst.Emit();
        }

        [Op]
        public static string format(AsmRoutine src, in AsmFormatConfig config)
        {
            var dst = text.buffer();
            render(src, config, dst);
            return dst.Emit();
        }

        [Op]
        public static string format(AsmRoutine src, string header, in AsmFormatConfig config)
        {
            var dst = text.buffer();
            dst.AppendLine(header);
            dst.AppendLine(instructions(src, config).Join(Eol));
            return dst.Emit();
        }

        [Op]
        public static void render(AsmRoutine src, in AsmFormatConfig config, ITextBuffer dst)
        {
            var buffer = span<string>(16);
            var header = new ApiCodeBlockHeader(src.Uri, src.DisplaySig.Format(), src.Code, src.TermCode);
            var count = render(header,buffer);
            for(var i=0; i<count; i++)
                dst.AppendLine(skip(buffer,i));
            dst.AppendLine(instructions(src, config).Join(Eol));
        }

        /// <summary>
        /// Formats the instructions in a function
        /// </summary>
        /// <param name="src">The source function</param>
        /// <param name="config">An optional format configuration</param>
        [Op]
        public static ReadOnlySpan<string> instructions(AsmRoutine src, in AsmFormatConfig config)
        {
            var summaries = AsmRoutines.summarize(src);
            var count = summaries.Length;
            if(count == 0)
                return default;
            var dst = span<string>(count);
            for(var i=0u; i< count; i++)
                seek(dst,i) = format(src.BaseAddress, skip(summaries,i), config);
            return dst;
        }

        [MethodImpl(Inline), Op]
        static AsmInlineComment comment(AsmCommentMarker marker, string src)
            => new AsmInlineComment(marker,src);

        static byte render(in ApiCodeBlockHeader src, Span<string> dst)
        {
            const string PageBreak = "#" + CharText.Space + RP.PageBreak160;
            const AsmCommentMarker CommentMarker = AsmCommentMarker.Hash;
            var i = z8;
            seek(dst, i++) = PageBreak;
            seek(dst, i++) = comment(CommentMarker, $"{src.DisplaySig}::{src.Uri}");
            seek(dst, i++) = bytespan(src.Uri, src.CodeBlock);
            seek(dst, i++) = hexarray(src.CodeBlock);
            seek(dst, i++) = comment(CommentMarker, string.Concat(nameof(CodeBlock.Address), RP.spaced(Chars.Eq), src.CodeBlock.Address));
            seek(dst, i++) = comment(CommentMarker, string.Concat(nameof(src.TermCode), RP.spaced(Chars.Eq), src.TermCode.ToString()));
            seek(dst, i++) = PageBreak;
            return i;
        }

        [Op]
        public static AsmInlineComment bytespan(OpUri uri, BinaryCode src)
            => new AsmInlineComment(AsmCommentMarker.Hash, SpanResFormatter.format(ByteSpans.specify(uri, src)));

        [Op]
        public static AsmInlineComment hexarray(BinaryCode src)
            => new AsmInlineComment(AsmCommentMarker.Hash, HexArray.from(src).Format(true));

        [Op]
        public static string format(MemoryAddress @base, in AsmInstructionInfo src, in AsmFormatConfig config)
        {
            var dst = text.buffer();
            render(@base, src, config, dst);
            return dst.ToString();
        }

        [Op]
        public static string format(in AsmOffsetLabel label, in AsmFormInfo src, byte[] encoded)
            => string.Format("{0} | {1,-3} | {2,-32} | ({3}) = {4}", label, encoded.Length, encoded.FormatHex(), src.Sig, src.OpCode);

        [Op]
        public static void render(MemoryAddress @base, in AsmInstructionInfo src, in AsmFormatConfig config, ITextBuffer dst)
        {
            const string AbsolutePattern = "{0} {1} {2}";
            const string RelativePattern = "{0} {1}";
            var label = offset(src.Offset, w16);
            var address = @base + src.Offset;
            if(config.EmitLineLabels)
            {
                if(config.AbsoluteLabels)
                    dst.Append(string.Format(AbsolutePattern, address.Format(), label, src.Statement.FormatPadded()));
                else
                    dst.Append(string.Format(RelativePattern, label, src.Statement.FormatPadded()));
            }
            else
            {
                dst.Append(src.Statement.FormatPadded());
            }

            dst.Append(new AsmInlineComment(AsmCommentMarker.Hash, format(AsmOffsetLabel.define(16, src.Offset), src.AsmForm, src.Encoded)));
        }

        [Op]
        public static string offset(ulong offset, DataWidth width)
            => width switch{
                DataWidth.W8 => ScalarCast.uint8(offset).FormatAsmHex(),
                DataWidth.W16 => ScalarCast.uint16(offset).FormatAsmHex(),
                DataWidth.W32 => ScalarCast.uint32(offset).FormatAsmHex(),
                DataWidth.W64 => offset.FormatAsmHex(),
                _ => EmptyString
            };
    }
}