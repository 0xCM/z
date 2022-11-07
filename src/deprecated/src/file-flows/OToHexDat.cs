//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using K = FileKind;

    using static Tools;

    partial class FileFlows
    {
        /// <summary>
        /// *.obj -> *.hex.dat
        /// </summary>
        public class OToHexDat : FileFlow<OToHexDat,Zsh>
        {
            public OToHexDat()
                : base(ztool, K.O, K.HexDat)
            {

            }
        }
    }
}