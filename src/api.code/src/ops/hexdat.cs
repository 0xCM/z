//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    partial class ApiCode
    {
        /// <summary>
        /// Emits a line of hex data that specifies the encoding for each emember
        /// </summary>
        /// <param name="src"></param>
        /// <param name="dst"></param>
        [Op]
        public static ByteSize hexdat(ReadOnlySpan<ApiEncoded> src, FilePath dst)
        {
            var options = HexFormatOptions.define();
            using var writer = dst.AsciWriter();
            var size = 0u;
            for(var i=0; i<src.Length; i++)
            {
                ref readonly var code = ref sys.skip(src,i).Code;
                writer.WriteLine(code.Format(options));
                size += code.Size;
            }

            return size;
        }

    }
}