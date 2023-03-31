// //-----------------------------------------------------------------------------
// // Copyright   :  (c) Chris Moore, 2020
// // License     :  MIT
// //-----------------------------------------------------------------------------
// namespace Z0
// {
//     public class CellAllocator<T>
//         where T : unmanaged
//     {
//         NativeBuffer Buffer;

//         public ByteSize Size {get;}

//         uint Offset;

//         MemoryAddress MaxAddress;

//         public readonly ByteSize CellSize;

//         public readonly uint CellCount;
        
//         internal CellAllocator(uint cellcount)
//         {
//             CellSize = sys.size<T>();
//             CellCount = cellcount;
//             Size = cellcount*CellSize;
//             Buffer = memory.native(Size);
//             MaxAddress = Buffer.Address(Size);
//             Offset = 0;
//         }

//         public ByteSize Consumed
//         {
//             [MethodImpl(Inline)]
//             get => Offset;
//         }

//         public ByteSize Remaining
//         {
//             [MethodImpl(Inline)]
//             get => Size - Offset;
//         }

//         public MemoryAddress BaseAddress
//         {
//             [MethodImpl(Inline)]
//             get => Buffer.BaseAddress;
//         }

//         public bool Alloc(uint count, out SegRef<T> dst)
//         {
//             var size = count*CellSize;
//             var max = Buffer.Address(Offset + size);
//             if(max > MaxAddress)
//             {
//                 dst = default;
//                 return false;
//             }
//             else
//             {
//                 dst = new SegRef<T>(Buffer.Address(Offset),size);
//                 Offset += (size + 1);
//                 return true;
//             }
//         }

//         public void Clear()
//         {
//             Offset = 0;
//         }

//         public void Dispose()
//         {
//             Buffer.Dispose();
//         }
//     }
// }