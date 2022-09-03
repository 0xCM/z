//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public readonly struct JsonProp
    {
        public string Name {get;}

        public JsonText Value {get;}

        [MethodImpl(Inline)]
        public JsonProp(string name, JsonText value)
        {
            Name = name;
            Value = value;
        }

        public KeyedValue<string,string> Unescape()
            => (Name, Value.Unescape());
    }
}