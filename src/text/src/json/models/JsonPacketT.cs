//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public sealed record class JsonPacket<T>
    {
        public readonly T Content;

        /// <summary>
        /// The content type identifier
        /// </summary>
        public readonly string Type;

        [MethodImpl(Inline)]
        public JsonPacket(T content)
        {
            Content = content;
            Type = typeof(T).FullName;
        }

        [MethodImpl(Inline)]
        public JsonPacket(T content, string type)
        {
            Content = content;
            Type = type;
        }

        [MethodImpl(Inline)]
        public static implicit operator JsonPacket<T>(T src)
            => new JsonPacket<T>(src);

        [MethodImpl(Inline)]
        public static implicit operator JsonPacket(JsonPacket<T> src)
            => new JsonPacket(src.Content, src.Type);
    }
}