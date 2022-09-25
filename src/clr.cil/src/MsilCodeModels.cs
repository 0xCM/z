//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using Msil;

    using static sys;

    [ApiHost]
    public readonly partial struct MsilCodeModels
    {
        public static MetadataVisualizer mdv(MetadataReader src, StreamWriter dst)
            => new MetadataVisualizer(src,dst);

        [Op]
        public static string format(CliSig src)
            => DefaultMsilFormatProvider.Instance.SigByteArrayToString(src);

        public static ReadOnlySpan<MsilOpCode> opcodes()
        {
            var buffer = span<MsilOpCode>(300);
            var count = OpCodeLoader.load(ref first(buffer));
            return slice(buffer,0,count);
        }
    }
}