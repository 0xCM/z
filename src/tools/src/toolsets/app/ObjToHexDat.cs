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
        public class ObjToHexDat : FileFlow<ObjToHexDat,ZTool>
        {
            public ObjToHexDat()
                : base(ztool, K.Obj, K.HexDat)
            {

            }
        }
    }
}