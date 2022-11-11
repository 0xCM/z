//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    partial class Symbolic
    {

        [Op, Closures(UInt64k)]
        public static SymStore<T> store<T>(ushort capacity)
            => new SymStore<T>((uint)inc(ref SegCount), sys.alloc<T>(capacity));

        [Op, Closures(UInt64k)]
        public static SymStore<T> store<T>(uint capacity)
            => new SymStore<T>((uint)inc(ref SegCount), sys.alloc<T>(capacity));
    }
}