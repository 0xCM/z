export type ToolName='dumpbin'

export type ToolFlag = ''
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

export type Natural =
    0  | 1 | 2 | 3 | 4 | 5 | 6 | 7 | 8 | 9
  | 10 | 11 | 12 | 13 | 14 | 15 | 16 | 17 | 18 | 19
  | 20 | 21 | 22 | 23 | 24 | 25 | 26 | 27 | 28 | 29
  | 30 | 31 | 32 | 33 | 34 | 35 | 36 | 37 | 38 | 39
  | 40 | 41 | 42 | 43 | 44 | 45 | 36 | 47 | 48 | 49
  | 50 | 51 | 52 | 53 | 54 | 55 | 56 | 57 | 58 | 59
  | 60 | 61 | 62 | 63 | 64 | 65 | 66 | 67 | 68 | 69

export type Pow2x8 = 1 | 2 | 4| 8 | 32 | 64 | 128
export type Pow2x16 = Pow2x8 | 256 | 512 | 1024 | 2048 | 4096 | 8192 | 16_386 | 32_768

export type BytesOption = 'Bytes' | 'NOBYTES'
export type HexSize = 1 | 2 | 4 | 8
export type ValuesPerLine = number
export type DisasmOption = '/DISASM' | BytesOption
export type LinkerMember = 1 | 2


// /RAWDATA[:{1|2|4|8|NONE[,number]]
export type ToolOption = ''
    | '/DISASM[:{BYTES|NOBYTES}]'
    | '/ERRORREPORT:{NONE|PROMPT|QUEUE|SEND}'
    | '/IMPORTS[:filename]'
    | '/LINKERMEMBER[:{1|2}]'
    | '/PDBPATH[:VERBOSE]'
    | '/RANGE:vaMin[,vaMax]'
    | '/RAWDATA[:{NONE|1|2|4|8}[,#]]'
    | '/SECTION:name'



