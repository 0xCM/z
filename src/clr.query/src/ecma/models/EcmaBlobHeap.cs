// //-----------------------------------------------------------------------------
// // Copyright   :  (c) Chris Moore, 2020
// // License     :  MIT
// //-----------------------------------------------------------------------------
// namespace Z0
// {
//     using static sys;

//     [StructLayout(StructLayout, Pack=1)]
//     public readonly struct EcmaBlobHeap : IEcmaHeap<EcmaBlobHeap>
//     {
//         public readonly MemoryAddress BaseAddress;

//         public readonly ByteSize Size;

//         [MethodImpl(Inline)]
//         public EcmaBlobHeap(MemoryAddress @base, ByteSize size)
//         {
//             BaseAddress = @base;
//             Size = size;
//         }

//         public EcmaHeapKind HeapKind
//         {
//             [MethodImpl(Inline)]
//             get => EcmaHeapKind.Blob;
//         }

//         public unsafe ReadOnlySpan<byte> Data
//         {
//             [MethodImpl(Inline)]
//             get => cover<byte>(BaseAddress, Size);
//         }

//         MemoryAddress IEcmaHeap.BaseAddress
//             => BaseAddress;

//         ByteSize IEcmaHeap.Size
//             => Size;

//         public string Format()
//             => string.Format(MemoryRange.define(BaseAddress, Size).Format());

//         public override string ToString()
//             => Format();
//     }
// }