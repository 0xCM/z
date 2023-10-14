//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

using static XedZ;
using static XedRules;

public class XedDisasmContext
{
    public readonly IDbArchive ProjectRoot;

    public readonly ConcurrentBag<XedDisasmDetailBlock> Blocks;

    public readonly InstBlockPatterns InstPatterns;
    
    public readonly MachineMode Mode;

    public XedDisasmContext(IDbArchive root)
    {
        ProjectRoot = root;
        Mode = MachineMode.Default;
        Blocks = new();
        InstPatterns = XedTables.BlockPatterns();
    }
}
