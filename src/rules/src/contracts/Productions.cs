//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public class Productions
    {
        ConstLookup<string, IProduction> Data;

        public Productions(Dictionary<string,IProduction> src)
        {
            Data = src;
        }

        public static implicit operator Productions(Dictionary<string,IProduction> src)
            => new Productions(src);

        public bool Find(string src, out IProduction dst)
            => Data.Find(src, out dst);

        public IProduction this[string src]
            => Data[src];

        public ReadOnlySpan<string> Keys
            => Data.Keys;

        public ReadOnlySpan<IProduction> Values
            => Data.Values;
    }

}