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