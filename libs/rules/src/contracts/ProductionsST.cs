//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public class Productions<S,T> : ConstLookup<S,Index<T>>
    {
        public Productions(Dictionary<S,Index<T>> src)
            : base(src)
        {

        }

        public static implicit operator Productions<S,T>(Dictionary<S,Index<T>> src)
            => new Productions<S,T>(src);
    }

}