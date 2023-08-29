//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;
    using static ErrorMsg;

    using api = ClaimValidator;

    [ApiHost]
    public readonly struct PrimalClaims
    {
        [Op]
        public static bool require(bool src, string msg = null, [CallerName] string caller = null, [CallerFile] string file = null, [CallerLine] int? line = null)
            => !src ? @throw<bool>(ClaimException.define(ClaimKind.Invariant,NotTrue(msg, caller, file,line).Format())) : true;

        [Op]
        public static bool eq(char a, char b, [CallerName] string caller = null, [CallerFile] string file = null, [CallerLine] int? line = null)
            => a == b ? true : @throw<bool>(Failed(ClaimKind.Eq, NotEqual(a, b, caller, file, line)));

        [Op]
        public static bool eq(string a, string b, [CallerName] string caller = null, [CallerFile] string file = null, [CallerLine] int? line = null)
            => string.Equals(a,b) ? true : @throw<bool>(Failed(ClaimKind.Eq, NotEqual(a, b, caller, file, line)));

        [Op]
        public static bool eq(byte a, byte b, [CallerName] string caller = null, [CallerFile] string file = null, [CallerLine] int? line = null)
            => a == b ? true : @throw<bool>(Failed(ClaimKind.Eq, NotEqual(a,b, caller, file, line)));

        [Op]
        public static bool eq(sbyte a, sbyte b, [CallerName] string caller = null, [CallerFile] string file = null, [CallerLine] int? line = null)
            => a == b ? true : @throw<bool>(Failed(ClaimKind.Eq, NotEqual(a,b, caller, file, line)));

        [Op]
        public static bool eq(short a, short b, [CallerName] string caller = null, [CallerFile] string file = null, [CallerLine] int? line = null)
            => a == b ? true : @throw<bool>(Failed(ClaimKind.Eq, NotEqual(a, b, caller, file, line)));

        [Op]
        public static bool eq(ushort a, ushort b, [CallerName] string caller = null, [CallerFile] string file = null, [CallerLine] int? line = null)
            => a == b ? true : @throw<bool>(Failed(ClaimKind.Eq, NotEqual(a, b, caller, file, line)));

        [Op]
        public static bool eq(int a, int b, [CallerName] string caller = null, [CallerFile] string file = null, [CallerLine] int? line = null)
            => a == b ? true : @throw<bool>(Failed(ClaimKind.Eq, NotEqual(a, b, caller, file, line)));

        [Op]
        public static bool eq(uint a, uint b, [CallerName] string caller = null, [CallerFile] string file = null, [CallerLine] int? line = null)
            => a == b ? true : @throw<bool>(Failed(ClaimKind.Eq, NotEqual(a, b, caller, file, line)));

        [Op]
        public static bool eq(long a, long b, [CallerName] string caller = null, [CallerFile] string file = null, [CallerLine] int? line = null)
            => a == b ? true : @throw<bool>(Failed(ClaimKind.Eq, NotEqual(a,b, caller, file, line)));

        [Op]
        public static bool eq(ulong a, ulong b, [CallerName] string caller = null, [CallerFile] string file = null, [CallerLine] int? line = null)
            => a == b ? true : @throw<bool>(Failed(ClaimKind.Eq, NotEqual(a, b, caller, file, line)));

        [Op]
        public static bool eq(bool a, bool b, [CallerName] string caller = null, [CallerFile] string file = null, [CallerLine] int? line = null)
            => a == b ? true : @throw<bool>(Failed(ClaimKind.Eq, NotEqual(a, b, caller, file, line)));

        [Op]
        public static bool eq(bit a, bit b, [CallerName] string caller = null, [CallerFile] string file = null, [CallerLine] int? line = null)
            => a == b ? true : @throw<bool>(Failed(ClaimKind.Eq, NotEqual(a, b, caller, file, line)));

        [Op]
        public static bool neq(bit a, bit b, [CallerName] string caller = null, [CallerFile] string file = null, [CallerLine] int? line = null)
            => a != b ? true : @throw<bool>(Failed(ClaimKind.Eq, Equal(a, b, caller, file, line)));

        [Op]
        public static bool neq(char a, char b, [CallerName] string caller = null, [CallerFile] string file = null, [CallerLine] int? line = null)
            => a != b ? true : @throw<bool>(Failed(ClaimKind.NEq, Equal(a, b, caller, file, line)));

        [Op]
        public static bool neq(string a, string b, [CallerName] string caller = null, [CallerFile] string file = null, [CallerLine] int? line = null)
            => a != b ? true : @throw<bool>(Failed(ClaimKind.NEq, Equal(a, b, caller, file, line)));

        [Op]
        public static bool neq(long a, long b, [CallerName] string caller = null, [CallerFile] string file = null, [CallerLine] int? line = null)
            => a != b ? true : @throw<bool>(Failed(ClaimKind.NEq, Equal(a, b, caller, file, line)));

        [Op]
        static ClaimException Failed(ClaimKind claim, IAppMsg msg)
            => api.failed(claim, msg);
    }
}