//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static BinaryTypes;

    public interface IBinaryField
    {
        @string Name {get;}

        BinaryType Type {get;}
    }    

    public interface IBinaryField<T> : IBinaryField
        where T : BinaryType
    {
        new T Type {get;}

        BinaryType IBinaryField.Type
            => Type;
    }

}