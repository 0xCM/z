// //-----------------------------------------------------------------------------
// // Copyright   :  (c) Chris Moore, 2020
// // License     :  MIT
// //-----------------------------------------------------------------------------
// namespace Z0
// {
//     /// <summary>
//     /// Correlates a sequence of native buffers with a 0-based/monotonic integral sequence
//     /// </summary>
//     [StructLayout(StructLayout,Pack=1)]
//     public readonly struct AddressSpace
//     {
//         [MethodImpl(Inline)]
//         public static AddressSpace define(uint index, MemoryRange range)
//             => new AddressSpace(index,range);

//         [MethodImpl(Inline)]
//         public static AddressSpace define(uint index, MemoryAddress @base, ByteSize size)
//             => new AddressSpace(index, @base, size);

//         [MethodImpl(Inline)]
//         public static AddressSpace define(uint index, MemoryAddress min, MemoryAddress max)
//             => new AddressSpace(index, min, max);

//         public readonly uint Index;

//         readonly MemoryRange Range;

//         [MethodImpl(Inline)]
//         public AddressSpace(uint index, MemoryRange range)
//         {
//             Index = index;
//             Range = range;
//         }

//         [MethodImpl(Inline)]
//         public AddressSpace(uint index, MemoryAddress min, MemoryAddress max)
//         {
//             Index = index;
//             Range = MemoryRange.define(min,max);
//         }

//         [MethodImpl(Inline)]
//         public AddressSpace(uint index, MemoryAddress @base, ByteSize size)
//         {
//             Index = index;
//             Range = MemoryRange.define(@base,size);
//         }

//         [MethodImpl(Inline)]
//         public MemoryAddress Address(uint disp)
//             => BaseAddress + disp;

//         public MemoryAddress BaseAddress
//         {
//             [MethodImpl(Inline)]
//             get => Range.Min;
//         }

//         public ByteSize Size
//         {
//             [MethodImpl(Inline)]
//             get => Range.ByteCount;
//         }

//         public MemoryAddress LastAddress
//         {
//             [MethodImpl(Inline)]
//             get => Range.Min;
//         }
//     }
// }