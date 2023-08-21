// //-----------------------------------------------------------------------------
// // Copyright   :  (c) Chris Moore, 2020
// // License     :  MIT
// //-----------------------------------------------------------------------------
// namespace Z0;

// using static sys;

// /// <summary>
// /// Owns a sequence of <see cref='StringRef'/> allocations
// /// </summary>
// public sealed class StringAllocation : Allocation<StringRef>
// {
//     readonly Index<StringRef> Storage;

//     readonly IBufferAllocator Allocator;

//     public StringAllocation(IBufferAllocator allocator, StringRef[] allocated)
//     {
//         Allocator = allocator;
//         Storage = allocated;
//     }

//     public override MemoryAddress BaseAddress
//     {
//         [MethodImpl(Inline)]
//         get => Allocator.BaseAddress;
//     }

//     protected override Span<StringRef> Data
//     {
//         [MethodImpl(Inline)]
//         get => Storage;
//     }

//     public override ByteSize Size
//     {
//         [MethodImpl(Inline)]
//         get => Allocator.Size;
//     }

//     protected override void Dispose()
//     {
//         Allocator.Dispose();
//     }
// }
