//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{    
    public sealed class AsmCaseAssets : Assets<AsmCaseAssets>
    {
        public Asset Switch() => Asset("prototypes.switch.asm");

        public Asset Branches() => Asset("prototypes.branches.asm");

        public Asset Mov() => Asset("prototypes.mov.asm");
    }
}