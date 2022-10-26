//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [StructLayout(LayoutKind.Sequential,Pack=1)]
    public readonly record struct Relation32 : IEntity<Relation32,uint>
    {
        public readonly ushort Source;

        public readonly ushort Target;            

        [MethodImpl(Inline)]
        public Relation32(ushort src, ushort dst)
        {
            Source = src;
            Target = dst;
        }

        [MethodImpl(Inline)]
        public Relation32(Arrow<ushort> def)
        {
            Source = def.Source;
            Target = def.Target;
        }

        public uint Key
        {
            [MethodImpl(Inline)]
            get => (uint)Source | (uint)Target << 16;
        }

        public Arrow<ushort> Arrow
        {
            [MethodImpl(Inline)]
            get => (Source,Target);
        }

        [MethodImpl(Inline)]
        public int CompareTo(Relation32 src)
        {
            var result = Source.CompareTo(src.Source);
            if(result==0)
                result = Target.CompareTo(src.Target);
            return result;
        }

        [MethodImpl(Inline)]
        public static explicit operator Relation32(uint id)
        {
            Numbers.split(id, out var src, out var dst);
            return new Relation32(src,dst);
        }

        [MethodImpl(Inline)]
        public static explicit operator uint(Relation32 src)
            => src.Key;

        [MethodImpl(Inline)]
        public static implicit operator Relation32((ushort src, ushort dst) x)
            => new Relation32(x.src, x.dst);

        [MethodImpl(Inline)]
        public static implicit operator Arrow<ushort>(Relation32 def)
            => def.Arrow;

        [MethodImpl(Inline)]
        public static implicit operator Relation32(Arrow<ushort> def)
            => new Relation32(def);
    }

}