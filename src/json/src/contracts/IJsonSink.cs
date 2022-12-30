//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2023
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public interface IJsonSink
    {
        void Null(Utf8JsonReader src);

        void Comment(Utf8JsonReader src);

        void ArrayBegin(Utf8JsonReader src);

        void ArrayEnd(Utf8JsonReader src);

        void ObjectBegin(Utf8JsonReader src);

        void ObjectEnd(Utf8JsonReader src);

        void Number(Utf8JsonReader src);

        void String(Utf8JsonReader src);

        void Bool(Utf8JsonReader src);

        void PropertyName(Utf8JsonReader src);
    }
}