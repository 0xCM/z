//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public readonly partial struct CalcHosts
    {
        const NumericKind Closure = Integers;
    }

    public readonly struct ResultCodes
    {
        public static ResultCode Ok => default;

        public static ResultCode BufferTooSmall => new ResultCode(0x01);
    }
}