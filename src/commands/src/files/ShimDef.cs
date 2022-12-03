//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;
    
    public record struct ShimDef
    {
        public static ShimDef parse(string[] src)
        {
            var count = src.Length;
            if(count != 3)
                throw new ArgumentException(ShimDef.Grammar);

            var path = FS.path(skip(src,0));
            var target = FS.dir(skip(src,2));
            return new ShimDef(path,skip(src,1),target);
        }

        public static ShimDef validate(ShimDef src)
        {
            var dst = src;
            if(!src.ShimSource.Exists)
                @throw($"Shim target '{src.ShimSource}' does not exist");

            if(!src.TargetFolder.Exists)
                @throw($"Target directory '{src.TargetFolder}' does not exist");

            return dst;
        }

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
