//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [Free]
    public interface IValueCover : IExprDeprecated
    {
        dynamic Value {get;}

        string IExpr.Format()
            => Value?.ToString() ?? string.Empty;
    }

    [Free]
    public interface IValueCover<T> : IValueCover
    {
        new T Value {get;}

        dynamic IValueCover.Value
            => Value;
    }
}