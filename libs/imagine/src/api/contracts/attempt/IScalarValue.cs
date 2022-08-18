//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [Free]
    public interface IScalarValue : ISizedValue, IExpr
    {
        bool INullity.IsEmpty
            => false;

        bool INullity.IsNonEmpty
            => false;

    }

    [Free]
    public interface IScalarValue<T> : IScalarValue, ISizedValue<T>
        where T : unmanaged
    {
        T IValued<T>.Value
            => sys.@as<IScalarValue<T>,T>(this);

        string IExpr.Format()
            => $"{Value}";
    }
}