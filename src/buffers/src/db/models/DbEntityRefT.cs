//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [StructLayout(LayoutKind.Sequential,Pack=1)]
    public readonly record struct DbEntityRef<T>: IComparable<DbEntityRef<T>>
        where T : unmanaged, IEquatable<T>, IComparable<T>
    {
        public readonly T Key;

        [MethodImpl(Inline)]
        public DbEntityRef(T key)
        {
            Key  = key;
        }

        public Hash32 Hash
        {
            [MethodImpl(Inline)]
            get => sys.nhash(Key);
        }

        public override int GetHashCode()
            => Hash;

        [MethodImpl(Inline)]
        public int CompareTo(DbEntityRef<T> src)
            => Key.CompareTo(src.Key);

        public bool Equals(DbEntityRef<T> src)
            => Key.Equals(src.Key);
    }    
}