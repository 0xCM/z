//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public interface IPartId : IExpr
    {
        /// <summary>
        /// The part identifier
        /// </summary>
        PartId Id {get;}

        bool INullity.IsEmpty
            => Id==0;

        bool INullity.IsNonEmpty
            => Id!=0;

        string IExpr.Format()
            => Id.Format();
    }

    public interface IPartId<P> : IPartId, IEquatable<P>
        where P : IPartId, new()
    {

        bool IEquatable<P>.Equals(P src)
            => src.Id == Id;
    }
}