//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class XedRules
    {
        [StructLayout(LayoutKind.Sequential,Pack=1)]
        public readonly struct InstLayout
        {
            public readonly ushort PatternId;

            public readonly XedInstClass Instruction;

            public readonly AsmOpCode OpCode;

            public readonly byte Count;

            public readonly SegRef<LayoutCell> Block;

            public InstLayout(ushort pid, XedInstClass inst, AsmOpCode oc, byte count, SegRef<LayoutCell> block)
            {
                PatternId = pid;
                Instruction = inst;
                OpCode = oc;
                Count = count;
                Block = block;
            }

            public MemoryAddress BaseAddress
            {
                [MethodImpl(Inline)]
                get => Block.BaseAddress;
            }

            public Span<LayoutCell> Cells
            {
                [MethodImpl(Inline)]
                get => Block.Data;
            }

            public ref LayoutCell this[int i]
            {
                [MethodImpl(Inline)]
                get => ref Block[i];
            }

            public ref LayoutCell this[uint i]
            {
                [MethodImpl(Inline)]
                get => ref Block[(int)i];
            }

            public string Format()
            {
                var dst = text.emitter();
                var slot = RP.slot(0,-LayoutCell.RenderWidth);
                for(var i=0; i<Count; i++)
                {
                    if(i != 0)
                        dst.Append(" | ");
                    dst.AppendFormat(slot, this[i]);
                }
                return dst.Emit();
            }


            public override string ToString()
                => Format();

            public static InstLayout Empty => default;
        }
    }
}