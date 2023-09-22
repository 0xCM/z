// //-----------------------------------------------------------------------------
// // Copyright   :  (c) Chris Moore, 2020
// // License     :  MIT
// //-----------------------------------------------------------------------------
// namespace Z0.Asm;

// public readonly struct AsmExprOffset : IAsmSourcePart
// {
//     [MethodImpl(Inline), Op]
//     public static AsmExprOffset define(string asm, MemoryAddress offset)
//         => new (asm, offset);

//     public readonly AsmExpr Asm;

//     public readonly MemoryAddress Offset;

//     [MethodImpl(Inline)]
//     public AsmExprOffset(AsmExpr expr, MemoryAddress offset)
//     {
//         Asm = expr;
//         Offset = offset;
//     }

//     public bool IsEmpty
//     {
//         [MethodImpl(Inline)]
//         get => Asm.IsEmpty;
//     }

//     public bool IsNonEmpty
//     {
//         [MethodImpl(Inline)]
//         get => Asm.IsNonEmpty;
//     }

//     public AsmOffsetLabel Label
//     {
//         [MethodImpl(Inline)]
//         get => new AsmOffsetLabel((byte)(bits.effsize(Offset)*8), Offset);
//     }

//     public AsmCellKind PartKind
//     {
//         [MethodImpl(Inline)]
//         get => AsmCellKind.OffsetValue;
//     }

//     public string Format()
//         => string.Format("{0,-6} {1}", Label, Asm);

//     public override string ToString()
//         => Format();

//     [MethodImpl(Inline)]
//     public static implicit operator AsmExprOffset((AsmExpr expr, MemoryAddress offset) src)
//         => new (src.expr, src.offset);

//     [MethodImpl(Inline)]
//     public static implicit operator AsmExprOffset((string expr, MemoryAddress offset) src)
//         => new (src.expr, src.offset);

//     [MethodImpl(Inline)]
//     public static implicit operator AsmExprOffset((AsmExpr expr, Address32 offset) src)
//         => new (src.expr, src.offset);

//     [MethodImpl(Inline)]
//     public static implicit operator AsmExprOffset((string expr, Address32 offset) src)
//         => new (src.expr, src.offset);

//     [MethodImpl(Inline)]
//     public static implicit operator AsmExprOffset((AsmExpr expr, Address16 offset) src)
//         => new (src.expr, src.offset);

//     [MethodImpl(Inline)]
//     public static implicit operator AsmExprOffset((string expr, Address16 offset) src)
//         => new (src.expr, src.offset);
// }
