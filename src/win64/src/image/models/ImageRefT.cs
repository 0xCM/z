//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public abstract class ImageRef<I> : INativeImage
        where I : INativeImage, new()
    {
        readonly I Image;

        protected ImageRef(I image)
        {
            Image = image;            
        }

        public ImageHandle Handle => Image.Handle;

        public MemoryAddress BaseAddress => Image.BaseAddress;

        public FilePath Path => Image.Path;

        void IDisposable.Dispose()
        {

        }
    }
}