//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm;

[ApiHost]
public partial class AsmSigs
{
    static readonly AsmSigDatasets _Datasets;

    const NumericKind Closure = UnsignedInts;

    static AsmSigs()
    {
        _Datasets = AsmSigDatasets.Instance;
    }
}
