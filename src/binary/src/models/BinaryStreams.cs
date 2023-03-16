//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public partial class BinaryStreams
    {
        public static IBinaryStream stream(FilePath src)
            => new FileStream(src);

        public class ByteStream : BinaryStream<byte> 
        {
            protected ByteStream(MemoryAddress @base, uint length)
                : base(@base,length)            
            {

            }

        }
    }
}