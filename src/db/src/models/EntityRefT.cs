//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [StructLayout(LayoutKind.Sequential,Pack=1)]
    public readonly record struct EntityRef<T>: IComparable<EntityRef<T>>
        where T : unmanaged, IEquatable<T>, IComparable<T>
    {
        public readonly T Key;

        [MethodImpl(Inline)]
        public EntityRef(T key)
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
        public int CompareTo(EntityRef<T> src)
            => Key.CompareTo(src.Key);

        public bool Equals(EntityRef<T> src)
            => Key.Equals(src.Key);
    }    
}