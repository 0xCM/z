//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using Caller = System.Runtime.CompilerServices.CallerMemberNameAttribute;
    using File = System.Runtime.CompilerServices.CallerFilePathAttribute;
    using Line = System.Runtime.CompilerServices.CallerLineNumberAttribute;

    using api = CheckInvariant;

    public interface ICheckInvariant : IClaimValidator
    {
        bool require(bool invariant, [CallerName] string caller = null, [CallerFile] string file = null, [CallerLine] int? line = null)
            => api.require(invariant, caller, file, line);

        void require<T>(T msg, bool invariant, [CallerName] string caller = null, [CallerFile] string file = null, [CallerLine] int? line = null)
            => api.require(invariant, msg?.ToString() ?? string.Empty, caller, file, line);

        void no<T>(bool src, T msg = default, [CallerName] string caller = null, [CallerFile] string file = null, [CallerLine] int? line = null)
            => api.not(src, msg?.ToString() ?? string.Empty, caller, file, line);

        void yea(bool src, string msg = null, [CallerName] string caller = null, [CallerFile] string file = null, [CallerLine] int? line = null)
            => api.require(src, msg, caller, file, line);

        void nea(bool src, string msg = null, [CallerName] string caller = null, [CallerFile] string file = null, [CallerLine] int? line = null)
            => api.not(src, msg, caller, file, line);
    }
}