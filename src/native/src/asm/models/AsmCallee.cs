//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    /// <summary>
    /// Represents the target of an invocation
    /// </summary>
    public struct AsmCallee
    {
        [MethodImpl(Inline), Op]
        public static AsmCallee define(MemoryAddress @base, string symbol)
            => new AsmCallee(@base, symbol);

        /// <summary>
        /// The target's base address
        /// </summary>
        public MemoryAddress Base {get;}

        /// <summary>
        /// The target's identifier
        /// </summary>
        public string Identity {get;}

        [MethodImpl(Inline)]
        public AsmCallee(MemoryAddress @base, string identity)
        {
            Identity = identity;
            Base = @base;
        }

        public string Format()
            => string.Concat(Base.Format(), Chars.Colon, Chars.Space, Identity);

        public override string ToString()
            => Format();

    }
}