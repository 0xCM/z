//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    /// <summary>
    /// Characterizes a thing that can be found
    /// </summary>
    public interface ILocatable : IExpr
    {
        dynamic Location {get;}

        bool INullity.IsEmpty
            => Location == null;
    }

    /// <summary>
    /// Characterizes a location of parametric type
    /// </summary>
    /// <typeparam name="T">The location type</typeparam>
    public interface ILocatable<T> : ILocatable
    {
        new T Location {get;}

        dynamic ILocatable.Location
            => Location;
    }
}