// //-----------------------------------------------------------------------------
// // Copyright   :  (c) Chris Moore, 2020
// // License     :  MIT
// //-----------------------------------------------------------------------------
// namespace Z0
// {
//     public readonly record struct EcmaString : IDataType<EcmaString>
//     {
//         public readonly EcmaToken Token;

//         public readonly string Value;

//         public readonly Hash32 Hash;

//         [MethodImpl(Inline)]
//         public EcmaString(EcmaToken token, string value)
//         {
//             Token = token;
//             Value = value;
//             Hash = token.Hash | sys.hash(value);
//         }

//         public bool IsEmpty
//         {
//             [MethodImpl(Inline)]
//             get => Token.IsEmpty && sys.empty(Value);
//         }

//         public bool IsNonEmpty
//         {
//             [MethodImpl(Inline)]
//             get => !IsEmpty;
//         }

//         Hash32 IHashed.Hash
//             => Hash;

//         public bool Equals(EcmaString src)
//             => Token == src.Token && Value == src.Value;

//         public int CompareTo(EcmaString src)
//         {
//             var result = Token.CompareTo(src.Token);
//             if(result == 0)
//                 result = SQ.cmp(Value, src.Value);
//             return result;
//         }

//         public override int GetHashCode()
//             => Hash;

//         public string Format()
//             => $"{Token}:{Value}";

//         public override string ToString()
//             => Format();
//     }
// }