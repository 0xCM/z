//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    partial class Tooling
    {
        public static Task<ExecToken> redirect(IWfChannel channel, FilePath tool, CmdArgs args, FilePath status, Action<string> receiver = null)
        {
            FilePath alt = (status + FS.ext("alt"));

            ExecToken Run()
            {
                var c1 = default(StreamWriter);
                var c0 = default(StreamWriter);
                var token = ExecToken.Empty;
                
                try
                {
                    void OnStatus(string msg)
                    {
                        if(c0 == null)
                            c0 = status.Utf8Writer(false);
                        c0.WriteLine(msg);
                        receiver?.Invoke(msg);
                    }

                    void OnError(string msg)
                    {
                        if(c1 == null)
                            c1 = alt.Utf8Writer(true);                     

                        channel.Row(msg, FlairKind.StatusData);
                        c1.WriteLine(msg);
                    }


                    var running = channel.Running(args);
                    token = channel.Ran(running, run(spec(tool, args), OnStatus, OnError));
                }
                catch(Exception e)
                {
                    channel.Error(e.Message);
                }
                finally
                {
                    c0?.Dispose();
                    c1?.Dispose();
                }
                return token;

            }

            return sys.start(Run);
        }

        public static Task<ExecToken> redirect(IWfChannel channel, CmdArgs args)
        {
            ExecToken Run()
            {
                var c0Name=$"{Environment.ProcessId}.channels.0";
                var c0Path = AppDb.Service.AppData().Path(c0Name, FileKind.Log);
                var h0 = $"# {args} -> {c0Path}";

                var c1Name = $"{Environment.ProcessId}.channels.1";
                var c1Path = AppDb.Service.AppData().Path(c1Name, FileKind.Log);
                var h1 = $"# {args} -> {c1Path}";
                
                using var c0 = c0Path.Utf8Writer(true);
                c0.WriteLine($"# {c0Name}");
                c0.WriteLine(h0);

                var c1 = default(StreamWriter);

                void Channel0(string msg)
                {
                    channel.Row(msg, FlairKind.Data);
                    c0.WriteLine(msg);
                }

                void Channel1(string msg)
                {
                    if(c1 == null)
                    {
                        c1 = c1Path.Utf8Writer(true);
                        c1.WriteLine($"# {c1Name}");
                        c1.WriteLine(h1);
                    }

                    channel.Row(msg, FlairKind.StatusData);
                    c1.WriteLine(msg);
                }

                var io = new SysIO(Channel0, Channel1);
                var running = channel.Running($"{args} -> ({c0Path}, {c1Path})");
                var status = run(io, args, spec());
                var token = channel.Ran(running, status);
                c1?.Dispose();
                return token;
            }

            return sys.start(Run);
        }
    }
}