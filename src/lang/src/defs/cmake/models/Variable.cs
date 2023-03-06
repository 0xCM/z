//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Lang
{
    partial class CMake
    {
        public record class Variable<T>
            where T : DataType<T>, new()
        {
            public readonly string Name;

            public readonly Value Value;
            
            public Variable(string name, Value value)
            {
                Name = name;
                Value = value;
            }

            public T Type => (T)Value.Type;
        }
        
        public record class Variable<V,T> : Variable<T>
            where T : DataType<T>, new()
            where V : Value<V,T>, new()
        {
            public Variable(string name, V value)
                : base(name,value)
            {

            }

            public new V Value => (V)base.Value;
        }
        
    }
}