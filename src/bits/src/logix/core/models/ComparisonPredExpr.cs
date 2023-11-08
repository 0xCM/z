//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

/// <summary>
/// Defines a typed comparison predicate
/// </summary>
public sealed class ComparisonPredExpr<T> : IComparisonPredExpr<T>
    where T : unmanaged
{
    /// <summary>
    /// The operator kind
    /// </summary>
    public ApiComparisonClass ComparisonKind {get;}

    /// <summary>
    /// The left operand
    /// </summary>
    public ILogixExpr<T> Left {get;}

    /// <summary>
    /// The right operand
    /// </summary>
    public ILogixExpr<T> Right {get;}

    /// <summary>
    /// The variables upon which the operands depend
    /// </summary>
    Index<ILogixVarExpr<T>> _Vars {get;}

    [MethodImpl(Inline)]
    public ComparisonPredExpr(ApiComparisonClass op, ILogixExpr<T> left, ILogixExpr<T> right, params ILogixVarExpr<T>[] vars)
    {
        ComparisonKind = op;
        Left = left;
        Right = right;
        _Vars = vars;
    }

    public bool IsEmpty
    {
        [MethodImpl(Inline)]
        get => ComparisonKind == 0;
    }

    public bool IsNonEmpty
    {
        [MethodImpl(Inline)]
        get => ComparisonKind != 0;
    }

    public ILogixVarExpr<T>[] Vars
    {
        [MethodImpl(Inline)]
        get => _Vars.Storage;
    }

    public void SetVars(params ILogixExpr<T>[] values)
    {
        var count = Math.Min(_Vars.Length, values.Length);
        for(var i=0; i<count; i++)
            _Vars[i].Set(values[i]);
    }

    public void SetVars(params T[] values)
    {
        var count = Math.Min(_Vars.Length, values.Length);
        for(var i=0; i<count; i++)
            _Vars[i].Set(values[i]);
    }

    [MethodImpl(Inline)]
    public void SetVar(int index, T value)
        => _Vars[index].Set(value);

    public string Format()
        => ComparisonKind.Format(Left,Right);

    public override string ToString()
        => Format();
}
