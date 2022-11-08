//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System.IO;

    struct WfLogger : IEventSink, ISink<IEvent>, ISink<IAppMsg>, IDisposable
    {
        public FilePath StatusPath {get;}

        public FilePath ErrorPath {get;}

        readonly FileStream Status;

        public WfLogger(LogSettings config)
        {
            StatusPath = config.StatusPath;
            ErrorPath = config.ErrorPath;
            StatusPath.Delete();
            ErrorPath.Delete();
            Status = StatusPath.Stream();
        }

        public void Dispose()
        {
            Status?.Flush();
            Status?.Dispose();
        }

        [MethodImpl(Inline)]
        void Display(IAppMsg src)
            => term.print(src);

        [MethodImpl(Inline)]
        void Display(IEvent src)
            => term.print(src);

        [MethodImpl(Inline)]
        static string format(ITextual src)
            => string.Concat(src.Format(), Eol);

        [MethodImpl(Inline)]
        static string summary(IErrorEvent src)
            => string.Concat(src.Format(), Eol);

        public void Deposit(IAppMsg e)
        {
            try
            {
                Display(e);

                if(e.IsError)
                    ErrorPath.AppendLines(e.Format());

                FS.write(format(e), Status);
            }
            catch(Exception error)
            {
                term.errlabel(error, "EventLogError");
            }
        }

        void Emit(IEvent e)
        {
            Display(e);

            try
            {
                if(e.IsError)
                    ErrorPath.AppendLines(e.Format());
                FS.write(e.Format(), Status);
            }
            catch(Exception error)
            {
                term.errlabel(error, "EventLogError");
            }
        }

        // [MethodImpl(Inline)]
        // public void Deposit(IEvent e)
        //     => Emit(e);

        // public void Deposit(object src)
        // {
        //     if(src is IWfEvent e)
        //         Deposit(e);
        //     else if(src is IAppMsg m)
        //         Deposit(m);
        // }

        [MethodImpl(Inline)]
        public void Deposit(IEvent e)
        {
            Display(e);

            try
            {
                if(e is IErrorEvent error)
                {
                    ErrorPath.AppendLines(e.Format());
                    FS.write(summary(error), Status);
                }
                else
                    FS.write(e.Format(), Status);
            }
            catch(Exception error)
            {
                term.errlabel(error, "EventLogError");
            }
        }
    }
}