//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class CellDelegates
    {
        [Free]
        public delegate bit BinaryPredicate1(bit a, bit b);

        [Free]
        public delegate bit BinaryPredicate<T>(T a, T b);

        [Free]
        public delegate bit UnaryPredicate1(bit a);

        [Free]
        public delegate bit UnaryPredicate8(Cell8 a);

        [Free]
        public delegate bit UnaryPredicate16(Cell16 a);

        [Free]
        public delegate bit UnaryPredicate32(Cell32 a);

        [Free]
        public delegate bit UnaryPredicate64(Cell64 a);

        [Free]
        public delegate bit UnaryPredicate128(Cell128 a);

        [Free]
        public delegate bit UnaryPredicate256(Cell256 a);

        [Free]
        public delegate bit UnaryPredicate512(Cell512 a);

        [Free]
        public delegate bit BinaryPredicate8(Cell8 a, Cell8 b);

        [Free]
        public delegate bit BinaryPredicate16(Cell16 a, Cell16 b);

        [Free]
        public delegate bit BinaryPredicate32(Cell32 a, Cell32 b);

        [Free]
        public delegate bit BinaryPredicate64(Cell64 a, Cell64 b);

        [Free]
        public delegate Bit32 BinaryPredicate128(Cell128 a, Cell128 b);

        [Free]
        public delegate Bit32 BinaryPredicate256(Cell256 a, Cell256 b);

        [Free]
        public delegate Bit32 BinaryPredicate512(Cell512 a, Cell512 b);

    }
}