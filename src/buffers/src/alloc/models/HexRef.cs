// //-----------------------------------------------------------------------------
// // Copyright   :  (c) Chris Moore, 2020
// // License     :  MIT
// //-----------------------------------------------------------------------------
// namespace Z0;

// using static sys;

// public readonly record struct HexRef
// {
//     readonly MemorySegment Seg;

//     [MethodImpl(Inline)]
//     public HexRef(MemorySegment seg)
//     {
//         Seg = seg;
//         Require.invariant(seg.IsNonEmpty);
//     }

//     public MemoryAddress BaseAddress
//     {
//         [MethodImpl(Inline)]
//         get => Seg.BaseAddress;
//     }

//     public ReadOnlySpan<byte> View
//     {
//         [MethodImpl(Inline)]
//         get => Seg.View;
//     }

//     public Span<byte> Edit
//     {
//         [MethodImpl(Inline)]
//         get => Seg.Edit;
//     }

//     public Hash32 Hash
//     {
//         [MethodImpl(Inline)]
//         get => sys.hash(View);
//     }

//     public byte Size
//     {
//         [MethodImpl(Inline)]
//         get => (byte)Seg.Size;
//     }

//     public string Format()
//         => View.FormatHex();

//     public override string ToString()
//         => Format();

//     [MethodImpl(Inline)]
//     public bool Equals(HexRef src)
//     {
//         var size = src.Size;
//         if(size != Size)
//             return false;
//         var lhs = View;
//         var rhs = src.View;
//         var result = true;
//         for(var i=0; i<size; i++)
//             result &= skip(lhs,i) == skip(rhs,i);
//         return result;
//     }

//     public override int GetHashCode()
//         => Hash;

//     [MethodImpl(Inline)]
//     public static implicit operator HexRef(MemorySegment src)
//         => new HexRef(src);
// }
