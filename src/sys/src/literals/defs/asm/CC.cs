//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using CC = System.Runtime.InteropServices.CallingConvention;

    [LiteralProvider("asm")]
    public class CallCv
    {
        /// <summary>
        /// Specifies the <see cref='CC.StdCall'/> calling convention where the
        /// callee is responsible for stack management
        /// </summary>
        /// <remarks>
        /// This is the default PInvoke convention
        /// </remarks>
        public const CC StdCall = CC.StdCall;

        /// <summary>
        /// Specifies the <see cref='CC.Cdecl'/> calling convention where the caller
        /// is responsible for stack management
        /// </summary>
        /// <remarks>
        /// According to the runtime documentation, "This enables calling functions with varargs, which
        /// makes it appropriate to use for methods that accept a variable number of parameters,
        /// such as Printf".
        /// </remarks>
        public const CC Cdecl = CC.Cdecl;

        /// <summary>
        /// Specifies the <see cref='CC.ThisCall'/> calling convention where first argument is <see cref='this'/> and is placed in ECX/RCX
        /// </summary>
        public const CC ThisCall = CC.ThisCall;
    }
}