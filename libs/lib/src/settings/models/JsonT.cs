//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using api = JsonData;

    public readonly struct Json<T> : IJsonSource<Json<T>>
    {
        public readonly Seq<T> Content;

        [MethodImpl(Inline)]
        public Json(T[] src)
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
        public static implicit operator Json<T>(T[] src)
            => new Json<T>(src);
    }
}