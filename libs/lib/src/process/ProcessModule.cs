//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using S = System.Diagnostics.ProcessModule;
    using D = System.Diagnostics;
    using A = ProcessModule;

    public class ProcessModule : IAdapter<A,S>
    {
        [MethodImpl(Inline)]
        public static A adapt(S subject)
            => new A(subject);

        public S Subject {get;}

        [MethodImpl(Inline)]
        public ProcessModule(S subject)
            => Subject = subject;

        [MethodImpl(Inline)]
        public ProcessModule Adapt(S subject)
            => adapt(subject);

        public override string ToString()
            => Subject.ToString();

        //
        // Summary:
        //     Gets the memory address where the module was loaded.
        //
        // Returns:
        //     The load address of the module.
        public MemoryAddress BaseAddress
        {
            [MethodImpl(Inline)]
            get => Subject.BaseAddress;
        }

        //
        // Summary:
        //     Gets the memory address for the function that runs when the system loads and
        //     runs the module.
        //
        // Returns:
        //     The entry point of the module.
        public MemoryAddress EntryPointAddress
        {
            [MethodImpl(Inline)]
            get => Subject.EntryPointAddress;
        }

        //
        // Summary:
        //     Gets the full path to the module.
        //
        // Returns:
        //     The fully qualified path that defines the location of the module.
        public FilePath Path
        {
            [MethodImpl(Inline)]
            get => FS.path(Subject.FileName);
        }

        //
        // Summary:
        //     Gets version information about the module.
        //
        // Returns:
        //     A System.Diagnostics.FileVersionInfo that contains the module's version information.
        public D.FileVersionInfo FileVersionInfo
        {
            [MethodImpl(Inline)]
            get => Subject.FileVersionInfo;
        }

        //
        // Summary:
        //     Gets the amount of memory that is required to load the module.
        //
        // Returns:
        //     The size, in bytes, of the memory that the module occupies.
        public ByteSize ModuleMemorySize
        {
            [MethodImpl(Inline)]
            get => Subject.ModuleMemorySize;
        }

        //
        // Summary:
        //     Gets the name of the process module.
        //
        // Returns:
        //     The name of the module.
        public string ModuleName
        {
            [MethodImpl(Inline)]
            get => Subject.ModuleName;
        }

        [MethodImpl(Inline)]
       public static implicit operator ProcessModule(D.ProcessModule src)
            => new ProcessModule(src);
    }
}