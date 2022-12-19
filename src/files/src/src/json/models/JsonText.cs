//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    public readonly struct JsonText : IExpr, IContented<string>
    {
        public readonly string Content;

        [MethodImpl(Inline)]
        public JsonText(string src)
        {
            Content = src ?? EmptyString;
        }

        [MethodImpl(Inline)]
        public string Format()
            => Content;

        public override string ToString()
            => Format();
 
        public string Unescape()
        {
            if(JsonData.unescape(Content, out var escaped))
                return escaped;
            else
                return EmptyString;
        }

        public Hash32 Hash
        {
            [MethodImpl(Inline)]
            get => hash(Content);
        }

        public bool IsEmpty
        {
            [MethodImpl(Inline)]
            get => empty(Content);
        }

        public bool IsNonEmpty
        {
            [MethodImpl(Inline)]
            get => nonempty(Content);
        }

        public int Length
        {
            [MethodImpl(Inline)]
            get => Content?.Length ?? 0;
        }

        [MethodImpl(Inline)]
        public static implicit operator JsonText(string src)
            => new JsonText(src);

        [MethodImpl(Inline)]
        public static implicit operator string(JsonText src)
            => src.Content;

        string IContented<string>.Content 
            => Content;

        public static JsonText Empty
           => new JsonText(EmptyString);           
    }
}