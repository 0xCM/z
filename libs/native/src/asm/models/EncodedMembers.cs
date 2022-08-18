//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public sealed class EncodedMembers : Seq<EncodedMembers, EncodedMember>
    {
        public EncodedMembers()
        {

        }

        public EncodedMembers(EncodedMember[] src)
            : base(src)
        {

        }

        public static implicit operator EncodedMembers(EncodedMember[] src)
            => new (src);
    }
}