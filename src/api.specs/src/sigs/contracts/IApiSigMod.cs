//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public interface IApiSigMod<T> : IExpr
        where T : struct, IApiSigMod<T>
    {
        string Name {get;}

        ApiSigModKind Kind {get;}

        bool INullity.IsEmpty
            => sys.empty(Name);
    }
}