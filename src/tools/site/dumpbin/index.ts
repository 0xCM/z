import * as Core from "../core"

export type Name='dumpbin'
export type Tool = Core.Actor<Name>

export type Flag = ''
    | '/ALL'
    | '/ARCHIVEMEMBERS'
    | '/CLRHEADER'
    | '/DEPENDENTS'
    | '/DIRECTIVES'
    | '/EXPORTS'
    | '/FPO'
    | '/HEADERS'
    | '/LINENUMBERS'
    | '/LOADCONFIG'
    | '/NOLOGO'
    | '/NOPDB'
    | '/PDATA'
    | '/RELOCATIONS'
    | '/SUMMARY'
    | '/SYMBOLS'
    | '/TLS'
    | '/UNWINDINFO'

export type BytesOption = 'Bytes' | 'NOBYTES'
export type HexSize = 1 | 2 | 4 | 8
export type ValuesPerLine = number
export type DisasmOption = '/DISASM' | BytesOption
export type LinkerMember = 1 | 2

// /RAWDATA[:{1|2|4|8|NONE[,number]]
export type Option = ''
    | '/DISASM[:{BYTES|NOBYTES}]'
    | '/ERRORREPORT:{NONE|PROMPT|QUEUE|SEND}'
    | '/IMPORTS[:filename]'
    | '/LINKERMEMBER[:{1|2}]'
    | '/PDBPATH[:VERBOSE]'
    | '/RANGE:vaMin[,vaMax]'
    | '/RAWDATA[:{NONE|1|2|4|8}[,#]]'
    | '/SECTION:name'
