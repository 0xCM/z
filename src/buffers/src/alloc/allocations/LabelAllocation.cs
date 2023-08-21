// //-----------------------------------------------------------------------------
// // Copyright   :  (c) Chris Moore, 2020
// // License     :  MIT
// //-----------------------------------------------------------------------------
// namespace Z0;

// using static sys;

// /// <summary>
// /// Owns a sequence of <see cref='Label'/> allocations
// /// </summary>
// public sealed class LabelAllocation : Allocation<Label>
// {
//     readonly Index<Label> Storage;

//     readonly IBufferAllocator Allocator;

//     public LabelAllocation(IBufferAllocator allocator, Label[] labels)
//     {
//         Storage = labels;
//         Allocator = allocator;
//     }

//     public override ByteSize Size
//     {
//         [MethodImpl(Inline)]
//         get => Allocator.Size;
//     }

//     public override MemoryAddress BaseAddress
//     {
//         [MethodImpl(Inline)]
//         get => Allocator.BaseAddress;
//     }

//     protected override Span<Label> Data
//     {
//         [MethodImpl(Inline)]
//         get => Storage;
//     }

//     protected override void Dispose()
//     {
//         Allocator.Dispose();
//     }
// }
