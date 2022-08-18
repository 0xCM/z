//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public readonly struct NasmListFile : IFile<FS.FilePath>
    {
        public FS.FilePath Location {get;}

        [MethodImpl(Inline)]
        public NasmListFile(FS.FilePath target)
        {
            Location = target;
        }

        [MethodImpl(Inline)]
        public static implicit operator NasmListFile(FS.FilePath src)
            => new NasmListFile(src);
    }
}