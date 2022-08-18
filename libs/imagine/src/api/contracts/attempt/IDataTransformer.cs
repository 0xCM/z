//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public interface IDataTransformer
    {
        Outcome Process(in dynamic src, out dynamic dst);
    }

    public interface IDataTransformer<S> : IDataTransformer
    {
        Outcome Process(in S src, out dynamic dst);

        Outcome IDataTransformer.Process(in dynamic src, out dynamic dst)
            => Process((S)src, out dst);
    }

    public interface IDataTransformer<S,T> : IDataTransformer<S>
    {
        Outcome Process(in S src, out T dst);

        Outcome IDataTransformer<S>.Process(in S src, out dynamic dst)
        {
            var outcome = Process(src, out var _dst);
            dst = _dst;
            return outcome;
        }
    }
}