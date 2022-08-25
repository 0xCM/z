//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial struct FS
    {
        [Op]
        public static FileName hostfile(ApiHostUri uri, FileExt ext)
            => file(string.Format("{0}.{1}", uri.Part.Format(), uri.HostName), ext);
    }
}