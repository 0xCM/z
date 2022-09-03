//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static ErrorMsg;
    using static ClaimValidator;

    using Caller = System.Runtime.CompilerServices.CallerMemberNameAttribute;
    using File = System.Runtime.CompilerServices.CallerFilePathAttribute;
    using Line = System.Runtime.CompilerServices.CallerLineNumberAttribute;

    public readonly struct CheckInvariant : ICheckInvariant
    {
        /// <summary>
        /// Raises an exception upon invariant failure
        /// </summary>
        /// <param name="invariant"></param>
        /// <param name="caller">The caller member name</param>
        /// <param name="file">The source file of the calling function</param>
        /// <param name="line">The source file line number where invocation ocurred</param>
        public static bool require(bool invariant, [CallerName] string caller = null, [CallerFile] string file = null, [CallerLine] int? line = null)
            => invariant ? true : throw failed(ClaimKind.Invariant, InvariantFailure(caller, file, line));

        /// <summary>
        /// Raises an exception upon invariant failure
        /// </summary>
        /// <param name="invariant">The value claimed to be false</param>
        /// <param name="msg">An optional message describing the assertion</param>
        /// <param name="caller">The caller member name</param>
        /// <param name="file">The source file of the calling function</param>
        /// <param name="line">The source file line number where invocation ocurred</param>
        public static void require(bool invariant, string msg, [CallerName] string caller = null, [CallerFile] string file = null, [CallerLine] int? line = null)
            => invariant.OnNone(() => throw failed(ClaimKind.Invariant,  InvariantFailure(msg, caller, file,line)));

        /// <summary>
        /// Raises an exception upon invariant failure
        /// </summary>
        /// <param name="src"></param>
        /// <param name="msg">An optional message describing the assertion</param>
        /// <param name="caller">The caller member name</param>
        /// <param name="file">The source file of the calling function</param>
        /// <param name="line">The source file line number where invocation ocurred</param>
        /// <typeparam name="T"></typeparam>
        public static void require<T>(bool src, string msg = null, [CallerName] string caller = null, [CallerFile] string file = null, [CallerLine] int? line = null)
            where T : unmanaged
                => src.OnNone(() => throw failed(ClaimKind.Invariant, NotTrue($"{typeof(T).NumericKind().Format()}" + (msg ?? string.Empty) , caller, file, line)));

        /// <summary>
        /// Asserts the operand is false
        /// </summary>
        /// <param name="src">The value claimed to be false</param>
        /// <param name="msg">An optional message describint the assertion</param>
        /// <param name="caller">The caller member name</param>
        /// <param name="file">The source file of the calling function</param>
        /// <param name="line">The source file line number where invocation ocurred</param>
        public static void not(bool src, string msg = null, [CallerName] string caller = null, [CallerFile] string file = null, [CallerLine] int? line = null)
            => src.OnSome(() => throw failed(ClaimKind.False, NotFalse(msg, caller, file,line)));
    }
}