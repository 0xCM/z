//-----------------------------------------------------------------------------------------//
// Source : LLVM - https://github.com/llvm/llvm-project/
// License: Apache-2.0 WITH LLVM-exception
//-----------------------------------------------------------------------------------------//
namespace Z0
{
    // Classifies assembler directives
    // https://github.com/llvm/llvm-project/blob/a8cfa4b9bda3014a88e089cadcc6d366317aec5b/llvm/lib/MC/MCParser/AsmParser.cpp

    [SymSource("coff")]
    public enum AsmDirectiveKind : byte
    {
        DK_NO_DIRECTIVE, // Placeholder

        [Symbol(".set")]
        DK_SET,

        [Symbol(".equ")]
        DK_EQU,

        [Symbol(".equiv")]
        DK_EQUIV,

        /// <summary>
        /// .ascii	"%s:(0x%llx, 0x%llx, 0x%llx)\n"
        /// .byte	0
        /// </summary>
        [Symbol(".ascii")]
        DK_ASCII,

        /// <summary>
        /// .asciz	"(%llu, %llu, %llu)\n"
        /// </summary>
        [Symbol(".asciz")]
        DK_ASCIZ,

        [Symbol(".string")]
        DK_STRING,

        [Symbol(".byte")]
        DK_BYTE,

        [Symbol(".short")]
        DK_SHORT,

        [Symbol(".reloc")]
        DK_RELOC,

        [Symbol(".value")]
        DK_VALUE,

        [Symbol(".2byte")]
        DK_2BYTE,

        [Symbol(".long")]
        DK_LONG,

        [Symbol(".int")]
        DK_INT,

        [Symbol(".4byte")]
        DK_4BYTE,

        [Symbol(".quad")]
        DK_QUAD,

        [Symbol(".8byte")]
        DK_8BYTE,

        [Symbol(".octa")]
        DK_OCTA,

        [Symbol(".dc")]
        DK_DC,

        [Symbol(".dc.a")]
        DK_DC_A,

        [Symbol(".dc.b")]
        DK_DC_B,

        [Symbol(".dc.d")]
        DK_DC_D,

        [Symbol(".dc.l")]
        DK_DC_L,

        [Symbol(".dc.s")]
        DK_DC_S,

        [Symbol(".dc.w")]
        DK_DC_W,

        [Symbol(".dc.x")]
        DK_DC_X,

        [Symbol(".dcb")]
        DK_DCB,

        [Symbol(".dcb.b")]
        DK_DCB_B,

        [Symbol(".dcb.d")]
        DK_DCB_D,

        [Symbol(".dcb.l")]
        DK_DCB_L,

        [Symbol(".dcb.s")]
        DK_DCB_S,

        [Symbol(".dcb.w")]
        DK_DCB_W,

        [Symbol(".dcb.x")]
        DK_DCB_X,

        [Symbol(".ds")]
        DK_DS,

        [Symbol(".ds.b")]
        DK_DS_B,

        [Symbol(".ds.d")]
        DK_DS_D,

        [Symbol(".ds.l")]
        DK_DS_L,

        [Symbol(".ds.p")]
        DK_DS_P,

        [Symbol(".ds.s")]
        DK_DS_S,

        [Symbol(".ds.w")]
        DK_DS_W,

        [Symbol(".ds.x")]
        DK_DS_X,

        [Symbol(".single")]
        DK_SINGLE,

        [Symbol(".float")]
        DK_FLOAT,

        [Symbol(".double")]
        DK_DOUBLE,

        [Symbol(".align")]
        DK_ALIGN,

        [Symbol(".align32")]
        DK_ALIGN32,

        [Symbol(".balign")]
        DK_BALIGN,

        [Symbol(".balignw")]
        DK_BALIGNW,

        [Symbol(".balignl")]
        DK_BALIGNL,

        [Symbol(".p2align")]
        DK_P2ALIGN,

        [Symbol(".p2alignw")]
        DK_P2ALIGNW,

        [Symbol(".p2alignl")]
        DK_P2ALIGNL,

        [Symbol(".org")]
        DK_ORG,

        [Symbol(".fill")]
        DK_FILL,

        [Symbol(".endr")]
        DK_ENDR,

        [Symbol(".bundle_align_mode")]
        DK_BUNDLE_ALIGN_MODE,

        [Symbol(".bundle_lock")]
        DK_BUNDLE_LOCK,

        [Symbol(".bundle_unlock")]
        DK_BUNDLE_UNLOCK,

        [Symbol(".zero")]
        DK_ZERO,

        [Symbol(".extern")]
        DK_EXTERN,

        [Symbol(".globl")]
        DK_GLOBL,

        [Symbol(".global")]
        DK_GLOBAL,

        [Symbol("lazy_reference")]
        DK_LAZY_REFERENCE,

        [Symbol(".no_dead_strip")]
        DK_NO_DEAD_STRIP,

        [Symbol(".symbol_resolver")]
        DK_SYMBOL_RESOLVER,

        [Symbol(".private_extern")]
        DK_PRIVATE_EXTERN,

        [Symbol(".reference")]
        DK_REFERENCE,

        [Symbol(".weak_definition")]
        DK_WEAK_DEFINITION,

        [Symbol(".weak_reference")]
        DK_WEAK_REFERENCE,

        [Symbol(".weak_def_can_be_hidden")]
        DK_WEAK_DEF_CAN_BE_HIDDEN,

        [Symbol(".cold")]
        DK_COLD,

        [Symbol(".comm")]
        DK_COMM,

        [Symbol(".common")]
        DK_COMMON,

        [Symbol(".lcomm")]
        DK_LCOMM,

        [Symbol(".abort")]
        DK_ABORT,

        [Symbol(".include")]
        DK_INCLUDE,

        [Symbol(".incbin")]
        DK_INCBIN,

        [Symbol(".code16")]
        DK_CODE16,

        [Symbol(".code16gcc")]
        DK_CODE16GCC,

        [Symbol(".rept")]
        DK_REPT,

        [Symbol(".rep")]
        DK_REP,

        [Symbol(".irp")]
        DK_IRP,

        [Symbol(".irpc")]
        DK_IRPC,

        [Symbol(".if")]
        DK_IF,

        [Symbol(".ifeq")]
        DK_IFEQ,

        [Symbol(".ifge")]
        DK_IFGE,

        [Symbol(".ifgt")]
        DK_IFGT,

        [Symbol(".ifle")]
        DK_IFLE,

        [Symbol(".iflt")]
        DK_IFLT,

        [Symbol(".ifne")]
        DK_IFNE,

        [Symbol(".ifb")]
        DK_IFB,

        [Symbol(".ifnb")]
        DK_IFNB,

        [Symbol(".ifc")]
        DK_IFC,

        [Symbol(".ifeqs")]
        DK_IFEQS,

        [Symbol(".ifnc")]
        DK_IFNC,

        [Symbol(".ifnes")]
        DK_IFNES,

        [Symbol(".ifdef")]
        DK_IFDEF,

        [Symbol(".ifndef")]
        DK_IFNDEF,

        [Symbol(".ifnotdef")]
        DK_IFNOTDEF,

        [Symbol(".elseif")]
        DK_ELSEIF,

        [Symbol(".else")]
        DK_ELSE,

        [Symbol(".endif")]
        DK_ENDIF,

        [Symbol(".space")]
        DK_SPACE,

        [Symbol(".skip")]
        DK_SKIP,

        /// <summary>
        /// .file	"canonical.c"
        /// </summary>
        [Symbol(".file")]
        DK_FILE,

        [Symbol(".line")]
        DK_LINE,

        [Symbol(".loc")]
        DK_LOC,

        [Symbol(".stabs")]
        DK_STABS,

        [Symbol(".cv_file")]
        DK_CV_FILE,

        [Symbol(".cv_func_id")]
        DK_CV_FUNC_ID,

        [Symbol(".cv_inline_site_id")]
        DK_CV_INLINE_SITE_ID,

        [Symbol(".cv_loc")]
        DK_CV_LOC,

        [Symbol(".cv_linetable")]
        DK_CV_LINETABLE,

        [Symbol(".cv_inline_linetable")]
        DK_CV_INLINE_LINETABLE,

        [Symbol(".cv_def_range")]
        DK_CV_DEF_RANGE,

        [Symbol(".cv_stringtable")]
        DK_CV_STRINGTABLE,

        [Symbol(".cv_string")]
        DK_CV_STRING,

        [Symbol(".cv_filechecksums")]
        DK_CV_FILECHECKSUMS,

        [Symbol(".cv_filechecksumoffset")]
        DK_CV_FILECHECKSUM_OFFSET,

        [Symbol(".cv_fpo_data")]
        DK_CV_FPO_DATA,

        [Symbol(".cfi_sections")]
        DK_CFI_SECTIONS,

        [Symbol(".cfi_startpro")]
        DK_CFI_STARTPROC,

        [Symbol(".cfi_endproc")]
        DK_CFI_ENDPROC,

        [Symbol(".cfi_def_cfa")]
        DK_CFI_DEF_CFA,

        [Symbol(".cfi_def_cfa_offset")]
        DK_CFI_DEF_CFA_OFFSET,

        [Symbol(".cfi_adjust_cfa_offset")]
        DK_CFI_ADJUST_CFA_OFFSET,

        [Symbol(".cfi_def_cfa_register")]
        DK_CFI_DEF_CFA_REGISTER,

        [Symbol(".cfi_llvm_def_aspace_cfa")]
        DK_CFI_LLVM_DEF_ASPACE_CFA,

        [Symbol(".cfi_offset")]
        DK_CFI_OFFSET,

        [Symbol(".cfi_rel_offset")]
        DK_CFI_REL_OFFSET,

        [Symbol(".cfi_personality")]
        DK_CFI_PERSONALITY,

        [Symbol(".cfi_lsda")]
        DK_CFI_LSDA,

        [Symbol(".cfi_remember_state")]
        DK_CFI_REMEMBER_STATE,

        [Symbol(".cfi_restore_state")]
        DK_CFI_RESTORE_STATE,

        [Symbol(".cfi_same_value")]
        DK_CFI_SAME_VALUE,

        [Symbol(".cfi_restore")]
        DK_CFI_RESTORE,

        [Symbol(".cfi_escape")]
        DK_CFI_ESCAPE,

        [Symbol(".cfi_return_column")]
        DK_CFI_RETURN_COLUMN,

        [Symbol(".cfi_signal_frame")]
        DK_CFI_SIGNAL_FRAME,

        [Symbol(".cfi_undefined")]
        DK_CFI_UNDEFINED,

        [Symbol(".cfi_register")]
        DK_CFI_REGISTER,

        [Symbol(".cfi_window_save")]
        DK_CFI_WINDOW_SAVE,

        [Symbol(".cfi_b_key_frame")]
        DK_CFI_B_KEY_FRAME,

        [Symbol(".macros_on")]
        DK_MACROS_ON,

        [Symbol(".macros_off")]
        DK_MACROS_OFF,

        [Symbol(".altmacr")]
        DK_ALTMACRO,

        [Symbol(".noaltmacro")]
        DK_NOALTMACRO,

        [Symbol(".macro")]
        DK_MACRO,

        [Symbol(".exitm")]
        DK_EXITM,

        [Symbol(".endm")]
        DK_ENDM,

        [Symbol(".endmacro")]
        DK_ENDMACRO,

        [Symbol(".purgem")]
        DK_PURGEM,

        [Symbol(".sleb128")]
        DK_SLEB128,

        [Symbol(".uleb128")]
        DK_ULEB128,

        [Symbol(".err")]
        DK_ERR,

        [Symbol(".error")]
        DK_ERROR,

        [Symbol(".warning")]
        DK_WARNING,

        [Symbol(".print")]
        DK_PRINT,

        [Symbol(".addrsig")]
        DK_ADDRSIG,

        [Symbol(".addrsig_sym")]
        DK_ADDRSIG_SYM,

        [Symbol(".pseudoprobe")]
        DK_PSEUDO_PROBE,

        [Symbol(".lto_discard")]
        DK_LTO_DISCARD,

        [Symbol(".intel_syntax")]
        DK_INTEL_SYNTAX,

        [Symbol("")]
        DK_END
    }
}