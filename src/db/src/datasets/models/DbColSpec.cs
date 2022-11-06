//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [StructLayout(LayoutKind.Sequential,Pack=1)]
    public record struct DbColSpec : IEntity<DbColSpec,uint>
    {
        public readonly uint Key;

        public readonly DbDataType Type;

        public readonly Name Name;

        [MethodImpl(Inline)]
        public DbColSpec(uint key, DbDataType type, Name name)
        {
            Key = key;
            Type = type;
            Name = name;
        }

        uint IKeyed<uint>.Key
            => Key;

        [MethodImpl(Inline)]
        public int CompareTo(DbColSpec src)
            => Key.CompareTo(src.Key);
    }   
}