// https://github.com/TheWover/donut/blob/2fac16df42f745e616e3e80908c971305a5d00c0/ModuleMonitor/Program.cs
namespace Z0
{
    using Windows;
    using System.Management;

    public class ProcessMonitor : IDisposable
    {
        public static ProcessMonitor start(IWfChannel channel, Action<ModuleLoadInfo> receiver = null)
        {
            var monitor = new ProcessMonitor(channel, receiver);
            monitor.Start();
            return monitor;
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct ModuleLoadInfo
        {
            public sbyte[] SECURITY_DESCRIPTOR;
            
            public Timestamp TIME_CREATED;
            
            public FilePath FileName;
            
            public MemoryAddress DefaultBase;
            
            public MemoryAddress ImageBase;
            
            public ulong ImageChecksum;
            
            public ByteSize ImageSize;
            
            public ProcessId ProcessID;
            
            public uint TimeDateSTamp;
        }

        // [DllImport("advapi32.dll", SetLastError = true)]
        // static extern bool OpenProcessToken(IntPtr ProcessHandle, uint DesiredAccess, out IntPtr TokenHandle);
        
        // [DllImport("kernel32.dll", SetLastError = true)]        
        // [return: MarshalAs(UnmanagedType.Bool)]
        // static extern bool CloseHandle(IntPtr hObject);

        /// <summary>
        /// Gets the owner of a process.
        /// https://stackoverflow.com/questions/777548/how-do-i-determine-the-owner-of-a-process-in-c
        /// </summary>
        /// <param name="process">The process to inspect.</param>
        /// <returns>The name of the user, or null if it could not be read.</returns>
        static string GetProcessUser(Process process)
        {
            IntPtr processHandle = IntPtr.Zero;
            try
            {
                AdvApi.OpenProcessToken(process.Handle, TokenAccessLevels.Query, out processHandle);
                var wi = new System.Security.Principal.WindowsIdentity(processHandle);
                return wi.Name;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
            finally
            {
                if (processHandle != IntPtr.Zero)
                {
                    Kernel32.CloseHandle(processHandle);
                }
            }
        }

        /// <summary>
        /// Try to get the process by ID and return null if it no longer exists.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        static Process SafeGetProcessByID(int id)
        {
            try
            {
                return Process.GetProcessById(id);

            }
            catch
            {
                return null;
            }
        }

        readonly Action<ModuleLoadInfo> Receiver;

        readonly IWfChannel Channel;

        bool Running;

        bool Cancelled = false;

        Thread Control;

        ProcessMonitor(IWfChannel channel, Action<ModuleLoadInfo> receiver)
        {
            Channel = channel;
            Running = true;
            Receiver = receiver ?? Print;
        }

        public void Dispose()
        {
            Running = false;
            while(!Cancelled)
            {
                sys.delay(500);
            }
        }

        void Print(ModuleLoadInfo src)
        {
            Channel.Row(RP.PageBreak180);

            Channel.RowFormat("[>] Process {0} has loaded a module:", src.ProcessID);

            Channel.RowFormat("{0,15} (Event)   TIME_CREATED: {1}", "[+]", src.TIME_CREATED);
            Channel.RowFormat("{0,15} (Process) ImageBase: {1}", "[+]", src.ImageBase);
            Channel.RowFormat("{0,15} (Process) DefaultBase: {1}", "[+]", src.DefaultBase);
            Channel.RowFormat("{0,15} (Module)  FileName: {1}", "[+]", src.FileName);
            Channel.RowFormat("{0,15} (Module)  TimeStamp: {1}", "[+]", src.TimeDateSTamp);
            Channel.RowFormat("{0,15} (Module)  ImageSize: {1}", "[+]", src.ImageSize);
            Channel.RowFormat("{0,15} (Module)  ImageChecksum: {1}", "[+]", src.ImageChecksum);

            var process = SafeGetProcessByID(int.Parse(src.ProcessID.ToString()));

            if (process != null)
            {
                Channel.RowFormat("{0,15} Process Name: {1}", "[+]", process.ProcessName);
                Channel.RowFormat("{0,15} Process User: {1}", "[+]", GetProcessUser(process));
            }
        }

        public void Start()
        {
            Control = sys.thread(() => Run());
            Control.Start();
        }

        void Run()
        {
            while (Running)
            {
                try
                {
                    var trace = new ModuleLoadInfo();
                    var tracecomp = new ModuleLoadInfo();

                    //Get the details of the next module load
                    trace = NextLoad();

                    //If the trace is not empty
                    if (!trace.Equals(tracecomp))
                    {
                        Receiver(trace);
                    }
                }
                catch(InvalidOperationException)
                {

                }
                catch(Exception e)
                {
                    Channel.Error(e);
                }
            }

            Cancelled = true;
        }

        /// <summary>
        /// Get the details of the next module load
        /// </summary>
        /// <param name="filters">Filenames to filter for.</param>
        /// <returns></returns>
        static ModuleLoadInfo NextLoad()
        {
            var trace = new ModuleLoadInfo();

            //Ideally, we would filter here to reduce the amount of events that we have to consume.
            //However, we cannot use the WHERE clause because the 
            var startWatch = new ManagementEventWatcher(new WqlEventQuery("SELECT * FROM Win32_ModuleLoadTrace"));

            var e = startWatch.WaitForNextEvent();

            if (e["SECURITY_DESCRIPTOR"] != null)
                trace.SECURITY_DESCRIPTOR = (sbyte[])e["SECURITY_DESCRIPTOR"];

            if ((e)["TIME_CREATED"] != null)
                trace.TIME_CREATED = new Timestamp((UInt64)(e)["TIME_CREATED"]);
            
            if ((e)["FileName"] != null)
                trace.FileName = FS.path((string)(e)["FileName"]);

            if ((e)["DefaultBase"] != null)
                trace.DefaultBase = (UInt64)(e)["DefaultBase"];

            if ((e)["ImageBase"] != null)
                trace.ImageBase = (UInt64)(e)["ImageBase"];

            if ((e)["ImageChecksum"] != null)
            trace.ImageChecksum = (UInt32)(e)["ImageChecksum"];

            if ((e)["ImageSize"] != null)
                trace.ImageSize = (UInt64)(e)["ImageSize"];

            if ((e)["ProcessID"] != null)
                trace.ProcessID = (UInt32)(e)["ProcessID"];

            if ((e)["TimeDateSTamp"] != null)
                trace.TimeDateSTamp = (UInt32)(e)["TimeDateSTamp"];

            return trace;
        }
    }
}