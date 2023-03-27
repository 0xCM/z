//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class JsonDeps
    {
        public record struct DependencyKey : IComparable<DependencyKey>
        {
            public readonly ComponentKey Source;

            public readonly ComponentKey Target;

            public DependencyKey(ComponentKey src, ComponentKey dst)
            {
                Source = src;
                Target = dst;
            }

            public Hash32 Hash
            {
                [MethodImpl(Inline)]
                get => Source.Hash | Target.Hash;
            }

            public override int GetHashCode()
                => Hash;

            public bool Equals(DependencyKey src)
                => Source == src.Source && Target == src.Target;

            public string Format()
                => $"{Source} -> {Target}";

            public override string ToString()
                => Format();

            public int CompareTo(DependencyKey src)
            {
                var result = Source.CompareTo(src.Source);
                if(result == 0)
                    result = Target.CompareTo(src.Target);
                return result;
            }
        }
    }
}