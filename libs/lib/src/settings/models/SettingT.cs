//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using api = Settings;

    /// <summary>
    /// Defines a value-parametric application setting
    /// </summary>
    [Record(TableId)]
    public readonly struct Setting<T> : IComparable<Setting<T>>
    {
        const string TableId = "settings";

        [Render(12)]
        public readonly SettingType Type;

        /// <summary>
        /// The setting name
        /// </summary>
        [Render(32)]
        public readonly Name Name;

        /// <summary>
        /// The setting value
        /// </summary>
        [Render(1)]
        public readonly T Value;

        [MethodImpl(Inline)]
        public Setting(Name name, T value)
        {
            Name = name;
            Value = value;
            Type = api.type(value);
        }

        [MethodImpl(Inline)]
        public Setting(Name name, SettingType type, T value)
        {
            Name = name;
            Value = value;
            Type = api.type(value);
        }

        public Setting NonGeneric
        {
            [MethodImpl(Inline)]
            get => new (Name, Value);
        }

        public string Format()
            => string.Format(RpOps.Setting, Name, Value);

        public string Json()
            => string.Format(RpOps.JsonProp, Name, Value);
        public int CompareTo(Setting<T> src)
            => Name.CompareTo(src.Name);

        [MethodImpl(Inline)]
        public static implicit operator Setting(Setting<T> src)
            => src.NonGeneric;

        [MethodImpl(Inline)]
        public static implicit operator T(Setting<T> src)
            => src.Value;

        [MethodImpl(Inline)]
        public static implicit operator Setting<T>(T src)
            => new Setting<T>(EmptyString, src);

        [MethodImpl(Inline)]
        public static implicit operator Setting<T>((string name, T value) src)
            => new Setting<T>(src.name, src.value);

        public static Setting<T> Empty
        {
            [MethodImpl(Inline)]
            get => new Setting<T>(String.Empty, core.EmptyType<T>());
        }
    }
}