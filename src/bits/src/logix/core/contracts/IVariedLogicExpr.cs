//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    /// <summary>
    /// Characterizes an expression that depends on a boolean variable
    /// </summary>
    public interface IVariedLogicExpr : IVariedExpr, ILogicExpr
    {
        ILogicExpr BaseExpr {get;}

        ILogicVarExpr[] Vars {get;}

        void SetVars(params ILogicExpr[] values);

        void SetVars(params Bit32[] values);
    }

    /// <summary>
    /// Characterizes an expression that depends on a boolean variable but which
    /// also carries type information
    /// </summary>
    public interface IVariedLogicExpr<T> : IVariedLogicExpr,  ILogicExpr<T>
        where T : unmanaged
    {
        new ILogicExpr<T> BaseExpr {get;}

        new ILogicVarExpr<T>[] Vars {get;}

        void SetVars(params ILogicExpr<T>[] values);
    }
}