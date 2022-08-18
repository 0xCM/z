//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public record struct DbEntity : IEntity<DbEntity,uint>
    {
        public readonly uint Key;

        public readonly Name Name;

        public readonly Index<Relation32> Rels;

        public readonly Index<DbColSpec> Cols;

        [MethodImpl(Inline)]
        public DbEntity(uint key, Name name, DbColSpec[] cols, Relation32[] rels)
        {
            Key = key;
            Name = name;
            Cols = cols;
            Rels = rels;
        }

        uint IKeyed<uint>.Key   
            => Key;

        [MethodImpl(Inline)]
        public int CompareTo(DbEntity src)
            => Key.CompareTo(src.Key);
    }
   
}