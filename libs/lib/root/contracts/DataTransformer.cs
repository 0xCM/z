//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public abstract class DataTransformer<S,T> : IDataTransformer<S,T>
    {
        public abstract Outcome Process(in S src, out T dst);
    }
}