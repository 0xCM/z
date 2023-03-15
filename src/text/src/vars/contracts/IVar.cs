//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [Free]
    public interface IVar : IExpr
    {
        @string Name {get;}

        bool Value(out object value);
    }

    [Free]
    public interface IVar<T> : IVar
        where T : IEquatable<T>, INullity, new()    
    {
        bool Value(out T value);

        bool IVar.Value(out object value) 
        {
            if(Value(out T _value))
            {
                value = _value;
                return true;
            }
            else
            {
                value = null;
                return false;
            }
        }
    }
}