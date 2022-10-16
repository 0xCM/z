//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public readonly struct EcmaArtifactRef : IExpr
    {
        public readonly ClrArtifactKind Kind;

        public readonly EcmaToken Token;

        public readonly string Name;

        [MethodImpl(Inline)]
        public EcmaArtifactRef(EcmaToken id, ClrArtifactKind kind, string name)
        {
            Token = id;
            Kind = kind;
            Name = name;
        }

        public bool IsEmpty
        {
            [MethodImpl(Inline)]
            get => Token.IsEmpty;
        }

        public string Format()
            => string.Format(RP.PSx3, Kind, Token, Name);

        public override string ToString()
            => Format();
    }
}