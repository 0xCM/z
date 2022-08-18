//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [StructLayout(LayoutKind.Sequential, Pack=1)]
    public struct PageBankInfo
    {
        public ByteSize BankSize;

        public ByteSize BlockSize;

        public ByteSize PageSize;

        public uint BlockCount;

        public uint PagesPerBlock;

        public uint TotalPageCount;
    }
}