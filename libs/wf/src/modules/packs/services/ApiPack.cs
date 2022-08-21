//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public class ApiPack : IApiPack
    {
        public readonly FS.FolderPath Root;

        public readonly Timestamp Timestamp;

        public ApiPack(FS.FolderPath root, Timestamp ts)
        {
            Root = root;
            Timestamp = ts;
        }

        Timestamp IApiPack.Timestamp 
            => Timestamp;

        FS.FolderPath IRootedArchive.Root 
            => Root;

        public string Format()
            => string.Format("{0}: {1}", Timestamp, Root);

        public override string ToString()
            => Format();
    }
}