//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using Caller = System.Runtime.CompilerServices.CallerMemberNameAttribute;
    using File = System.Runtime.CompilerServices.CallerFilePathAttribute;
    using Line = System.Runtime.CompilerServices.CallerLineNumberAttribute;

    using api = CheckPrimalSeq;

    public interface ICheckPrimalSeq : ICheckLengths, ICheckInvariant, ICheckPrimal
    {
        bool TestEq(ReadOnlySpan<char> a, ReadOnlySpan<char> b)
            => api.TestEq(a, b);

        bool TestEq(ReadOnlySpan<byte> a, ReadOnlySpan<byte> b)
            => api.TestEq(a,b);

        bool TestEq(ReadOnlySpan<int> a, ReadOnlySpan<int> b)
            => api.TestEq(a,b);

        bool TestEq(ReadOnlySpan<uint> a, ReadOnlySpan<uint> b)
            => api.TestEq(a, b);

        bool TestEq(ReadOnlySpan<ulong> a, ReadOnlySpan<ulong> b)
            => api.TestEq(a,b);

        void eq(ReadOnlySpan<bool> a, ReadOnlySpan<bool> b, [CallerName] string caller = null, [CallerFile] string file = null, [CallerLine] int? line = null)
            => api.eq(a, b, caller, file, line);

        void eq(ReadOnlySpan<char> a, ReadOnlySpan<char> b, [CallerName] string caller = null, [CallerFile] string file = null, [CallerLine] int? line = null)
            => api.eq(a, b, caller, file, line);

        void eq(ReadOnlySpan<sbyte> a, ReadOnlySpan<sbyte> b, [CallerName] string caller = null, [CallerFile] string file = null, [CallerLine] int? line = null)
            => api.eq(a, b, caller, file, line);

        void eq(ReadOnlySpan<byte> a, ReadOnlySpan<byte> b, [CallerName] string caller = null, [CallerFile] string file = null, [CallerLine] int? line = null)
            => api.eq(a, b, caller, file, line);

        void eq(ReadOnlySpan<int> a, ReadOnlySpan<int> b, [CallerName] string caller = null, [CallerFile] string file = null, [CallerLine] int? line = null)
            => api.eq(a, b, caller, file, line);

        void eq(ReadOnlySpan<uint> a, ReadOnlySpan<uint> b, [CallerName] string caller = null, [CallerFile] string file = null, [CallerLine] int? line = null)
            => api.eq(a, b, caller, file, line);

        void eq(ReadOnlySpan<ulong> a, ReadOnlySpan<ulong> b, [CallerName] string caller = null, [CallerFile] string file = null, [CallerLine] int? line = null)
             => api.eq(a, b, caller, file, line);
   }
}