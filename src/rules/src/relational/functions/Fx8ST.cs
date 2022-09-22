//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    partial struct PointFunctions
    {
        /// <summary>
        /// Defines a total function over an 8-bit domain
        /// </summary>
        public unsafe struct Fx8<S,T> : IFunction<Fx8<S,T>,S,T>
            where S : unmanaged
            where T : unmanaged
        {
            readonly Ptr<S> PSrc;

            readonly Ptr<T> PDst;

            internal readonly Index<byte> SrcMap;

            internal uint Size;

            internal const uint Capacity = 256;

            [MethodImpl(Inline)]
            internal Fx8(MemoryAddress src, MemoryAddress dst)
            {
                Size = 0;
                PSrc = src.Pointer<S>();
                PDst = dst.Pointer<T>();
                SrcMap = alloc<byte>(Capacity);
            }

            [MethodImpl(Inline)]
            ref readonly byte iY(byte x)
                => ref SrcMap[x];

            [MethodImpl(Inline)]
            public T Eval(S x)
                => skip(cover(PDst.P, Size), iY(u8(x)));

            [MethodImpl(Inline)]
            public KeyedValue<S,T> Map(S x)
                => (x, Eval(x));
        }
    }
}