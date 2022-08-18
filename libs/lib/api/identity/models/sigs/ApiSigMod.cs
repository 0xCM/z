//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public readonly record struct ApiSigMod : IExpr
    {
        public readonly string Name;

        public readonly ApiSigModKind Kind;

        public ApiSigMod(string name, ApiSigModKind kind)
        {
            Name = name;
            Kind = kind;
        }

        public bool IsEmpty
        {
            [MethodImpl(Inline)]
            get => sys.empty(Name);
        }

        public string Format()
            => Name;

        public override string ToString()
            => Format();
    }
}