//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class DbgHelp
    {
        public unsafe class Image : NativeImage<Image>
        {            
            public Image()
            {

            }
            public Image(FilePath path, ImageHandle handle)
                : base(path, handle)
            {
            }

        }
    }
}