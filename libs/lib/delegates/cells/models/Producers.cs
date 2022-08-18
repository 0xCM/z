//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial struct CellDelegates
    {
        [Free]
        public delegate bit Producer1();

        [Free]
        public delegate Cell8 Producer8();

        [Free]
        public delegate Cell16 Producer16();

        [Free]
        public delegate Cell32 Producer32();

        [Free]
        public delegate Cell64 Producer64();

        [Free]
        public delegate Cell128 Producer128();

        [Free]
        public delegate Cell256 Producer256();

        [Free]
        public delegate Cell512 Producer512();
    }
}