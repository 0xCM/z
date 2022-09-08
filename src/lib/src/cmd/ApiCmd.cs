//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static ApiCmdNames;

    public readonly struct ApiCmdNames
    {   
        const string Sep = "/";

        public const string files = nameof(files);

        public const string copy = nameof(copy);

        public const string files_copy = files + Sep + copy;
    }

    public class ApiCmd
    {
        [ApiComplete("api.files")]
        public class files
        {
            [Api]
            public static Copy copy(FolderPath src, FolderPath dst)
                => new (src,dst);

            [Api]
            public static Zip zip(FolderPath src, FilePath dst)
                => new (src,dst);

            [Cmd(files_copy)]
            public struct Copy : ICmd<Copy>
            {
                public Copy(FolderPath src, FolderPath dst)
                {
                    Source = src;
                    Target = dst;
                }

                public FolderPath Source;

                public FolderPath Target;
            }

            [Cmd(files_copy)]
            public struct Zip : ICmd<Zip>
            {
                public Zip(FolderPath src, FilePath dst)
                {
                    Source = src;
                    Target = dst;
                }

                public FolderPath Source;

                public FilePath Target;
            }
        }
    }
}