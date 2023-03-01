//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using Windows;

    public abstract class NativeOp<F> : INativeOp<F>
        where F : NativeOp<F>
    {
        public string Name {get;}

        public SystemHandle Module {get;}

        public MemoryAddress Address {get;}

        protected NativeOp(string name, SystemHandle module)
        {
            Name = name;
            Module = module;
            Address = Kernel32.GetProcAddress(module, name);
        }
    }
}