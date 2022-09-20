//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public record struct ShimDef
    {
        public const string Grammar = $"<{nameof(ShimSource)}> <{nameof(ShimName)}> <{nameof(TargetFolder)}>";

        public FilePath ShimSource;
        
        public string ShimName;
     
        public FolderPath TargetFolder;

        public ShimDef()
        {
            ShimSource = FilePath.Empty;
            ShimName = string.Empty;
            TargetFolder = FolderPath.Empty;
        }

        public ShimDef(FilePath src, string name, FolderPath dst)
        {
            ShimSource = src;
            ShimName = name;
            TargetFolder = dst;
        }

        public FilePath TargetPath 
            => TargetFolder + FS.file(ShimName,FileKind.Exe);

        public string Format()
            => ToString();

        public static ShimDef Empty = new();
    }
}
