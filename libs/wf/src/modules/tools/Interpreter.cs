//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System.Diagnostics;

    using static core;

    public class Interpreter : IDisposable
    {
        public static Interpreter create(WfEmit channel, FilePath path, params string[] args)
            => new Interpreter(channel, path, args);

        Interpreter(WfEmit channel, FilePath path, string[] args)
        {
            Channel = channel;
            Tokens = TokenDispenser.create();
            Worker = new Process();
            var start = new ProcessStartInfo(path.Format(), text.join(Chars.Space,args))
            {
                UseShellExecute = false,
                RedirectStandardError = true,
                RedirectStandardOutput = true,
                RedirectStandardInput = true,
                ErrorDialog = false,
                CreateNoWindow = true,
            };

            Worker.StartInfo = start;
            Worker.OutputDataReceived += OnStatus;
            Worker.ErrorDataReceived += OnError;
            Worker.Exited += OnExit;
            Worker.EnableRaisingEvents = true;
        }

        readonly WfEmit Channel;

        Process Worker;

        TokenDispenser Tokens;

        void OnStatus(object _, DataReceivedEventArgs e)
        {
            if(e != null && nonempty(e.Data))
            {
                Channel.Status(e.Data);
            }
        }

        void OnError(object _, DataReceivedEventArgs e)
        {
            if(e != null && nonempty(e.Data))
            {
                Channel.Status(e.Data);
            }
        }

        void OnExit(object _, EventArgs e)
        {
            Running = false;
            Channel.Status($"Exit code {Worker.ExitCode}");
        }

        bool Running;

        public void Start()
        {
            Worker.Start();
            Worker.BeginOutputReadLine();
            Worker.BeginErrorReadLine();
            Running = true;
        }

        public void Dispose()
        {
            Worker.Dispose();
        }

        public void Submit(string cmd)
        {
            try
            {
                start(() => Worker.StandardInput.WriteLine(cmd));
            }
            catch(Exception e)
            {
                Channel.Error(e);
            }
        }

        public bool WaitForExit(Duration time)
            => Worker.WaitForExit((int)time.Ms);
    }
}