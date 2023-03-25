//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Ice
{
	[Ignore]
    public enum IceInstructionFieldSize : byte
    {
        NextRip = 8,

        CodeFlags = 4,

        OpKindFlags = 4,

        Imm = 4,

        MemDx = 4,

        MemFlags = 2,

        BaseReg = 1,

        IndexReg = 1,

        Reg0 = 1,

        Reg1 = 1,

        Reg2 = 1,

        Reg3 = 1
    }
}