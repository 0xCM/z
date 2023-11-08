//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

using static sys;

/// <summary>
/// Defines an untyped comparison expression
/// </summary>
public readonly struct ComparisonExpr : IComparisonExpr
{
    /// <summary>
    /// The operator kind
    /// </summary>
    public ApiComparisonClass ComparisonKind {get;}

    /// <summary>
    /// The left operand
    /// </summary>
    public ILogicExpr Left {get;}

    /// <summary>
    /// The right operand
    /// </summary>
    public ILogicExpr Right {get;}

    /// <summary>
    /// The variables upon which the operands depend
    /// </summary>
    Index<ILogicVarExpr> _Vars {get;}

    public ComparisonExpr(ApiComparisonClass kind, ILogicExpr lhs, ILogicExpr rhs, params ILogicVarExpr[] vars)
    {
        ComparisonKind = kind;
        Left = require(lhs);
        Right = require(rhs);
        _Vars = vars;
    }

    public ILogicVarExpr[] Vars
    {
        [MethodImpl(Inline)]
        get => _Vars.Storage;
    }

    public void SetVars(params ILogicExpr[] values)
    {
        var count = min(_Vars.Length, values.Length);
        for(var i=0; i<count; i++)
            _Vars[i].Set(values[i]);
    }

    public byte SetVars(ILiteralLogixSeqExpr values)
    {
        var count = min(VarCount, (byte)values.Length);
        for(var i=0; i<count; i++)
            _Vars[i].Set(values[i]);
        return count;
    }

    public byte SetVars(params bit[] values)
    {
        var count = min(VarCount, (byte)values.Length);
        for(var i=0; i<count; i++)
            _Vars[i].Set(values[i]);
        return count;
    }

    public byte VarCount
    {
        [MethodImpl(Inline)]
        get => (byte)_Vars.Count;
    }

    [MethodImpl(Inline)]
    public void SetVar(bit a)
    {
        _Vars[0].Set(a);
    }

    [MethodImpl(Inline)]
    public bool SetVars(bit a, bit b)
    {
        if(VarCount >= 2)
        {
            _Vars[0].Set(a);
            _Vars[1].Set(b);
            return true;
        }
        else
            return false;
    }

    [MethodImpl(Inline)]
    public bool SetVars(bit a, bit b, bit c)
    {
        if(VarCount >= 3)
        {
            _Vars[0].Set(a);
            _Vars[1].Set(b);
            _Vars[2].Set(c);
            return true;
        }
        else
            return false;
    }

    public string Format()
        => Left.Format() + " == " + Right.Format();
}
