//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [StructLayout(LayoutKind.Sequential,Pack=1)]
    public readonly record struct EntityRef64 : IComparable<EntityRef64>
    {
        public readonly uint Kind;

        public readonly uint Key;

        [MethodImpl(Inline)]
        public EntityRef64(uint kind, uint key)
        {
            Key  = key;
            Kind = kind;
        }

        [MethodImpl(Inline)]
        public int CompareTo(EntityRef64 src)
            => Key.CompareTo(src.Key);
    }    
}