//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using api = JsonData;

    public struct JsonSetting
    {
        public readonly string Name {get;}

        public readonly dynamic Value {get;}

        [MethodImpl(Inline)]
        public JsonSetting(string name, dynamic value)
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