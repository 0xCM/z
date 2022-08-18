//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public interface IBijection
    {
        dynamic Apply(dynamic src);

        dynamic Invert(dynamic src);
    }

    [Free]
    public interface IBijection<S,T> : IBijection
    {
        T Apply(S src);

        S Invert(T src);

        dynamic IBijection.Apply(dynamic src)
            => Apply(src);

        dynamic IBijection.Invert(dynamic src)
            => Apply(src);
    }
}