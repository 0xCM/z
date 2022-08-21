//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public readonly struct NumericParser<T> : IParser<T>
    {
        public Outcome Parse(string src, out T dst)
            => NumericParser.parse(src, out dst);
    }
}