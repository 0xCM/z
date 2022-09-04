//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public readonly struct JittedMethod : IComparable<JittedMethod>
    {
        public _ApiHostUri Host {get;}

        public MethodInfo Method {get;}

        public MemoryAddress Location {get;}

        [MethodImpl(Inline)]
        public JittedMethod(_ApiHostUri host, MethodInfo method, MemoryAddress location = default)
        {
            Host = host;
            Method = method;
            Location = location;
        }

        [MethodImpl(Inline)]
        public int CompareTo(JittedMethod src)
            => Location.CompareTo(src.Location);
    }
}