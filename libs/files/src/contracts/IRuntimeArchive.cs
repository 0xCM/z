//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static FileKind;

    public interface IRuntimeArchive : IRootedArchive
    {
        /// <summary>
        /// All runtime-related files in the archive
        /// </summary>
        FS.Files RuntimeFiles()
             => Root.Files(false, Exe, Dll, Pdb, Json, Xml);

        FS.Files ExeFiles()
            => Files().Where(x => x.Is(Exe));

        FS.Files XmlFiles()
            => Files().Where(x => x.Is(Xml));

        FS.Files DllFiles()
            => Files().Where(x => x.Is(Dll));
    }
}