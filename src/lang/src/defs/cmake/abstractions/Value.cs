//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Lang
{
    using static CMake.Types;

    partial class CMake
    {
        public abstract record class Value
        {
            public readonly DataType Type;

            protected Value(DataType type)
            {
                Type = type;
            }

            public abstract bool IsEmpty {get;}

            public virtual bool IsNonEmpty => !IsEmpty;

            public abstract string Format();
        }
        
        public abstract record class Value<V,T> : Value
            where T : DataType<T>, new()
            where V : Value<V,T>, new()
        {
            protected Value()
                : base(_Type)
            {
                
            }

            static readonly T _Type = new();

            public static new ref readonly T Type => ref _Type;

            public static V Empty => new();
        }
    }
}