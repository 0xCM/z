//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;


public class XedDisasmContext
{
    public readonly IDbArchive ProjectRoot;

    public readonly ConcurrentBag<XedDisasmDetailBlock> Blocks;

    public XedDisasmContext(IDbArchive root)
    {
        ProjectRoot = root;
        Blocks = new();        
    }
}
