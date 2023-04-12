//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2023
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public abstract record VarAssignment : IVarAssignment, IComparable<VarAssignment>
    {
        public readonly VarDef Def;

        readonly dynamic Value;

        protected VarAssignment(VarDef def, dynamic value)
        {
            Def = def;
            Value = value;
        }

        public bool IsEmpty 
            => Value == null;

        VarDef IVarAssignment.Def 
            => Def;

        dynamic IVarAssignment.Value 
            => Value;

        public int CompareTo(VarAssignment src)
            => Def.CompareTo(src.Def);

        public virtual string Format()
            => $"{Def}={Value}";

        public sealed override string ToString()
            => Format();
    }
}