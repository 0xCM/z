//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public readonly struct NasmListFile : IFile<FilePath>
    {
        public FilePath Location {get;}

        [MethodImpl(Inline)]
        public NasmListFile(FilePath target)
        {
            Location = target;
        }

        [MethodImpl(Inline)]
        public static implicit operator NasmListFile(FilePath src)
            => new NasmListFile(src);
    }
}