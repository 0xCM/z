// //-----------------------------------------------------------------------------
// // Copyright   :  (c) Chris Moore, 2020
// // License     :  MIT
// //-----------------------------------------------------------------------------
// namespace Z0;

// public struct BitPackOp
// {
//     [MethodImpl(Inline)]
//     public static BitPackOp pack(ushort c0, CellSpec i, ushort c1, CellSpec o)
//     {
//         var dst = new BitPackOp();
//         dst.Kind = OpKind.Pack;
//         return metrics(c0,i,c1,o, ref dst);
//     }

//     [MethodImpl(Inline)]
//     public static BitPackOp unpack(ushort c0, CellSpec i, ushort c1, CellSpec o)
//     {
//         var dst = new BitPackOp();
//         dst.Kind = OpKind.Unpack;
//         return metrics(c0,i,c1,o, ref dst);
//     }

//     [MethodImpl(Inline)]
//     public static ref BitPackOp metrics(ushort c0, CellSpec i, ushort c1, CellSpec o, ref BitPackOp dst)
//     {
//         dst.InputCount = c0;
//         dst.InputSpec = i;
//         dst.OutputCount = c1;
//         dst.OutputSpec = o;
//         return ref dst;
//     }

//     public enum OpKind
//     {
//         None,

//         Pack,

//         Unpack
//     }

//     public OpKind Kind;

//     public ushort InputCount;

//     public CellSpec InputSpec;

//     public ushort OutputCount;

//     public CellSpec OutputSpec;

//     public string Format()
//         => string.Format("{0}:({1},{2}) -> ({3}, {4})", Kind, InputCount, InputSpec, OutputCount, OutputSpec);

//     public override string ToString()
//         => Format();
// }
