//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public class ApiFiles
    {
        public static FileName filename(ApiHostUri host, FileExt ext)
            => FS.file(host.Id.Format(), ext);

        public static FileName filename(ApiHostUri host, FileExt a, FileExt b)
            => FS.file(text.concat(host.Id.Format(), a), b);

        [MethodImpl(Inline), Op]
        public static FolderName folder(ApiHostUri host)
            => FS.folder(host.HostName);

        [MethodImpl(Inline), Op]
        public static FolderName folder(PartId part)
            => FS.folder(part.Format());

        [Op]
        public static FileName hostfile(ApiHostUri uri, FileExt ext)
            => FS.file(string.Format("{0}.{1}", uri.Part.Format(), uri.HostName), ext);

        [Op]
        public static FileName hostfile(ApiHostUri uri, FileKind ext)
            => FS.file(string.Format("{0}.{1}", uri.Part.Format(), uri.HostName), ext);

        /// <summary>
        /// Determines whether the name of a file is of the form {owner}.{host}.{*}
        /// </summary>
        /// <param name="host">The owner to test</param>
        public static bool IsHost(FileName src, ApiHostUri host)
            => src.Name.Text.StartsWith(string.Concat(host.Part.Format(), Chars.Dot, host.HostName.ToLower(), Chars.Dot));

        [Op]
        public static FileName file(ApiHostUri host, FileExt ext)
            => FS.file(string.Format("{0}.{1}", host.Part.Format(), host.HostName), ext);

        [Op]
        public static FileName file(ApiHostUri host, string subject, FileExt ext)
            => FS.file(string.Format("{0}.{1}.{2}", host.Part.Format(), host.HostName, subject), ext);

        public static FileName file(ApiHostUri host, FileKind kind)
            => file(host,kind.Ext());

        [Op]
        public static FileName file(PartId part, FileExt x1, FileExt x2)
            => FS.file(part, FS.combine(x1, x2));

        [Op]
        public static FileName file(PartId part, string hostname, FileExt ext)
            => FS.file(text.concat(part.Format(), Chars.Dot, hostname), ext);
    }
}