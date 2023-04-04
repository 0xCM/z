//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using Windows;

    public unsafe class NativeImage : NativeImage<NativeImage>
    {
        public NativeImage()
        {

        }
        public NativeImage(FilePath path, ImageHandle handle)
            : base(path,handle)
        {
        }

        [MethodImpl(Inline)]
        public static implicit operator void*(NativeImage src)
            => src.BaseAddress.Pointer();        
 
        [MethodImpl(Inline)]
        public static implicit operator IntPtr(NativeImage src)
            => src.Handle;
    }
}