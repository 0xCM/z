//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public sealed class VariableExpr<T> : ILogixVarExpr<T>
        where T : unmanaged
    {
        /// <summary>
        /// The name of the variable
        /// </summary>
        public string Name {get;}

        /// <summary>
        /// The value of the variable
        /// </summary>
        public ILogixExpr<T> Value {get; private set;}

        [MethodImpl(Inline)]
        public VariableExpr(string name, ILogixExpr<T> value)
        {
            Value = value;
            Name = name;
        }

        /// <summary>
        /// Updates the variable's value
        /// </summary>
        /// <param name="value">The new value</param>
        [MethodImpl(Inline)]
        public void Set(ILogixExpr<T> value)
        {
            Value = value;
        }

        [MethodImpl(Inline)]
        public void Set(T value)
        {
            Value = new LogixLiteral<T>(value);
        }

        [MethodImpl(Inline)]
        public void Set(IExprDeprecated value)
            => Value = (ILogixExpr<T>)value;

        public string Format()
            => Format(false);

        public string Format(bool expand)
            => $"{Name}:{typeof(T).DisplayName()}" + (expand ? $" := {Value}" : string.Empty);

        public override string ToString()
            => Format();
    }
}