//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public enum LogicExprKind : byte
    {
        False = (byte)BinaryBitLogicKind.False,

        And = (byte)BinaryBitLogicKind.And,

        CNonImpl = (byte)(BinaryBitLogicKind.CNonImpl),

        Or = (byte)BinaryBitLogicKind.Or,

        XOr = (byte)BinaryBitLogicKind.Xor,

        Nor = (byte)BinaryBitLogicKind.Nor,

        Impl = (byte)BinaryBitLogicKind.Impl,

        Not = (byte)BinaryBitLogicKind.LNot,

        CImpl = (byte)(BinaryBitLogicKind.CImpl),

        True = (byte)BinaryBitLogicKind.True,
    }
}