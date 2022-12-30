//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2023
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public record struct JsonProp<T> : IJsonRender
    {
        public readonly @string Name;

        public readonly T Value;

        [MethodImpl(Inline)]
        public JsonProp(string name, T value)
        {
            Name = name;
            Value = value;
        }

        public void Destructure(out @string name, out T value)
        {
            name = Name;
            value = Value;
        }

        public bool IsEmpty
        {
            [MethodImpl(Inline)]
            get=> Name.IsEmpty;
        }

        public bool IsNonEmpty
        {
            [MethodImpl(Inline)]
            get=> Name.IsNonEmpty;
        }

        public void Render(IJsonEmitter dst)
        {
            dst.Prop(Name,Value);
        }

        public static implicit operator JsonProp<T>((string name, T value) src)
            => new (src.name,src.value);
    }    
}