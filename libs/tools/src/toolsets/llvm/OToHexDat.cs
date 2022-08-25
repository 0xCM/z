//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using K = FileKind;

    partial class Tools
    {
        /// <summary>
        /// *.obj -> *.hex.dat
        /// </summary>
        public class OToHexDat : FileFlow<OToHexDat,ZTool>
        {
            public OToHexDat()
                : base(ztool, K.O, K.HexDat)
            {

            }
        }
    }
}