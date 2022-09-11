// //-----------------------------------------------------------------------------
// // Copyright   :  (c) Chris Moore, 2020
// // License     :  MIT
// //-----------------------------------------------------------------------------
// namespace Z0
// {
//     [Free]
//     public interface IFixedWidth<F> : ICellWidth, INativeSize<F>
//         where F : struct, IFixedWidth<F>
//     {
//         CpuCellWidth ICellWidth.CellWidth
//             => Widths.cell<F>();
//     }
// }