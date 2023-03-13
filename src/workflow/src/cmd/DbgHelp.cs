//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using Windows;

    using static DbgHelpOps;

    public unsafe partial class DbgHelpOps
    {
        public DbgHelpOps()
        {
        }

        public sealed class SymInitialize : NativeOp<SymInitialize>
        {
            readonly delegate* unmanaged<ulong*, sbyte*, bool, bool> Op;

            public SymInitialize(SystemHandle module)
                : base(nameof(SymInitialize), module)
            {
                Op = (delegate* unmanaged<ulong*, sbyte*, bool, bool>)Address.Pointer();
            } 

            public bool Invoke(SystemHandle hProcess, string UserSearchPath, bool fInvadeProcess)
            {
                var s = Marshal.StringToHGlobalAnsi(UserSearchPath);
                var ps = s.ToPointer<sbyte>();
                var result = Op(hProcess.Pointer<ulong>(), ps, fInvadeProcess);
                Marshal.FreeHGlobal(s);
                return result;
            }
        }
    }

    public unsafe partial class DbgHelp : IDisposable
    {
        public readonly FilePath Path;

        public readonly SystemHandle Handle;
        
        readonly Index<INativeOp> Ops;

        public DbgHelp(FilePath path, SystemHandle module)
        {
            Path = path;
            Handle = module;
            Ops = new INativeOp[]{
                new SymInitialize(module),
            };
        }

        public ReadOnlySeq<INativeOp> Operations
        {
            [MethodImpl(Inline)]
            get => Ops;
        }
        
        public void Dispose()
        {
            Kernel32.CloseHandle(Handle);
        }

        [MethodImpl(Inline)]
        T Op<T>(uint index)
            => (T)Ops[index];

        public bool SymInitialize(SystemHandle hProcess, string UserSearchPath, bool fInvadeProcess)
            => Op<SymInitialize>(0).Invoke(hProcess, UserSearchPath, fInvadeProcess);
    }
}