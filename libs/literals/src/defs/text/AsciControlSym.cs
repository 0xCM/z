//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    /// <summary>
    /// Defines asci control symbols
    /// </summary>
    [SymSource(chars)]
    public enum AsciControlSym : ushort
    {
        /// <summary>
        /// The '\0' control symbol
        /// </summary>
        Null = '\0',

        /// <summary>
        /// Start of heading, asci code 1
        /// </summary>
        SOH = 1,

        /// <summary>
        /// Start of text, asci code 2
        /// </summary>
        SOT = 2,

        /// <summary>
        /// End of text, asci code 3
        /// </summary>
        EOT = 3,

        /// <summary>
        /// End of transmission, asci code 4
        /// </summary>
        EOTR = 4,

        /// <summary>
        /// Enquiry, asci code 5
        /// </summary>
        ENQ = 5,

        /// <summary>
        /// Acknowledgement, asci code 6
        /// </summary>
        ACK = 6,

        /// <summary>
        /// Hell's bells, asci code 7
        /// </summary>
        Bell = '\a',

        /// <summary>
        /// The backspace control symbol '\b', asci code 8
        /// </summary>
        BS = '\b',

        /// <summary>
        /// The horizontal tab control character '\t',
        /// </summary>
        Tab = '\t',

        /// <summary>
        /// The vertical tab control character '\v'
        /// </summary>
        VTab = '\v',

        /// <summary>
        /// The new-line control character \n', asci code 10
        /// </summary>
        LF = '\n',

        /// <summary>
        /// The form-feed control character '\f', asci code 12
        /// </summary>
        FF  = '\f',

        /// <summary>
        /// The carriage return control character '\r', asci code 13
        /// </summary>
        CR = '\r',

        /// <summary>
        /// The delete control character, asci code 127
        /// </summary>
        Del = (byte)sbyte.MaxValue
    }
}
