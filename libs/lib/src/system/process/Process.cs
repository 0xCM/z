//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System.Linq;
    using System.ComponentModel;
    using System.IO;

    using S = System.Diagnostics.Process;
    using D = System.Diagnostics;
    using A = ProcessAdapter;

    public sealed class ProcessAdapter : Adapter<A,S>
    {
        public ProcessAdapter()
        {}

        [MethodImpl(Inline)]
        public ProcessAdapter(S subject)
            : base(subject)
        {

        }

        public MemoryAddress BaseAddress
        {
            [MethodImpl(Inline)]
            get => MainModule.BaseAddress;
        }

        //
        // Summary:
        //     Gets the base priority of the associated process.
        //
        // Returns:
        //     The base priority, which is computed from the System.Diagnostics.Process.PriorityClass
        //     of the associated process.
        //
        // Exceptions:
        //   T:System.InvalidOperationException:
        //     The process has exited. -or- The process has not started, so there is no process
        //     ID.
        public int BasePriority
        {
            [MethodImpl(Inline)]
            get => Subject.BasePriority;
        }

        //
        // Summary:
        //     Gets or sets whether the System.Diagnostics.Process.Exited event should be raised
        //     when the process terminates.
        //
        // Returns:
        //     true if the System.Diagnostics.Process.Exited event should be raised when the
        //     associated process is terminated (through either an exit or a call to System.Diagnostics.Process.Kill);
        //     otherwise, false. The default is false. Note that the System.Diagnostics.Process.Exited
        //     event is raised even if the value of System.Diagnostics.Process.EnableRaisingEvents
        //     is false when the process exits during or before the user performs a System.Diagnostics.Process.HasExited
        //     check.
        public bool EnableRaisingEvents
        {
            [MethodImpl(Inline)]
            get => Subject.EnableRaisingEvents;

            [MethodImpl(Inline)]
            set => Subject.EnableRaisingEvents = value;
        }

        //
        // Summary:
        //     Gets the value that the associated process specified when it terminated.
        //
        // Returns:
        //     The code that the associated process specified when it terminated.
        //
        // Exceptions:
        //   T:System.InvalidOperationException:
        //     The process has not exited. -or- The process System.Diagnostics.Process.Handle
        //     is not valid.
        //
        //   T:System.NotSupportedException:
        //     You are trying to access the System.Diagnostics.Process.ExitCode property for
        //     a process that is running on a remote computer. This property is available only
        //     for processes that are running on the local computer.
        public int ExitCode
        {
            [MethodImpl(Inline)]
            get => Subject.ExitCode;
        }

        //
        // Summary:
        //     Gets the time that the associated process exited.
        //
        // Returns:
        //     A System.DateTime that indicates when the associated process was terminated.
        //
        // Exceptions:
        //   T:System.NotSupportedException:
        //     You are trying to access the System.Diagnostics.Process.ExitTime property for
        //     a process that is running on a remote computer. This property is available only
        //     for processes that are running on the local computer.
        public Timestamp ExitTime
        {
            [MethodImpl(Inline)]
            get => Subject.ExitTime;
        }

        //
        // Summary:
        //     Gets the native handle of the associated process.
        //
        // Returns:
        //     The handle that the operating system assigned to the associated process when
        //     the process was started. The system uses this handle to keep track of process
        //     attributes.
        //
        // Exceptions:
        //   T:System.InvalidOperationException:
        //     The process has not been started or has exited. The System.Diagnostics.Process.Handle
        //     property cannot be read because there is no process associated with this System.Diagnostics.Process
        //     instance. -or- The System.Diagnostics.Process instance has been attached to a
        //     running process but you do not have the necessary permissions to get a handle
        //     with full access rights.
        //
        //   T:System.NotSupportedException:
        //     You are trying to access the System.Diagnostics.Process.Handle property for a
        //     process that is running on a remote computer. This property is available only
        //     for processes that are running on the local computer.
        public Ptr Handle
        {
            [MethodImpl(Inline)]
            get => Subject.Handle;
        }

        //
        // Summary:
        //     Gets the number of handles opened by the process.
        //
        // Returns:
        //     The number of operating system handles the process has opened.
        public Count HandleCount
        {
            [MethodImpl(Inline)]
            get => Subject.HandleCount;
        }

        //
        // Summary:
        //     Gets a value indicating whether the associated process has been terminated.
        //
        // Returns:
        //     true if the operating system process referenced by the System.Diagnostics.Process
        //     component has terminated; otherwise, false.
        //
        // Exceptions:
        //   T:System.InvalidOperationException:
        //     There is no process associated with the object.
        //
        //   T:System.ComponentModel.Win32Exception:
        //     The exit code for the process could not be retrieved.
        //
        //   T:System.NotSupportedException:
        //     You are trying to access the System.Diagnostics.Process.HasExited property for
        //     a process that is running on a remote computer. This property is available only
        //     for processes that are running on the local computer.
        public bool HasExited
        {
            [MethodImpl(Inline)]
            get => Subject.HasExited;
        }

        //
        // Summary:
        //     Gets the unique identifier for the associated process.
        //
        // Returns:
        //     The system-generated unique identifier of the process that is referenced by this
        //     System.Diagnostics.Process instance.
        //
        // Exceptions:
        //   T:System.InvalidOperationException:
        //     The process's System.Diagnostics.Process.Id property has not been set. -or- There
        //     is no process associated with this System.Diagnostics.Process object.
        public int Id
        {
            [MethodImpl(Inline)]
            get => Subject.Id;
        }

        //
        // Summary:
        //     Gets the name of the computer the associated process is running on.
        //
        // Returns:
        //     The name of the computer that the associated process is running on.
        //
        // Exceptions:
        //   T:System.InvalidOperationException:
        //     There is no process associated with this System.Diagnostics.Process object.
        public string MachineName
        {
            [MethodImpl(Inline)]
            get => Subject.MachineName;
        }

        //
        // Summary:
        //     Gets the main module for the associated process.
        //
        // Returns:
        //     The System.Diagnostics.ProcessModule that was used to start the process.
        //
        // Exceptions:
        //   T:System.NotSupportedException:
        //     You are trying to access the System.Diagnostics.Process.MainModule property for
        //     a process that is running on a remote computer. This property is available only
        //     for processes that are running on the local computer.
        //
        //   T:System.ComponentModel.Win32Exception:
        //     A 32-bit process is trying to access the modules of a 64-bit process.
        //
        //   T:System.InvalidOperationException:
        //     The process System.Diagnostics.Process.Id is not available. -or- The process
        //     has exited.
        public ProcessModule MainModule
        {
            [MethodImpl(Inline)]
            get => new ProcessModule(Subject.MainModule);
        }

        public FileUri Uri
        {
            [MethodImpl(Inline)]
            get => MainModule.Path;
        }

        //
        // Summary:
        //     Gets the window handle of the main window of the associated process.
        //
        // Returns:
        //     The system-generated window handle of the main window of the associated process.
        //
        // Exceptions:
        //   T:System.InvalidOperationException:
        //     The System.Diagnostics.Process.MainWindowHandle is not defined because the process
        //     has exited.
        //
        //   T:System.NotSupportedException:
        //     You are trying to access the System.Diagnostics.Process.MainWindowHandle property
        //     for a process that is running on a remote computer. This property is available
        //     only for processes that are running on the local computer.
        public Ptr MainWindowHandle
        {
            [MethodImpl(Inline)]
            get => Subject.MainWindowHandle;
        }

        //
        // Summary:
        //     Gets the caption of the main window of the process.
        //
        // Returns:
        //     The main window title of the process.
        //
        // Exceptions:
        //   T:System.InvalidOperationException:
        //     The System.Diagnostics.Process.MainWindowTitle property is not defined because
        //     the process has exited.
        //
        //   T:System.NotSupportedException:
        //     You are trying to access the System.Diagnostics.Process.MainWindowTitle property
        //     for a process that is running on a remote computer. This property is available
        //     only for processes that are running on the local computer.
        public string MainWindowTitle
        {
            [MethodImpl(Inline)]
            get => Subject.MainWindowTitle;
        }

        //
        // Summary:
        //     Gets or sets the maximum allowable working set size, in bytes, for the associated
        //     process.
        //
        // Returns:
        //     The maximum working set size that is allowed in memory for the process, in bytes.
        //
        // Exceptions:
        //   T:System.ArgumentException:
        //     The maximum working set size is invalid. It must be greater than or equal to
        //     the minimum working set size.
        //
        //   T:System.ComponentModel.Win32Exception:
        //     Working set information cannot be retrieved from the associated process resource.
        //     -or- The process identifier or process handle is zero because the process has
        //     not been started.
        //
        //   T:System.NotSupportedException:
        //     You are trying to access the System.Diagnostics.Process.MaxWorkingSet property
        //     for a process that is running on a remote computer. This property is available
        //     only for processes that are running on the local computer.
        //
        //   T:System.InvalidOperationException:
        //     The process System.Diagnostics.Process.Id is not available. -or- The process
        //     has exited.
        public ByteSize MaxWorkingSet
        {
            [MethodImpl(Inline)]
            get => Subject.MaxWorkingSet;

            [MethodImpl(Inline)]
            set => Subject.MaxWorkingSet = value;
        }

        //
        // Summary:
        //     Gets or sets the minimum allowable working set size, in bytes, for the associated
        //     process.
        //
        // Returns:
        //     The minimum working set size that is required in memory for the process, in bytes.
        //
        // Exceptions:
        //   T:System.ArgumentException:
        //     The minimum working set size is invalid. It must be less than or equal to the
        //     maximum working set size.
        //
        //   T:System.ComponentModel.Win32Exception:
        //     Working set information cannot be retrieved from the associated process resource.
        //     -or- The process identifier or process handle is zero because the process has
        //     not been started.
        //
        //   T:System.NotSupportedException:
        //     You are trying to access the System.Diagnostics.Process.MinWorkingSet property
        //     for a process that is running on a remote computer. This property is available
        //     only for processes that are running on the local computer.
        //
        //   T:System.InvalidOperationException:
        //     The process System.Diagnostics.Process.Id is not available. -or- The process
        //     has exited.
        public ByteSize MinWorkingSet
        {
            [MethodImpl(Inline)]
            get => Subject.MinWorkingSet;

            [MethodImpl(Inline)]
            set => Subject.MinWorkingSet = value;
        }

        //
        // Summary:
        //     Gets the modules that have been loaded by the associated process.
        //
        // Returns:
        //     An array of type System.Diagnostics.ProcessModule that represents the modules
        //     that have been loaded by the associated process.
        //
        // Exceptions:
        //   T:System.NotSupportedException:
        //     You are attempting to access the System.Diagnostics.Process.Modules property
        //     for a process that is running on a remote computer. This property is available
        //     only for processes that are running on the local computer.
        //
        //   T:System.InvalidOperationException:
        //     The process System.Diagnostics.Process.Id is not available.
        //
        //   T:System.ComponentModel.Win32Exception:
        //     You are attempting to access the System.Diagnostics.Process.Modules property
        //     for either the system process or the idle process. These processes do not have
        //     modules.
        public ReadOnlySeq<ProcessModule> Modules
        {
            [MethodImpl(Inline)]
            get => Subject.Modules.Cast<D.ProcessModule>().Map(ProcessModule.adapt);
        }

        //
        // Summary:
        //     Gets the amount of nonpaged system memory, in bytes, allocated for the associated
        //     process.
        //
        // Returns:
        //     The amount of system memory, in bytes, allocated for the associated process that
        //     cannot be written to the virtual memory paging file.
        public ByteSize NonpagedSystemMemorySize64
        {
            [MethodImpl(Inline)]
            get => Subject.NonpagedSystemMemorySize64;
        }

        //
        // Summary:
        //     Gets the amount of paged memory, in bytes, allocated for the associated process.
        //
        // Returns:
        //     The amount of memory, in bytes, allocated in the virtual memory paging file for
        //     the associated process.
        public ByteSize PagedMemorySize64
        {
            [MethodImpl(Inline)]
            get => Subject.PagedMemorySize64;
        }

        //
        // Summary:
        //     Gets the amount of pageable system memory, in bytes, allocated for the associated
        //     process.
        //
        // Returns:
        //     The amount of system memory, in bytes, allocated for the associated process that
        //     can be written to the virtual memory paging file.
        public ByteSize PagedSystemMemorySize64
        {
            [MethodImpl(Inline)]
            get => Subject.PagedSystemMemorySize64;
        }

        //
        // Summary:
        //     Gets the maximum amount of memory in the virtual memory paging file, in bytes,
        //     used by the associated process.
        //
        // Returns:
        //     The maximum amount of memory, in bytes, allocated in the virtual memory paging
        //     file for the associated process since it was started.
        public ByteSize PeakPagedMemorySize64
        {
            [MethodImpl(Inline)]
            get => Subject.PeakPagedMemorySize64;
        }

        //
        // Summary:
        //     Gets the maximum amount of virtual memory, in bytes, used by the associated process.
        //
        // Returns:
        //     The maximum amount of virtual memory, in bytes, allocated for the associated
        //     process since it was started.
        public ByteSize PeakVirtualMemorySize64
        {
            [MethodImpl(Inline)]
            get => Subject.PeakVirtualMemorySize64;
        }

        //
        // Summary:
        //     Gets the maximum amount of physical memory, in bytes, used by the associated
        //     process.
        //
        // Returns:
        //     The maximum amount of physical memory, in bytes, allocated for the associated
        //     process since it was started.
        public ByteSize PeakWorkingSet64
        {
            [MethodImpl(Inline)]
            get => Subject.PeakWorkingSet64;
        }

        //
        // Summary:
        //     Gets or sets the overall priority category for the associated process.
        //
        // Returns:
        //     The priority category for the associated process, from which the System.Diagnostics.Process.BasePriority
        //     of the process is calculated.
        //
        // Exceptions:
        //   T:System.ComponentModel.Win32Exception:
        //     Process priority information could not be set or retrieved from the associated
        //     process resource. -or- The process identifier or process handle is zero. (The
        //     process has not been started.)
        //
        //   T:System.NotSupportedException:
        //     You are attempting to access the System.Diagnostics.Process.PriorityClass property
        //     for a process that is running on a remote computer. This property is available
        //     only for processes that are running on the local computer.
        //
        //   T:System.InvalidOperationException:
        //     The process System.Diagnostics.Process.Id is not available.
        //
        //   T:System.ComponentModel.InvalidEnumArgumentException:
        //     Priority class cannot be set because it does not use a valid value, as defined
        //     in the System.Diagnostics.ProcessPriorityClass enumeration.
        public D.ProcessPriorityClass PriorityClass
        {
            [MethodImpl(Inline)]
            get => Subject.PriorityClass;

            [MethodImpl(Inline)]
            set => Subject.PriorityClass = value;
        }

        //
        // Summary:
        //     Gets the amount of private memory, in bytes, allocated for the associated process.
        //
        // Returns:
        //     The amount of memory, in bytes, allocated for the associated process that cannot
        //     be shared with other processes.
        public ByteSize PrivateMemorySize64
        {
            [MethodImpl(Inline)]
            get => Subject.PrivateMemorySize64;
        }


        //
        // Summary:
        //     Gets the privileged processor time for this process.
        //
        // Returns:
        //     A System.TimeSpan that indicates the amount of time that the process has spent
        //     running code inside the operating system core.
        //
        // Exceptions:
        //   T:System.NotSupportedException:
        //     You are attempting to access the System.Diagnostics.Process.PrivilegedProcessorTime
        //     property for a process that is running on a remote computer. This property is
        //     available only for processes that are running on the local computer.
        public Duration PrivilegedProcessorTime
        {
            [MethodImpl(Inline)]
            get => Subject.PrivilegedProcessorTime;
        }

        //
        // Summary:
        //     Gets the name of the process.
        //
        // Returns:
        //     The name that the system uses to identify the process to the user.
        //
        // Exceptions:
        //   T:System.InvalidOperationException:
        //     The process does not have an identifier, or no process is associated with the
        //     System.Diagnostics.Process. -or- The associated process has exited.
        //
        //   T:System.NotSupportedException:
        //     The process is not on this computer.
        public NameOld ProcessName
        {
            [MethodImpl(Inline)]
            get => Subject.ProcessName;
        }

        //
        // Summary:
        //     Gets or sets the processors on which the threads in this process can be scheduled
        //     to run.
        //
        // Returns:
        //     A bitmask representing the processors that the threads in the associated process
        //     can run on. The default depends on the number of processors on the computer.
        //     The default value is 2 n -1, where n is the number of processors.
        //
        // Exceptions:
        //   T:System.ComponentModel.Win32Exception:
        //     System.Diagnostics.Process.ProcessorAffinity information could not be set or
        //     retrieved from the associated process resource. -or- The process identifier or
        //     process handle is zero. (The process has not been started.)
        //
        //   T:System.NotSupportedException:
        //     You are attempting to access the System.Diagnostics.Process.ProcessorAffinity
        //     property for a process that is running on a remote computer. This property is
        //     available only for processes that are running on the local computer.
        //
        //   T:System.InvalidOperationException:
        //     The process System.Diagnostics.Process.Id was not available. -or- The process
        //     has exited.
        public ulong ProcessorAffinity
        {
            [MethodImpl(Inline)]
            get => (ulong)Subject.ProcessorAffinity;

            [MethodImpl(Inline)]
            set => Subject.ProcessorAffinity = (IntPtr)value;
        }

        //
        // Summary:
        //     Gets a value indicating whether the user interface of the process is responding.
        //
        // Returns:
        //     true if the user interface of the associated process is responding to the system;
        //     otherwise, false.
        //
        // Exceptions:
        //   T:System.InvalidOperationException:
        //     There is no process associated with this System.Diagnostics.Process object.
        //
        //   T:System.NotSupportedException:
        //     You are attempting to access the System.Diagnostics.Process.Responding property
        //     for a process that is running on a remote computer. This property is available
        //     only for processes that are running on the local computer.
        public bool Responding
        {
            [MethodImpl(Inline)]
            get => Subject.Responding;
        }

        //
        // Summary:
        //     Gets the Terminal Services session identifier for the associated process.
        //
        // Returns:
        //     The Terminal Services session identifier for the associated process.
        //
        // Exceptions:
        //   T:System.NullReferenceException:
        //     There is no session associated with this process.
        //
        //   T:System.InvalidOperationException:
        //     There is no process associated with this session identifier. -or- The associated
        //     process is not on this machine.
        public int SessionId
        {
            [MethodImpl(Inline)]
            get => Subject.SessionId;
        }

        //
        // Summary:
        //     Gets a stream used to read the error output of the application.
        //
        // Returns:
        //     A System.IO.StreamReader that can be used to read the standard error stream of
        //     the application.
        //
        // Exceptions:
        //   T:System.InvalidOperationException:
        //     The System.Diagnostics.Process.StandardError stream has not been defined for
        //     redirection; ensure System.Diagnostics.ProcessStartInfo.RedirectStandardError
        //     is set to true and System.Diagnostics.ProcessStartInfo.UseShellExecute is set
        //     to false. -or- The System.Diagnostics.Process.StandardError stream has been opened
        //     for asynchronous read operations with System.Diagnostics.Process.BeginErrorReadLine.
        public StreamReader StandardError
        {
            [MethodImpl(Inline)]
            get => Subject.StandardError;
        }

        //
        // Summary:
        //     Gets a stream used to write the input of the application.
        //
        // Returns:
        //     A System.IO.StreamWriter that can be used to write the standard input stream
        //     of the application.
        //
        // Exceptions:
        //   T:System.InvalidOperationException:
        //     The System.Diagnostics.Process.StandardInput stream has not been defined because
        //     System.Diagnostics.ProcessStartInfo.RedirectStandardInput is set to false.
        public StreamWriter StandardInput
        {
            [MethodImpl(Inline)]
            get => Subject.StandardInput;
        }

        //
        // Summary:
        //     Gets a stream used to read the textual output of the application.
        //
        // Returns:
        //     A System.IO.StreamReader that can be used to read the standard output stream
        //     of the application.
        //
        // Exceptions:
        //   T:System.InvalidOperationException:
        //     The System.Diagnostics.Process.StandardOutput stream has not been defined for
        //     redirection; ensure System.Diagnostics.ProcessStartInfo.RedirectStandardOutput
        //     is set to true and System.Diagnostics.ProcessStartInfo.UseShellExecute is set
        //     to false. -or- The System.Diagnostics.Process.StandardOutput stream has been
        //     opened for asynchronous read operations with System.Diagnostics.Process.BeginOutputReadLine.
        public StreamReader StandardOutput
        {
            [MethodImpl(Inline)]
            get => Subject.StandardOutput;
        }

        //
        // Summary:
        //     Gets or sets the properties to pass to the System.Diagnostics.Process.Start method
        //     of the System.Diagnostics.Process.
        //
        // Returns:
        //     The System.Diagnostics.ProcessStartInfo that represents the data with which to
        //     start the process. These arguments include the name of the executable file or
        //     document used to start the process.
        //
        // Exceptions:
        //   T:System.ArgumentNullException:
        //     The value that specifies the System.Diagnostics.Process.StartInfo is null.
        //
        //   T:System.InvalidOperationException:
        //     The System.Diagnostics.Process.Start method was not used to start the process.
        public D.ProcessStartInfo StartInfo
        {
            [MethodImpl(Inline)]
            get => Subject.StartInfo;

            [MethodImpl(Inline)]
            set => Subject.StartInfo = value;

        }

        //
        // Summary:
        //     Gets the time that the associated process was started.
        //
        // Returns:
        //     An object that indicates when the process started. An exception is thrown if
        //     the process is not running.
        //
        // Exceptions:
        //   T:System.NotSupportedException:
        //     You are attempting to access the System.Diagnostics.Process.StartTime property
        //     for a process that is running on a remote computer. This property is available
        //     only for processes that are running on the local computer.
        //
        //   T:System.InvalidOperationException:
        //     The process has exited. -or- The process has not been started.
        //
        //   T:System.ComponentModel.Win32Exception:
        //     An error occurred in the call to the Windows function.
        public Timestamp StartTime
        {
            [MethodImpl(Inline)]
            get => Subject.StartTime;
        }

        //
        // Summary:
        //     Gets or sets the object used to marshal the event handler calls that are issued
        //     as a result of a process exit event.
        //
        // Returns:
        //     The System.ComponentModel.ISynchronizeInvoke used to marshal event handler calls
        //     that are issued as a result of an System.Diagnostics.Process.Exited event on
        //     the process.
        public ISynchronizeInvoke SynchronizingObject
        {
            [MethodImpl(Inline)]
            get => Subject.SynchronizingObject;

            [MethodImpl(Inline)]
            set => Subject.SynchronizingObject = value;
        }

        //
        // Summary:
        //     Gets the set of threads that are running in the associated process.
        //
        // Returns:
        //     An array of type System.Diagnostics.ProcessThread representing the operating
        //     system threads currently running in the associated process.
        //
        // Exceptions:
        //   T:System.SystemException:
        //     The process does not have an System.Diagnostics.Process.Id, or no process is
        //     associated with the System.Diagnostics.Process instance. -or- The associated
        //     process has exited.
        public Index<ProcessThreadAdapter> Threads
        {
            [MethodImpl(Inline)]
            get => Subject.Threads.Cast<D.ProcessThread>().Map(ProcessThreadAdapter.adapt);
        }

        //
        // Summary:
        //     Gets the total processor time for this process.
        //
        // Returns:
        //     A System.TimeSpan that indicates the amount of time that the associated process
        //     has spent utilizing the CPU. This value is the sum of the System.Diagnostics.Process.UserProcessorTime
        //     and the System.Diagnostics.Process.PrivilegedProcessorTime.
        //
        // Exceptions:
        //   T:System.NotSupportedException:
        //     You are attempting to access the System.Diagnostics.Process.TotalProcessorTime
        //     property for a process that is running on a remote computer. This property is
        //     available only for processes that are running on the local computer.
        public Duration TotalProcessorTime
        {
            [MethodImpl(Inline)]
            get => Subject.TotalProcessorTime;
        }

        //
        // Summary:
        //     Gets the user processor time for this process.
        //
        // Returns:
        //     A System.TimeSpan that indicates the amount of time that the associated process
        //     has spent running code inside the application portion of the process (not inside
        //     the operating system core).
        //
        // Exceptions:
        //   T:System.NotSupportedException:
        //     You are attempting to access the System.Diagnostics.Process.UserProcessorTime
        //     property for a process that is running on a remote computer. This property is
        //     available only for processes that are running on the local computer.
        public Duration UserProcessorTime
        {
            [MethodImpl(Inline)]
            get => Subject.UserProcessorTime;
        }

        //
        // Summary:
        //     Gets the amount of the virtual memory, in bytes, allocated for the associated
        //     process.
        //
        // Returns:
        //     The amount of virtual memory, in bytes, allocated for the associated process.
        public long VirtualMemorySize64
        {
            [MethodImpl(Inline)]
            get => Subject.VirtualMemorySize64;
        }

        //
        // Summary:
        //     Gets the amount of physical memory, in bytes, allocated for the associated process.
        //
        // Returns:
        //     The amount of physical memory, in bytes, allocated for the associated process.
        public ByteSize WorkingSet64
        {
            [MethodImpl(Inline)]
            get => Subject.WorkingSet64;
        }

        //
        // Summary:
        //     Immediately stops the associated process.
        //
        // Exceptions:
        //   T:System.ComponentModel.Win32Exception:
        //     The associated process could not be terminated. -or- The process is terminating.
        //
        //   T:System.NotSupportedException:
        //     You are attempting to call System.Diagnostics.Process.Kill for a process that
        //     is running on a remote computer. The method is available only for processes running
        //     on the local computer.
        //
        //   T:System.InvalidOperationException:
        //     The process has already exited. -or- There is no process associated with this
        //     System.Diagnostics.Process object.
        [MethodImpl(Inline)]
        public void Kill()
            => Subject.Kill();

        //
        // Summary:
        //     Immediately stops the associated process, and optionally its child/descendent
        //     processes.
        //
        // Parameters:
        //   entireProcessTree:
        //     true to kill the associated process and its descendants; false to kill only the
        //     associated process.
        //
        // Exceptions:
        //   T:System.ComponentModel.Win32Exception:
        //     The associated process could not be terminated. -or- The process is terminating.
        //
        //   T:System.NotSupportedException:
        //     You are attempting to call System.Diagnostics.Process.Kill for a process that
        //     is running on a remote computer. The method is available only for processes running
        //     on the local computer.
        //
        //   T:System.InvalidOperationException:
        //     The process has already exited. -or- There is no process associated with this
        //     System.Diagnostics.Process object. -or- The calling process is a member of the
        //     associated process' descendant tree.
        //
        //   T:System.AggregateException:
        //     Not all processes in the associated process' descendant tree could be terminated.
        [MethodImpl(Inline)]
        public void Kill(bool entireProcessTree)
            => Subject.Kill(entireProcessTree);

        //
        // Summary:
        //     Discards any information about the associated process that has been cached inside
        //     the process component.
        [MethodImpl(Inline)]
        public void Refresh()
            => Subject.Refresh();

        //
        // Summary:
        //     Starts (or reuses) the process resource that is specified by the System.Diagnostics.Process.StartInfo
        //     property of this System.Diagnostics.Process component and associates it with
        //     the component.
        //
        // Returns:
        //     true if a process resource is started; false if no new process resource is started
        //     (for example, if an existing process is reused).
        //
        // Exceptions:
        //   T:System.InvalidOperationException:
        //     No file name was specified in the System.Diagnostics.Process component's System.Diagnostics.Process.StartInfo.
        //     -or- The System.Diagnostics.ProcessStartInfo.UseShellExecute member of the System.Diagnostics.Process.StartInfo
        //     property is true while System.Diagnostics.ProcessStartInfo.RedirectStandardInput,
        //     System.Diagnostics.ProcessStartInfo.RedirectStandardOutput, or System.Diagnostics.ProcessStartInfo.RedirectStandardError
        //     is true.
        //
        //   T:System.ComponentModel.Win32Exception:
        //     There was an error in opening the associated file.
        //
        //   T:System.ObjectDisposedException:
        //     The process object has already been disposed.
        //
        //   T:System.PlatformNotSupportedException:
        //     Method not supported on operating systems without shell support such as Nano
        //     Server (.NET Core only).
        [MethodImpl(Inline)]
        public bool Start()
            => Subject.Start();

        //
        // Summary:
        //     Formats the process's name as a string, combined with the parent component type,
        //     if applicable.
        //
        // Returns:
        //     The System.Diagnostics.Process.ProcessName, combined with the base component's
        //     System.Object.ToString return value.
        [MethodImpl(Inline)]
        public override string ToString()
            => Subject.ToString();

        //
        // Summary:
        //     Instructs the System.Diagnostics.Process component to wait indefinitely for the
        //     associated process to exit.
        //
        // Exceptions:
        //   T:System.ComponentModel.Win32Exception:
        //     The wait setting could not be accessed.
        //
        //   T:System.SystemException:
        //     No process System.Diagnostics.Process.Id has been set, and a System.Diagnostics.Process.Handle
        //     from which the System.Diagnostics.Process.Id property can be determined does
        //     not exist. -or- There is no process associated with this System.Diagnostics.Process
        //     object. -or- You are attempting to call System.Diagnostics.Process.WaitForExit
        //     for a process that is running on a remote computer. This method is available
        //     only for processes that are running on the local computer.
        [MethodImpl(Inline)]
        public void WaitForExit()
            => Subject.WaitForExit();

        //
        // Summary:
        //     Instructs the System.Diagnostics.Process component to wait the specified number
        //     of milliseconds for the associated process to exit.
        //
        // Parameters:
        //   milliseconds:
        //     The amount of time, in milliseconds, to wait for the associated process to exit.
        //     The maximum is the largest possible value of a 32-bit integer, which represents
        //     infinity to the operating system.
        //
        // Returns:
        //     true if the associated process has exited; otherwise, false.
        //
        // Exceptions:
        //   T:System.ComponentModel.Win32Exception:
        //     The wait setting could not be accessed.
        //
        //   T:System.SystemException:
        //     No process System.Diagnostics.Process.Id has been set, and a System.Diagnostics.Process.Handle
        //     from which the System.Diagnostics.Process.Id property can be determined does
        //     not exist. -or- There is no process associated with this System.Diagnostics.Process
        //     object. -or- You are attempting to call System.Diagnostics.Process.WaitForExit(System.Int32)
        //     for a process that is running on a remote computer. This method is available
        //     only for processes that are running on the local computer.
        //
        //   T:System.ArgumentOutOfRangeException:
        //     milliseconds is a negative number other than -1, which represents an infinite
        //     time-out.
        [MethodImpl(Inline)]
        public bool WaitForExit(int milliseconds)
            => Subject.WaitForExit(milliseconds);

        //
        // Summary:
        //     Causes the System.Diagnostics.Process component to wait indefinitely for the
        //     associated process to enter an idle state. This overload applies only to processes
        //     with a user interface and, therefore, a message loop.
        //
        // Returns:
        //     true if the associated process has reached an idle state.
        //
        // Exceptions:
        //   T:System.InvalidOperationException:
        //     The process does not have a graphical interface. -or- An unknown error occurred.
        //     The process failed to enter an idle state. -or- The process has already exited.
        //     -or- No process is associated with this System.Diagnostics.Process object.
        [MethodImpl(Inline)]
        public bool WaitForInputIdle()
            => Subject.WaitForInputIdle();

        //
        // Summary:
        //     Causes the System.Diagnostics.Process component to wait the specified number
        //     of milliseconds for the associated process to enter an idle state. This overload
        //     applies only to processes with a user interface and, therefore, a message loop.
        //
        // Parameters:
        //   milliseconds:
        //     A value of 1 to System.Int32.MaxValue that specifies the amount of time, in milliseconds,
        //     to wait for the associated process to become idle. A value of 0 specifies an
        //     immediate return, and a value of -1 specifies an infinite wait.
        //
        // Returns:
        //     true if the associated process has reached an idle state; otherwise, false.
        //
        // Exceptions:
        //   T:System.InvalidOperationException:
        //     The process does not have a graphical interface. -or- An unknown error occurred.
        //     The process failed to enter an idle state. -or- The process has already exited.
        //     -or- No process is associated with this System.Diagnostics.Process object.
        [MethodImpl(Inline)]
        public bool WaitForInputIdle(int milliseconds)
            => Subject.WaitForInputIdle(milliseconds);

        [MethodImpl(Inline)]
        public static implicit operator ProcessAdapter(AdapterHost<A,S> src)
            => new ProcessAdapter(src.Subject);

        [MethodImpl(Inline)]
        public static implicit operator ProcessAdapter(S subject)
            => new ProcessAdapter(subject);

        [MethodImpl(Inline)]
        public static implicit operator S(A src)
            => src.Subject;
    }
}