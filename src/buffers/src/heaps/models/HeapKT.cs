// //-----------------------------------------------------------------------------
// // Copyright   :  (c) Chris Moore, 2020
// // License     :  MIT
// //-----------------------------------------------------------------------------
// namespace Z0
// {
//     using api = Heaps;

//     internal class Heap<K,T>
//         where K : unmanaged
//     {
//         readonly Index<T> Data;

//         readonly Index<K,uint> Offsets;

//         internal readonly uint LastSegment;

//         public readonly uint CellCount;

//         [MethodImpl(Inline)]
//         public Heap(Index<T> src, Index<K,uint> offsets)
//         {
//             Data = src;
//             Offsets = offsets;
//             CellCount = (uint)Require.equal(src.Length, offsets.Length);
//             LastSegment = (uint)offsets.Length - 1;
//         }

//         public Span<T> Cells
//         {
//             [MethodImpl(Inline)]
//             get => Data.Edit;
//         }

//         [MethodImpl(Inline)]
//         public ref uint Offset(K index)
//             => ref Offsets[index];

//         [MethodImpl(Inline)]
//         public Span<T> Segment(K index)
//             => api.segment(this, index);

//         public Span<T> this[K index]
//         {
//             [MethodImpl(Inline)]
//             get => Segment(index);
//         }
//     }
// }