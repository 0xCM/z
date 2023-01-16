//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public class SysIO : ISysIO
    {        
        readonly Action<string> StatusHandler;

        readonly Action<string> ErrorHandler;

        readonly Func<string> InputProvider;
        
        static string empty() => EmptyString;

        public SysIO(Action<string> status, Action<string> error, Func<string> input = null)
        {
            StatusHandler = status;
            ErrorHandler = error;
            InputProvider = input ?? empty;
        }

        public void Status(string msg)
            => StatusHandler(msg);
        
        public void Error(string msg)
            => ErrorHandler(msg);

        public string Input()
        {
            return InputProvider();
        }
    }
}