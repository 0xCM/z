//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public sealed record class EcmaTableStats
    {
        public readonly AssemblyName Assembly;

        public readonly ReadOnlySeq<EcmaRowStats> Rows;

        public EcmaTableStats(AssemblyName assembly, EcmaRowStats[] rows)
        {
            Assembly = assembly;
            Rows = rows;
        }
    }
}