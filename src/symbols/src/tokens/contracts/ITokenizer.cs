//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public interface ITokenizer<S,T,V>
        where S : ITokenSource<V>
        where V : new()
    {
        IEnumerable<T> Tokenize(S src);
    }
}