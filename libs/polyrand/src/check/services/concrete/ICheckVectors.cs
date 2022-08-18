//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static ErrorMsg;

    using Caller = System.Runtime.CompilerServices.CallerMemberNameAttribute;
    using File = System.Runtime.CompilerServices.CallerFilePathAttribute;
    using Line = System.Runtime.CompilerServices.CallerLineNumberAttribute;

    public interface ICheckVectors : IChecking, ICheckPrimalSeq, ICheckNumeric, ICheckSets, ICheckSpanBlocks
    {
        /// <summary>
        /// Asserts the equality of two vectors
        /// </summary>
        /// <param name="a">The left vector</param>
        /// <param name="b">The right vector</param>
        /// <param name="caller">The caller member name</param>
        /// <param name="file">The source file of the calling function</param>
        /// <param name="line">The source file line number where invocation ocurred</param>
        void veq<T>(Vector128<T> a, Vector128<T> b, [CallerName] string caller = null, [CallerFile] string file = null, [CallerLine] int? line = null)
            where T : unmanaged
        {
            if(!a.Equals(b))
                throw failed(ClaimKind.Eq, NotEqual(a,b, caller, file, line));
        }

        /// <summary>
        /// Asserts the equality of two vectors
        /// </summary>
        /// <param name="a">The left vector</param>
        /// <param name="b">The right vector</param>
        /// <param name="caller">The caller member name</param>
        /// <param name="file">The source file of the calling function</param>
        /// <param name="line">The source file line number where invocation ocurred</param>
        void veq<T>(Vector256<T> a, Vector256<T> b, [CallerName] string caller = null, [CallerFile] string file = null, [CallerLine] int? line = null)
            where T : unmanaged
        {
            if(!a.Equals(b))
                throw failed(ClaimKind.Eq, NotEqual(a,b, caller, file, line));
        }

        void eq<T>(Vector128<T> a, Vector128<T> b, [CallerName] string caller = null, [CallerFile] string file = null, [CallerLine] int? line = null)
            where T : unmanaged
        {
            if(!a.Equals(b))
                throw failed(ClaimKind.Eq, NotEqual(a, b, caller, file, line));
        }

        void neq<T>(Vector128<T> a, Vector128<T> b, [CallerName] string caller = null, [CallerFile] string file = null, [CallerLine] int? line = null)
            where T : unmanaged
        {
            if(a.Equals(b))
                throw failed(ClaimKind.NEq, Equal(a,b, caller, file, line));
        }

        void eq<T>(Vector256<T> a, Vector256<T> b, [CallerName] string caller = null, [CallerFile] string file = null, [CallerLine] int? line = null)
            where T : unmanaged
        {
            if(!a.Equals(b))
                throw failed(ClaimKind.Eq, NotEqual(a,b, caller, file, line));
        }

        void neq<T>(Vector256<T> a, Vector256<T> b, [CallerName] string caller = null, [CallerFile] string file = null, [CallerLine] int? line = null)
            where T : unmanaged
        {
            if(a.Equals(b))
                throw failed(ClaimKind.NEq, Equal(a,b, caller, file, line));
        }

        void eq<T>(Vector512<T> a, Vector512<T> b, [CallerName] string caller = null, [CallerFile] string file = null, [CallerLine] int? line = null)
            where T : unmanaged
        {
            if(!a.Equals(b))
                throw failed(ClaimKind.Eq, NotEqual(a,b, caller, file, line));
        }

        void neq<T>(Vector512<T> a, Vector512<T> b, [CallerName] string caller = null, [CallerFile] string file = null, [CallerLine] int? line = null)
            where T : unmanaged
        {
            if(a.Equals(b))
                throw failed(ClaimKind.NEq, Equal(a,b, caller, file, line));
        }
    }
}