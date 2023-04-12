//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2023
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public record VarAssignment<T> : VarAssignment
    {
        public readonly T Value;

        public VarAssignment(VarDef def, T value)
            : base(def,value)
        {
            Value = value;
        }
    }
}