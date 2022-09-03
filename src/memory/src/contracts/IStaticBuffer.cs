//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    /// <summary>
    /// Characterizes a buffer with an invariant address
    /// </summary>
    /// <typeparam name="T">The buffer cell type</typeparam>
    public interface IStaticBuffer<T>
    {
        /// <summary>
        /// The buffer's address which should remain unchanged throughout its lifetime
        /// </summary>
        MemoryAddress Address {get;}

        /// <summary>
        /// The number of cells held in the buffer
        /// </summary>
        uint CellCount {get;}

        ref T this[uint index] {get;}

        ref T this[int index] {get;}

        void Enumerate(uint i0, uint i1, Action<T> receiver);

        void Enumerate(Action<T> receiver);
    }
}