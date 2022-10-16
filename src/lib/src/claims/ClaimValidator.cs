//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public readonly struct ClaimValidator
    {
        [MethodImpl(Inline), Op]
        public static int length<T>(Span<T> lhs, Span<T> rhs)
            => lhs.Length == rhs.Length ? lhs.Length : AppErrors.ThrowNotEqualNoCaller(lhs.Length, rhs.Length);

        /// <summary>
        /// Creates, but does not throw, a claim exception
        /// </summary>
        /// <param name="claim">The sort of claim that failed</param>
        /// <param name="msg">The failure description</param>
        [MethodImpl(Inline), Op]
        public static ClaimException failed(ClaimKind claim, IAppMsg msg)
            => ClaimException.define(claim, msg.Format());

        /// <summary>
        /// Creates, but does not throw, a claim exception
        /// </summary>
        /// <param name="claim">The sort of claim that failed</param>
        [MethodImpl(Inline), Op]
        public static ClaimException exception(ClaimKind claim, [CallerName] string caller = null, [CallerFile] string file = null, [CallerLine] int? line = null)
            => failed(claim, AppMsg.error("failed", caller, file,line));

        /// <summary>
        /// Raises an exception if an invariant does not hold
        /// </summary>
        /// <param name="condition">The invariant state</param>
        /// <param name="claim">The sort of claim that failed</param>
        public static void require(bool condition, ClaimKind claim, [CallerName] string caller = null, [CallerFile] string file = null, [CallerLine] int? line = null)
        {
            if(!condition)
                throw exception(claim,caller,file,line);
        }

        /// <summary>
        /// Fails unconditionally with a message
        /// </summary>
        /// <param name="msg">The failure reason</param>
        /// <param name="caller">The caller member name</param>
        /// <param name="file">The source file of the calling function</param>
        /// <param name="line">The source file line number where invocation ocurred</param>
        [MethodImpl(Inline), Op]
        public static void fail(string msg, [CallerName] string caller = null, [CallerFile] string file = null, [CallerLine] int? line = null)
            => throw failed(ClaimKind.None, AppMsg.error(msg, caller, file,line));

        [MethodImpl(Inline), Op]
        public static void fail([CallerName] string caller = null, [CallerFile] string file = null, [CallerLine] int? line = null)
            => throw failed(ClaimKind.None, AppMsg.error("failed", caller, file,line));
    }
}