//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    [StructLayout(LayoutKind.Sequential, Pack=1)]
    public readonly record struct FlowId : IEquatable<FlowId>, IHashed, IComparable<FlowId>
    {
        [MethodImpl(Inline)]
        public static FlowId identify<A,S,T>(A actor, S src, T dst)
            => new FlowId(hash(actor), hash(src), hash(dst));

        public readonly Hex32 ActorId;

        public readonly Hex32 SourceId;

        public readonly Hex32 TargetId;

        public readonly Hash32 Hash;

        [MethodImpl(Inline)]
        public FlowId(uint actor, uint src, uint dst)
        {
            ActorId = actor;
            SourceId = src;
            TargetId = dst;
            Hash = hash(actor, src, dst);
        }

        [MethodImpl(Inline)]
        public int CompareTo(FlowId src)
        {
            var result = ActorId.CompareTo(src.ActorId);
            if(result == 0)
            {
                result = SourceId.CompareTo(src.SourceId);
                if(result == 0)
                    result = TargetId.CompareTo(src.TargetId);
            }
            return result;
        }

        Hash32 IHashed.Hash
            => Hash;

        public override int GetHashCode()
            => Hash;

        [MethodImpl(Inline)]
        public bool Equals(FlowId src)
            => ActorId == src.ActorId && SourceId == src.SourceId && TargetId == src.TargetId;

        public string Format()
            => string.Format("{0:x8}{1:x8}{2:x8}", (uint)ActorId, (uint)SourceId, (uint)TargetId);

        public override string ToString()
            => Format();

        public static FlowId Empty => default;
    }
}