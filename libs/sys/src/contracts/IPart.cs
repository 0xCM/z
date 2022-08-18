//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public interface IPart : IPartId
    {
        /// <summary>
        /// The resolved assembly
        /// </summary>
        Assembly Owner {get;}

        /// <summary>
        /// The part name, equivalent to the simple assembly name
        /// </summary>
        string Name
            => Owner.GetName().Name;

        /// <summary>
        /// The part identifier, known from the assembly
        /// </summary>
        PartId IPartId.Id
            => PartIdAttribute.id(Owner);
    }

    public interface IPart<P> : IPart, IPartId<P>, IEquatable<P>
        where P : IPart<P>, new()
    {
        /// <summary>
        /// The assembly, known from the reifying type
        /// </summary>
        Assembly IPart.Owner
            => typeof(P).Assembly;
    }
}