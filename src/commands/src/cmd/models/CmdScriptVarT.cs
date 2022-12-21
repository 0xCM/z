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
        public string VarName {get;}

        /// <summary>
        /// The variable value, possibly empty
        /// </summary>
        public T VarValue {get;set;}

        [MethodImpl(Inline)]
        public CmdScriptVar(string name, T value)
        {
            VarName = name;
            VarValue = value;
        }

        [MethodImpl(Inline)]
        public string Format()
            => CmdScriptVar.format(this);

        [MethodImpl(Inline)]
        public string Format(VarContextKind vck)
            => CmdScriptVar.format(vck, this);

        public override string ToString()
            => Format();

        public string Resolve(VarContextKind vck)
            => string.Format(RP.pattern(vck), VarValue);
    }
}