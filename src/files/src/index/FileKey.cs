//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [StructLayout(LayoutKind.Sequential)]
    public readonly record struct FileKey
    {
        public readonly uint Seq;

        public readonly FileHash Hash;

        public FileKey(uint seq, FileHash hash)
        {
            Seq = seq;
            Hash = hash;
        }
    }        
}