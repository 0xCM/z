//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [StructLayout(LayoutKind.Sequential,Pack=1)]
    public readonly record struct DbCol : IComparable<DbCol>
    {
        public readonly ushort Pos;

        public readonly Name ColName;

        public readonly byte RenderWidth;

        [MethodImpl(Inline)]
        public DbCol(ushort pos, Name name, byte rw)
        {
            Pos = pos;
            ColName = name;
            RenderWidth = rw;
        }

        public Hash32 Hash
        {
            [MethodImpl(Inline)]
            get => ColName.Hash | (Hash16)Pos;
        }

        public override int GetHashCode()
            => Hash;

        [MethodImpl(Inline)]
        public bool Equals(DbCol src)
            => Pos == src.Pos && ColName == src.ColName && RenderWidth == src.RenderWidth;

        [MethodImpl(Inline)]
        public int CompareTo(DbCol src)
            => Pos.CompareTo(src.Pos);

        [MethodImpl(Inline)]
        public DbCol Reposition(ushort pos)
            => new DbCol(pos, ColName, RenderWidth);
    }
}