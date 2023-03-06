//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Lang
{
    public partial class CMake
    {
        public abstract record class DataType
        {
            public readonly string Name;

            public readonly TypeKind Kind;

            protected DataType(string name, TypeKind kind)
            {
                Name = name;
                Kind = kind;
            }

            public string Format()
                => Name;

            public override string ToString()
                => Format();
        }

        public enum SyntaxKind : ushort
        {
            None,

            Set,
        }

        public abstract record class Syntax
        {
            public readonly SyntaxKind Kind;

            protected Syntax(SyntaxKind kind)
            {
                Kind = kind;
            }
        }

        public abstract record class Syntax<S> : Syntax
            where S : Syntax<S>,new()
        {
            protected Syntax(SyntaxKind kind)
                : base(kind)
            {
            }
        }
    }
}