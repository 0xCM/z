//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    /// <summary>
    /// Defines an untyped logic expression over one or more variables
    /// </summary>
    public sealed class VariedLogicExpr : IVariedLogicExpr
    {
        /// <summary>
        /// The variable-dependent expression
        /// </summary>
        public ILogicExpr BaseExpr {get;}

        /// <summary>
        /// The variables that parametrize the base expression
        /// </summary>
        public ILogicVarExpr[] Vars {get;}

        [MethodImpl(Inline)]
        public VariedLogicExpr(ILogicExpr baseExpr, params LogicVariable[] variables)
        {
            BaseExpr = baseExpr;
            Vars = variables;
        }

        public byte VarCount
        {
            [MethodImpl(Inline)]
            get => (byte)(Vars?.Length ?? 0);
        }

        public void SetVars(params ILogicExpr[] values)
        {
            var n = Math.Min(Vars.Length, values.Length);
            for(var i=0; i<n; i++)
                Vars[i].Set(values[i]);
        }

        public void SetVars(params Bit32[] values)
        {
            var n = Math.Min(Vars.Length, values.Length);
            for(var i=0; i<n; i++)
                Vars[i].Set(values[i]);
        }

        public void SetVars(LiteralLogicSeqExpr values)
        {
            var n = Math.Min(Vars.Length, values.Length);
            for(var i=0; i<n; i++)
                Vars[i].Set(values[i]);
        }

        public string Format()
            => BaseExpr.Format();
    }
}