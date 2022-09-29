// https://github.com/llvm/llvm-project/llvm/include/llvm/Support/X86DisassemblerDecoderCommon.h
export type INSTRUCTIONS_SYM  = 'x86DisassemblerInstrSpecifiers'
export type CONTEXTS_SYM      = 'x86DisassemblerContexts'
export type ONEBYTE_SYM       = 'x86DisassemblerOneByteOpcodes'
export type TWOBYTE_SYM       = 'x86DisassemblerTwoByteOpcodes'
export type THREEBYTE38_SYM   = 'x86DisassemblerThreeByte38Opcodes'
export type THREEBYTE3A_SYM   = 'x86DisassemblerThreeByte3AOpcodes'
export type XOP8_MAP_SYM      = 'x86DisassemblerXOP8Opcodes'
export type XOP9_MAP_SYM      = 'x86DisassemblerXOP9Opcodes'
export type XOPA_MAP_SYM      = 'x86DisassemblerXOPAOpcodes'
export type THREEDNOW_MAP_SYM = 'x86Disassembler3DNowOpcodes'
export type MAP5_SYM          = 'x86DisassemblerMap5Opcodes'
export type MAP6_SYM          = 'x86DisassemblerMap6Opcodes'


export enum attributeBits {
    ATTR_NONE   = 0x00,
    ATTR_64BIT  = 0x1 << 0,
    ATTR_XS     = 0x1 << 1,
    ATTR_XD     = 0x1 << 2,
    ATTR_REXW   = 0x1 << 3,
    ATTR_OPSIZE = 0x1 << 4,
    ATTR_ADSIZE = 0x1 << 5,
    ATTR_VEX    = 0x1 << 6,
    ATTR_VEXL   = 0x1 << 7,
    ATTR_EVEX   = 0x1 << 8,
    ATTR_EVEXL2 = 0x1 << 9,
    ATTR_EVEXK  = 0x1 << 10,
    ATTR_EVEXKZ = 0x1 << 11,
    ATTR_EVEXB  = 0x1 << 12,
    ATTR_max    = 0x1 << 13,
  };
  
export type OpCodeTable = 
  | INSTRUCTIONS_SYM
  | CONTEXTS_SYM
  | ONEBYTE_SYM
  | TWOBYTE_SYM
  | THREEBYTE38_SYM
  | THREEBYTE3A_SYM
  | XOP8_MAP_SYM
  | XOP9_MAP_SYM
  | XOPA_MAP_SYM
  | THREEBYTE38_SYM
  | MAP5_SYM
  | MAP6_SYM
