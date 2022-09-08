// //-----------------------------------------------------------------------------
// // Copyright   :  (c) Chris Moore, 2020
// // License     :  MIT
// //-----------------------------------------------------------------------------
// namespace Z0
// {
//     /// <summary>
//     /// Defines a link between an identified resource and an emission target
//     /// </summary>
//     public readonly struct ResEmission : IFlow<Asset,FilePath>
//     {
//         public readonly Asset Source;

//         public readonly FilePath Target;

//         [MethodImpl(Inline)]
//         public ResEmission(Asset src, FilePath dst)
//         {
//             Source = src;
//             Target = dst;
//         }

//         public bool IsEmpty => Source.IsEmpty || Target.IsEmpty;

//         Asset IArrow<Asset, FilePath>.Source
//             => Source;

//         FilePath IArrow<Asset, FilePath>.Target
//             => Target;

//         public string Format()
//             => string.Format("{0} -> {1}", Source, Target.ToUri());

//         public override string ToString()
//             => Format();

//         [MethodImpl(Inline)]
//         public static implicit operator ResEmission(Arrow<Asset,FilePath> link)
//             => new ResEmission(link.Source, link.Target);

//         [MethodImpl(Inline)]
//         public static implicit operator Arrow<Asset,FilePath>(ResEmission src)
//             => new ResEmission(src.Source, src.Target);
//     }
// }