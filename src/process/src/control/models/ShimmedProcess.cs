//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public record class ShimmedProcess
    {
        public readonly uint Seq;

        public readonly ShimDef Spec;

        public readonly ProcessAdapter Process;

        public ShimmedProcess(uint seq, ShimDef def, ProcessAdapter process)
        {
            Seq = seq;
            Spec = def;
            Process = process;
        }


        public ulong Id
        {
            [MethodImpl(Inline)]
            get => Seq | ((ulong)Process.Id << 32);
        }
    }
}