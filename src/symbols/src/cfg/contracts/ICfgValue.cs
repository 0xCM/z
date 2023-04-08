//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public interface ICfgValue : IExpr, IHashed
    {
        CfgValueKind ValueKind {get;}

        Fence<char> Fence {get;}     

        bool Equals(ICfgValue src);
    }

    public interface ICfgValue<V> : ICfgValue, IEquatable<V>, IHashed
        where V : ICfgValue<V>, new()
    {
        V New() => new V();

        bool ICfgValue.Equals(Z0.ICfgValue src)
            => src is V v && this.Equals(v);
    }
}
