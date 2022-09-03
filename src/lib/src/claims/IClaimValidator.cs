//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;

    using api = ClaimValidator;

    using Caller = System.Runtime.CompilerServices.CallerMemberNameAttribute;
    using File = System.Runtime.CompilerServices.CallerFilePathAttribute;
    using Line = System.Runtime.CompilerServices.CallerLineNumberAttribute;

    public interface IClaimValidator
    {
        Type HostType
            => GetType();

        ClaimException failed(ClaimKind claim, IAppMsg msg)
            => api.failed(claim, msg);

        void require(bool condition, ClaimKind claim, [CallerName] string caller = null, [CallerFile] string file = null, [CallerLine] int? line = null)
            => api.require(condition,claim, caller,file,line);

        ClaimException failed(ClaimKind claim, [CallerName] string caller = null, [CallerFile] string file = null, [CallerLine] int? line = null)
            => api.failed(claim, AppMsg.error("failed", caller, file,line));

        void failed(string msg, [CallerName] string caller = null, [CallerFile] string file = null, [CallerLine] int? line = null)
            => api.fail(msg, caller,file,line);

        void fail([CallerName] string caller = null, [CallerFile] string file = null, [CallerLine] int? line = null)
            => api.fail(caller,file,line);
    }

    public interface IClaimValidator<V,I> : IClaimValidator
        where V : struct, IClaimValidator<V,I>, I
        where I : IClaimValidator
    {
        I Validator
            => default(V);
    }
}