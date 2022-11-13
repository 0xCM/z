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
            => string.Format("{0}{1}{2}", var.VarName, assign, var.VarValue);

        public static string format(VarContextKind vck, IVarValue var)
            => format(vck,var, Chars.Eq);

        public static string format(VarContextKind vck, IVarValue var, char assign)
            => string.Format("{0}{1}{2}", format(vck, var.VarName), assign, var.VarValue);

        static string format(VarContextKind vck, string name)
            => string.Format(RP.pattern(vck), name);

        /// <summary>
        /// The variable symbol
        /// </summary>
        public string VarName {get;}

        /// <summary>
        /// The variable value, possibly empty
        /// </summary>
        public string VarValue {get;set;}

        [MethodImpl(Inline)]
        public CmdScriptVar(string name, string value)
        {
            VarName = name;
            VarValue = value;
        }

        [MethodImpl(Inline)]
        public CmdScriptVar(string name)
        {
            VarName = name;
            VarValue = EmptyString;
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
            => string.Format(RP.pattern(vck), VarValue);

        [MethodImpl(Inline)]
        public static implicit operator CmdScriptVar((string symbol, string value) src)
            => new CmdScriptVar(src.symbol, src.value);
    }
}