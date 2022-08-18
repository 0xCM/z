//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [Free]
    public interface IVarValue : ITextual
    {
        Name VarName {get;}

        object VarValue {get;}

        string Format(VarContextKind vck)
            => VarName.Format();

        string ITextual.Format()
            => VarValue?.ToString();
    }

    [Free]
    public interface IVarValue<T> : IVarValue
    {
        new T VarValue {get;}

        object IVarValue.VarValue
            => VarValue;
    }
}