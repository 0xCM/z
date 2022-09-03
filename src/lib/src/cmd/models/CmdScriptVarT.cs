//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    /// <summary>
    /// Defines a script variable
    /// </summary>
    public struct CmdScriptVar<T> : ICmdScriptVar<T>
    {
        /// <summary>
        /// The variable symbol
        /// </summary>
        public Name VarName {get;}

        /// <summary>
        /// The variable value, possibly empty
        /// </summary>
        public T VarValue {get;set;}

        [MethodImpl(Inline)]
        public CmdScriptVar(Name name, T value)
        {
            VarName = name;
            VarValue = value;
        }

        [MethodImpl(Inline)]
        public string Format()
            => ExprFormatters.format(this);

        [MethodImpl(Inline)]
        public string Format(VarContextKind vck)
            => ExprFormatters.format(vck, this);

        public override string ToString()
            => Format();

        public string Resolve(VarContextKind vck)
            => string.Format(RpOps.pattern(vck), VarValue);

        [MethodImpl(Inline)]
        public static implicit operator CmdScriptVar<T>((Name symbol, T value) src)
            => new CmdScriptVar<T>(src.symbol, src.value);
    }
}