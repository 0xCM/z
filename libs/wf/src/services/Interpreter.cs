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
        public static Interpreter create(FS.FilePath exe, string args, Action<string> status, Action<string> error, Action<int> exit)
            => new Interpreter(exe, args, status, error, exit);

        Interpreter(FS.FilePath exe, string args, Action<string> status, Action<string> error, Action<int> exit)
        {
            StatusReceiver = status;
            ErrorReceiver = error;
            ExitReceiver = exit;
            Tokens = TokenDispenser.create();
            Worker = new Process();
            var start = new ProcessStartInfo(exe.Name, args)
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
            Worker.EnableRaisingEvents = true;
            Worker.Exited += OnExit;
        }

        Process Worker;

        TokenDispenser Tokens;

        Action<string> StatusReceiver;

        Action<string> ErrorReceiver;

        Action<int> ExitReceiver;

        bool Running;

        void OnStatus(object src, DataReceivedEventArgs e)
        {
            if(e != null && nonempty(e.Data))
                StatusReceiver(e.Data);
        }

        void OnError(object src, DataReceivedEventArgs e)
        {
            if(e != null && nonempty(e.Data))
                ErrorReceiver(e.Data);
        }

        void OnExit(object sender, EventArgs e)
        {
            Running = false;
            ExitReceiver(Worker.ExitCode);
        }

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

        public Outcome Submit(string cmd)
        {
            var result = Outcome.Success;
            try
            {
                start(() => Dispatch(cmd));
            }
            catch(Exception e)
            {
                result = e;
            }
            return result;
        }

        public Outcome WaitForExit()
        {
            var result = Worker.WaitForExit(5000);
            return result ? Outcome.Success : (false, "Worker would not stop");
        }

        void Dispatch(string cmd)
        {
            Worker.StandardInput.WriteLine(cmd);
        }
    }
}