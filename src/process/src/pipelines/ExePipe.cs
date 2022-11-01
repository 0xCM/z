//-----------------------------------------------------------------------------
// Copyright   :  (c) Microsoft
// License     :  MIT
// Source      : Adapted from miengine/src/WindowsDebugLauncher/DebugLauncher.cs
//-----------------------------------------------------------------------------
namespace Z0
{
    using System.Globalization;
    using System.IO.Pipes;
    using System.Security.Principal;
    using System.Text;

    public class ExeStreams : IDisposable
    {
        readonly NamedPipeClientStream CmdSource;

        readonly StreamReader CmdReader;

        readonly NamedPipeClientStream Targets;

        readonly StreamWriter TargetEmitter;

        readonly NamedPipeClientStream Errors;

        readonly StreamWriter ErrorEmitter;

        readonly NamedPipeClientStream ObservedProcess;

        readonly StreamWriter ObservationEmitter;

        readonly ProcessAdapter Process;

        readonly CancellationTokenSource Cts = new CancellationTokenSource();

        readonly StreamWriter ExeCmdStream;

        readonly StreamReader ExeOutStream;

        readonly StreamReader ExeErrStream;

        readonly StreamReader CmdStream;

        readonly StreamWriter ErrStream;

        readonly StreamWriter OutStream;

        readonly ExePipeOptions Options;

        bool IsRunning;

        public ExeStreams(ExePipeOptions options)
        {
            const int BUFFER_SIZE = 1024 * 4;
            Options = options;
            var encoding = new UTF8Encoding(encoderShouldEmitUTF8Identifier: false);
            CmdSource = new NamedPipeClientStream(options.PipeServer, options.StdInPipeName, PipeDirection.In, PipeOptions.None, TokenImpersonationLevel.Impersonation);
            CmdSource.Connect();
            CmdReader = new StreamReader(CmdSource, encoding, false, BUFFER_SIZE);
            Targets = new NamedPipeClientStream(options.PipeServer, options.StdOutPipeName, PipeDirection.Out, PipeOptions.None, TokenImpersonationLevel.Impersonation);

            Targets.Connect();
            Errors = new NamedPipeClientStream(options.PipeServer, options.StdErrPipeName, PipeDirection.Out, PipeOptions.None, TokenImpersonationLevel.Impersonation);
            Errors.Connect();
            ObservedProcess = new NamedPipeClientStream(options.PipeServer, options.PidPipeName, PipeDirection.Out, PipeOptions.None, TokenImpersonationLevel.Impersonation);
            ObservedProcess.Connect();

            TargetEmitter = new StreamWriter(Targets, encoding, BUFFER_SIZE) { AutoFlush = true };
            ErrorEmitter = new StreamWriter(Errors, encoding, BUFFER_SIZE) { AutoFlush = true };
            ObservationEmitter = new StreamWriter(ObservedProcess, encoding, 5000) { AutoFlush = true };


            var info = new ProcessStartInfo();

            if (Path.IsPathRooted(options.ExePath.Format()))
                info.WorkingDirectory = options.ExePath.FolderPath.Format();

            info.FileName = options.ExePath.Format();
            info.Arguments = options.Format();
            info.UseShellExecute = false;
            info.RedirectStandardInput = true;
            info.RedirectStandardOutput = true;
            info.RedirectStandardError = true;

            Process = new Process();
            Process.StartInfo = info;
            Process.EnableRaisingEvents = true;
            Process.WithExitHandler(OnExit);

            ExeCmdStream = new StreamWriter(Process.StandardInput.BaseStream, encoding) { AutoFlush = true };
            ExeOutStream = Process.StandardOutput;
            ExeErrStream = Process.StandardError;
        }

        public void Run()
        {
            IsRunning = true;
            Process.Start();

            var read = new Thread(() => RunLoop(CmdStream, ExeCmdStream, Cts.Token));
            read.Name = string.Format("{0}.{1}", Options.ControllerName, "InputThread");
            read.Start();

            var write = new Thread(() => RunLoop(ExeOutStream, OutStream, Cts.Token));
            write.Name = string.Format("{0}.{1}", Options.ControllerName, "OutputThread");
            write.Start();

            var error = new Thread(() => RunLoop(ExeErrStream, ErrStream, Cts.Token));
            error.Name = string.Format("{0}.{1}", Options.ControllerName, "ErrorThread");
            error.Start();

            ObservationEmitter.WriteLine(ExecutingPart.Process.Id.ToString(CultureInfo.CurrentCulture));
            ObservationEmitter.WriteLine(Process.Id);  

        }
        void OnExit(EventArgs e)
        {

        }

        void RunLoop(StreamReader reader, StreamWriter writer, CancellationToken token)
        {
            try
            {
                while(IsRunning)
                {
                    var line = ReadLine(reader, token);
                    if (line != null)
                    {
                        writer.WriteLine(line);
                        writer.Flush();
                    }
                }
            }
            catch(Exception e)
            {
                ReportExceptionAndShutdown(e);
            }
        }

        void ReportExceptionAndShutdown(Exception e)
        {
            try
            {
                ErrStream.WriteLine(FormattableString.Invariant($"Exception while debugging. {e.Message}. Shutting down."));
            }
            catch (Exception) { } // Eat any exceptions
            finally
            {
                Shutdown();
            }
        }

        string ReadLine(StreamReader reader, CancellationToken token)
        {
            try
            {
                //return reader.ReadLine();
                var task = reader.ReadLineAsync();
                task.Wait(token);
                return task.Result;
            }
            catch (Exception e)
            {
                // We will get some exceptions we expect. Assert only on the ones we don't expect
                if(e is OperationCanceledException || e is IOException || e is ObjectDisposedException || (e is AggregateException && ((AggregateException)e).InnerException is ArgumentException)) // we get this when the host side is closed
                {
                    Shutdown();
                }
                else
                {
                    term.error(e);
                    Shutdown();
                }
                return null;
            }
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (IsRunning)
                {
                    Shutdown();
                }

                try
                {
                    CmdStream?.Dispose();
                    OutStream?.Dispose();
                    ErrStream?.Dispose();
                    ObservationEmitter?.Dispose();
                    Cts?.Dispose();
                    ExeCmdStream?.Dispose();
                    ExeOutStream?.Dispose();
                    ExeErrStream?.Dispose();
                }
                // catch all exceptions
                catch
                { }
            }
        }

        private void Shutdown()
        {
            if (IsRunning)
            {
                IsRunning = false;
                Cts.Cancel();
                Process?.Close();
            }
        }

        public void Dispose()
        {
            Dispose(true);
        }

    }
    public class ExePipe : IDisposable
    {
        const int BUFFER_SIZE = 1024 * 4;

        bool IsRunning = true;

        StreamWriter ExeCmdStream;

        StreamReader ExeOutStream;

        StreamReader ExeErrStream;

        StreamReader CmdStream;

        StreamWriter ErrStream;

        StreamWriter OutStream;

        StreamWriter PidStream;

        ProcessAdapter ExeProcess;

        CancellationTokenSource Cts = new CancellationTokenSource();

        public ExePipe()
        {

        }

        public void Run(ExePipeOptions options)
        {
            var inputStream = new NamedPipeClientStream(options.PipeServer, options.StdInPipeName, PipeDirection.In, PipeOptions.None, TokenImpersonationLevel.Impersonation);
            var outputStream = new NamedPipeClientStream(options.PipeServer, options.StdOutPipeName, PipeDirection.Out, PipeOptions.None, TokenImpersonationLevel.Impersonation);
            var errorStream = new NamedPipeClientStream(options.PipeServer, options.StdErrPipeName, PipeDirection.Out, PipeOptions.None, TokenImpersonationLevel.Impersonation);
            var pidStream = new NamedPipeClientStream(options.PipeServer, options.PidPipeName, PipeDirection.Out, PipeOptions.None, TokenImpersonationLevel.Impersonation);

            try
            {
                // Connect as soon as possible
                inputStream.Connect();
                outputStream.Connect();
                errorStream.Connect();
                pidStream.Connect();

                var encoding = new UTF8Encoding(encoderShouldEmitUTF8Identifier: false);
                CmdStream = new StreamReader(inputStream, encoding, false, BUFFER_SIZE);
                OutStream = new StreamWriter(outputStream, encoding, BUFFER_SIZE) { AutoFlush = true };
                ErrStream = new StreamWriter(errorStream, encoding, BUFFER_SIZE) { AutoFlush = true };
                PidStream = new StreamWriter(pidStream, encoding, 5000) { AutoFlush = true };

                var info = new ProcessStartInfo();

                if (Path.IsPathRooted(options.ExePath.Format()))
                    info.WorkingDirectory = options.ExePath.FolderPath.Format();

                info.FileName = options.ExePath.Format();
                info.Arguments = options.Format();
                info.UseShellExecute = false;
                info.RedirectStandardInput = true;
                info.RedirectStandardOutput = true;
                info.RedirectStandardError = true;

                ExeProcess = new Process();
                ExeProcess.StartInfo = info;
                ExeProcess.EnableRaisingEvents = true;
                ExeProcess.WithExitHandler(OnProcessExited);

                ExeProcess.Start();
                ExeCmdStream = new StreamWriter(ExeProcess.StandardInput.BaseStream, encoding) { AutoFlush = true };
                ExeOutStream = ExeProcess.StandardOutput;
                ExeErrStream = ExeProcess.StandardError;

                var read = new Thread(() => RunLoop(CmdStream, ExeCmdStream, Cts.Token));
                read.Name = string.Format("{0}.{1}", options.ControllerName, "InputThread");
                read.Start();

                var write = new Thread(() => RunLoop(ExeOutStream, OutStream, Cts.Token));
                write.Name = string.Format("{0}.{1}", options.ControllerName, "OutputThread");
                write.Start();

                var error = new Thread(() => RunLoop(ExeErrStream, ErrStream, Cts.Token));
                error.Name = string.Format("{0}.{1}", options.ControllerName, "ErrorThread");
                error.Start();

                PidStream.WriteLine(Process.GetCurrentProcess().Id.ToString(CultureInfo.CurrentCulture));
                PidStream.WriteLine(ExeProcess.Id.Format());
            }
            catch (Exception e)
            {
                ReportExceptionAndShutdown(e);
            }
        }

        void OnProcessExited(EventArgs e)
        {
            Shutdown();
        }

        private void Shutdown()
        {
            if (IsRunning)
            {
                IsRunning = false;
                Cts.Cancel();
                ExeProcess?.Close();
                ExeProcess = null;
            }
        }

        void RunLoop(StreamReader reader, StreamWriter writer, CancellationToken token)
        {
            try
            {
                while(IsRunning)
                {
                    var line = ReadLine(reader, token);
                    if (line != null)
                    {
                        writer.WriteLine(line);
                        writer.Flush();
                    }
                }
            }
            catch(Exception e)
            {
                ReportExceptionAndShutdown(e);
            }
        }

        void ReportExceptionAndShutdown(Exception e)
        {
            try
            {
                ErrStream.WriteLine(FormattableString.Invariant($"Exception while debugging. {e.Message}. Shutting down."));
            }
            catch (Exception) { } // Eat any exceptions
            finally
            {
                Shutdown();
            }
        }

        string ReadLine(StreamReader reader, CancellationToken token)
        {
            try
            {
                //return reader.ReadLine();
                var task = reader.ReadLineAsync();
                task.Wait(token);
                return task.Result;
            }
            catch (Exception e)
            {
                // We will get some exceptions we expect. Assert only on the ones we don't expect
                if(e is OperationCanceledException || e is IOException || e is ObjectDisposedException || (e is AggregateException && ((AggregateException)e).InnerException is ArgumentException)) // we get this when the host side is closed
                {
                    Shutdown();
                }
                else
                {
                    term.error(e);
                    Shutdown();
                }
                return null;
            }
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (IsRunning)
                {
                    Shutdown();
                }

                try
                {
                    CmdStream?.Dispose();
                    OutStream?.Dispose();
                    ErrStream?.Dispose();
                    PidStream?.Dispose();
                    Cts?.Dispose();
                    ExeCmdStream?.Dispose();
                    ExeOutStream?.Dispose();
                    ExeErrStream?.Dispose();
                }
                // catch all exceptions
                catch
                { }
            }
        }

        public void Dispose()
        {
            Dispose(true);
        }
    }
}