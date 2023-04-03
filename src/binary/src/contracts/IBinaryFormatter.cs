//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public interface IBinaryFormatter : IBinaryEncoder, IBinaryDecoder
    {
        ReadOnlySpan<Type> SupportedTypes {get;}

    }

    public interface IBinaryFormatter<T> : IBinaryFormatter, IBinaryEncoder<T>, IBinaryDecoder<T>
    {

    }
}