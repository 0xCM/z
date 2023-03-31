//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using Windows;

    public class ClrDac : NativeDll
    {
        public static ClrDac load(FilePath src)
            => new ClrDac(src, ImageHandle.own(Kernel32.LoadLibrary(src.Format())));

        internal ClrDac(FilePath path, ImageHandle handle)
            : base(path, handle)
        {
            //Main(1);
        }

    }
}