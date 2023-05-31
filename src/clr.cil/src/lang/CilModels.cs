//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using Msil;

    [ApiHost]
    public readonly partial struct CilModels
    {
        public static MetadataVisualizer mdv(MetadataReader src, StreamWriter dst)
            => new MetadataVisualizer(src,dst);
        [Op]
        public static string format(EcmaSig src)
            => DefaultMsilFormatProvider.Instance.SigByteArrayToString(src);
    }
}