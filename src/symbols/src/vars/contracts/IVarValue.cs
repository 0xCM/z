//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [Free]
    public interface IVarValue : IExpr
    {
        string Name {get;}

        object Value {get;}

        bool INullity.IsEmpty
            => sys.empty(Name) || Value == null;

        bool INullity.IsNonEmpty
            => sys.nonempty(Name) && Value != null;

        string Format(VarContextKind vck)
            => Name ?? EmptyString;

        string IExpr.Format()
            => Value != null ? Value.ToString() : EmptyString;
    }

    [Free]
    public interface IVarValue<T> : IVarValue
    {
        new T Value {get;}

        object IVarValue.Value
            => Value;
    }
}