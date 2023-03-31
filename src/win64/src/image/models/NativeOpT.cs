//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{    
    public abstract class NativeOp<F> : INativeFunction<F>
        where F : NativeOp<F>
    {
        public string Name {get;}

        public NativeImage Image {get;}

        public MemoryAddress Address {get;}

        protected NativeOp(NativeImage image, string name)
        {
            Name = name;
            Image = image;
            Address = image.ProcAddress(name);
        }

        ImageHandle INativeFunction.Image
            => Image.Handle;
    }
}