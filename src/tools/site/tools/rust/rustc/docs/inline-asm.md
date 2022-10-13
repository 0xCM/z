# Rust Inline Assembly

## Operand type
Several types of operands are supported:

* in(<reg>) <expr>
    - <reg> can refer to a register class or an explicit register. The allocated register name is substituted into the asm template string.
    - The allocated register will contain the value of <expr> at the start of the asm code.
    - The allocated register must contain the same value at the end of the asm code (except if a lateout is allocated to the same register).

* out(<reg>) <expr>
    - <reg> can refer to a register class or an explicit register. The allocated register name is substituted into the asm template string.
    - The allocated register will contain an undefined value at the start of the asm code.
    - <expr> must be a (possibly uninitialized) place expression, to which the contents of the allocated register are written at the end of the asm code.
    - An underscore (_) may be specified instead of an expression, which will cause the contents of the register to be discarded at the end of the asm code (effectively acting as a clobber).

* lateout(<reg>) <expr>
    - Identical to out except that the register allocator can reuse a register allocated to an in.
    - You should only write to the register after all inputs are read, otherwise you may clobber an input.

* inout(<reg>) <expr>
    - <reg> can refer to a register class or an explicit register. The allocated register name is substituted into the asm template string.
    - The allocated register will contain the value of <expr> at the start of the asm code.
    - <expr> must be a mutable initialized place expression, to which the contents of the allocated register are written at the end of the asm code.

* inout(<reg>) <in expr> => <out expr>
    - Same as inout except that the initial value of the register is taken from the value of <in expr>.
    - <out expr> must be a (possibly uninitialized) place expression, to which the contents of the allocated register are written at the end of the asm code.
    - An underscore (_) may be specified instead of an expression for <out expr>, which will cause the contents of the register to be discarded at the end of the asm code (effectively acting as a clobber).
    - <in expr> and <out expr> may have different types.

* inlateout(<reg>) <expr> / inlateout(<reg>) <in expr> => <out expr>
    - Identical to inout except that the register allocator can reuse a register allocated to an in (this can happen if the compiler knows the in has the same initial value as the inlateout).
    - You should only write to the register after all inputs are read, otherwise you may clobber an input.
    - Operand expressions are evaluated from left to right, just like function call arguments. After the asm! has executed, outputs are written to in left to right order. This is significant if two outputs point to the same place: that place will contain the value of the rightmost output.

Since global_asm! exists outside a function, it cannot use input/output operands.

## Register operands
Input and output operands can be specified either as an explicit register or as a register class from which the register allocator can select a register. Explicit registers are specified as string literals (e.g. "eax") while register classes are specified as identifiers (e.g. reg).

Note that explicit registers treat register aliases (e.g. r14 vs lr on ARM) and smaller views of a register (e.g. eax vs rax) as equivalent to the base register. It is a compile-time error to use the same explicit register for two input operands or two output operands. Additionally, it is also a compile-time error to use overlapping registers (e.g. ARM VFP) in input operands or in output operands.

Only the following types are allowed as operands for inline assembly:

* Integers (signed and unsigned)
* Floating-point numbers
* Pointers (thin only)
* Function pointers
* SIMD vectors (structs defined with #[repr(simd)] and which implement Copy). This includes architecture-specific vector types defined in std::arch such as __m128 (x86) or int8x16_t (ARM).

Here is the list of currently supported register classes:


## Rules for inline assembly
To avoid undefined behavior, these rules must be followed when using function-scope inline assembly (asm!):

Any registers not specified as inputs will contain an undefined value on entry to the asm block.
An "undefined value" in the context of inline assembly means that the register can (non-deterministically) have any one of the possible values allowed by the architecture. Notably it is not the same as an LLVM undef which can have a different value every time you read it (since such a concept does not exist in assembly code).
Any registers not specified as outputs must have the same value upon exiting the asm block as they had on entry, otherwise behavior is undefined.
This only applies to registers which can be specified as an input or output. Other registers follow target-specific rules.
Note that a lateout may be allocated to the same register as an in, in which case this rule does not apply. Code should not rely on this however since it depends on the results of register allocation.
Behavior is undefined if execution unwinds out of an asm block.
This also applies if the assembly code calls a function which then unwinds.
The set of memory locations that assembly code is allowed to read and write are the same as those allowed for an FFI function.
Refer to the unsafe code guidelines for the exact rules.
If the readonly option is set, then only memory reads are allowed.
If the nomem option is set then no reads or writes to memory are allowed.
These rules do not apply to memory which is private to the asm code, such as stack space allocated within the asm block.
The compiler cannot assume that the instructions in the asm are the ones that will actually end up executed.
This effectively means that the compiler must treat the asm! as a black box and only take the interface specification into account, not the instructions themselves.
Runtime code patching is allowed, via target-specific mechanisms.
Unless the nostack option is set, asm code is allowed to use stack space below the stack pointer.
On entry to the asm block the stack pointer is guaranteed to be suitably aligned (according to the target ABI) for a function call.
You are responsible for making sure you don't overflow the stack (e.g. use stack probing to ensure you hit a guard page).
You should adjust the stack pointer when allocating stack memory as required by the target ABI.
The stack pointer must be restored to its original value before leaving the asm block.
If the noreturn option is set then behavior is undefined if execution falls through to the end of the asm block.
If the pure option is set then behavior is undefined if the asm! has side-effects other than its direct outputs. Behavior is also undefined if two executions of the asm! code with the same inputs result in different outputs.
When used with the nomem option, "inputs" are just the direct inputs of the asm!.
When used with the readonly option, "inputs" comprise the direct inputs of the asm! and any memory that the asm! block is allowed to read.
These flags registers must be restored upon exiting the asm block if the preserves_flags option is set:
x86
Status flags in EFLAGS (CF, PF, AF, ZF, SF, OF).
Floating-point status word (all).
Floating-point exception flags in MXCSR (PE, UE, OE, ZE, DE, IE).
ARM
Condition flags in CPSR (N, Z, C, V)
Saturation flag in CPSR (Q)
Greater than or equal flags in CPSR (GE).
Condition flags in FPSCR (N, Z, C, V)
Saturation flag in FPSCR (QC)
Floating-point exception flags in FPSCR (IDC, IXC, UFC, OFC, DZC, IOC).
AArch64
Condition flags (NZCV register).
Floating-point status (FPSR register).
RISC-V
Floating-point exception flags in fcsr (fflags).
Vector extension state (vtype, vl, vcsr).
On x86, the direction flag (DF in EFLAGS) is clear on entry to an asm block and must be clear on exit.
Behavior is undefined if the direction flag is set on exiting an asm block.
On x86, the x87 floating-point register stack must remain unchanged unless all of the st([0-7]) registers have been marked as clobbered with out("st(0)") _, out("st(1)") _, ....
If all x87 registers are clobbered then the x87 register stack is guaranteed to be empty upon entering an asm block. Assembly code must ensure that the x87 register stack is also empty when exiting the asm block.
The requirement of restoring the stack pointer and non-output registers to their original value only applies when exiting an asm! block.
This means that asm! blocks that never return (even if not marked noreturn) don't need to preserve these registers.
When returning to a different asm! block than you entered (e.g. for context switching), these registers must contain the value they had upon entering the asm! block that you are exiting.
You cannot exit an asm! block that has not been entered. Neither can you exit an asm! block that has already been exited (without first entering it again).
You are responsible for switching any target-specific state (e.g. thread-local storage, stack bounds).
You cannot jump from an address in one asm! block to an address in another, even within the same function or block, without treating their contexts as potentially different and requiring context switching. You cannot assume that any particular value in those contexts (e.g. current stack pointer or temporary values below the stack pointer) will remain unchanged between the two asm! blocks.
The set of memory locations that you may access is the intersection of those allowed by the asm! blocks you entered and exited.
You cannot assume that two asm! blocks adjacent in source code, even without any other code between them, will end up in successive addresses in the binary without any other instructions between them.
You cannot assume that an asm! block will appear exactly once in the output binary. The compiler is allowed to instantiate multiple copies of the asm! block, for example when the function containing it is inlined in multiple places.
On x86, inline assembly must not end with an instruction prefix (such as LOCK) that would apply to instructions generated by the compiler.
The compiler is currently unable to detect this due to the way inline assembly is compiled, but may catch and reject this in the future.
Note: As a general rule, the flags covered by preserves_flags are those which are not preserved when performing a function call.

## Directives Support
Inline assembly supports a subset of the directives supported by both GNU AS and LLVM's internal assembler, given as follows. The result of using other directives is assembler-specific (and may cause an error, or may be accepted as-is).

If inline assembly includes any "stateful" directive that modifies how subsequent assembly is processed, the block must undo the effects of any such directives before the inline assembly ends.

The following directives are guaranteed to be supported by the assembler:

.2byte
.4byte
.8byte
.align
.ascii
.asciz
.alt_entry
.balign
.balignl
.balignw
.balign
.balignl
.balignw
.bss
.byte
.comm
.data
.def
.double
.endef
.equ
.equiv
.eqv
.fill
.float
.globl
.global
.lcomm
.inst
.long
.octa
.option
.private_extern
.p2align
.pushsection
.popsection
.quad
.scl
.section
.set
.short
.size
.skip
.sleb128
.space
.string
.text
.type
.uleb128
.word