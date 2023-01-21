//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class XTend
    {
        public static IDbArchive DbArchive(this FolderPath root)
            => new DbArchive(root);

        public static string SearchPattern(this FileKind kind)
            => kind.Ext().SearchPattern;
    }
}