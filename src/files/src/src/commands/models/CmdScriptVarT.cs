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
        public string Name {get;}

        /// <summary>
        /// The variable value, possibly empty
        /// </summary>
        public T Value {get;set;}

        [MethodImpl(Inline)]
        public CmdScriptVar(string name, T value)
        {
            Name = name;
            Value = value;
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
            => string.Format(RP.pattern(vck), Value);
    }
}