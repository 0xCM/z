//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2023
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public interface IVarAssignment : IExpr
    {
        VarDef Def {get;}

        dynamic Value {get;}
    }

    public interface IVarAssignment<T> : IVarAssignment
    {
        new T Value {get;}
        
        dynamic IVarAssignment.Value
            => Value;
    }
}