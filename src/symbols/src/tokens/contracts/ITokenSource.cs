//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public interface ITokenSource : IDisposable
    {
        bool Next(out dynamic dst);
    }

    public interface ITokenSource<S> : ITokenSource
        where S : new()
    {
        bool Next(out S atom);

        bool ITokenSource.Next(out dynamic dst)
        {
            var result = Next(out var _dst);
            dst = result ? _dst : new S();
            return dst;
        }
    }   
}