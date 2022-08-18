//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [ApiHost,Free]
    public class AsciStrings
    {
        [Op]
        public static IAsciStringFormatter formatter()
            => new AsciStringFormatter();
    }
}