//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using S = AsciControlSym;

    /// <summary>
    /// Defines asci control codes
    /// </summary>
    [SymSource(chars)]
    public enum AsciControlCode : byte
    {
        /// <summary>
        /// The null terminator, asci code 0
        /// </summary>
        Null = (byte)S.Null,

        /// <summary>
        /// Start of heading, asci code 1
        /// </summary>
        SOH = (byte)S.SOH,

        /// <summary>
        /// Start of text, asci code 2
        /// </summary>
        SOT = (byte)S.SOT,

        /// <summary>
        /// End of text, asci code 3
        /// </summary>
        EOT = (byte)S.EOT,

        /// <summary>
        /// End of transmission, asci code 4
        /// </summary>
        EOTR = (byte)S.EOTR,

        /// <summary>
        /// Enquiry, asci code 5
        /// </summary>
        ENQ = (byte)S.ENQ,

        /// <summary>
        /// Acknowledgement, asci code 6
        /// </summary>
        ACK = (byte)S.ACK,

        /// <summary>
        /// Hell's bells, asci code 7
        /// </summary>
        Bell = (byte)S.Bell,

        /// <summary>
        /// The backspace control symbol code
        /// </summary>
        BS = (byte)S.BS,

        /// <summary>
        /// The tab control symbol, asci code 9
        /// </summary>
        Tab = (byte)S.Tab,

        /// <summary>
        /// The vertical tab control character '\v'
        /// </summary>
        VTab = (byte)S.VTab,

        /// <summary>
        /// The line-feed/new-line control symbol, asci code 10
        /// </summary>
        LF = (byte)S.LF,

        /// <summary>
        /// The form-feed control symbol, asci code 12
        /// </summary>
        FF  = (byte)S.FF,

        /// <summary>
        /// The carriage return control symbol, asci code 13
        /// </summary>
        CR = (byte)S.CR,

        /// <summary>
        /// The delete control character, asci code 127
        /// </summary>
        Del = (byte)S.Del

    }
}