//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public interface IVarResolver
    {
        IExpr Resolve(Name name);

        T Resolve<T>(Name name)
            where T : IExpr;
    }
}