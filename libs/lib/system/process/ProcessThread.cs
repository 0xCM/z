//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using S = System.Diagnostics.ProcessThread;
    using D = System.Diagnostics;
    using A = ProcessThreadAdapter;

    public readonly struct ProcessThreadAdapter : IAdapter<A,S>
    {
        [MethodImpl(Inline)]
        public static A adapt(S subject)
            => new A(subject);

        public S Subject {get;}

        [MethodImpl(Inline)]
        public ProcessThreadAdapter(S subject)
            => Subject = subject;

        [MethodImpl(Inline)]
        public A Adapt(S subject)
            => new A(subject);

        public override string ToString()
            => Subject.ToString();

        [MethodImpl(Inline)]
        public static implicit operator A(S src)
            => new A(src);

        //
        // Summary:
        //     Gets the base priority of the thread.
        //
        // Returns:
        //     The base priority of the thread, which the operating system computes by combining
        //     the process priority class with the priority level of the associated thread.
        public int BasePriority
        {
            [MethodImpl(Inline)]
            get => Subject.BasePriority;
        }

        //
        // Summary:
        //     Gets the current priority of the thread.
        //
        // Returns:
        //     The current priority of the thread, which may deviate from the base priority
        //     based on how the operating system is scheduling the thread. The priority may
        //     be temporarily boosted for an active thread.
        public int CurrentPriority
        {
            [MethodImpl(Inline)]
            get => Subject.CurrentPriority;
        }

        //
        // Summary:
        //     Gets the unique identifier of the thread.
        //
        // Returns:
        //     The unique identifier associated with a specific thread.
        public int Id
        {
            [MethodImpl(Inline)]
            get => Subject.Id;
        }

        //
        // Summary:
        //     Sets the preferred processor for this thread to run on.
        //
        // Returns:
        //     The preferred processor for the thread, used when the system schedules threads,
        //     to determine which processor to run the thread on.
        //
        // Exceptions:
        //   T:System.ComponentModel.Win32Exception:
        //     The system could not set the thread to start on the specified processor.
        //
        //   T:System.NotSupportedException:
        //     The process is on a remote computer.
        public int IdealProcessor
        {
            [MethodImpl(Inline)]
            set => Subject.IdealProcessor = value;
        }

        //
        // Summary:
        //     Gets or sets the priority level of the thread.
        //
        // Returns:
        //     One of the System.Diagnostics.ThreadPriorityLevel values, specifying a range
        //     that bounds the thread's priority.
        //
        // Exceptions:
        //   T:System.ComponentModel.Win32Exception:
        //     The thread priority level information could not be retrieved. -or- The thread
        //     priority level could not be set.
        //
        //   T:System.NotSupportedException:
        //     The process is on a remote computer.
        public D.ThreadPriorityLevel PriorityLevel
        {
            [MethodImpl(Inline)]
            get => Subject.PriorityLevel;

            [MethodImpl(Inline)]
            set => Subject.PriorityLevel = value;
        }

        //
        // Summary:
        //     Gets the amount of time that the thread has spent running code inside the operating
        //     system core.
        //
        // Returns:
        //     A System.TimeSpan indicating the amount of time that the thread has spent running
        //     code inside the operating system core.
        //
        // Exceptions:
        //   T:System.ComponentModel.Win32Exception:
        //     The thread time could not be retrieved.
        //
        //   T:System.NotSupportedException:
        //     The process is on a remote computer.
        public Duration PrivilegedProcessorTime
        {
            [MethodImpl(Inline)]
            get => Subject.PrivilegedProcessorTime;
        }

        //
        // Summary:
        //     Sets the processors on which the associated thread can run.
        //
        // Returns:
        //     An System.IntPtr that points to a set of bits, each of which represents a processor
        //     that the thread can run on.
        //
        // Exceptions:
        //   T:System.ComponentModel.Win32Exception:
        //     The processor affinity could not be set.
        //
        //   T:System.NotSupportedException:
        //     The process is on a remote computer.
        public ulong ProcessorAffinity
        {
            [MethodImpl(Inline)]
            set => Subject.ProcessorAffinity = (IntPtr)value;
        }

        //
        // Summary:
        //     Gets the memory address of the function that the operating system called that
        //     started this thread.
        //
        // Returns:
        //     The thread's starting address, which points to the application-defined function
        //     that the thread executes.
        //
        // Exceptions:
        //   T:System.NotSupportedException:
        //     The process is on a remote computer.
        public MemoryAddress StartAddress
        {
            [MethodImpl(Inline)]
            get => Subject.StartAddress;
        }

        //
        // Summary:
        //     Gets the time that the operating system started the thread.
        //
        // Returns:
        //     A System.DateTime representing the time that was on the system when the operating
        //     system started the thread.
        //
        // Exceptions:
        //   T:System.ComponentModel.Win32Exception:
        //     The thread time could not be retrieved.
        //
        //   T:System.NotSupportedException:
        //     The process is on a remote computer.
        public Timestamp StartTime
        {
            [MethodImpl(Inline)]
            get => Subject.StartTime;
        }

        //
        // Summary:
        //     Gets the current state of this thread.
        //
        // Returns:
        //     A System.Diagnostics.ThreadState that indicates the thread's execution, for example,
        //     running, waiting, or terminated.
        //
        // Exceptions:
        //   T:System.NotSupportedException:
        //     The process is on a remote computer.
        public D.ThreadState ThreadState
        {
            [MethodImpl(Inline)]
            get => Subject.ThreadState;
        }

        //
        // Summary:
        //     Gets the total amount of time that this thread has spent using the processor.
        //
        // Returns:
        //     A System.TimeSpan that indicates the amount of time that the thread has had control
        //     of the processor.
        //
        // Exceptions:
        //   T:System.ComponentModel.Win32Exception:
        //     The thread time could not be retrieved.
        //
        //   T:System.NotSupportedException:
        //     The process is on a remote computer.
        public Duration TotalProcessorTime
        {
            [MethodImpl(Inline)]
            get => Subject.TotalProcessorTime;
        }

        //
        // Summary:
        //     Gets the amount of time that the associated thread has spent running code inside
        //     the application.
        //
        // Returns:
        //     A System.TimeSpan indicating the amount of time that the thread has spent running
        //     code inside the application, as opposed to inside the operating system core.
        //
        // Exceptions:
        //   T:System.ComponentModel.Win32Exception:
        //     The thread time could not be retrieved.
        //
        //   T:System.NotSupportedException:
        //     The process is on a remote computer.
        public TimeSpan UserProcessorTime
        {
            [MethodImpl(Inline)]
            get => Subject.UserProcessorTime;
        }

        //
        // Summary:
        //     Gets the reason that the thread is waiting.
        //
        // Returns:
        //     A System.Diagnostics.ThreadWaitReason representing the reason that the thread
        //     is in the wait state.
        //
        // Exceptions:
        //   T:System.InvalidOperationException:
        //     The thread is not in the wait state.
        //
        //   T:System.NotSupportedException:
        //     The process is on a remote computer.
        public D.ThreadWaitReason WaitReason
        {
            [MethodImpl(Inline)]
            get => Subject.WaitReason;
        }

        //
        // Summary:
        //     Resets the ideal processor for this thread to indicate that there is no single
        //     ideal processor. In other words, so that any processor is ideal.
        //
        // Exceptions:
        //   T:System.ComponentModel.Win32Exception:
        //     The ideal processor could not be reset.
        //
        //   T:System.NotSupportedException:
        //     The process is on a remote computer.
        [MethodImpl(Inline)]
        public void ResetIdealProcessor()
            => Subject.ResetIdealProcessor();
    }
}