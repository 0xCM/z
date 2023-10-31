//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using Caller = System.Runtime.CompilerServices.CallerMemberNameAttribute;
    using File = System.Runtime.CompilerServices.CallerFilePathAttribute;
    using Line = System.Runtime.CompilerServices.CallerLineNumberAttribute;

    public interface ICheckFiles : IClaimValidator
    {
        void Exists(FilePath path, [Caller] string caller = null, [CallerFile] string file = null, [CallerLine] int? line = null)
            => path.Exists.OnNone(() => throw AppException.define($"The file {path} does not exist", caller, file,line));

        void Exists(FolderPath path, [Caller] string caller = null, [CallerFile] string file = null, [CallerLine] int? line = null)
            => path.Exists.OnNone(() => throw AppException.define($"The folder {path} does not exist", caller, file,line));
    }
}