// //-----------------------------------------------------------------------------
// // Copyright   :  (c) Chris Moore, 2020
// // License     :  MIT
// //-----------------------------------------------------------------------------
// namespace Z0;

// using static sys;

// /// <summary>
// /// Owns <typeparamref name='N'/> page allocations
// /// </summary>
// /// <typeparam name="N">The page allocation count</typeparam>
// public class PageAllocation<N> : IBufferAllocation
//     where N : unmanaged, ITypeNat
// {
//     public static PageAllocation<N> alloc()
//         => new ();

//     public const uint PageSize = Pow2.T12;

//     readonly NativeBuffer Buffer;

//     public PageAllocation()
//     {
//         Buffer = NativeBuffers.alloc(PageSize*Typed.nat32u<N>());
//     }

//     public void Dispose()
//     {
//         Buffer.Dispose();
//     }

//     public uint PageCount
//     {
//         [MethodImpl(Inline)]
//         get => Typed.nat32u<N>();
//     }

//     public MemoryAddress BaseAddress
//     {
//         [MethodImpl(Inline)]
//         get => Buffer.BaseAddress;
//     }

//     public ByteSize Size
//     {
//         [MethodImpl(Inline)]
//         get => Buffer.Size;
//     }

//     public BitWidth Width
//     {
//         [MethodImpl(Inline)]
//         get => Buffer.Width;
//     }

//     public ReadOnlySpan<MemorySegment> Allocated
//     {
//         [MethodImpl(Inline)]
//         get => cover<MemorySegment>(BaseAddress, PageCount);
//     }

//     [MethodImpl(Inline)]
//     public Span<byte> PageBuffer(uint index)
//         => slice(Buffer.Edit, index*PageSize, PageSize);

//     [MethodImpl(Inline)]
//     public MemoryAddress PageAddress(uint index)
//         => address(first(PageBuffer(index)));
// }
