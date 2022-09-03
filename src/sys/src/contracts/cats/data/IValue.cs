//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [Free]
    public interface IValued : IExpr
    {
        dynamic Value {get;}
    }

    [Free]
    public interface IValued<T> : IValued
    {
        new T Value {get;}

        dynamic IValued.Value
            => Value;

        string IExpr.Format()
            => Value?.ToString() ?? string.Empty;
    }

    /// <def>
    /// A value is a concretized thing
    /// </def>
    public interface IValue
    {
        dynamic Value {get;}
    }

    /// <summary>
    /// Characterizes a value of parametric type
    /// </summary>
    /// <typeparam name="T">The value type</typeparam>
    public interface IValue<T> : IValue
    {
        new T Value {get;}

        dynamic IValue.Value
            => Value;
    }
}