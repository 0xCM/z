//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class XTend
    {
        public static BinaryWriter BinaryWriter(this FilePath dst)
            => new BinaryWriter(File.Open(dst.EnsureParentExists().Name, FileMode.Create), Encoding.ASCII);
    }
}