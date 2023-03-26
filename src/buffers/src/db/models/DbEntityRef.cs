//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [StructLayout(LayoutKind.Sequential,Pack=1)]
    public readonly record struct DbEntityRef : IComparable<DbEntityRef>
    {
        public readonly uint Kind;

        public readonly uint Key;

        [MethodImpl(Inline)]
        public DbEntityRef(uint kind, uint key)
        {
            Key  = key;
            Kind = kind;
        }

        [MethodImpl(Inline)]
        public int CompareTo(DbEntityRef src)
            => Key.CompareTo(src.Key);
    }    
}