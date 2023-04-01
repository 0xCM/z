//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class DbgHelp
    {
        public unsafe class Image : NativeImage
        {            
            //readonly Index<INativeFunction> Ops;

            public Image(FilePath path, ImageHandle handle)
                : base(path, handle)
            {
                // Ops = new INativeFunction[]{
                //     new SymInitialize(this),
                // };
            }

            // public override ReadOnlySeq<INativeFunction> Operations
            // {
            //     [MethodImpl(Inline)]
            //     get => Ops;
            // }

            // [MethodImpl(Inline)]
            // T Op<T>(uint index)
            //     => (T)Ops[index];

            // public bool SymInitialize(SystemHandle hProcess, string UserSearchPath, bool fInvadeProcess)
            //     => Op<SymInitialize>(0).Invoke(hProcess, UserSearchPath, fInvadeProcess);
        }
    }
}