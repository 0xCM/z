//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    /// <summary>
    /// Captures operation invocation information from the client perspective
    /// </summary>
    public struct AsmCallInfo
    {
        [MethodImpl(Inline), Op]
        public static AsmCallInfo define(AsmCallSite callsite, AsmCallee target)
            => new AsmCallInfo(callsite, target);

        /// <summary>
        /// The base-relative address that captures the offset follows the client call instruction
        /// </summary>
        public AsmCallSite CallSite;

        /// <summary>
        /// The argument supplied to the call instruction
        /// </summary>
        public AsmCallee Target;

        [MethodImpl(Inline)]
        public AsmCallInfo(AsmCallSite callsite, AsmCallee target)
        {
            CallSite = callsite;
            Target = target;
        }

        public string Format()
            => string.Format("{0} -> {2}", CallSite, Target);

        public override string ToString()
            => Format();
    }
}