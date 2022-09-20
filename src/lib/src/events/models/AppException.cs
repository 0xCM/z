//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public class AppException : Exception
    {
        public new IAppMsg Message {get;}

        public static AppException define(object reason, string caller, string file, int? line)
            => new AppException(reason?.ToString() ?? EmptyString, caller, file, line);

        public AppException() { }

        public AppException(IAppMsg src)
            : base(src?.Format() ?? EmptyString)
                => Message = src ?? AppMsg.Empty;

        AppException(string msg, string caller, string file, int? line)
            : base(msg ?? EmptyString)
        {
            Message = AppMsg.error(msg ?? EmptyString, caller, file, line);
        }

        public string Format()
            => Message.Format();

        public override string ToString()
            => Format();
    }
}