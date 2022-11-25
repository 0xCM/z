//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class XedRules
    {
        public class InstLayouts : IDisposable
        {
            readonly NativeCells<InstLayoutBlock> Blocks;

            readonly Index<InstLayout> Layouts;

            public readonly Index<InstLayoutRecord> Records;

            public InstLayouts(InstLayout[] src, NativeCells<InstLayoutBlock> blocks)
            {
                Layouts = src;
                Blocks = blocks;
                Records = sys.alloc<InstLayoutRecord>(src.Length);;
            }


            public uint BlockCount
            {
                [MethodImpl(Inline)]
                get => Blocks.CellCount;
            }

            [MethodImpl(Inline)]
            public ref InstLayoutRecord Record(uint i)
                => ref Records[i];

            [MethodImpl(Inline)]
            public ref InstLayoutRecord Record(int i)
                => ref Records[i];

            [MethodImpl(Inline)]
            public ref readonly InstLayoutBlock Block(int i)
            {
                ref readonly var block = ref Blocks[i];
                return ref block.Content;
            }

            [MethodImpl(Inline)]
            public ref readonly InstLayoutBlock Block(uint i)
            {
                ref readonly var block = ref Blocks[i];
                return ref block.Content;
            }

            public uint LayoutCount
            {
                [MethodImpl(Inline)]
                get => Layouts.Count;
            }

            public ref InstLayout this[uint i]
            {
                [MethodImpl(Inline)]
                get => ref Layouts[i];
            }

            public ref InstLayout this[int i]
            {
                [MethodImpl(Inline)]
                get => ref Layouts[i];
            }

            public bool IsEmpty
            {
                [MethodImpl(Inline)]
                get => Layouts.IsEmpty;
            }

            public bool IsNonEmpty
            {
                [MethodImpl(Inline)]
                get => Layouts.IsNonEmpty;
            }

            public ReadOnlySpan<InstLayout> View
            {
                [MethodImpl(Inline)]
                get => Layouts;
            }

            public void Render(ITextEmitter dst)
            {
                const string RenderPattern = "{0,-10} | {1,-18} | {2,-22} | {3,-6} | {4}";
                dst.AppendLineFormat(RenderPattern,"PatternId", "Instruction", "OpCode", "Length", "Vector");
                for(var i=0; i<LayoutCount; i++)
                {
                    ref readonly var src = ref this[i];
                    dst.AppendLineFormat(RenderPattern, src.PatternId, src.Instruction, src.OpCode, src.Count, src.Format());
                }
            }

            public string Format()
            {
                var dst = text.emitter();
                Render(dst);
                return dst.Emit();
            }

            public override string ToString()
                => Format();

            public void Dispose()
            {
                Blocks.Dispose();
            }
        }
    }
}