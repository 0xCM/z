//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    using static sys;

    [ApiHost]
    public readonly struct ApiInstructions
    {
        [Op]
        public static uint count(ReadOnlySpan<AsmRoutine> src)
        {
            var count = src.Length;
            var total = 0u;
            for(var i=0; i<count; i++)
                total += (uint)skip(src,i).InstructionCount;
            return total;
        }

        [Op]
        public static uint hostasm(in AsmRoutine src, Span<HostAsmRecord> dst)
        {
            var instructions = src.Instructions.View;
            var count = (uint)instructions.Length;
            for(var i=0u; i<count; i++)
            {
                ref readonly var instruction = ref skip(instructions, i);
                ref var target = ref seek(dst,i);
                target.BlockAddress = src.BaseAddress;
                target.IP = instruction.IP;
                target.BlockOffset = (Address16)instruction.Offset;
                target.Expression = instruction.Statment;
                target.Encoded = instruction.AsmHex;
                target.Sig = instruction.AsmSig;
                target.OpCode = instruction.OpCode;
                target.Bitstring = asm.bitstring(instruction.AsmHex);
                target.OpUri = src.Uri;
            }
            return count;
        }

        [Op]
        public static uint hostasm(in AsmInstructionBlock src, List<HostAsmRecord> dst)
        {
            var instructions = src.Instructions;
            var count = (uint)instructions.Length;
            var offset = z16;
            var bytes = src.Code.Bytes;
            for(var i=0; i<count; i++)
            {
                ref readonly var instruction = ref skip(instructions,i);
                var opcode = instruction.OpCode.ToString();
                var statement = new HostAsmRecord();
                var size = (ushort)instruction.ByteLength;
                var specifier = instruction.Specifier;
                statement.BlockAddress = src.BaseAddress;
                statement.BlockOffset = offset;
                statement.IP = instruction.IP;
                statement.OpUri = src.Uri;
                statement.Expression = instruction.FormattedInstruction;
                AsmSigInfo.parse(instruction.OpCode.InstructionString, out statement.Sig);
                statement.Encoded = asm.asmhex(bytes.Slice(offset, size));
                statement.OpCode = opcode;
                statement.Bitstring = asm.bitstring(statement.Encoded);
                dst.Add(statement);

                offset += size;
            }
            return count;
        }

        [Op]
        public static AsmInstructionInfo summarize(MemoryAddress @base, IceInstruction src, CodeBlock encoded, AsmExpr statement, uint offset)
            => new AsmInstructionInfo(@base, offset,  statement,  src.Specifier, AsmBytes.code(encoded, offset, src.InstructionSize));

        public static ReadOnlySpan<ApiInstruction> filter(ReadOnlySpan<ApiInstruction> src, byte opcode)
        {
            var dst = list<ApiInstruction>();
            var count = src.Length;
            for(var i=0; i<count; i++)
            {
                ref readonly var instruction = ref skip(src,i);
                if(instruction.Encoded.StartsWith(opcode))
                    dst.Add(instruction);
            }
            return dst.ViewDeposited();
        }

        [Op]
        public static HexVector16 offsets(ReadOnlySpan<ApiInstruction> src)
        {
            var count = src.Length;
            var buffer = alloc<Hex16>(count);
            ref var dst = ref first(buffer);
            for(var i=0; i<count; i++)
                seek(dst,i) = (Hex16)skip(src, i).Offset;
            return buffer;
        }

        [Op]
        public static Index<ApiInstruction> from(ApiCodeBlock code, IceInstruction[] src)
        {
            var @base = code.BaseAddress;
            var offseq = AsmOffsetSeq.Zero;
            var count = src.Length;
            var buffer = alloc<ApiInstruction>(count);
            ref var dst = ref first(buffer);
            var data = span(code.Storage);

            for(var i=0; i<count; i++)
            {
                var fx = skip(src, i);
                var len = fx.ByteLength;
                var recoded = new ApiCodeBlock(fx.IP, code.OpUri, data.Slice((int)offseq.Offset, len).ToArray());
                seek(dst, i) = new ApiInstruction(@base, fx, recoded);
                offseq = offseq.AccrueOffset((uint)len);
            }
            return buffer;
        }
    }
}