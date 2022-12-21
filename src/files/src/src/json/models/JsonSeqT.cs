//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using api = JsonData;

    public sealed record class JsonSeq<T> : IJsonSource<JsonSeq<T>>
    {
        public readonly Seq<T> Content;

        public JsonSeq()
        {
            Content = sys.empty<T>();
        }

        [MethodImpl(Inline)]
        public JsonSeq(T[] src)
        {
            Content = src;
        }

        public bool IsEmpty
        {
            [MethodImpl(Inline)]
            get => Content.IsEmpty;
        }

        [MethodImpl(Inline)]
        public string Format()
            => Content?.Format();

        public override string ToString()
            => Format();

        public JsonText ToJson()
            => api.jtext(this);

        [MethodImpl(Inline)]
        public static implicit operator JsonSeq<T>(T[] src)
            => new JsonSeq<T>(src);
    }
}