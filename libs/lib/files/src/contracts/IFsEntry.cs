//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public interface IFsEntry : IDataString, ILocatable<PathPart>
    {
        PathPart Name {get;}

        PathPart ILocatable<PathPart>.Location
            => Name;
        Hash32 IHashed.Hash
            => HashCodes.hash(Name.Format());

        bool INullity.IsEmpty
            => Name.IsEmpty;

        bool INullity.IsNonEmpty
            => Name.IsNonEmpty;

        string IExpr.Format()
            => Name.Format();
    }

    public interface IFsEntry<F> : IFsEntry, IDataString<F>, IDataType<F>
        where F : struct, IFsEntry<F>
    {
        bool IEquatable<F>.Equals(F src)
            => Name == src.Name;

        int IComparable<F>.CompareTo(F src)
            => Name.CompareTo(src.Name);
    }
}