//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{

    public readonly struct CasePaths
    {
        public PartId PartId {get;}

        public FolderPath Root {get;}

        public Type UnitType {get;}

        [MethodImpl(Inline)]
        public CasePaths(FolderPath root, PartId part, Type subject)
        {
            PartId = part;
            Root = root;
            UnitType = subject;
        }

        FolderPath PartDir
        {
            [MethodImpl(Inline)]
            get => Root + FS.folder(PartId.Format());
        }

        FolderPath CaseDir
        {
            [MethodImpl(Inline)]
            get => PartDir + FS.folder(UnitType.Name);
        }

        [MethodImpl(Inline)]
        public FilePath CasePath(FS.FileName @case)
            => CaseDir + @case;

        [MethodImpl(Inline)]
        public FilePath CasePath(FileExt? ext = null, [CallerName] string caller = null)
            => CasePath(FS.file(caller,  ext ?? DefaultExt));

        FileExt DefaultExt
        {
            [MethodImpl(Inline)]
            get => FS.Csv;
        }
    }
}