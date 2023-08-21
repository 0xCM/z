// //-----------------------------------------------------------------------------
// // Copyright   :  (c) Chris Moore, 2020
// // License     :  MIT
// //-----------------------------------------------------------------------------
// namespace Z0;

// using static sys;

// /// <summary>
// /// Owns a sequence of <see cref='SourceText'/> allocations
// /// </summary>
// public sealed class SourceAllocation : Allocation<SourceText>
// {
//     readonly Index<SourceText> Storage;

//     readonly IBufferAllocator Allocator;

//     public SourceAllocation(IBufferAllocator allocator, SourceText[] allocated)
//     {
//         Storage = allocated;
//         Allocator = allocator;
//     }

//     public override MemoryAddress BaseAddress
//     {
//         [MethodImpl(Inline)]
//         get => Allocator.BaseAddress;
//     }

//     protected override Span<SourceText> Data
//     {
//         [MethodImpl(Inline)]
//         get => Storage;
//     }

//     protected override void Dispose()
//     {
//         Allocator.Dispose();
//     }
// }
