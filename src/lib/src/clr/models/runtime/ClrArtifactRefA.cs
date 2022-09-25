//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    /// <summary>
    /// Defines a reference to clr-specific artifact
    /// </summary>
    public readonly struct ClrArtifactRef<A> : IClrArtifact<A>
        where A : struct, IClrArtifact<A>
    {
        readonly A Artifact;

        public ClrArtifactKind Kind
        {
            [MethodImpl(Inline)]
            get => Artifact.Kind;
        }

        public EcmaToken Token
        {
            [MethodImpl(Inline)]
            get => Artifact.Token;
        }

        public string Name
        {
            [MethodImpl(Inline)]
            get => Artifact.Name;
        }


        [MethodImpl(Inline)]
        public ClrArtifactRef(A artifact)
            => Artifact = artifact;

        public string Format()
            => string.Format(RpOps.PSx3, Kind, Token, Name);

        public override string ToString()
            => Format();

        public static implicit operator ClrArtifactRef<A>(A src)
            => new ClrArtifactRef<A>(src);

        [MethodImpl(Inline)]
        public static implicit operator ClrArtifactRef(ClrArtifactRef<A> src)
            => new ClrArtifactRef(src.Token, src.Kind, src.Name);
    }
}