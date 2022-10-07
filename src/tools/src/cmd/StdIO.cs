//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    class StdIO : IStdIO
    {
        readonly Action<string> StatusHandler;

        readonly Action<string> ErrorHandler;

        public StdIO(Action<string> status, Action<string> error)
        {
            StatusHandler = status;
            ErrorHandler = error;
        }

        public void Status(string msg)
        {
            StatusHandler(msg);
        }
        
        public void Error(string msg)
        {
            ErrorHandler(msg);
        }

    }
}