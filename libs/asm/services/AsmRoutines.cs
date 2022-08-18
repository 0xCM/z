//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    using static core;

    [ApiHost]
    public sealed class AsmRoutines : AppService<AsmRoutines>
    {
        public static ApiHostRoutine hosted(MemoryAddress @base, ApiCodeBlock code, IceInstruction[] src)
            => new ApiHostRoutine(@base, ApiInstructions.from(code, src));

        public static AsmRoutine routine(MemberCodeBlock member, AsmInstructionBlock asm)
        {
            var code = new ApiCodeBlock(member.OpUri, member.Encoded);
            return new AsmRoutine(member.OpUri, member.Method.Artifact().DisplaySig.Format(), code, member.TermCode, ApiInstructions.from(code, asm));
        }

        public static Index<ApiCodeBlock> blocks(ReadOnlySpan<AsmRoutine> src)
        {
            var count = src.Length;
            var dst = alloc<ApiCodeBlock>(count);
            var size = blocks(src, dst);
            return dst.Sort();
        }

        [Op]
        public static ByteSize blocks(ReadOnlySpan<AsmRoutine> src, Span<ApiCodeBlock> dst)
        {
            var size = ByteSize.Zero;
            var count = src.Length;
            for(var i=0; i<count; i++)
            {
                var routine = skip(src,i);
                seek(dst, i) = routine.Code;
                size += skip(dst,i).Size;
            }
            return size;
        }

        /// <summary>
        /// Describes the instructions that comprise a function
        /// </summary>
        /// <param name="src">The source function</param>
        [Op]
        public static ReadOnlySpan<AsmInstructionInfo> summarize(AsmRoutine src)
        {
            var count = src.InstructionCount;
            var buffer = new AsmInstructionInfo[count];
            var offset = 0u;
            var @base = src.BaseAddress;
            var view = src.Instructions.View;
            var dst = span(buffer);
            var counter = 0u;
            for(var i=0u; i<count; i++)
            {
                ref readonly var instruction = ref skip(view,i);
                var size = instruction.InstructionSize;

                if(src.Code.Size < offset + size)
                {
                    term.error($"Instruction size mismatch {instruction.IP} {offset} {src.Code.Size} {size}");
                    continue;
                }

                var invalid = instruction.Mnemonic == IceMnemonic.INVALID;
                if(invalid)
                    break;

                seek(dst, i) = ApiInstructions.summarize(@base, instruction.Instruction, src.Code, instruction.Statment, offset);
                offset += size;
                counter++;
            }
            return slice(dst,0,counter);
        }
    }
}
