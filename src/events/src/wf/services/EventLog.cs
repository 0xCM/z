//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

using System.IO;

public class EventLog : IEventSink, ISink<IAppMsg>, IDisposable
{
    public static EventLog open(LogSettings config)
        => new (config);

    public FilePath StatusPath {get;}

    public FilePath ErrorPath {get;}

    readonly FileStream Status;

    public EventLog(LogSettings config)
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

    [MethodImpl(Inline)]
    public void Deposit(IEvent e)
    {
        Display(e);

        try
        {
            if(e.IsError)
            {
                ErrorPath.AppendLines(e.Format());
                FS.write(string.Concat(e.Format(), Eol), Status);
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
