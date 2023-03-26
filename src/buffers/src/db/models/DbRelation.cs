//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [StructLayout(LayoutKind.Sequential,Pack=1)]
    public readonly record struct DbRelation : IEntity<DbRelation,ulong>
    {
        public readonly uint Source;

        public readonly uint Target;            

        [MethodImpl(Inline)]
        public DbRelation(uint src, uint dst)
        {
            Source = src;
            Target = dst;
        }

        [MethodImpl(Inline)]
        public DbRelation(Arrow<uint> def)
        {
            Source = def.Source;
            Target = def.Target;
        }

        public ulong Key
        {
            [MethodImpl(Inline)]
            get => (ulong)Source | (ulong)Target << 32;
        }

        public Arrow<uint> Arrow
        {
            [MethodImpl(Inline)]
            get => (Source,Target);
        }

        [MethodImpl(Inline)]
        public int CompareTo(DbRelation src)
        {
            var result = Source.CompareTo(src.Source);
            if(result==0)
                result = Target.CompareTo(src.Target);
            return result;
        }

        [MethodImpl(Inline)]
        public static explicit operator DbRelation(uint id)
        {
            Numbers.split(id, out var src, out var dst);
            return new DbRelation(src,dst);
        }

        [MethodImpl(Inline)]
        public static explicit operator ulong(DbRelation src)
            => src.Key;

        [MethodImpl(Inline)]
        public static implicit operator DbRelation((uint src, uint dst) x)
            => new DbRelation(x.src, x.dst);

        [MethodImpl(Inline)]
        public static implicit operator Arrow<uint>(DbRelation def)
            => def.Arrow;

        [MethodImpl(Inline)]
        public static implicit operator DbRelation(Arrow<uint> def)
            => new DbRelation(def);
    }

}