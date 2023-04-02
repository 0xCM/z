//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{    
    public abstract class NativeFunction<F> : INativeFunction
        where F : NativeFunction<F>
    {
        public string Name {get;}

        public NativeImage Image {get;}

        public MemoryAddress Address {get;}

        protected NativeFunction(NativeImage image, string name)
        {
            Name = name;
            Image = image;
            Address = image.ProcAddress(name);
        }

    }
}