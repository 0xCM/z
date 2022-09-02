
export type Prefix = 
    | 'rep' 
    | 'repe' 
    | 'repne' 
    | 'lock' 
    | 'xacquire' 
    | 'xrelease' 
    | 'vex' 
    | 'vex2' 
    | 'vex3' 
    | 'evex'

export type RoundingMode =
    | 'rn-sae'
    | 'rz-sae'
    | 'rd-sae'
    | 'ru-sae'
    | 'sae'

export type Instruction<P,M,O> = {
    prefix:P
    mnemonic:M
    operands:Array<O>
}
/*
;
  endOfLine | comment

=Dir
  id = immExpr ;;

addOp
  + | -

aExpr
  term | aExpr && term

altId
  id

alpha
  Any upper or lowercase letter (A-Z) or one of these four characters: @ _ $ ?

arbitraryText
  charList

asmInstruction
  mnemonic ⟦ exprList ⟧

assumeDir
  ASSUME assumeList ;;
  | ASSUME NOTHING ;;

assumeList
  assumeRegister | assumeList , assumeRegister

assumeReg
  register : assumeVal

assumeRegister
  assumeSegReg | assumeReg

assumeSegReg
  segmentRegister : assumeSegVal

assumeSegVal
  frameExpr | NOTHING | ERROR

assumeVal
  qualifiedType | NOTHING | ERROR

bcdConst
  ⟦ sign ⟧ decNumber

binaryOp
  == | != | >= | <= | > | < | &

bitDef
  bitFieldId : bitFieldSize ⟦ = constExpr ⟧

bitDefList
  bitDef | bitDefList , ⟦ ;; ⟧ bitDef

bitFieldId
  id

bitFieldSize
  constExpr

blockStatements
  directiveList
  | .CONTINUE ⟦ .IF cExpr ⟧
  | .BREAK ⟦ .IF cExpr ⟧

bool
  TRUE | FALSE

byteRegister
  AL | AH | CL | CH | DL | DH | BL | BH | R8B | R9B | R10B | R11B | R12B | R13B | R14B | R15B

cExpr
  aExpr | cExpr || aExpr

character
  Any character with ordinal in the range 0–255 except linefeed (10).

charList
  character | charList character

className
  string

commDecl
  ⟦ nearfar ⟧ ⟦ langType ⟧ id : commType
  ⟦ : constExpr ⟧

commDir
  COMM
  commList ;;

comment
  ; text ;;

commentDir
  COMMENT delimiter
  text
  text delimiter text ;;

commList
  commDecl | commList , commDecl

commType
  type | constExpr

constant
  digits ⟦ radixOverride ⟧

constExpr
  expr

contextDir
  PUSHCONTEXT contextItemList ;;
  | POPCONTEXT contextItemList ;;

contextItem
  ASSUMES | RADIX | LISTING | CPU | ALL

contextItemList
  contextItem | contextItemList , contextItem

controlBlock
  whileBlock | repeatBlock

controlDir
  controlIf | controlBlock

controlElseif
  .ELSEIF cExpr ;;
  directiveList
  ⟦ controlElseif ⟧

controlIf
  .IF cExpr ;;
  directiveList
  ⟦ controlElseif ⟧
  ⟦ .ELSE ;;
  directiveList⟧
  .ENDIF ;;

coprocessor
  .8087 | .287 | .387 | .NO87

crefDir
  crefOption ;;

crefOption
  .CREF
  | .XCREF ⟦ idList ⟧
  | .NOCREF ⟦ idList ⟧

cxzExpr
  expr
  | ! expr
  | expr == expr
  | expr != expr

dataDecl
  DB | DW | DD | DF | DQ | DT | dataType | typeId

dataDir
  ⟦ id ⟧ dataItem ;;

dataItem
  dataDecl scalarInstList
  | structTag structInstList
  | typeId structInstList
  | unionTag structInstList
  | recordTag recordInstList

dataType
  BYTE | SBYTE | WORD | SWORD | DWORD | SDWORD | FWORD | QWORD | SQWORD | TBYTE | OWORD | REAL4 | REAL8 | REAL10 | MMWORD | XMMWORD | YMMWORD

decdigit
  0 | 1 | 2 | 3 | 4 | 5 | 6 | 7 | 8 | 9

decNumber
  decdigit
  | decNumber decdigit

delimiter
  Any character except whiteSpaceCharacter

digits
  decdigit
  | digits decdigit
  | digits hexdigit

directive
  generalDir | segmentDef

directiveList
  directive | directiveList directive

distance
  nearfar | NEAR16 | NEAR32 | FAR16 | FAR32

e01
  e01 orOp e02 | e02

e02
  e02 AND e03 | e03

e03
  NOT e04 | e04

e04
  e04 relOp e05 | e05

e05
  e05 addOp e06 | e06

e06
  e06 mulOp e07 | e06 shiftOp e07 | e07

e07
  e07 addOp e08 | e08

e08
  HIGH e09
  | LOW e09
  | HIGHWORD e09
  | LOWWORD e09
  | e09

e09
  OFFSET e10
  | SEG e10
  | LROFFSET e10
  | TYPE e10
  | THIS e10
  | e09 PTR e10
  | e09 : e10
  | e10

e10
  e10 . e11
  | e10 ⟦ expr ⟧
  | e11

e11
  ( expr )
  | ⟦ expr ⟧
  | WIDTH id
  | MASK id
  | SIZE sizeArg
  | SIZEOF sizeArg
  | LENGTH id
  | LENGTHOF id
  | recordConst
  | string
  | constant
  | type
  | id
  | $
  | segmentRegister
  | register
  | ST
  | ST ( expr )

echoDir
  ECHO arbitraryText ;;
  %OUT arbitraryText ;;

elseifBlock
  elseifStatement ;;
  directiveList
  ⟦ elseifBlock ⟧

elseifStatement
  ELSEIF constExpr
  | ELSEIFE constExpr
  | ELSEIFB textItem
  | ELSEIFNB textItem
  | ELSEIFDEF id
  | ELSEIFNDEF id
  | ELSEIFDIF textItem , textItem
  | ELSEIFDIFI textItem , textItem
  | ELSEIFIDN textItem , textItem
  | ELSEIFIDNI textItem , textItem
  | ELSEIF1
  | ELSEIF2

endDir
  END ⟦ immExpr ⟧ ;;

endpDir
  procId ENDP ;;

endsDir
  id ENDS ;;

equDir
  textMacroId EQU equType ;;

equType
  immExpr | textLiteral

errorDir
  errorOpt ;;

errorOpt
  .ERR ⟦ textItem ⟧
  | .ERRE constExpr ⟦ optText ⟧
  | .ERRNZ constExpr ⟦ optText ⟧
  | .ERRB textItem ⟦ optText ⟧
  | .ERRNB textItem ⟦ optText ⟧
  | .ERRDEF id ⟦ optText ⟧
  | .ERRNDEF id ⟦ optText ⟧
  | .ERRDIF textItem , textItem ⟦ optText ⟧
  | .ERRDIFI textItem , textItem ⟦ optText ⟧
  | .ERRIDN textItem , textItem ⟦ optText ⟧
  | .ERRIDNI textItem , textItem ⟦ optText ⟧
  | .ERR1 ⟦ textItem ⟧
  | .ERR2 ⟦ textItem ⟧

exitDir
  .EXIT ⟦ expr ⟧ ;;

exitmDir
  : EXITM | EXITM textItem

exponent
  E ⟦ sign ⟧ decNumber

expr
  SHORT e05
  | .TYPE e01
  | OPATTR e01
  | e01

exprList
  expr | exprList , expr

externDef
  ⟦ langType ⟧ id ⟦ ( altId ) ⟧ : externType

externDir
  externKey externList ;;

externKey
  EXTRN | EXTERN | EXTERNDEF

externList
  externDef | externList , ⟦ ;; ⟧ externDef

externType
  ABS | qualifiedType

fieldAlign
  constExpr

fieldInit
  ⟦ initValue ⟧ | structInstance

fieldInitList
  fieldInit | fieldInitList , ⟦ ;; ⟧ fieldInit

fileChar
  delimiter

fileCharList
  fileChar | fileCharList fileChar

fileSpec
  fileCharList | textLiteral

flagName
  ZERO? | CARRY? | OVERFLOW? | SIGN? | PARITY?

floatNumber
  ⟦ sign ⟧ decNumber . ⟦ decNumber ⟧ ⟦ exponent ⟧
  | digits R
  | digits r

forcDir
  FORC | IRPC

forDir
  FOR | IRP

forParm
  id ⟦ : forParmType ⟧

forParmType
  REQ | = textLiteral

fpuRegister
  ST expr

frameExpr
  SEG id
  | DGROUP : id
  | segmentRegister : id
  | id

generalDir
  modelDir | segOrderDir | nameDir
  | includeLibDir | commentDir
  | groupDir | assumeDir
  | structDir | recordDir | typedefDir
  | externDir | publicDir | commDir | protoTypeDir
  | equDir | =Dir | textDir
  | contextDir | optionDir | processorDir
  | radixDir
  | titleDir | pageDir | listDir
  | crefDir | echoDir
  | ifDir | errorDir | includeDir
  | macroDir | macroCall | macroRepeat | purgeDir
  | macroWhile | macroFor | macroForc
  | aliasDir

gpRegister
  AX | EAX | CX | ECX | DX | EDX | BX | EBX
  | DI | EDI | SI | ESI | BP | EBP | SP | ESP
  | R8W | R8D | R9W | R9D | R12D | R13W | R13D | R14W | R14D

groupDir
  groupId GROUP segIdList

groupId
  id

hexdigit
  a | b | c | d | e | f
  | A | B | C | D | E | F

id
  alpha
  | id alpha
  | id decdigit
  Maximum length is 247 characters.

idList
  id | idList , id

ifDir
  ifStatement ;;
  directiveList
  ⟦ elseifBlock ⟧
  ⟦ ELSE ;;
  directiveList ⟧ ;;

ifStatement
  IF constExpr
  | IFE constExpr
  | IFB textItem
  | IFNB textItem
  | IFDEF id
  | IFNDEF id
  | IFDIF textItem , textItem
  | IFDIFI textItem , textItem
  | IFIDN textItem , textItem
  | IFIDNI textItem , textItem
  | IF1
  | IF2

immExpr
  expr

includeDir
  INCLUDE fileSpec ;;

includeLibDir
  INCLUDELIB fileSpec ;;

initValue
  immExpr
  | string
  | ?
  | constExpr DUP ( scalarInstList )
  | floatNumber
  | bcdConst

inSegDir
  ⟦ labelDef ⟧ inSegmentDir

inSegDirList
  inSegDir | inSegDirList inSegDir

inSegmentDir
  instruction
  | dataDir
  | controlDir
  | startupDir
  | exitDir
  | offsetDir
  | labelDir
  | procDir ⟦ localDirList ⟧ ⟦ inSegDirList ⟧ endpDir
  | invokeDir
  | generalDir

instrPrefix
  REP | REPE | REPZ | REPNE | REPNZ | LOCK

instruction
  ⟦ instrPrefix ⟧ asmInstruction

invokeArg
  register :: register
  | expr
  | ADDR expr

invokeDir
  INVOKE expr ⟦ , ⟦ ;; ⟧ invokeList ⟧ ;;

invokeList
  invokeArg | invokeList , ⟦ ;; ⟧ invokeArg

keyword
  Any reserved word.

keywordList
  keyword | keyword keywordList

labelDef
  id : | id :: | @@:

labelDir
  id LABEL qualifiedType ;;

langType
  C | PASCAL | FORTRAN | BASIC | SYSCALL | STDCALL

listDir
  listOption ;;

listOption
  .LIST
  | .NOLIST
  | .XLIST
  | .LISTALL
  | .LISTIF
  | .LFCOND
  | .NOLISTIF
  | .SFCOND
  | .TFCOND
  | .LISTMACROALL | .LALL
  | .NOLISTMACRO | .SALL
  | .LISTMACRO | .XALL

localDef
  LOCAL idList ;;

localDir
  LOCAL parmList ;;

localDirList
  localDir | localDirList localDir

localList
  localDef | localList localDef

macroArg
  % constExpr
  | % textMacroId
  | % macroFuncId ( macroArgList )
  | string
  | arbitraryText
  | < arbitraryText >

macroArgList
  macroArg | macroArgList , macroArg

macroBody
  ⟦ localList ⟧ macroStmtList

macroCall
  id macroArgList ;;
  | id ( macroArgList )

macroDir
  id MACRO ⟦ macroParmList ⟧ ;;
  macroBody
  ENDM ;;

macroFor
  forDir forParm , < macroArgList > ;;
  macroBody
  ENDM ;;

macroForc
  forcDir id , textLiteral ;;
  macroBody
  ENDM ;;

macroFuncId
  id

macroId
  macroProcId | macroFuncId

macroIdList
  macroId | macroIdList , macroId

macroLabel
  id

macroParm
  id ⟦ : parmType ⟧

macroParmList
  macroParm | macroParmList , ⟦ ;; ⟧ macroParm

macroProcId
  id

macroRepeat
  repeatDir constExpr ;;
  macroBody
  ENDM ;;

macroStmt
  directive
  | exitmDir
  | : macroLabel
  | GOTO macroLabel

macroStmtList
  macroStmt ;;
  | macroStmtList macroStmt ;;

macroWhile
  WHILE constExpr ;;
  macroBody
  ENDM ;;

mapType
  ALL | NONE | NOTPUBLIC

memOption
  TINY | SMALL | MEDIUM | COMPACT | LARGE | HUGE | FLAT

mnemonic
  Instruction name.

modelDir
  .MODEL memOption ⟦ , modelOptlist ⟧ ;;

modelOpt
  langType | stackOption

modelOptlist
  modelOpt | modelOptlist , modelOpt

module
  ⟦ directiveList ⟧ endDir

mulOp
  * | / | MOD

nameDir
  NAME id ;;

nearfar
  NEAR | FAR

nestedStruct
  structHdr ⟦ id ⟧ ;;
  structBody
  ENDS ;;

offsetDir
  offsetDirType ;;

offsetDirType
  EVEN
  | ORG immExpr
  | ALIGN ⟦ constExpr ⟧

offsetType
  GROUP | SEGMENT | FLAT

oldRecordFieldList
  ⟦ constExpr ⟧ | oldRecordFieldList , ⟦ constExpr ⟧

optionDir
  OPTION optionList ;;

optionItem
  CASEMAP : mapType
  | DOTNAME | NODOTNAME
  | EMULATOR | NOEMULATOR
  | EPILOGUE : macroId
  | EXPR16 | EXPR32
  | LANGUAGE : langType
  | LJMP | NOLJMP
  | M510 | NOM510
  | NOKEYWORD : < keywordList >
  | NOSIGNEXTEND
  | OFFSET : offsetType
  | OLDMACROS | NOOLDMACROS
  | OLDSTRUCTS | NOOLDSTRUCTS
  | PROC : oVisibility
  | PROLOGUE : macroId
  | READONLY | NOREADONLY
  | SCOPED | NOSCOPED
  | SEGMENT : segSize
  | SETIF2 : bool

optionList
  optionItem | optionList , ⟦ ;; ⟧ optionItem

optText
  , textItem

orOp
  OR | XOR

oVisibility
  PUBLIC | PRIVATE | EXPORT

pageDir
  PAGE ⟦ pageExpr ⟧ ;;

pageExpr
  + | ⟦ pageLength ⟧ ⟦ , pageWidth ⟧

pageLength
  constExpr

pageWidth
  constExpr

parm
  parmId ⟦ : qualifiedType ⟧
  | parmId ⟦ constExpr ⟧ ⟦ : qualifiedType ⟧

parmId
  id

parmList
  parm | parmList , ⟦ ;; ⟧ parm

parmType
  REQ | = textLiteral | VARARG

pOptions
  ⟦ distance ⟧ ⟦ langType ⟧ ⟦ oVisibility ⟧

primary
  expr binaryOp expr | flagName | expr

procDir
  procId PROC ⟦ pOptions ⟧ ⟦ < macroArgList > ⟧
  ⟦ usesRegs ⟧ ⟦ procParmList ⟧

processor
  | .386 | .386p | .486 | .486P
  | .586 | .586P | .686 | .686P | .387

processorDir
  processor ;;
  | coprocessor ;;

procId
  id

procItem
  instrPrefix | dataDir | labelDir | offsetDir | generalDir

procParmList
  ⟦ , ⟦ ;; ⟧ parmList ⟧
  ⟦ , ⟦ ;; ⟧ parmId :VARARG ⟧

protoArg
  ⟦ id ⟧ : qualifiedType

protoArgList
  ⟦ , ⟦ ;; ⟧ protoList ⟧
  ⟦ , ⟦ ;; ⟧ ⟦ id ⟧ :VARARG ⟧

protoList
  protoArg
  | protoList , ⟦ ;; ⟧ protoArg

protoSpec
  ⟦ distance ⟧ ⟦ langType ⟧ ⟦ protoArgList ⟧
  | typeId

protoTypeDir
  id PROTO protoSpec

pubDef
  ⟦ langType ⟧ id

publicDir
  PUBLIC pubList ;;

pubList
  pubDef | pubList , ⟦ ;; ⟧ pubDef

purgeDir
  PURGE macroIdList

qualifiedType
  type
  | ⟦ distance ⟧ PTR ⟦ qualifiedType ⟧

qualifier
  qualifiedType | PROTO protoSpec

quote
  " | '

qwordRegister
  RAX | RCX | RDX | RBX | RSP | RBP | RSI | RDI
  | R8 | R9 | R10 | R11 | R12 | R13 | R14 | R15

radixDir
  .RADIX constExpr ;;

radixOverride
  h | o | q | t | y
  | H | O | Q | T | Y

recordConst
  recordTag { oldRecordFieldList }
  | recordTag < oldRecordFieldList >

recordDir
  recordTag RECORD bitDefList ;;

recordFieldList
  ⟦ constExpr ⟧ | recordFieldList , ⟦ ;; ⟧ ⟦ constExpr ⟧

recordInstance
  { ⟦ ;; ⟧ recordFieldList ⟦ ;; ⟧ }
  | < oldRecordFieldList >
  | constExpr DUP ( recordInstance )

recordInstList
  recordInstance | recordInstList , ⟦ ;; ⟧ recordInstance

recordTag
  id

register
  specialRegister | gpRegister | byteRegister | qwordRegister | fpuRegister | SIMDRegister | segmentRegister

regList
  register | regList register

relOp
  EQ | NE | LT | LE | GT | GE

repeatBlock
  .REPEAT ;;
  blockStatements ;; untilDir ;;

repeatDir
  REPEAT | REPT

scalarInstList
  initValue
  | scalarInstList , ⟦ ;; ⟧ initValue

segAlign
  BYTE | WORD | DWORD | PARA | PAGE

segAttrib
  PUBLIC | STACK | COMMON | MEMORY | AT constExpr | PRIVATE

segDir
  .CODE ⟦ segId ⟧
  | .DATA
  | .DATA?
  | .CONST
  | .FARDATA ⟦ segId ⟧
  | .FARDATA? ⟦ segId ⟧
  | .STACK ⟦ constExpr ⟧

segId
  id

segIdList
  segId
  | segIdList , segId

segmentDef
  segmentDir ⟦ inSegDirList ⟧ endsDir | simpleSegDir ⟦ inSegDirList ⟧ ⟦ endsDir ⟧

segmentDir
  segId SEGMENT ⟦ segOptionList ⟧ ;;

segmentRegister
  CS | DS | ES | FS | GS | SS

segOption
  segAlign
  | segRO
  | segAttrib
  | segSize
  | className

segOptionList
  segOption | segOptionList segOption

segOrderDir
  .ALPHA | .SEQ | .DOSSEG | DOSSEG

segRO
  READONLY

segSize
  USE16 | USE32 | FLAT

shiftOp
  SHR | SHL

sign
  + | -

simdRegister
  MM0 | MM1 | MM2 | MM3 | MM4 | MM5 | MM6 | MM7
  | xmmRegister
  | YMM0 | YMM1 | YMM2 | YMM3 | YMM4 | YMM5 | YMM6 | YMM7
  | YMM8 | YMM9 | YMM10 | YMM11 | YMM12 | YMM13 | YMM14 | YMM15

simpleExpr
  ( cExpr ) | primary

simpleSegDir
  segDir ;;

sizeArg
  id | type | e10

specialChars
  : | . | [ | ] | ( | ) | < | > | { | }
  | + | - | / | * | & | % | !
  | ' | \ | = | ; | , | "
  | whiteSpaceCharacter
  | endOfLine

specialRegister
  CR0 | CR2 | CR3
  | DR0 | DR1 | DR2 | DR3 | DR6 | DR7
  | TR3 | TR4 | TR5 | TR6 | TR7

stackOption
  NEARSTACK | FARSTACK

startupDir
  .STARTUP ;;

stext
  stringChar | stext stringChar

string
  quote ⟦ stext ⟧ quote

stringChar
  quote quote | Any character except quote.

structBody
  structItem ;;
  | structBody structItem ;;

structDir
  structTag structHdr ⟦ fieldAlign ⟧
  ⟦ , NONUNIQUE ⟧ ;;
  structBody
  structTag ENDS ;;

structHdr
  STRUC | STRUCT | UNION

structInstance
  < ⟦ fieldInitList ⟧ >
  | { ⟦ ;; ⟧ ⟦ fieldInitList ⟧ ⟦ ;; ⟧ }
  | constExpr DUP ( structInstList )

structInstList
  structInstance | structInstList , ⟦ ;; ⟧ structInstance

structItem
  dataDir
  | generalDir
  | offsetDir
  | nestedStruct

structTag
  id

term
  simpleExpr | ! simpleExpr

text
  textLiteral | text character | ! character text | character | ! character

textDir
  id textMacroDir ;;

textItem
  textLiteral | textMacroId | % constExpr

textLen
  constExpr

textList
  textItem | textList , ⟦ ;; ⟧ textItem

textLiteral
  < text > ;;

textMacroDir
  CATSTR ⟦ textList ⟧
  | TEXTEQU ⟦ textList ⟧
  | SIZESTR textItem
  | SUBSTR textItem , textStart ⟦ , textLen ⟧
  | INSTR ⟦ textStart , ⟧ textItem , textItem

textMacroId
  id

textStart
  constExpr

titleDir
  titleType arbitraryText ;;

titleType
  TITLE | SUBTITLE | SUBTTL

type
  structTag
  | unionTag
  | recordTag
  | distance
  | dataType
  | typeId

typedefDir
  typeId TYPEDEF qualifier

typeId
  id

unionTag
  id

untilDir
  .UNTIL cExpr ;;
  .UNTILCXZ ⟦ cxzExpr ⟧ ;;

usesRegs
  USES regList

whileBlock
  .WHILE cExpr ;;
  blockStatements ;;
  .ENDW

whiteSpaceCharacter
  ASCII 8, 9, 11–13, 26, 32

xmmRegister
  XMM0 | XMM1 | XMM2 | XMM3 | XMM4 | XMM5 | XMM6 | XMM7
  | XMM8 | XMM9 | XMM10 | XMM11 | XMM12 | XMM13 | XMM14 | XMM15


*/