//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class Redirects
    {
       [Record(TableName)]
       public record struct Redirect<K,S,T> : IArrow<S,T>, IDataType<Redirect<K,S,T>>, IExpr
            where S : IDataType<S>, IExpr, new()
            where T : IDataType<T>, IExpr,new()
            where K : unmanaged
        {
            const string TableName = "redirect";

            public readonly K Kind;

            public readonly S Source;

            public readonly T Target;

            public Redirect()
            {
                Kind = default;
                Source = new();
                Target = new();
            }

            public Redirect(K kind, S src, T dst)
            {
                Kind = kind;
                Source = src;
                Target = dst;
            }

            public bool IsEmpty
            {
                [MethodImpl(Inline)]
                get => sys.u64(Kind) == 0 && Source.IsEmpty && Target.IsEmpty;
            }

            public bool IsNonEmpty
            {
                [MethodImpl(Inline)]
                get => !IsEmpty;
            }
            public Hash32 Hash
            {
                [MethodImpl(Inline)]
                get => sys.nhash(Kind) | Source.Hash | Target.Hash;
            }

            S IArrow<S, T>.Source 
                => Source;

            T IArrow<S, T>.Target 
                => Target;

            public string Format()
                => $"${Source.Format()} -> ${Target.Format()}";

            public override string ToString()
                => Format();

            public override int GetHashCode()
                => Hash;

            public int CompareTo(Redirect<K,S,T> src)
            {
                var result = sys.u64(Kind).CompareTo(sys.u64(src.Kind));
                if(result == 0)
                {
                    result = Source.CompareTo(src.Source);
                    if(result == 0)
                        result = Target.CompareTo(src.Target);
                }
                return result;
            }

            public bool Equals(Redirect<K,S,T> src)
                => sys.u64(Kind) == sys.u64(src.Kind) && Source.Equals(src.Source) && Target.Equals(src.Target);

            [MethodImpl(Inline)]
            public static implicit operator Arrow<K,S,T>(Redirect<K,S,T> src)
                => new Arrow<K, S, T>(src.Kind, src.Source, src.Target);

            public static Redirect<K,S,T> Empty = new();
        }
    }
}