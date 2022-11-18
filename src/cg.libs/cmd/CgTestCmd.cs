//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using llvm;
    using Asm;
    
    public sealed partial class CgTestCmd : WfAppCmd<CgTestCmd>
    {

        AsmWriterChecks AsmWriterChecks => Service(() => AsmWriterChecks.create(Wf));

        [CmdOp("asm/check/heaps")]
        void CheckHeaps()
        {
            void Check1()
            {
                var src = Heaps.symbols<SymNotKind>(w16,w16);
                var count = src.EntryCount;
                var size = src.Size;
                var remainder = src.Size/2;
                for(var i=0u; i<count; i++)
                {
                    ref readonly var entry = ref src.Entry(i);
                    var symbol = src.Symbol(entry);
                    var length  = (uint)Require.equal(entry.Length, symbol.Length);
                    remainder -= length;
                    Write(string.Format("{0,-8} | {1,-8} | {2,-8} | {3,-8} | {4,-64} | '{5}'",
                        i,
                        entry.Offset,
                        entry.Length,
                        remainder,
                        entry.Index,
                        text.format(symbol)
                        ));
                }

            }

            void Check2()
            {
                const string Seg0 = "This";
                const string Seg1 = "is";
                const string Seg2 = "a";
                const string Seg3 = "HeapString";
                const string segments = "This" + "is" + "a" + "HeapString";

                var s0 = (uint)Seg0.Length;
                var s1 = (uint)Seg1.Length;
                var s2 = (uint)Seg2.Length;
                var s3 = (uint)Seg3.Length;

                var offsets = sys.array<uint>(
                    0,
                    s0,
                    s0 + s1,
                    s0 + s1 + s2
                    );

                var heap = Heaps.create(text.span(segments), offsets);
                for(var i=0u; i<offsets.Length; i++)
                {
                    Row(text.format(heap.Segment(i)));
                }
            }

            Check1();
            Check2();
        }

        [CmdOp("asm/check/writers")]
        void CheckWriters()
            => AsmWriterChecks.Run();

        [CmdOp("asm/check/bytes")]
        void CheckAsmBytes()
        {
            var log = text.emitter();
            AsmWriterChecks.CheckAsmBytes(log);
            var data = log.Emit();
            FileEmit(data, AppDb.Logs("codegen.test").Path("asm.checks", FileKind.Csv));
        }
    }
}
