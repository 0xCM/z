//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using XF = ExprPatterns;

    /// <summary>
    /// Binds a variable to a value
    /// </summary>
    public class BoundVar : IBinding
    {
        public readonly Var Var;

        public dynamic Value {get;}

        [MethodImpl(Inline)]
        public BoundVar(Var var, Value<dynamic> val)
        {
            Var = var;
            Value = val;
        }

        public @string Name
        {
            [MethodImpl(Inline)]
            get => Var.Name;
        }

        public string Format()
           => string.Format(XF.Binding, Var.Name, Value);

        public override string ToString()
            => Format();
    }
}