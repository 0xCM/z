//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    public abstract class Interpreter<S> : WfSvc<S>
        where S : Interpreter<S>, new()
    {
        public static S create()
            => new S();

        bool _Initialized;

        bool _Running;

        protected Interpreter()
        {
            Name = typeof(S).Name;
            Frequency = new TimeSpan(0, 0, 0, 0, 50);
            CommandQueue = new ConcurrentQueue<string>();
            ExecLog = new ConcurrentDictionary<ulong,ExecToken>();
            DispatchKeys = new ConcurrentBag<Guid>();
            Tokens = TokenDispenser.create();
            _Initialized = false;
            _Running = false;

        }

        public NameOld Name {get;}

        Duration Frequency;

        Process Worker;

        Task SpinTask;

        ExecToken Token;

        TokenDispenser Tokens;

        readonly ConcurrentQueue<string> CommandQueue;

        readonly ConcurrentBag<Guid> DispatchKeys;

        readonly ConcurrentDictionary<ulong,ExecToken> ExecLog;

        public void Submit(string command)
        {
            try
            {
                var key = Guid.NewGuid();
                DispatchKeys.Add(key);
                CommandQueue.Enqueue(string.Format("echo dispatching:{0}", key));
                CommandQueue.Enqueue(command);
                CommandQueue.Enqueue(string.Format("echo executed:{0}", key));
            }
            catch(Exception e)
            {
                Error(e);
            }
        }

        protected virtual string StartupArgs {get;}
            = EmptyString;

        protected abstract FS.FilePath ExePath {get;}

        public Task RunAsync()
        {
            if(!_Initialized)
                Errors.Throw("Not Initialized");

            Worker.Start();
            Worker.BeginOutputReadLine();
            Worker.BeginErrorReadLine();
            _Running = true;
            SpinTask = core.start(() => Spin());
            return SpinTask;
        }

        protected override void Initialized()
        {
            try
            {
                Worker = new Process();

                var start = new ProcessStartInfo(ExePath.Name, StartupArgs)
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
                Worker.Exited += Exited;
                _Initialized = true;
            }
            catch(Exception e)
            {
                Error(e);
                throw;
            }
        }

        public virtual void SubmitStop()
        {
            exit();
        }

        void Exited(object sender, EventArgs e)
        {
            Status("Process exit event received");
        }

        void OnStatus(object sender, DataReceivedEventArgs e)
        {
            if(e != null && e.Data != null)
                Status(e.Data);
        }

        void OnError(object sender, DataReceivedEventArgs e)
        {
            if(e != null && e.Data != null)
            {
                Error(e.Data);
            }
        }

        protected override void Disposing()
        {
            if(Worker != null)
                Worker.Close();
        }

        void Dispatch()
        {
            if(_Running)
            {
                if(CommandQueue.TryDequeue(out var cmd))
                {
                    var token = Tokens.Open();
                    ExecLog[token.StartSeq] = token;
                    Worker.StandardInput.WriteLine(cmd);
                    Dispatch();
                }
            }
        }

        void Spin()
        {
            while(true && _Running)
            {
                Dispatch();
                delay(Frequency);
            }
        }

        public ExecToken WaitForExit()
        {
            SubmitStop();
            Worker.WaitForExit();
            return Token;
        }

        public void exit()
            => Submit("exit");
    }
}