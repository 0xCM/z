//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public class ApiHostMembers
    {
        public readonly ApiHostUri Host;

        public readonly ApiMembers Members;

        [MethodImpl(Inline)]
        public ApiHostMembers(ApiHostUri host, ApiMembers members)
        {
            Host = host;
            Members = members;
        }

        public bool IsEmpty
        {
            [MethodImpl(Inline)]
            get => Members.Count == 0;
        }

        public bool IsNonEmpty
        {
            [MethodImpl(Inline)]
            get => Members.Count != 0;
        }

        public uint Count
        {
            [MethodImpl(Inline)]
            get => Members.Count;
        }

        public ref readonly ApiMember this[uint i]
        {
            [MethodImpl(Inline)]
            get => ref Members[i];
        }

        public ref readonly ApiMember this[int i]
        {
            [MethodImpl(Inline)]
            get => ref Members[i];
        }        
    }
}