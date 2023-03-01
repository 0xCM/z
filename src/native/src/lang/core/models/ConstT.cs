//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Lang
{
    public record class Const<T> : IConst<T>
    {
        public readonly @string Name;

        public readonly uint Ordinal;

        public readonly T Value;

        public readonly @string Description;

        internal Const(@string name, uint ordinal, T value, @string? description = null)
        {
            Name = name;
            Ordinal = ordinal;
            Value = value;
            Description = description ?? EmptyString;
        }

        T IConst<T>.Value 
            => Value;

        @string IConst.Name 
            => Name;

        uint IConst.Ordinal 
            => Ordinal;

        @string IConst.Description 
            => Description;
    }
}
