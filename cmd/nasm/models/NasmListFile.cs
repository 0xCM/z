//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public readonly struct NasmListFile
    {
        public FilePath Path {get;}

        [MethodImpl(Inline)]
        public NasmListFile(FilePath target)
        {
            Path = target;
        }

        [MethodImpl(Inline)]
        public static implicit operator NasmListFile(FilePath src)
            => new NasmListFile(src);
    }
}