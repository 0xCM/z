//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public readonly struct ClrDataMembers : IIndex<ClrDataMember>
    {
        readonly Index<ClrDataMember> Data;

        [MethodImpl(Inline)]
        public ClrDataMembers(ClrDataMember[] src)
            => Data = src;

        public uint Count
        {
            [MethodImpl(Inline)]
            get => Data.Count;
        }

        public ClrDataMember[] Storage
        {
            [MethodImpl(Inline)]
            get => Data.Storage;
        }

        public ref ClrDataMember First
        {
            [MethodImpl(Inline)]
            get => ref Data.First;
        }

        public ref ClrDataMember this[uint index]
        {
            [MethodImpl(Inline)]
            get => ref Data[index];
        }

        [MethodImpl(Inline)]
        public static implicit operator ClrDataMembers(ClrDataMember[] src)
            => new ClrDataMembers(src);

        public static ClrDataMembers Empty
            => new ClrDataMembers(sys.empty<ClrDataMember>());
    }
}