//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [Free]
    public unsafe class MemorySeqChecks : Checker<MemorySeqChecks>
    {
        ITextEmitter Output;

        protected override void Execute(IWfEventTarget log)
        {
            Output  = text.emitter();
            Run(Output);
            log.Deposit(Events.row(Output.Emit()));
        }

        public void Run(ITextEmitter dst)
        {
            var count = Pow2.T12;
            using var buffer0 = memory.native<uint>(count);
            using var buffer1 = memory.native<uint>(count);
            using var buffer2 = memory.native<uint>(count);
            Random.Fill(buffer0.Edit);
            Random.Fill(buffer1.Edit);
            var r0 = MemorySeq.reader(buffer0);
            var r1 = MemorySeq.reader(buffer1);
            var reader = MemorySeq.reader(r0,r1);
            var editor = MemorySeq.editor(buffer2);

            while(reader.Next(out var c0, out var c1))
                editor.Next(out var _) = math.xor(c0, c1);

            var result = MemorySeq.reader(buffer2);
            var counter = 0u;
            while(result.Next(out var r))
                dst.AppendLineFormat("{0:D5} {1:x}", counter++, r.FormatHex());
        }
    }
}