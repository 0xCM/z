//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [StructLayout(LayoutKind.Sequential,Pack=1)]
    public readonly record struct DbTypeRef
    {
        public readonly uint Key;

        public readonly Name TypeName;

        [MethodImpl(Inline)]
        public DbTypeRef(uint key, Name name)
        {
            Key = key;
            TypeName = name;
        }

        public int CompareTo(DbTypeRef src)
            => TypeName.CompareTo(src.TypeName);

        public string Format()
            => string.Format("{0,-6} | {1,-8} | {2}");

        public override string ToString()
            => Format();
    }
}