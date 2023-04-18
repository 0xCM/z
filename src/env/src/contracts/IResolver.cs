//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public interface IResolver
    {
        bool Resolve(dynamic src, out dynamic dst);
    }

    public interface IResolver<S,T> : IResolver
    {
        bool Resolve(S src, out T dst);

        bool IResolver.Resolve(dynamic src, out dynamic dst)
        {
            var _dst = default(T);
            var result = Resolve((S)src, out _dst);
            dst = _dst;
            return result;
        }
    }
}