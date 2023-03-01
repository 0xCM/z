//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class XTend
    {
        public static BinaryReader BinaryReader(this FilePath src)
            => new BinaryReader(File.Open(src.Format(), FileMode.Open));
    }
}