//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static Algs;

    partial class Build
    {
        public readonly record struct Property<T> : IProjectProperty<Property<T>,T>
            where T : IProjectProperty
        {
            readonly T Definition;

            [MethodImpl(Inline)]
            public Property(T value)
                => Definition = value;

            public string Name
            {
                [MethodImpl(Inline)]
                get => Definition.Name;
            }

            public T Value
            {
                [MethodImpl(Inline)]
                get => Definition.Value;
            }

            public Hash32 Hash
            {
                [MethodImpl(Inline)]
                get => hash(Name) | hash(Value);
            }

            public string Format()
                => $"{Name}={Value}";

            public override string ToString()
                => Format();

            [MethodImpl(Inline)]
            public static implicit operator Property<T>(T src)
                => new Property<T>(src);

            [MethodImpl(Inline)]
            public static implicit operator T(Property<T> src)
                => src.Definition;
        }
    }
}