//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class JsonDeps
    {
        public record struct RuntimeFileInfo
        {
            public FilePath Path;

            public string AssemblyVersion;

            public string FileVersion;

            public string Format()
            {
                if(Path.IsNonEmpty)
                {
                    if(text.nonempty(AssemblyVersion))
                        return string.Format("{0}, {1}", Path.ToUri(), AssemblyVersion);
                    else
                        return Path.ToUri().Format();
                }
                return string.Empty;
            }

            public override string ToString()
                => Format();
        }
    }
}