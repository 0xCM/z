//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    unsafe partial class DbgHelp
    {
        public sealed class SymInitialize : NativeOp<SymInitialize>
        {
            readonly delegate* unmanaged<ulong*, sbyte*, bool, bool> Op;

            public SymInitialize(Image image)
                : base(image, nameof(SymInitialize))
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
}