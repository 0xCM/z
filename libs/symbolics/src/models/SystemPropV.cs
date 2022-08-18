//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public readonly struct SystemProp<V> : ISystemProp<V>
    {
        public readonly string Name;

        public readonly V Value;

        public SystemProp(string name, V value)
        {
            Name = name;
            Value = value;
        }

        V ISystemProp<V>.Value
            => Value;

        string ISystemProp.Name
            => Name;

        public string Format()
            => Value.ToString();

    }
}