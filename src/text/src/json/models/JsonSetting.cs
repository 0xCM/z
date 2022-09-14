//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System.Text.Json;
    public record class JsonSetting
    {
        public readonly string Name;

        public readonly dynamic Value;

        [MethodImpl(Inline)]
        public JsonSetting(string name, dynamic value)
        {
            Name = name;
            Value = value;
        }
        public string Format()
            => JsonSerializer.Serialize(this);

        public override string ToString()
            => Format();
    }
}