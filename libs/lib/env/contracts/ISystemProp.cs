//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public interface ISystemProp
    {
        string Name {get;}

        dynamic Value {get;}
    }

    public interface ISystemProp<V> : ISystemProp
    {
        new V Value {get;}

        dynamic ISystemProp.Value
            => Value;
    }
}