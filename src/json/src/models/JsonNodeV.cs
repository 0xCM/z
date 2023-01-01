//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public record class JsonNode<V> : IJsonNode<V>
        where V : new()
    {     
        protected JsonNode(JsonNode src)
        {
            Data = src;
        }

        readonly JsonNode Data;
        
        JsonNode IJsonNode.Data 
            => Data;

        public bool IsEmpty 
            => false;

        public virtual T GetValue<T>()
            => Json.convert<T>(Data);

        public bool TryGetValue<T>(out T value)
            => Json.convert(Data, out value);

        [MethodImpl(Inline)]
        public static implicit operator JsonNode<V>(byte src)
            => new(JsonValue.Create(src));

        [MethodImpl(Inline)]
        public static implicit operator JsonNode<V>(sbyte src)
            => new(JsonValue.Create(src));

        [MethodImpl(Inline)]
        public static implicit operator JsonNode<V>(int src)
            => new(JsonValue.Create(src));

        [MethodImpl(Inline)]
        public static implicit operator JsonNode<V>(uint src)
            => new(JsonValue.Create(src));

        [MethodImpl(Inline)]
        public static implicit operator JsonNode<V>(short src)
            => new(JsonValue.Create(src));

        [MethodImpl(Inline)]
        public static implicit operator JsonNode<V>(ushort src)
            => new(JsonValue.Create(src));

        [MethodImpl(Inline)]
        public static implicit operator JsonNode<V>(long src)
            => new(JsonValue.Create(src));

        [MethodImpl(Inline)]
        public static implicit operator JsonNode<V>(ulong src)
            => new(JsonValue.Create(src));

        [MethodImpl(Inline)]
        public static implicit operator JsonNode<V>(double src)
            => new(JsonValue.Create(src));

        [MethodImpl(Inline)]
        public static implicit operator JsonNode<V>(float src)
            => new(JsonValue.Create(src));

        [MethodImpl(Inline)]
        public static implicit operator JsonNode<V>(decimal src)
            => new(JsonValue.Create(src));
        
        [MethodImpl(Inline)]
        public static implicit operator JsonNode<V>(char src)
            => new(JsonValue.Create(src));

        [MethodImpl(Inline)]
        public static implicit operator JsonNode<V>(DateTime src)
            => new(JsonValue.Create(src));

        [MethodImpl(Inline)]
        public static implicit operator JsonNode<V>(DateTimeOffset src)
            => new(JsonValue.Create(src));

        [MethodImpl(Inline)]
        public static implicit operator JsonNode<V>(Guid src)
            => new(JsonValue.Create(src));

        [MethodImpl(Inline)]
        public static implicit operator JsonNode<V>(string src)
            => new(JsonValue.Create(src));

        [MethodImpl(Inline)]
        public static implicit operator JsonNode<V>(@string src)
            => new(JsonValue.Create(src));

        [MethodImpl(Inline)]
        public static implicit operator JsonNode<V>(TextBlock src)
            => new(JsonValue.Create(src));
    }
}