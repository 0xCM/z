//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public interface IBinaryType
    {
        @string Name {get;}
    }

    public interface IBinaryType<T> : IBinaryType
        where T : BinaryType
    {

    }
}