//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    using System.IO;

    using Iced = Iced.Intel;

    readonly struct IceInstructionFormatter : IIceInstructionFormatter
    {
        readonly AsmFormatConfig Config;

        readonly Iced.MasmFormatter MasmFormatter;

        static Iced.MasmFormatterOptions DefaultOptions => new Iced.MasmFormatterOptions
            {
                DecimalDigitGroupSize = 4,
                BranchLeadingZeroes = false,
                HexDigitGroupSize = 4,
                UpperCaseRegisters = false,
                LeadingZeroes = false,
                DisplInBrackets = true,
                UpperCaseHex = false,
                RipRelativeAddresses = true,
                SignedMemoryDisplacements = true,
                ShowSymbolAddress = true,
                SignedImmediateOperands = false,
            };

        [MethodImpl(Inline)]
        internal IceInstructionFormatter(in AsmFormatConfig config)
        {
            Config = config;
            MasmFormatter = new Iced.MasmFormatter(DefaultOptions);
        }

        public string FormatInstruction(in Iced.Instruction src, ulong @base)
        {
            var sb = text.build();
            var writer = new StringWriter(sb);
            var output = new AsmOutput(writer, @base);
            MasmFormatter.Format(src, output);
            return sb.ToString();
        }

        public ReadOnlySpan<string> FormatInstructions(Iced.InstructionList src, ulong @base)
        {
            var count = src.Count;
            if(count == 0)
                return default;

            Span<string> dst = new string[count];
            var sb = text.build();
            var writer = new StringWriter(sb);
            var output = new AsmOutput(writer, @base);
            for(var i= 0u; i <count; i++)
            {
                ref readonly var instruction = ref src[(int)i];
                MasmFormatter.Format(instruction, output);
                sys.seek(dst, i) = sb.ToString();
                sb.Clear();
            }
            return dst;
        }

        class AsmOutput : Iced.FormatterOutput
        {
            readonly TextWriter Writer;

            readonly ulong BaseAddress;

            public AsmOutput(TextWriter writer, ulong baseaddress)
            {
                Writer = writer;
                BaseAddress = baseaddress;
            }

            static string label(string src, ulong baseaddress)
            {
                var hex = HexNumericParser.parse64u(src).ValueOrDefault();
                return (hex - baseaddress).FormatAsmHex(4);
            }

            public override void Write(string text, Iced.FormatterOutputTextKind kind)
            {
                switch(kind)
                {
                    case Iced.FormatterOutputTextKind.LabelAddress:
                        Writer.Write(label(text, BaseAddress));
                    break;
                    default:
                        Writer.Write(text);
                    break;
                }
            }
        }
    }
}