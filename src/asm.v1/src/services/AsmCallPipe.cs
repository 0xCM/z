//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    using static core;

    public sealed class AsmCallPipe : WfSvc<AsmCallPipe>
    {
        public Index<AsmCallRow> EmitRows(ReadOnlySpan<ApiPartRoutines> src, FolderPath dir)
        {
            var dst = sys.bag<AsmCallRow>();
            var count = src.Length;
            for(var i=0; i<count; i++)
                EmitRows(skip(src,i), dst, FilePath.Empty);
            return dst.Index().Sort();
        }

        public Index<AsmCallRow> EmitRows(ReadOnlySpan<AsmRoutine> src, FilePath dst)
        {
            var instructions = list<ApiInstruction>();
            iter(src, routine => instructions.AddRange(routine.Instructions));
            var calls = BuildRows(instructions.ViewDeposited());
            var count = calls.Length;
            TableEmit(calls.View, dst);
            return calls;
        }

        void EmitRows(in ApiPartRoutines src, ConcurrentBag<AsmCallRow> dst, FilePath path)
        {
            var calls = BuildRows(src.Instructions());
            iter(calls, call => dst.Add(call));
            TableEmit(calls, path);
        }

        [MethodImpl(Inline), Op]
        static bool rel32dx(BinaryCode src, out int dx)
        {
            var opcode = src.First;
            if(opcode == 0xe8)
            {
                dx = i32(slice(src.View, 1));
                return true;
            }
            dx = default;
            return false;
        }

        [Op]
        public Index<AsmCallRow> BuildRows(ReadOnlySpan<ApiInstruction> src)
        {
            var calls = ApiInstructions.filter(src, 0xE8);
            var count = calls.Length;
            var buffer = alloc<AsmCallRow>(count);
            ref var row = ref first(span(buffer));
            for(var i=0u; i<count; i++)
            {
                ref readonly var call = ref skip(calls,i);
                ref var dst = ref seek(row,i);
                rel32dx(call.Encoded, out var offset);
                dst.SourcePart = call.Part;
                dst.Block = call.BaseAddress;
                dst.InstructionSize = call.InstructionSize;
                dst.Source = call.IP;
                dst.TargetOffset = (uint)offset;
                dst.Target =  (call.IP + call.InstructionSize) + (uint)offset;
                dst.Instruction = call.Statment;
                dst.Encoded = call.Encoded;
            }
            return buffer.Sort();
        }
    }
}