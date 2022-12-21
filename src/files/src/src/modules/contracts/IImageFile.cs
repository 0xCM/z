//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public interface IImageFile
    {
        FilePath Path {get;}

        public bool IsExe
            => Path.Is(FileKind.Exe);
        
        public bool IsDll
            => Path.Is(FileKind.Dll);
    }

    public interface IImageFile<F> : IImageFile
        where F : IImageFile<F>, new()
    {

    }
}