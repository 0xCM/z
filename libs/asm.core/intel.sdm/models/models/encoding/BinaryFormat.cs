//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    partial struct SdmModels
    {
        /// <summary>
        /// Represents an entry in an instruction's binary format table
        /// </summary>
        public struct BinaryFormat
        {
            public AsmMnemonic Mnemonic;

            public TextMarker Marker;

            public string BitFormat;
        }
    }
}