//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public interface ISdkKind : IDataString
    {
        asci16 Name {get;}

        bool INullity.IsEmpty
            => Name.IsEmpty;

        bool INullity.IsNonEmpty
            => Name.IsNonEmpty;

        Hash32 IHashed.Hash
            => Name.Hash;        
    }

    public interface ISdkKind<K> : ISdkKind, IDataType<K>
        where K : ISdkKind<K>
    {
        bool IEquatable<K>.Equals(K src)
            => Name == src.Name;
        
        int IComparable<K>.CompareTo(K src)
            => Name.CompareTo(src.Name);

        string IExpr.Format()
            => Name.Format();
    }
}

//K:\dist\dotnet\coreclr\windows.x64.Release