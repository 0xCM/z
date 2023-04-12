// //-----------------------------------------------------------------------------
// // Copyright   :  (c) Chris Moore, 2020
// // License     :  MIT
// //-----------------------------------------------------------------------------
// namespace Z0
// {
//     using static sys;

//     public readonly record struct CmdLinePart : IExpr
//     {
//         public readonly @string Content;

//         [MethodImpl(Inline)]
//         public CmdLinePart(string content)
//             => Content = content;

//         public ReadOnlySpan<char> Chars
//         {
//             [MethodImpl(Inline)]
//             get => chars(Content);
//         }

//         public bool IsEmpty
//         {
//             [MethodImpl(Inline)]
//             get => Content.IsEmpty;
//         }

//         public bool IsNonEmpty
//         {
//             [MethodImpl(Inline)]
//             get => Content.IsNonEmpty;
//         }

//         public Hash32 Hash
//         {
//             [MethodImpl(Inline)]
//             get => Content.Hash;
//         }

//         public override int GetHashCode()
//             => Hash;

//         public bool Equals(CmdLinePart src)
//             => Content == src.Content;

//         [MethodImpl(Inline)]
//         public string Format()
//             => Content.Format();

//         public override string ToString()
//             => Format();

//         [MethodImpl(Inline)]
//         public static implicit operator CmdLinePart(string src)
//             => new CmdLinePart(src);

//         [MethodImpl(Inline)]
//         public static implicit operator string(CmdLinePart src)
//             => src.Content;

//         public static CmdLinePart Empty => new CmdLinePart(EmptyString);
//     }
// }