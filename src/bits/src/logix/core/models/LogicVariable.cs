//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    /// <summary>
    /// Defines an untyped logic variable
    /// </summary>
    public sealed class LogicVariable : ILogicVarExpr
    {
        /// <summary>
        /// The variable's symbolic identifier
        /// </summary>
        public uint Symbol {get;}

        /// <summary>
        /// The variable value
        /// </summary>
        public ILogicExpr Value {get; private set;}

        /// <summary>
        /// The variable name
        /// </summary>
        public string Name => Symbol.ToString();

        [MethodImpl(Inline)]
        public LogicVariable(uint name, Bit32 init)
        {
            Symbol = name;
            Value = new LiteralLogicExpr(init);
        }

        public bool IsEmpty
        {
            [MethodImpl(Inline)]
            get => Symbol == 0;
        }

        public bool IsNonEmpty
        {
            [MethodImpl(Inline)]
            get => Symbol != 0;
        }

        [MethodImpl(Inline)]
        public void Set(ILogicExpr value)
            => Value = value;

        [MethodImpl(Inline)]
        public void Set(Bit32 value)
            => Value = new LiteralLogicExpr(value);

        [MethodImpl(Inline)]
        public void Set(IExprDeprecated value)
            => Value = (ILogicExpr)value;

        public string Format()
            => Format(false);

        public string Format(bool expand)
            => $"{Name}" + (expand ? $" := {Value}" : string.Empty);

        public override string ToString()
            => Format();
    }
}