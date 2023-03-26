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

        public readonly Name TableName;

        public readonly ReadOnlySeq<DbCol> Cols;

        [MethodImpl(Inline)]
        public DbTableDef(uint seq, Name name, DbCol[] cols)
        {
            Key = seq;
            TableName = name;
            Cols = cols;
        }

        uint IKeyed<uint>.Key 
            => Key;

        [MethodImpl(Inline)]
        public int CompareTo(DbTableDef src)
            => TableName.CompareTo(src.TableName);
    }   
}