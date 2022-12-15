//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using Z0.Types;
    public class EnvVals
    {
        public sealed record class File : EnvVal<File>
        {
            readonly FilePath Value;

            public File(FilePath value)
            {
                Value = value;
            }
            
            public File()
            {
                Value = FilePath.Empty;
            }

            public override Hash32 Hash
            {
                get => Value.Hash;
            }

            public override bool IsEmpty 
                => Value.IsEmpty;

            public override string Format()        
                => Value.Format();

            public bool Equals(File src)
                => Value.Equals(src.Value);

            public override int GetHashCode()
                => Hash;

            public static implicit operator File(FilePath src)
                => new File(src);

            public static implicit operator File(FileUri src)
                => new File(src);

        }

        public sealed record class Folder : EnvVal<Folder>
        {
            readonly FolderPath Value;

            public Folder(FolderPath value)
            {
                Value = value;
            }
            
            public Folder()
            {
                Value = FolderPath.Empty;
            }

            public override Hash32 Hash
            {
                get => Value.Hash;
            }

            public override bool IsEmpty 
                => Value.IsEmpty;

            public bool Equals(Folder src)
                => Value.Equals(src.Value);

            public override int GetHashCode()
                => Hash;

            public override string Format()        
                => Value.Format();

            public static implicit operator Folder(FolderPath src)
                => new Folder(src);
        }
    }
}