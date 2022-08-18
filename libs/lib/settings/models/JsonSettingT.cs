//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using api = JsonData;

    public readonly struct JsonSetting<T>
    {
        public readonly string Name {get;}

        public readonly T Value {get;}

        [MethodImpl(Inline)]
        public JsonSetting(string name, T value)
        {
            Name = name;
            Value = value;
        }
        public string Format()
            => api.format(this);

        public override string ToString()
            => Format();
    }
}