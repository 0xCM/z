// //-----------------------------------------------------------------------------
// // Copyright   :  (c) Chris Moore, 2020
// // License     :  MIT
// //-----------------------------------------------------------------------------
// namespace Z0
// {
//     [StructLayout(LayoutKind.Sequential,Pack=1)]
//     public record struct DbColSpec : IEntity<DbColSpec,uint>
//     {
//         public readonly uint Pos;

//         public readonly DbDataType Type;

//         public readonly Name Name;

//         [MethodImpl(Inline)]
//         public DbColSpec(uint pos, DbDataType type, Name name)
//         {
//             Pos = pos;
//             Type = type;
//             Name = name;
//         }

//         uint IKeyed<uint>.Key
//             => Pos;

//         [MethodImpl(Inline)]
//         public int CompareTo(DbColSpec src)
//             => Pos.CompareTo(src.Pos);
//     }   
// }