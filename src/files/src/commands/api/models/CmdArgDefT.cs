// //-----------------------------------------------------------------------------
// // Copyright   :  (c) Chris Moore, 2020
// // License     :  MIT
// //-----------------------------------------------------------------------------
// namespace Z0
// {
//     /// <summary>
//     /// Defines a tool flag argument
//     /// </summary>
//     public readonly record struct CmdArgDef<T>
//     {
//         /// <summary>
//         /// The argument's relative position
//         /// </summary>
//         public readonly ushort Position;

//         /// <summary>
//         /// The flag name
//         /// </summary>
//         public readonly string Name;

//         /// <summary>
//         /// The argument value
//         /// </summary>
//         public readonly T Value;

//         public readonly ArgProtocol Protocol;

//         public readonly ArgPartKind Classifier;

//         [MethodImpl(Inline)]
//         public CmdArgDef(ushort pos, string name, T value, ArgPrefix? prefix = null)
//         {
//             Position = pos;
//             Name = name;
//             Value = value;
//             Protocol = prefix ?? ArgPrefix.DoubleDash;
//             Classifier = ArgPartKind.Name | ArgPartKind.Position;
//         }

//         [MethodImpl(Inline)]
//         public CmdArgDef(string name, T value, ArgPrefix? prefix = null)
//         {
//             Position = 0;
//             Name = name;
//             Value = value;
//             Protocol = prefix ?? ArgPrefix.DoubleDash;
//             Classifier = ArgPartKind.Name;
//         }

//         [MethodImpl(Inline)]
//         public CmdArgDef(T value, ArgPrefix? prefix = null)
//         {
//             Position = 0;
//             Name = value.ToString();
//             Value = value;
//             Protocol = prefix ?? ArgPrefix.DoubleDash;
//             Classifier = ArgPartKind.Name;
//         }

//         public bool IsFlag => true;

//         public ArgPrefix Prefix => Protocol.Prefix;

//         public ArgQualifier Qualifier => Protocol.Qualifier;

//         [MethodImpl(Inline)]
//         public static implicit operator CmdArgDef(CmdArgDef<T> src)
//             => new CmdArgDef(src.Position, src.Name, src.Prefix);
//     }
// }