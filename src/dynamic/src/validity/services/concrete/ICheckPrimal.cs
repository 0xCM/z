//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static ErrorMsg;

    using api = PrimalClaims;
    using Caller = System.Runtime.CompilerServices.CallerMemberNameAttribute;
    using File = System.Runtime.CompilerServices.CallerFilePathAttribute;
    using Line = System.Runtime.CompilerServices.CallerLineNumberAttribute;

    public interface ICheckPrimal : IClaimValidator
    {
        bool eq(bit a, bit b, [Caller] string caller = null, [File] string file = null, [Line] int? line = null)
            => api.eq(a, b, caller, file, line);

        bool eq(char a, char b, [Caller] string caller = null, [File] string file = null, [Line] int? line = null)
            => api.eq(a, b, caller, file, line);

        bool eq(string a, string b, [Caller] string caller = null, [File] string file = null, [Line] int? line = null)
            => api.eq(a, b, caller, file, line);

        bool eq(byte a, byte b, [Caller] string caller = null, [File] string file = null, [Line] int? line = null)
            => api.eq(a, b, caller, file, line);

        bool eq(sbyte a, sbyte b, [Caller] string caller = null, [File] string file = null, [Line] int? line = null)
            => api.eq(a, b, caller, file, line);

        bool eq(short a, short b, [Caller] string caller = null, [File] string file = null, [Line] int? line = null)
            => api.eq(a, b, caller, file, line);

        bool eq(ushort a, ushort b, [Caller] string caller = null, [File] string file = null, [Line] int? line = null)
            => api.eq(a, b, caller, file, line);

        bool eq(int a, int b, [Caller] string caller = null, [File] string file = null, [Line] int? line = null)
            => api.eq(a, b, caller, file, line);

        bool eq(uint a, uint b, [Caller] string caller = null, [File] string file = null, [Line] int? line = null)
            => api.eq(a, b, caller, file, line);

        bool eq(long a, long b, [Caller] string caller = null, [File] string file = null, [Line] int? line = null)
            => api.eq(a, b, caller, file, line);

        bool eq(ulong a, ulong b, [Caller] string caller = null, [File] string file = null, [Line] int? line = null)
            => api.eq(a, b, caller, file, line);

        bool eq(bool a, bool b, [Caller] string caller = null, [File] string file = null, [Line] int? line = null)
            => api.eq(a, b, caller, file, line);

        bool eq(uint a, uint b, AppMsg msg)
            => a == b ? true : throw failed(ClaimKind.Eq, msg);

        bool neq(char a, char b, [Caller] string caller = null, [File] string file = null, [Line] int? line = null)
            => a != b ? true : throw failed(ClaimKind.NEq, NotEqual(a, b, caller, file, line));

        bool neq(string a, string b, [Caller] string caller = null, [File] string file = null, [Line] int? line = null)
            => a != b ? true : throw failed(ClaimKind.NEq, Equal(a, b, caller, file, line));

        bool neq(long a, long b, [Caller] string caller = null, [File] string file = null, [Line] int? line = null)
            => a != b ? true : throw failed(ClaimKind.NEq, Equal(a, b, caller, file, line));

        bool eq(int? a, int? b, [Caller] string caller = null, [File] string file = null, [Line] int? line = null)
            => a == b ? true : throw failed(ClaimKind.Eq, NotEqual(a, b, caller, file, line));

        bool eq(int? a, int? b, string msg, [Caller] string caller = null, [File] string file = null, [Line] int? line = null)
            => a == b ? true : throw failed(ClaimKind.Eq, NotEqual(a, b, caller, file, line));
    }
}