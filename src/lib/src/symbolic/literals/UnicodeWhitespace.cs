//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    /// <summary>
    /// Defines (a subset of) the unicode whitespace characters
    /// </summary>
    /// <remarks>
    /// See https://en.wikipedia.org/wiki/Whitespace_character
    /// </remarks>
    [SymSource]
    public enum UnicodeWhitespace : ushort
    {
        Tab = Unicode.Tab,

        LF = Unicode.LF,

        FF = Unicode.FF,

        CR = Unicode.CR,

        Space = Unicode.Space,

        NextLine = Unicode.NextLine,

        NoBreakSpace = Unicode.NoBreakSpace,
    }
}