//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public abstract class ImageRef<I> : IImageRef
        where I : INativeImage, new()
    {
        readonly I Image;

        protected ImageRef(I image)
        {
            Image = image;            
        }

        public ImageHandle Handle 
        {
            [MethodImpl(Inline)]
            get => Image.Handle;
        }

        public MemoryAddress BaseAddress 
            => Image.BaseAddress;

        public FilePath Path 
            => Image.Path;
    }
}