//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [Free]
    public interface IVarValue : IExpr
    {
        string VarName {get;}

        object VarValue {get;}

        bool INullity.IsEmpty
            => sys.empty(VarName) || VarValue == null;

        bool INullity.IsNonEmpty
            => sys.nonempty(VarName) && VarValue != null;

        string Format(VarContextKind vck)
            => VarName ?? EmptyString;

        string IExpr.Format()
            => VarValue != null ? VarValue.ToString() : EmptyString;
    }

    [Free]
    public interface IVarValue<T> : IVarValue
    {
        new T VarValue {get;}

        object IVarValue.VarValue
            => VarValue;
    }
}