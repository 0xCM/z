//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Binary
{
    public class Streams
    {
        public static IBinaryStream stream(FilePath src)
            => new FileStream(src);

    }
}