//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public abstract class Stateless<T> : Stateless
        where T : Stateless<T>,new()
    {
        public static T create() => new T();
    }
}