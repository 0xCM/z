//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial struct CellDelegates
    {
        [Free]
        public delegate bit BinaryOp1(bit a, bit b);

        [Free]
        public delegate Cell8 BinaryOp8(Cell8 a, Cell8 b);

        [Free]
        public delegate Cell32 BinaryOp32(Cell32 a, Cell32 b);

        [Free]
        public delegate Cell16 BinaryOp16(Cell16 a, Cell16 b);

        [Free]
        public delegate Cell64 BinaryOp64(Cell64 a, Cell64 b);

        [Free]
        public delegate Cell128 BinaryOp128(Cell128 a, Cell128 b);

        [Free]
        public delegate Cell256 BinaryOp256(Cell256 a, Cell256 b);

        [Free]
        public delegate Cell512 BinaryOp512(Cell512 a, Cell512 b);

    }
}