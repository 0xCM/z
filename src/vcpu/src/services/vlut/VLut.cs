//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

[ApiHost]
public class VLut
{
    [MethodImpl(Inline), Init]
    public static VLut16 init(Vector128<byte> src)
        => new (src);

    [MethodImpl(Inline), Init]
    public static VLut32 init(Vector256<byte> src)
        => new (src);
}
