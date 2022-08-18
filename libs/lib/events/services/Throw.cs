//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [ApiHost]
    public readonly struct Throw
    {
        [Op]
        public static void OnError(Outcome result, [CallerName]string caller = null, [CallerFile] string? file = null, [CallerLine] int? line = null)
        {
            if(result.Fail)
                sourced(result.Message, caller, file, line);
        }

        [Op]
        public static void e(Exception e)
            => throw e;

        public static T e<T>(Exception e)
            => throw e;

        [Op]
        public static void sourced(string msg, [CallerName]string caller = null, [CallerFile] string? file = null, [CallerLine] int? line = null)
            => sourced(msg, AppMsg.orginate(caller,file,line));

        [Op]
        public static void message(string msg)
            => throw new Exception(msg);

        [Op]
        public static void message(Func<string> f)
            => throw new Exception(f());

        [Op]
        public static void sourced(string msg, in AppMsgSource src)
            => throw new Exception(string.Format("{0} {1}", msg, src.Format()));
    }
}