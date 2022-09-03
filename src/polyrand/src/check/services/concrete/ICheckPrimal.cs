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
        bool eq(bit a, bit b, [CallerName] string caller = null, [CallerFile] string file = null, [CallerLine] int? line = null)
            => api.eq(a, b, caller, file, line);

        bool eq(char a, char b, [CallerName] string caller = null, [CallerFile] string file = null, [CallerLine] int? line = null)
            => api.eq(a, b, caller, file, line);

        bool eq(string a, string b, [CallerName] string caller = null, [CallerFile] string file = null, [CallerLine] int? line = null)
            => api.eq(a, b, caller, file, line);

        bool eq(byte a, byte b, [CallerName] string caller = null, [CallerFile] string file = null, [CallerLine] int? line = null)
            => api.eq(a, b, caller, file, line);

        bool eq(sbyte a, sbyte b, [CallerName] string caller = null, [CallerFile] string file = null, [CallerLine] int? line = null)
            => api.eq(a, b, caller, file, line);

        bool eq(short a, short b, [CallerName] string caller = null, [CallerFile] string file = null, [CallerLine] int? line = null)
            => api.eq(a, b, caller, file, line);

        bool eq(ushort a, ushort b, [CallerName] string caller = null, [CallerFile] string file = null, [CallerLine] int? line = null)
            => api.eq(a, b, caller, file, line);

        bool eq(int a, int b, [CallerName] string caller = null, [CallerFile] string file = null, [CallerLine] int? line = null)
            => api.eq(a, b, caller, file, line);

        bool eq(uint a, uint b, [CallerName] string caller = null, [CallerFile] string file = null, [CallerLine] int? line = null)
            => api.eq(a, b, caller, file, line);

        bool eq(long a, long b, [CallerName] string caller = null, [CallerFile] string file = null, [CallerLine] int? line = null)
            => api.eq(a, b, caller, file, line);

        bool eq(ulong a, ulong b, [CallerName] string caller = null, [CallerFile] string file = null, [CallerLine] int? line = null)
            => api.eq(a, b, caller, file, line);

        bool eq(bool a, bool b, [CallerName] string caller = null, [CallerFile] string file = null, [CallerLine] int? line = null)
            => api.eq(a, b, caller, file, line);

        bool eq(uint a, uint b, AppMsg msg)
            => a == b ? true : throw failed(ClaimKind.Eq, msg);

        bool neq(char a, char b, [CallerName] string caller = null, [CallerFile] string file = null, [CallerLine] int? line = null)
            => a != b ? true : throw failed(ClaimKind.NEq, NotEqual(a, b, caller, file, line));

        bool neq(string a, string b, [CallerName] string caller = null, [CallerFile] string file = null, [CallerLine] int? line = null)
            => a != b ? true : throw failed(ClaimKind.NEq, Equal(a, b, caller, file, line));

        bool neq(long a, long b, [CallerName] string caller = null, [CallerFile] string file = null, [CallerLine] int? line = null)
            => a != b ? true : throw failed(ClaimKind.NEq, Equal(a, b, caller, file, line));

        bool eq(int? a, int? b, [CallerName] string caller = null, [CallerFile] string file = null, [CallerLine] int? line = null)
            => a == b ? true : throw failed(ClaimKind.Eq, NotEqual(a, b, caller, file, line));

        bool eq(int? a, int? b, string msg, [CallerName] string caller = null, [CallerFile] string file = null, [CallerLine] int? line = null)
            => a == b ? true : throw failed(ClaimKind.Eq, NotEqual(a, b, caller, file, line));
    }
}