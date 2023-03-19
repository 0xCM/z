//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2023
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [JsonTranformer]
    public abstract class JsonTransform<T> : JsonConverter<T>
    {
        public override T Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options) 
            => Read(ref reader);

        public override void Write(Utf8JsonWriter writer, T src, JsonSerializerOptions options) 
            => Write(src, writer);

        protected abstract void Write(T src, Utf8JsonWriter dst);

        protected abstract T Read(ref Utf8JsonReader src);
    }   
}