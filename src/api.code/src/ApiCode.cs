//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    [ApiHost("api")]
    public partial class ApiCode
    {
        [Op]
        public static ApiHostRes hostres(ApiHostBlocks src)
        {
            var count = src.Length;
            var buffer = alloc<BinaryResSpec>(count);
            var dst = span(buffer);
            var blocks = src.Blocks.View;
            for(var i=0u; i<count; i++)
            {
                ref readonly var code = ref skip(blocks,i);
                seek(dst,i) = new BinaryResSpec(LegalIdentityBuilder.code(code.Id), code.Encoded);
            }
            return new ApiHostRes(src.Host, buffer);
        }        

        static bool PllExec
        {
            [MethodImpl(Inline)]
            get => AppData.get().PllExec();
        }

        [MethodImpl(Inline), Op]
        public static ApiCodeParser parser(byte[] buffer)
            => new (EncodingPatterns.Default, buffer);        
    }
}