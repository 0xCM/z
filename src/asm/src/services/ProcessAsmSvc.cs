//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    using static sys;

    public sealed class ProcessAsmSvc : WfSvc<ProcessAsmSvc>
    {
        AsmDecoder Decoder => Wf.AsmDecoder();

        public SortedSpan<ProcessAsmRecord> BuildProcessAsm(ReadOnlySpan<AsmRoutine> src)
        {
            var kRountines = src.Length;
            if(kRountines == 0)
                return default;

            var total = ApiInstructions.count(src);
            var buffer = span<ProcessAsmRecord>(total);
            var counter = 0u;
            var @base = skip(src,0).BaseAddress;
            for(var i=0u; i<kRountines; i++)
            {
                ref readonly var routine = ref skip(src,i);
                var instructions = routine.Instructions.View;
                var icount = instructions.Length;
                if(icount == 0)
                    continue;

                var data = routine.Code.Data.Index();
                var i0 = first(instructions);
                var blockBase = i0.IP;
                var blockOffset = z16;
                for(var j=0; j<icount; j++)
                {
                    var instruction = skip(instructions,j).Instruction;
                    var opcode = new AsmOpCodeString(instruction.OpCode.ToString());
                    if(!opcode.IsValid)
                        break;

                    var record = new ProcessAsmRecord();
                    var size = (byte)instruction.ByteLength;
                    var ip = (MemoryAddress)instruction.IP;
                    record.Sequence = counter++;
                    record.GlobalOffset = (Address32)(ip - @base);
                    record.BlockAddress = blockBase;
                    record.BlockOffset = blockOffset;
                    record.IP = ip;
                    record.OpUri = routine.Uri;
                    record.Statement = instruction.FormattedInstruction;
                    AsmSigInfo.parse(instruction.OpCode.InstructionString, out record.Sig);
                    record.Encoded = asm.asmhex(slice(data.View, blockOffset, size));
                    record.OpCode = opcode.Format();
                    record.Bitstring = ApiNative.bitstring(record.Encoded);
                    seek(buffer,counter) = record;

                    blockOffset += size;
                }
            }

            var records = slice(buffer,1,counter);
            return SortedSpans.define(records);
        }

        public void EmitProcessAsm(SortedReadOnlySpan<ProcessAsmRecord> src, FilePath dst)
            => TableEmit(src.View, dst, rowpad: ProcessAsmRecord.RowPad);

        public ReadOnlySpan<ProcessAsmRecord> EmitProcessAsm(ReadOnlySpan<AsmRoutine> src, FilePath dst)
        {
            var rows = BuildProcessAsm(src);
            EmitProcessAsm(rows, dst);
            return rows;
        }

        public SortedReadOnlySpan<ProcessAsmRecord> BuildProcessAsm(SortedSpan<ApiCodeBlock> src)
        {
            var count = src.Length;
            if(count == 0)
                return default;

            var dst = list<ProcessAsmRecord>();
            var counter = 0u;
            var @base = src[0].BaseAddress;

            for(var i=0u; i<count; i++)
            {
                ref readonly var code = ref src[i];
                var decoded = Decode(code);
                var instructions = decoded.Instructions;
                var icount = instructions.Length;
                if(icount == 0)
                    continue;

                var bytes = code.Bytes;
                var i0 = first(instructions);
                var blockBase = (MemoryAddress)i0.IP;
                var blockOffset = z16;
                for(var j=0; j<icount; j++)
                {
                    var instruction = skip(instructions,j);
                    var opcode = new AsmOpCodeString(instruction.OpCode.ToString());
                    if(!opcode.IsValid)
                        break;

                    var statement = new ProcessAsmRecord();
                    var size = (ushort)instruction.ByteLength;
                    var specifier = instruction.Specifier;
                    var ip = (MemoryAddress)instruction.IP;
                    statement.Sequence = counter++;
                    statement.GlobalOffset = (Address32)(ip - @base);
                    statement.BlockAddress = blockBase;
                    statement.BlockOffset = blockOffset;
                    statement.IP = ip;
                    statement.OpUri = code.OpUri;
                    statement.Statement = instruction.FormattedInstruction;
                    AsmSigInfo.parse(instruction.OpCode.InstructionString, out statement.Sig);
                    statement.Encoded = asm.asmhex(slice(bytes, blockOffset, size));
                    statement.OpCode = opcode.Format();
                    statement.Bitstring = ApiNative.bitstring(statement.Encoded);
                    dst.Add(statement);

                    blockOffset += size;
                }
            }

            return SortedSpans.define(dst.ViewDeposited());
        }

        AsmInstructionBlock Decode(in ApiCodeBlock src)
        {
            var outcome = Decoder.Decode(src, out var decoded);
            if(outcome)
                return decoded;
            else
            {
                Wf.Error(outcome.Message);
                return AsmInstructionBlock.Empty;
            }
        }
    }
}