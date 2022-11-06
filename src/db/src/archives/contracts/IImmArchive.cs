//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public interface IImmArchive : IRootedArchive
    {
        FolderPath[] ImmDirs(PartId part)
            => Root.SubDirs().Where(d => d.Name.EndsWith(part.Format()));

        FolderPath[] ImmDirs(FolderPath root, PartId part)
            => Root.SubDirs().Where(d => d.Name.EndsWith(part.Format()));

        FolderPath[] ImmHostDirs(PartId part)
            => ImmDirs(part).SelectMany(path => path.SubDirs());

        FolderPath[] ImmHostDirs(FolderPath root, PartId part)
            => ImmDirs(root, part).SelectMany(path => path.SubDirs());

        FolderPath[] ImmHostDirs(params PartId[] parts)
            => parts.SelectMany(ImmHostDirs);

        FolderPath[] ImmHostDirs(FolderPath root, params PartId[] parts)
        {
            var dst = core.list<FolderPath>();
            foreach(var p in parts)
                dst.AddRange(ImmHostDirs(root, p));
            return dst.ToArray();
        }

        FolderPath ImmSubDir(FolderName name)
            => (Root + name);

        FolderPath ImmSubDir(FolderPath root, FolderName name)
            => (Root + name);

        FilePath HexImmPath(PartId owner, ApiHostUri host, OpIdentity id, bool refined)
            => ImmSubDir(FS.folder(owner.Format(), host.HostName)) + id.ToFileName(refined ? "r" : EmptyString, FS.Hex);

        FilePath HexImmPath(FolderPath root, PartId owner, ApiHostUri host, OpIdentity id, bool refined)
            => ImmSubDir(root, FS.folder(owner.Format(), host.HostName)) + id.ToFileName(refined ? "r" : EmptyString, FS.Hex);

        FilePath AsmImmPath(PartId owner, ApiHostUri host, OpIdentity id, bool refined)
            => ImmSubDir(FS.folder(owner.Format(), host.HostName)) + id.ToFileName(refined ? "r" : EmptyString, FS.Asm);

        FilePath AsmImmPath(FolderPath root, PartId owner, ApiHostUri host, OpIdentity id, bool refined)
            => ImmSubDir(root, FS.folder(owner.Format(), host.HostName)) + id.ToFileName(refined ? "r" : EmptyString, FS.Asm);
    }
}