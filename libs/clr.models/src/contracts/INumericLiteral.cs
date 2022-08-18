//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    /// <summary>
    /// Characterizes a representation of a numeric literal
    /// </summary>
    /// <typeparam name="T">The representation type</typeparam>
    [Free]
    public interface INumericLiteral<T> : ILiteral<T>
        where T : struct, INumericLiteral<T>
    {
    }

    /// <summary>
    /// Characterizes a representation of a numeric literal
    /// </summary>
    /// <typeparam name="F">The representation type</typeparam>
    /// <typeparam name="T">The represented type</typeparam>
    [Free]
    public interface INumericLiteral<H,T> : INumericLiteral<H>, ILiteral<H,T>
        where H : struct, INumericLiteral<H,T>
        where T : unmanaged
    {

    }
}