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

        bool INullity.IsEmpty
            => sys.empty(Name);

        bool INullity.IsNonEmpty
            => sys.nonempty(Name);

        string IExpr.Format()
            => Name;
    }


}