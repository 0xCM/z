//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    /// <summary>
    /// Defines a script variable
    /// </summary>
    public struct CmdScriptVar : IVarValue<string>
    {
        public static string format(IVarValue var)
            => format(var, Chars.Eq);

        public static string format(IVarValue var, char assign)
            => string.Format("{0}{1}{2}", var.Name, assign, var.Value);

        public static string format(VarContextKind vck, IVarValue var)
            => format(vck,var, Chars.Eq);

        public static string format(VarContextKind vck, IVarValue var, char assign)
            => string.Format("{0}{1}{2}", format(vck, var.Name), assign, var.Value);

        static string format(VarContextKind vck, string name)
            => string.Format(RP.pattern(vck), name);

        /// <summary>
        /// The variable symbol
        /// </summary>
        public string Name {get;}

        /// <summary>
        /// The variable value, possibly empty
        /// </summary>
        public string Value {get;set;}

        [MethodImpl(Inline)]
        public CmdScriptVar(string name, string value)
        {
            Name = name;
            Value = value;
        }

        [MethodImpl(Inline)]
        public CmdScriptVar(string name)
        {
            Name = name;
            Value = EmptyString;
        }

        [MethodImpl(Inline)]
        public string Format()
            => format(this);

        [MethodImpl(Inline)]
        public string Format(VarContextKind vck)
            => format(vck, this);

        public override string ToString()
            => Format();

        public string Resolve(VarContextKind vck)
            => string.Format(RP.pattern(vck), Value);

        [MethodImpl(Inline)]
        public static implicit operator CmdScriptVar((string symbol, string value) src)
            => new CmdScriptVar(src.symbol, src.value);
    }
}