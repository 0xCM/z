//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------

namespace Z0
{
    partial class TS
    {
        public readonly struct TypeKind : ITypeKind
        {
            readonly string Name;

            [MethodImpl(Inline)]
            public TypeKind(string name)
            {
                Name = name;
            }

            string ITypeKind.Name 
                => Name;

            [MethodImpl(Inline)]
            public static implicit operator TypeKind(string src)
                => new TypeKind(src);

            [MethodImpl(Inline)]
            public static TypeKind operator+(TypeKind a, TypeKind b)
                =>  new TypeKind($"{a}/{b}");

            [MethodImpl(Inline)]
            public static TypeKind operator|(TypeKind a, TypeKind b)
                =>  new TypeKind($"{a} | {b}");

            [MethodImpl(Inline)]
            public static TypeKind operator^(TypeKind a, TypeKind b)
                =>  new TypeKind($"{a} ^ {b}");

            [MethodImpl(Inline)]
            public static TypeKind operator<(TypeKind a, TypeKind b)
                =>  new TypeKind($"{a} < {b}");

            [MethodImpl(Inline)]
            public static TypeKind operator>(TypeKind a, TypeKind b)
                =>  new TypeKind($"{a} > {b}");

        }
    }
}