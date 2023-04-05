//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Lang.Dot
{
    public record class Attribute<T> : Attribute
    {
        protected Attribute(string name, T value)
            : base(name,value)
        {
        }         

    }
}