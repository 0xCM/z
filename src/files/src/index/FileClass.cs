//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [StructLayout(LayoutKind.Sequential)]
    public readonly record struct FileClass
    {
        public readonly FilePath Path;

        public readonly FileKind Kind;

        public FileClass(FilePath path, FileKind kind)
        {
            Path = path;
            Kind = kind;
        }

        public bool IsEmpty
        {
            get => Kind == 0;            
        }

        public bool IsNonEmpty
        {
            get => Kind != 0;            
        }

        public static FileClass Empty => new FileClass(FilePath.Empty, FileKind.None);
    }        
}