//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2023
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public class JsonArray<T> : ReadOnlySeq<T>
        where T : IJsonRender
    {   
        public JsonArray()
        {

        }

        public JsonArray(T[] src)
            : base(src)
        {}
    }
}