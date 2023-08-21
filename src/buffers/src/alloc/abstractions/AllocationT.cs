// //-----------------------------------------------------------------------------
// // Copyright   :  (c) Chris Moore, 2020
// // License     :  MIT
// //-----------------------------------------------------------------------------
// namespace Z0;

// /// <summary>
// /// Abstraction for a container that owns a sequence of <typeparamref name='T'/> allocations
// /// </summary>
// /// <typeparam name="T">The allocated content</typeparam>
// public abstract class Allocation<T> : IDisposable
//     where T : unmanaged
// {
//     protected Allocation()
//     {

//     }

//     protected abstract void Dispose();

//     public abstract MemoryAddress BaseAddress {get;}

//     protected abstract Span<T> Data {get;}

//     public ReadOnlySpan<T> Cells
//     {
//         [MethodImpl(Inline)]
//         get => Data;
//     }

//     public uint Count
//     {
//         [MethodImpl(Inline)]
//         get => (uint)Data.Length;
//     }

//     public ref readonly T this[uint i]
//     {
//         [MethodImpl(Inline)]
//         get => ref sys.skip(Data,i);
//     }

//     public ref readonly T this[int i]
//     {
//         [MethodImpl(Inline)]
//         get => ref sys.skip(Data,i);
//     }

//     public virtual ByteSize Size 
//     {
//         [MethodImpl(Inline)]
//         get => Data.Length*sys.size<T>();
//     }


//     void IDisposable.Dispose()
//     {
//         Dispose();
//     }
// }
