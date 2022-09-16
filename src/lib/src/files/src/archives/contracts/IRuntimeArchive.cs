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
        Files RuntimeFiles()
             => Root.Files(false, Exe, Dll, Pdb, Json, Xml);

        Files ExeFiles()
            => Files().Where(x => x.Is(Exe));

        Files XmlFiles()
            => Files().Where(x => x.Is(Xml));

        Files DllFiles()
            => Files().Where(x => x.Is(Dll));
    }
}