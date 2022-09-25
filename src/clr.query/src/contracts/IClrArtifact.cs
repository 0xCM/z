//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [Free]
    public interface IClrArtifact : IExpr
    {
        /// <summary>
        /// The artifact metadata token
        /// </summary>
        EcmaToken Token {get;}

        /// <summary>
        /// The artifact name
        /// </summary>
        string Name {get;}

        /// <summary>
        /// The artifact classifier
        /// </summary>
        ClrArtifactKind Kind {get;}

        ClrArtifactRef Ref
            => new ClrArtifactRef(Token, Kind ,Name);

        bool INullity.IsEmpty
            => sys.empty(Name);

        bool INullity.IsNonEmpty
            => sys.nonempty(Name);

        string IExpr.Format()
            => Name;
    }

    [Free]
    public interface IClrArtifact<A> : IClrArtifact
        where A : struct, IClrArtifact<A>
    {

    }
}