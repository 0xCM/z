//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public interface IBinaryField
    {
        @string Name {get;}

        IBinaryType Type {get;}
    }    

    public interface IBinaryField<T> : IBinaryField
        where T : IBinaryType
    {
        new T Type {get;}

        IBinaryType IBinaryField.Type
            => Type;
    }
}