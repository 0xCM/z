//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial struct CellDelegates
    {
        [Free]
        public delegate bit UnaryOp1(bit a);

        [Free]
        public delegate Cell8 UnaryOp8(Cell8 a);

        [Free]
        public delegate Cell16 UnaryOp16(Cell16 a);

        [Free]
        public delegate Cell32 UnaryOp32(Cell32 a);

        [Free]
        public delegate Cell64 UnaryOp64(Cell64 a);

        [Free]
        public delegate Cell128 UnaryOp128(Cell128 a);

        [Free]
        public delegate Cell256 UnaryOp256(Cell256 a);

        [Free]
        public delegate Cell512 UnaryOp512(Cell512 a);
    }
}