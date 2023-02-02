//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [StructLayout(LayoutKind.Sequential,Pack=1)]
    public readonly record struct DbTableDef : IEntity<DbTableDef,uint>
    {
        public readonly uint Key;

        public readonly asci32 Name;

        public readonly Index<DbCol> Cols;

        [MethodImpl(Inline)]
        public DbTableDef(uint seq, asci32 name, DbCol[] cols)
        {
            Key = seq;
            Name = name;
            Cols = cols;
        }

        uint IKeyed<uint>.Key 
            => Key;

        [MethodImpl(Inline)]
        public int CompareTo(DbTableDef src)
            => Name.CompareTo(src.Name);
    }   
}