//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    using api = Settings;

    [Record(TableId)]
    public readonly record struct Setting : ISetting, IDataType<Setting>
    {
        const string TableId = "settings";

        [Render(12)]
        public readonly SettingType Type;

        [Render(32)]
        public readonly @string Name;

        [Render(1)]
        public readonly object Value;

        [MethodImpl(Inline)]
        public Setting(@string name, object value)
        {
            Type = api.type(value);
            Name = name;
            Value = value;
        }

        [MethodImpl(Inline)]
        public Setting(@string name, SettingType type, object value)
        {
            Name = name;
            Type = type;
            Value = value ?? EmptyString;
        }

        public string ValueText
            => Value?.ToString() ?? EmptyString;

        public bool IsEmpty
        {
            [MethodImpl(Inline)]
            get => Name.IsEmpty || Value is null;
        }

        public Hash32 Hash
        {
            [MethodImpl(Inline)]
            get => hash(Name) | (Hash32)(Value?.GetHashCode() ?? 0);
        }

        @string INamed.Name
            => Name;

        string ISetting.Value
            => ValueText;

        public override int GetHashCode()
            => Hash;

        public bool Equals(Setting src)
            => Value == src.Value && Name == src.Name;

        public string Format()
            => Format(Chars.Eq);

        public override string ToString()
            => Format();

        public string Json()
            => api.json(this);

        public string Format(char sep)
            => $"{Name}{sep}{ValueText}";

        public int CompareTo(Setting src)
            => Name.CompareTo(src.Name);

        public static Setting Empty
        {
            [MethodImpl(Inline)]
            get => new (EmptyString, 0, EmptyString);
        }
    }
}