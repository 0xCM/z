import {HelpDoc} from "../core"
import * as Core from "../core"

import * as Tk from "./tokens"

const Content = 
`OVERVIEW: MLIR modular optimizer driver
Available Dialects: acc, affine, amdgpu, amx, arith, arm_neon, arm_sve, async, bufferization, builtin, cf, complex, dlti, emitc, func, gpu, linalg, llvm, math, memref, ml_program, nvgpu, nvvm, omp, pdl, pdl_interp, quant, rocdl, scf, shape, sparse_tensor, spv, tensor, test, tosa, transform, vector, x86vector
USAGE: mlir-opt.exe [options] <input file>

OPTIONS:

Color Options:

  --color                                                         - Use colors in output (default=autodetect)

General options:

  --aa-trace                                                      - 
  --abort-on-max-devirt-iterations-reached                        - Abort when the max iterations for devirtualization CGSCC repeat pass is reached
  --accel-tables=<value>                                          - Output dwarf accelerator tables.
    =Default                                                      -   Default for platform
    =Disable                                                      -   Disabled.
    =Apple                                                        -   Apple
    =Dwarf                                                        -   DWARF
  --adce-remove-control-flow                                      - 
  --adce-remove-loops                                             - 
  --addr-sink-combine-base-gv                                     - Allow combining of BaseGV field in Address sinking.
  --addr-sink-combine-base-offs                                   - Allow combining of BaseOffs field in Address sinking.
  --addr-sink-combine-base-reg                                    - Allow combining of BaseReg field in Address sinking.
  --addr-sink-combine-scaled-reg                                  - Allow combining of ScaledReg field in Address sinking.
  --addr-sink-new-phis                                            - Allow creation of Phis in Address sinking.
  --addr-sink-new-select                                          - Allow creation of selects in Address sinking.
  --addr-sink-using-gep                                           - Address sinking in CGP using GEPs.
  --agg-antidep-debugdiv=<int>                                    - Debug control for aggressive anti-dep breaker
  --agg-antidep-debugmod=<int>                                    - Debug control for aggressive anti-dep breaker
  --aggregate-extracted-args                                      - Aggregate arguments to code-extracted functions
  --aggressive-ext-opt                                            - Aggressive extension optimization
  --alias-set-saturation-threshold=<uint>                         - The maximum number of pointers may-alias sets may contain before degradation
  --align-all-blocks=<uint>                                       - Force the alignment of all blocks in the function in log2 format (e.g 4 means align on 16B boundaries).
  --align-all-functions=<uint>                                    - Force the alignment of all functions in log2 format (e.g. 4 means align on 16B boundaries).
  --align-all-nofallthru-blocks=<uint>                            - Force the alignment of all blocks that have no fall-through predecessors (i.e. don't add nops that are executed). In log2 format (e.g 4 means align on 16B boundaries).
  --allow-ginsert-as-artifact                                     - Allow G_INSERT to be considered an artifact. Hack around AMDGPU test infinite loops.
  --allow-unregistered-dialect                                    - Allow operation with no registered dialects
  --allow-unroll-and-jam                                          - Allows loops to be unroll-and-jammed.
  --amdgcn-skip-cache-invalidations                               - Use this to skip inserting cache invalidating instructions.
  --amdgpu-any-address-space-out-arguments                        - Replace pointer out arguments with struct returns for non-private address space
  --amdgpu-assume-dynamic-stack-object-size=<uint>                - Assumed extra stack use if there are any variable sized objects (in bytes)
  --amdgpu-assume-external-call-stack-size=<uint>                 - Assumed stack use of any external call (in bytes)
  --amdgpu-atomic-optimizations                                   - Enable atomic optimizations
  --amdgpu-bypass-slow-div                                        - Skip 64-bit divide for dynamic 32-bit values
  --amdgpu-dce-in-ra                                              - Enable machine DCE inside regalloc
  --amdgpu-disable-loop-alignment                                 - Do not align and prefetch loops
  --amdgpu-disable-unclustred-high-rp-reschedule                  - Disable unclustred high register pressure reduction scheduling stage.
  --amdgpu-dpp-combine                                            - Enable DPP combiner
  --amdgpu-dump-hsa-metadata                                      - Dump AMDGPU HSA Metadata
  --amdgpu-early-ifcvt                                            - Run early if-conversion
  --amdgpu-early-inline-all                                       - Inline all functions early
  --amdgpu-enable-delay-alu                                       - Enable s_delay_alu insertion
  --amdgpu-enable-lds-replace-with-pointer                        - Enable LDS replace with pointer pass
  --amdgpu-enable-lower-module-lds                                - Enable lower module lds pass
  --amdgpu-enable-max-ilp-scheduling-strategy                     - Enable scheduling strategy to maximize ILP for a single wave.
  --amdgpu-enable-merge-m0                                        - Merge and hoist M0 initializations
  --amdgpu-enable-power-sched                                     - Enable scheduling to minimize mAI power bursts
  --amdgpu-enable-pre-ra-optimizations                            - Enable Pre-RA optimizations pass
  --amdgpu-enable-promote-kernel-arguments                        - Enable promotion of flat kernel pointer arguments to global
  --amdgpu-enable-structurizer-workarounds                        - Enable workarounds for the StructurizeCFG pass
  --amdgpu-enable-vopd                                            - Enable VOPD, dual issue of VALU in wave32
  --amdgpu-function-calls                                         - Enable AMDGPU function call support
  --amdgpu-igrouplp                                               - Enable construction of Instruction Groups and their ordering for scheduling
  --amdgpu-igrouplp-ldr-group-size=<value>                        - The maximum number of instructions to include in lds/gds read group.
  --amdgpu-igrouplp-ldw-group-size=<value>                        - The maximum number of instructions to include in lds/gds write group.
  --amdgpu-igrouplp-mfma-group-size=<value>                       - The maximum number of instructions to include in MFMA group.
  --amdgpu-igrouplp-vmem-group-size=<value>                       - The maximum number of instructions to include in VMEM group.
  --amdgpu-indirect-access-weight=<uint>                          - Indirect access memory instruction weight
  --amdgpu-inline-arg-alloca-cost=<uint>                          - Cost of alloca argument
  --amdgpu-inline-arg-alloca-cutoff=<uint>                        - Maximum alloca size to use for inline cost
  --amdgpu-inline-max-bb=<ulong>                                  - Maximum number of BBs allowed in a function after inlining (compile time constraint)
  --amdgpu-internalize-symbols                                    - Enable elimination of non-kernel functions and unused globals
  --amdgpu-ir-lower-kernel-arguments                              - Lower kernel argument loads in IR pass
  --amdgpu-large-stride-threshold=<uint>                          - Large stride memory access threshold
  --amdgpu-large-stride-weight=<uint>                             - Large stride memory access weight
  --amdgpu-late-structurize                                       - Enable late CFG structurization
  --amdgpu-limit-to-128-vgprs                                     - Never use more than 128 VGPRs
  --amdgpu-limit-wave-threshold=<uint>                            - Kernel limit wave threshold in %
  --amdgpu-load-store-vectorizer                                  - Enable load store vectorizer
  --amdgpu-max-memory-clause=<uint>                               - Maximum length of a memory clause, instructions
  --amdgpu-max-return-arg-num-regs=<uint>                         - Approximately limit number of return registers for replacing out arguments
  --amdgpu-mem-intrinsic-expand-size=<int>                        - Set minimum mem intrinsic size to expand in IR
  --amdgpu-membound-threshold=<uint>                              - Function mem bound threshold in %
  --amdgpu-mfma-padding-ratio=<uint>                              - Fill a percentage of the latency between neighboring MFMA with s_nops.
  --amdgpu-mode-register                                          - Enable mode register pass
  --amdgpu-opt-exec-mask-pre-ra                                   - Run pre-RA exec mask optimizations
  --amdgpu-opt-vgpr-liverange                                     - Enable VGPR liverange optimizations for if-else structure
  --amdgpu-prelink                                                - Enable pre-link mode optimizations
  --amdgpu-promote-alloca-to-vector-limit=<uint>                  - Maximum byte size to consider promote alloca to vector
  --amdgpu-reassign-regs                                          - Enable register reassign optimizations on gfx10+
  --amdgpu-scalar-ir-passes                                       - Enable scalar IR passes
  --amdgpu-scalarize-global-loads                                 - Enable global load scalarization
  --amdgpu-sdwa-peephole                                          - Enable SDWA peepholer
  --amdgpu-set-wave-priority                                      - Adjust wave priority
  --amdgpu-simplify-libcall                                       - Enable amdgpu library simplifications
  --amdgpu-skip-threshold=<uint>                                  - Number of instructions before jumping over divergent control flow
  --amdgpu-stress-function-calls                                  - Force all functions to be noinline
  --amdgpu-super-align-lds-globals                                - Increase alignment of LDS if it is not on align boundary
  --amdgpu-unroll-max-block-to-analyze=<uint>                     - Inner loop block size threshold to analyze in unroll for AMDGPU
  --amdgpu-unroll-runtime-local                                   - Allow runtime unroll for AMDGPU if local memory used in a loop
  --amdgpu-unroll-threshold-if=<uint>                             - Unroll threshold increment for AMDGPU for each if statement inside loop
  --amdgpu-unroll-threshold-local=<uint>                          - Unroll threshold for AMDGPU if local memory used in a loop
  --amdgpu-unroll-threshold-private=<uint>                        - Unroll threshold for AMDGPU if private memory used in a loop
  --amdgpu-use-aa-in-codegen                                      - Enable the use of AA during codegen.
  --amdgpu-use-divergent-register-indexing                        - Use indirect register addressing for divergent indexes
  --amdgpu-use-legacy-divergence-analysis                         - Enable legacy divergence analysis for AMDGPU
  --amdgpu-use-native[=<string>]                                    - Comma separated list of functions to replace with native, or all
  --amdgpu-verify-hsa-metadata                                    - Verify AMDGPU HSA Metadata
  --amdgpu-vgpr-index-mode                                        - Use GPR indexing mode instead of movrel for vector indexing
  --amdgpu-waitcnt-forcezero                                      - Force all waitcnt instrs to be emitted as s_waitcnt vmcnt(0) expcnt(0) lgkmcnt(0)
  --amdhsa-code-object-version=<uint>                             - AMDHSA Code Object Version
  --annotate-inline-phase                                         - If true, annotate inline advisor remarks with LTO and pass information.
  --annotate-sample-profile-inline-phase                          - Annotate LTO phase (prelink / postlink), or main (no LTO) for sample-profile inline pass name.
  --arc-opt-max-ptr-states=<uint>                                 - Maximum number of ptr states the optimizer keeps track of
  --as-secure-log-file-name=<value>                               - As secure log file name (initialized from AS_SECURE_LOG_FILE env variable)
  --asan-always-slow-path                                         - use instrumentation with slow path for all accesses
  --asan-debug=<int>                                              - debug
  --asan-debug-func=<string>                                      - Debug func
  --asan-debug-max=<int>                                          - Debug max inst
  --asan-debug-min=<int>                                          - Debug min inst
  --asan-debug-stack=<int>                                        - debug stack
  --asan-destructor-kind=<value>                                  - Sets the ASan destructor kind. The default is to use the value provided to the pass constructor
    =none                                                         -   No destructors
    =global                                                       -   Use global destructors
  --asan-detect-invalid-pointer-cmp                               - Instrument <, <=, >, >= with pointer operands
  --asan-detect-invalid-pointer-pair                              - Instrument <, <=, >, >=, - with pointer operands
  --asan-detect-invalid-pointer-sub                               - Instrument - operations with pointer operands
  --asan-force-dynamic-shadow                                     - Load shadow address into a local variable for each function
  --asan-force-experiment=<uint>                                  - Force optimization experiment (for testing)
  --asan-globals                                                  - Handle global objects
  --asan-globals-live-support                                     - Use linker features to support dead code stripping of globals
  --asan-guard-against-version-mismatch                           - Guard against compiler/runtime version mismatch.
  --asan-initialization-order                                     - Handle C++ initializer order
  --asan-instrument-atomics                                       - instrument atomic instructions (rmw, cmpxchg)
  --asan-instrument-byval                                         - instrument byval call arguments
  --asan-instrument-dynamic-allocas                               - instrument dynamic allocas
  --asan-instrument-reads                                         - instrument read instructions
  --asan-instrument-writes                                        - instrument write instructions
  --asan-instrumentation-with-call-threshold=<int>                - If the function being instrumented contains more than this number of memory accesses, use callbacks instead of inline checks (-1 means never use callbacks).
  --asan-kernel                                                   - Enable KernelAddressSanitizer instrumentation
  --asan-kernel-mem-intrinsic-prefix                              - Use prefix for memory intrinsics in KASAN mode
  --asan-mapping-offset=<ulong>                                   - offset of asan shadow mapping [EXPERIMENTAL]
  --asan-mapping-scale=<int>                                      - scale of asan shadow mapping
  --asan-max-inline-poisoning-size=<uint>                         - Inline shadow poisoning for blocks up to the given size in bytes.
  --asan-max-ins-per-bb=<int>                                     - maximal number of instructions to instrument in any given BB
  --asan-memory-access-callback-prefix=<string>                   - Prefix for memory access callbacks
  --asan-opt                                                      - Optimize instrumentation
  --asan-opt-globals                                              - Don't instrument scalar globals
  --asan-opt-same-temp                                            - Instrument the same temp just once
  --asan-opt-stack                                                - Don't instrument scalar stack variables
  --asan-optimize-callbacks                                       - Optimize callbacks
  --asan-realign-stack=<uint>                                     - Realign stack to the value of this flag (power of two)
  --asan-recover                                                  - Enable recovery mode (continue-after-error).
  --asan-redzone-byval-args                                       - Create redzones for byval arguments (extra copy required)
  --asan-skip-promotable-allocas                                  - Do not instrument promotable allocas
  --asan-stack                                                    - Handle stack memory
  --asan-stack-dynamic-alloca                                     - Use dynamic alloca to represent stack variables
  --asan-use-after-return=<value>                                 - Sets the mode of detection for stack-use-after-return.
    =never                                                        -   Never detect stack use after return.
    =runtime                                                      -   Detect stack use after return if binary flag 'ASAN_OPTIONS=detect_stack_use_after_return' is set.
    =always                                                       -   Always detect stack use after return.
  --asan-use-after-scope                                          - Check stack-use-after-scope
  --asan-use-odr-indicator                                        - Use odr indicators to improve ODR reporting
  --asan-use-private-alias                                        - Use private aliases for global variables
  --asan-use-stack-safety                                         - Use Stack Safety analysis results
  --asan-with-comdat                                              - Place ASan constructors in comdat sections
  --asan-with-ifunc                                               - Access dynamic shadow through an ifunc global on platforms that support this
  --asan-with-ifunc-suppress-remat                                - Suppress rematerialization of dynamic shadow address by passing it through inline asm in prologue.
  --asm-macro-max-nesting-depth=<uint>                            - The maximum nesting depth allowed for assembly macros.
  --assume-preserve-all                                           - enable preservation of all attrbitues. even those that are unlikely to be usefull
  --atomic-counter-update-promoted                                - Do counter update using atomic fetch add  for promoted counters only
  --atomic-first-counter                                          - Use atomic fetch add for first counter in a function (usually the entry counter)
  --attributor-allow-deep-wrappers                                - Allow the Attributor to use IP information derived from non-exact functions via cloning
  --attributor-allow-shallow-wrappers                             - Allow the Attributor to create shallow wrappers for non-exact definitions.
  --attributor-annotate-decl-cs                                   - Annotate call sites of function declarations.
  --attributor-depgraph-dot-filename-prefix=<string>              - The prefix used for the CallGraph dot file names.
  --attributor-dump-dep-graph                                     - Dump the dependency graph to dot files.
  --attributor-enable=<value>                                     - Enable the attributor inter-procedural deduction pass.
    =all                                                          -   enable all attributor runs
    =module                                                       -   enable module-wide attributor runs
    =cgscc                                                        -   enable call graph SCC attributor runs
    =none                                                         -   disable attributor runs
  --attributor-enable-call-site-specific-deduction                - Allow the Attributor to do call site specific analysis
  --attributor-function-seed-allow-list=<string>                  - Comma seperated list of function names that are allowed to be seeded.
  --attributor-manifest-internal                                  - Manifest Attributor internal string attributes.
  --attributor-max-initialization-chain-length=<uint>             - Maximal number of chained initializations (to avoid stack overflows)
  --attributor-max-interfering-accesses=<uint>                    - Maximum number of interfering accesses to check before assuming all might interfere.
  --attributor-max-iterations=<uint>                              - Maximal number of fixpoint iterations.
  --attributor-max-iterations-verify                              - Verify that max-iterations is a tight bound for a fixpoint
  --attributor-max-potential-values=<uint>                        - Maximum number of potential values to be tracked for each position.
  --attributor-max-potential-values-iterations=<int>              - Maximum number of iterations we keep dismantling potential values.
  --attributor-print-call-graph                                   - Print Attributor's internal call graph
  --attributor-print-dep                                          - Print attribute dependencies
  --attributor-seed-allow-list=<string>                           - Comma seperated list of attribute names that are allowed to be seeded.
  --attributor-simplify-all-loads                                 - Try to simplify all loads.
  --attributor-view-dep-graph                                     - View the dependency graph.
  --available-load-scan-limit=<uint>                              - Use this to specify the default maximum number of instructions to scan backward from a given instruction, when searching for available loaded value
  --avoid-speculation                                             - MachineLICM should avoid speculation
  --basic-aa-recphi                                               - 
  --bbsections-cold-text-prefix=<string>                          - The text prefix to use for cold basic block clusters
  --bbsections-detect-source-drift                                - This checks if there is a fdo instr. profile hash mismatch for this function
  --bbsections-guided-section-prefix                              - Use the basic-block-sections profile to determine the text section prefix for hot functions. Functions with basic-block-sections profile will be placed in '.text.hot' regardless of their FDO profile info. Other functions won't be impacted, i.e., their prefixes will be decided by FDO/sampleFDO profiles.
  --bitcode-flush-threshold=<uint>                                - The threshold (unit M) for flushing LLVM bitcode.
  --bitcode-mdindex-threshold=<uint>                              - Number of metadatas above which we emit an index to enable lazy-loading
  --block-freq-ratio-threshold=<uint>                             - Do not hoist instructions if targetblock is N times hotter than the source.
  --block-placement-exit-block-bias=<uint>                        - Block frequency percentage a loop exit block needs over the original exit to be considered the new exit.
  --bonus-inst-threshold=<uint>                                   - Control the number of bonus instructions (default = 1)
  --bounds-checking-single-trap                                   - Use one trap block per function
  --branch-fold-placement                                         - Perform branch folding during placement. Reduces code size.
  --branch-on-poison-as-ub                                        - 
  --break-anti-dependencies=<string>                              - Break post-RA scheduling anti-dependencies: "critical", "all", or "none"
  --cache-line-size=<uint>                                        - Use this to override the target cache line size when specified by the user.
  --callgraph-dot-filename-prefix=<string>                        - The prefix used for the CallGraph dot file names.
  --callgraph-heat-colors                                         - Show heat colors in call-graph
  --callgraph-multigraph                                          - Show call-multigraph (do not remove parallel edges)
  --callgraph-show-weights                                        - Show edges labeled with weights
  --callsite-splitting-duplication-threshold=<uint>               - Only allow instructions before a call, if their cost is below DuplicationThreshold
  --canon-nth-function=<N>                                        - Function number to canonicalize.
  --canonicalize-icmp-predicates-to-unsigned                      - Enables canonicalization of signed relational predicates to unsigned (e.g. sgt => ugt)
  --capture-tracking-max-uses-to-explore=<uint>                   - Maximal number of uses to explore.
  --cfg-dot-filename-prefix=<string>                              - The prefix used for the CFG dot file names.
  --cfg-func-name=<string>                                        - The name of a function (or its substring) whose CFG is viewed/printed.
  --cfg-heat-colors                                               - Show heat colors in CFG
  --cfg-hide-cold-paths=<number>                                  - Hide blocks with relative frequency below the given value
  --cfg-hide-deoptimize-paths                                     - 
  --cfg-hide-unreachable-paths                                    - 
  --cfg-raw-weights                                               - Use raw weights for labels. Use percentages as default.
  --cfg-weights                                                   - Show edges labeled with weights
  --cgp-freq-ratio-to-skip-merge=<uint>                           - Skip merging empty blocks if (frequency of empty block) / (frequency of destination block) is greater than this ratio
  --cgp-icmp-eq2icmp-st                                           - Enable ICMP_EQ to ICMP_S(L|G)T conversion.
  --cgp-optimize-phi-types                                        - Enable converting phi types in CodeGenPrepare
  --cgp-split-large-offset-gep                                    - Enable splitting large offset of GEP.
  --cgp-type-promotion-merge                                      - Enable merging of redundant sexts when one is dominating the other.
  --cgp-verify-bfi-updates                                        - Enable BFI update verification for CodeGenPrepare.
  --cgscc-inline-replay=<filename>                                - Optimization remarks file containing inline remarks to be replayed by cgscc inlining.
  --cgscc-inline-replay-fallback=<value>                          - How cgscc inline replay treats sites that don't come from the replay. Original: defers to original advisor, AlwaysInline: inline all sites not in replay, NeverInline: inline no sites not in replay
    =Original                                                     -   All decisions not in replay send to original advisor (default)
    =AlwaysInline                                                 -   All decisions not in replay are inlined
    =NeverInline                                                  -   All decisions not in replay are not inlined
  --cgscc-inline-replay-format=<value>                            - How cgscc inline replay file is formatted
    =Line                                                         -   <Line Number>
    =LineColumn                                                   -   <Line Number>:<Column Number>
    =LineDiscriminator                                            -   <Line Number>.<Discriminator>
    =LineColumnDiscriminator                                      -   <Line Number>:<Column Number>.<Discriminator> (default)
  --cgscc-inline-replay-scope=<value>                             - Whether inline replay should be applied to the entire Module or just the Functions (default) that are present as callers in remarks during cgscc inlining.
    =Function                                                     -   Replay on functions that have remarks associated with them (default)
    =Module                                                       -   Replay on the entire module
  --check-bfi-unknown-block-queries                               - Check if block frequency is queried for an unknown block for debugging missed BFI updates
  --chr-bias-threshold=<number>                                   - CHR considers a branch bias greater than this ratio as biased
  --chr-function-list=<string>                                    - Specify file to retrieve the list of functions to apply CHR to
  --chr-merge-threshold=<uint>                                    - CHR merges a group of N branches/selects where N >= this value
  --chr-module-list=<string>                                      - Specify file to retrieve the list of modules to apply CHR to
  --cold-branch-ratio=<number>                                    - Minimum BranchProbability to consider a region cold.
  --cold-callsite-rel-freq=<int>                                  - Maximum block frequency, expressed as a percentage of caller's entry frequency, for a callsite to be cold in the absence of profile information.
  --cold-operand-max-cost-multiplier=<uint>                       - Maximum cost multiplier of TCC_expensive for the dependence slice of a cold operand to be considered inexpensive.
  --cold-operand-threshold=<uint>                                 - Maximum frequency of path for an operand to be considered cold.
  --cold-synthetic-count=<int>                                    - Initial synthetic entry count for cold functions.
  --coldcc-rel-freq=<int>                                         - Maximum block frequency, expressed as a percentage of caller's entry frequency, for a call site to be considered cold for enablingcoldcc
  --combiner-aa-only-func=<string>                                - Only use DAG-combiner alias analysis in this function
  --combiner-global-alias-analysis                                - Enable DAG combiner's use of IR alias analysis
  --combiner-reduce-load-op-store-width                           - DAG combiner enable reducing the width of load/op/store sequence
  --combiner-shrink-load-replace-store-with-store                 - DAG combiner enable load/<replace bytes>/store with a narrower store
  --combiner-split-load-index                                     - DAG combiner may split indexing from loads
  --combiner-store-merge-dependence-limit=<uint>                  - Limit the number of times for the same StoreNode and RootNode to bail out in store merging dependence check
  --combiner-store-merging                                        - DAG combiner enable merging multiple stores into a wider store
  --combiner-stress-load-slicing                                  - Bypass the profitability model of load slicing
  --combiner-tokenfactor-inline-limit=<uint>                      - Limit the number of operands to inline for Token Factors
  --combiner-use-tbaa                                             - Enable DAG combiner's use of TBAA
  --compute-dead                                                  - Compute dead symbols
  --consthoist-gep                                                - Try hoisting constant gep expressions
  --consthoist-min-num-to-rebase=<uint>                           - Do not rebase if number of dependent constants of a Base is less than this number.
  --consthoist-with-block-frequency                               - Enable the use of the block frequency analysis to reduce the chance to execute const materialization more frequently than without hoisting.
  --coro-elide-info-output-file=<filename>                        - File to record the coroutines got elided
  --cost-kind=<value>                                             - Target cost kind
    =throughput                                                   -   Reciprocal throughput
    =latency                                                      -   Instruction latency
    =code-size                                                    -   Code size
    =size-latency                                                 -   Code size and latency
  --costmodel-reduxcost                                           - Recognize reduction patterns.
  --crash-diagnostics-dir=<directory>                             - Directory for crash diagnostic files.
  --cvp-max-functions-per-value=<uint>                            - The maximum number of functions to track per lattice value
  --da-delinearize                                                - Try to delinearize array references.
  --da-disable-delinearization-checks                             - Disable checks that try to statically verify validity of delinearized subscripts. Enabling this option may result in incorrect dependence vectors for languages that allow the subscript of one dimension to underflow or overflow into another dimension.
  --da-miv-max-level-threshold=<uint>                             - Maximum depth allowed for the recursive algorithm used to explore MIV direction vectors.
  --dag-dump-verbose                                              - Display more information when dumping selection DAG nodes.
  --dag-maps-huge-region=<uint>                                   - The limit to use while constructing the DAG prior to scheduling, at which point a trade-off is made to avoid excessive compile time.
  --dag-maps-reduction-size=<uint>                                - A huge scheduling region will have maps reduced by this many nodes at a time. Defaults to HugeRegion / 2.
  --dataflow-edge-limit=<uint>                                    - Maximum number of dataflow edges to traverse when evaluating the benefit of commuting operands
  --ddg-pi-blocks                                                 - Create pi-block nodes.
  --ddg-simplify                                                  - Simplify DDG by merging nodes that have less interesting edges.
  --debug                                                         - Enable debug output
  --debug-buffer-size=<uint>                                      - Buffer the last N characters of debug output until program termination. [default 0 -- immediate print-out]
  -debug-counter                                                  - Comma separated list of debug counter skip and count
    =si-insert-waitcnts-forceexp                                  -   Force emit s_waitcnt expcnt(0) instrs
    =si-insert-waitcnts-forcelgkm                                 -   Force emit s_waitcnt lgkmcnt(0) instrs
    =si-insert-waitcnts-forcevm                                   -   Force emit s_waitcnt vmcnt(0) instrs
    =attributor-manifest                                          -   Determine what attributes are manifested in the IR
    =machine-cp-fwd                                               -   Controls which register COPYs are forwarded
    =early-cse                                                    -   Controls which instructions are removed
    =conds-eliminated                                             -   Controls which conditions are eliminated
    =dse-memoryssa                                                -   Controls which MemoryDefs are eliminated.
    =div-rem-pairs-transform                                      -   Controls transformations in div-rem-pairs pass
    =newgvn-vn                                                    -   Controls which instructions are value numbered
    =newgvn-phi                                                   -   Controls which instructions we create phi of ops for
    =dce-transform                                                -   Controls which instructions are eliminated
    =partially-inline-libcalls-transform                          -   Controls transformations in partially-inline-libcalls
    =instcombine-visit                                            -   Controls which instructions are visited
    =instcombine-negator                                          -   Controls Negator transformations in InstCombine pass
    =assume-builder-counter                                       -   Controls which assumes gets created
    =predicateinfo-rename                                         -   Controls which variables are renamed with predicateinfo
    =assume-queries-counter                                       -   Controls which assumes gets created
  --debug-info-correlate                                          - Use debug info to correlate profiles.
  --debug-only=<debug string>                                     - Enable a specific type of debug output (comma separated list of types)
  --debug-pass=<value>                                            - Print legacy PassManager debugging information
    =Disabled                                                     -   disable debug output
    =Arguments                                                    -   print pass arguments to pass to 'opt'
    =Structure                                                    -   print pass structure before run()
    =Executions                                                   -   print pass name before it is executed
    =Details                                                      -   print pass details when it is executed
  --debugify-and-strip-all-safe                                   - Debugify MIR before and Strip debug after each pass except those known to be unsafe when debug info is present
  --debugify-check-and-strip-all-safe                             - Debugify MIR before, by checking and stripping the debug info after, each pass except those known to be unsafe when debug info is present
  --debugify-func-limit=<ulong>                                   - Set max number of processed functions per pass.
  --debugify-level=<value>                                        - Kind of debug info to add
    =locations                                                    -   Locations only
    =location+variables                                           -   Locations and Variables
  --debugify-quiet                                                - Suppress verbose debugify output
  --default-gcov-version=<string>                                 - 
  --default-trip-count=<uint>                                     - Use this to specify the default trip count of a loop
  --demote-catchswitch-only                                       - Demote catchswitch BBs only (for wasm EH)
  --dfa-cost-threshold=<uint>                                     - Maximum cost accepted for the transformation
  --dfa-instr-limit=<uint>                                        - If present, stops packetizing after N instructions
  --dfa-jump-view-cfg-before                                      - View the CFG before DFA Jump Threading
  --dfa-max-num-paths=<uint>                                      - Max number of paths enumerated around a switch
  --dfa-max-path-length=<uint>                                    - Max number of blocks searched to find a threading path
  --dfa-sched-reg-pressure-threshold=<int>                        - Track reg pressure and switch priority to in-depth
  --dfsan-abilist=<string>                                        - File listing native ABI functions and how the pass treats them
  --dfsan-combine-offset-labels-on-gep                            - Combine the label of the offset with the label of the pointer when doing pointer arithmetic.
  --dfsan-combine-pointer-labels-on-load                          - Combine the label of the pointer with the label of the data when loading from memory.
  --dfsan-combine-pointer-labels-on-store                         - Combine the label of the pointer with the label of the data when storing in memory.
  --dfsan-combine-taint-lookup-table=<string>                     - When dfsan-combine-offset-labels-on-gep and/or dfsan-combine-pointer-labels-on-load are false, this flag can be used to re-enable combining offset and/or pointer taint when loading specific constant global variables (i.e. lookup tables).
  --dfsan-conditional-callbacks                                   - Insert calls to callback functions on conditionals.
  --dfsan-debug-nonzero-labels                                    - Insert calls to __dfsan_nonzero_label on observing a parameter, load or return with a nonzero label
  --dfsan-event-callbacks                                         - Insert calls to __dfsan_*_callback functions on data events.
  --dfsan-ignore-personality-routine                              - If a personality routine is marked uninstrumented from the ABI list, do not create a wrapper for it.
  --dfsan-instrument-with-call-threshold=<int>                    - If the function being instrumented requires more than this number of origin stores, use callbacks instead of inline checks (-1 means never use callbacks).
  --dfsan-preserve-alignment                                      - respect alignment requirements provided by input IR
  --dfsan-track-origins=<int>                                     - Track origins of labels
  --dfsan-track-select-control-flow                               - Propagate labels from condition values of select instructions to results.
  --disable-2addr-hack                                            - Disable scheduler's two-address hack
  --disable-adv-copy-opt                                          - Disable advanced copy optimization
  --disable-basic-aa                                              - 
  --disable-binop-extract-shuffle                                 - Disable binop extract to shuffle transforms
  --disable-bitcode-version-upgrade                               - Disable automatic bitcode upgrade for version mismatch
  --disable-block-placement                                       - Disable probability-driven block placement
  --disable-branch-fold                                           - Disable branch folding
  --disable-cfi-fixup                                             - Disable the CFI fixup pass
  --disable-cgp                                                   - Disable Codegen Prepare
  --disable-cgp-branch-opts                                       - Disable branch optimizations in CodeGenPrepare
  --disable-cgp-ext-ld-promotion                                  - Disable ext(promotable(ld)) -> promoted(ext(ld)) optimization in CodeGenPrepare
  --disable-cgp-gc-opts                                           - Disable GC optimizations in CodeGenPrepare
  --disable-cgp-select2branch                                     - Disable select to branch conversion.
  --disable-cgp-store-extract                                     - Disable store(extract) optimizations in CodeGenPrepare
  --disable-cleanups                                              - Do not remove implausible terminators or other similar cleanups
  --disable-complex-addr-modes                                    - Disables combining addressing modes with different parts in optimizeMemoryInst.
  --disable-constant-hoisting                                     - Disable ConstantHoisting
  --disable-copyprop                                              - Disable Copy Propagation pass
  --disable-debug-info-print                                      - Disable debug info printing
  --disable-demotion                                              - Clone multicolor basic blocks but do not demote cross scopes
  --disable-dfa-sched                                             - Disable use of DFA during scheduling
  --disable-early-ifcvt                                           - Disable Early If-conversion
  --disable-early-taildup                                         - Disable pre-register allocation tail duplication
  --disable-expand-reductions                                     - Disable the expand reduction intrinsics pass from running
  --disable-gep-const-evaluation                                  - Disables evaluation of GetElementPtr with constant operands
  --disable-gisel-legality-check                                  - Don't verify that MIR is fully legal between GlobalISel passes
  --disable-hoisting-to-hotter-blocks=<value>                     - Disable hoisting instructions to hotter blocks
    =none                                                         -   disable the feature
    =pgo                                                          -   enable the feature when using profile data
    =all                                                          -   enable the feature with/wo profile data
  --disable-i2p-p2i-opt                                           - Disables inttoptr/ptrtoint roundtrip optimization
  --disable-icp                                                   - Disable indirect call promotion
  --disable-ifcvt-diamond                                         - 
  --disable-ifcvt-forked-diamond                                  - 
  --disable-ifcvt-simple                                          - 
  --disable-ifcvt-simple-false                                    - 
  --disable-ifcvt-triangle                                        - 
  --disable-ifcvt-triangle-false                                  - 
  --disable-ifcvt-triangle-false-rev                              - 
  --disable-ifcvt-triangle-rev                                    - 
  --disable-inlined-alloca-merging                                - 
  --disable-interleaved-load-combine                              - Disable combining of interleaved loads
  --disable-layout-fsprofile-loader                               - Disable MIRProfileLoader before BlockPlacement
  --disable-lftr                                                  - Disable Linear Function Test Replace optimization
  --disable-libcalls-shrinkwrap                                   - Disable shrink-wrap library calls
  --disable-licm-promotion                                        - Disable memory promotion in LICM pass
  --disable-loop-level-heuristics                                 - Disable loop-level heuristics.
  --disable-lsr                                                   - Disable Loop Strength Reduction Pass
  --disable-machine-cse                                           - Disable Machine Common Subexpression Elimination
  --disable-machine-dce                                           - Disable Machine Dead Code Elimination
  --disable-machine-licm                                          - Disable Machine LICM
  --disable-machine-sink                                          - Disable Machine Sinking
  --disable-memop-opt                                             - Disable optimize
  --disable-mergeicmps                                            - Disable MergeICmps Pass
  --disable-mr-partial-inlining                                   - Disable multi-region partial inlining
  --disable-nofree-inference                                      - Stop inferring nofree attribute during function-attrs pass
  --disable-non-allocatable-phys-copy-opt                         - Disable non-allocatable physical register copy optimization
  --disable-nounwind-inference                                    - Stop inferring nounwind attribute during function-attrs pass
  --disable-nvptx-load-store-vectorizer                           - Disable load/store vectorizer
  --disable-nvptx-require-structured-cfg                          - Transitional flag to turn off NVPTX's requirement on preserving structured CFG. The requirement should be disabled only when unexpected regressions happen.
  --disable-ondemand-mds-loading                                  - Force disable the lazy-loading on-demand of metadata when loading bitcode for importing.
  --disable-partial-inlining                                      - Disable partial inlining
  --disable-partial-libcall-inlining                              - Disable Partial Libcall Inlining
  --disable-peephole                                              - Disable the peephole optimizer
  --disable-phi-elim-edge-splitting                               - Disable critical edge splitting during PHI elimination
  --disable-post-ra                                               - Disable Post Regalloc Scheduler
  --disable-postra-machine-licm                                   - Disable Machine LICM
  --disable-postra-machine-sink                                   - Disable PostRA Machine Sinking
  --disable-preheader-prot                                        - Disable protection against removing loop preheaders
  --disable-preinline                                             - Disable pre-instrumentation inliner
  --disable-promote-alloca-to-lds                                 - Disable promote alloca to LDS
  --disable-promote-alloca-to-vector                              - Disable promote alloca to vector
  --disable-ra-fsprofile-loader                                   - Disable MIRProfileLoader before RegAlloc
  --disable-sample-loader-inlining                                - If true, artifically skip inline transformation in sample-loader pass, and merge (or scale) profiles (as configured by --sample-profile-merge-inlinee).
  --disable-sched-critical-path                                   - Disable critical path priority in sched=list-ilp
  --disable-sched-cycles                                          - Disable cycle-level precision during preRA scheduling
  --disable-sched-hazard                                          - Disable hazard detection during preRA scheduling
  --disable-sched-height                                          - Disable scheduled-height priority in sched=list-ilp
  --disable-sched-live-uses                                       - Disable live use priority in sched=list-ilp
  --disable-sched-physreg-join                                    - Disable physreg def-use affinity
  --disable-sched-reg-pressure                                    - Disable regpressure priority in sched=list-ilp
  --disable-sched-stalls                                          - Disable no-stall priority in sched=list-ilp
  --disable-sched-vrcycle                                         - Disable virtual register cycle interference checks
  --disable-select-optimize                                       - Disable the select-optimization pass from running
  --disable-separate-const-offset-from-gep                        - Do not separate the constant offset from a GEP instruction
  --disable-spill-hoist                                           - Disable inline spill hoisting
  --disable-ssc                                                   - Disable Stack Slot Coloring
  --disable-strictnode-mutation                                   - Don't mutate strict-float node to a legalize node
  --disable-symbolication                                         - Disable symbolizing crash backtraces.
  --disable-tail-duplicate                                        - Disable tail duplication
  --disable-thinlto-funcattrs                                     - Don't propagate function-attrs in thinLTO
  --disable-type-promotion                                        - Disable type promotion pass
  --disable-vector-combine                                        - Disable all vector combine transforms
  --disable-vp                                                    - Disable Value Profiling
  --disable-whole-program-visibility                              - Disable whole program visibility (overrides enabling options)
  --do-comdat-renaming                                            - Append function hash to the name of COMDAT function to avoid function hash mismatch due to the preinliner
  --do-counter-promotion                                          - Do counter register promotion
  --dom-conditions-max-uses=<uint>                                - 
  --dom-tree-reachability-max-bbs-to-explore=<uint>               - Max number of BBs to explore for reachability analysis
  --dot-cfg-mssa=<file name for generated dot file>               - file name for generated dot file
  --dot-ddg-filename-prefix=<string>                              - The prefix used for the DDG dot file names.
  --dot-ddg-only                                                  - simple ddg dot graph
  --dse-memoryssa-defs-per-block-limit=<uint>                     - The number of MemoryDefs we consider as candidates to eliminated other stores per basic block (default = 5000)
  --dse-memoryssa-otherbb-cost=<uint>                             - The cost of a step in a different basic block than the killing MemoryDef(default = 5)
  --dse-memoryssa-partial-store-limit=<uint>                      - The maximum number candidates that only partially overwrite the killing MemoryDef to consider (default = 5)
  --dse-memoryssa-path-check-limit=<uint>                         - The maximum number of blocks to check when trying to prove that all paths to an exit go through a killing block (default = 50)
  --dse-memoryssa-samebb-cost=<uint>                              - The cost of a step in the same basic block as the killing MemoryDef(default = 1)
  --dse-memoryssa-scanlimit=<uint>                                - The number of memory instructions to scan for dead store elimination (default = 150)
  --dse-memoryssa-walklimit=<uint>                                - The maximum number of steps while walking upwards to find MemoryDefs that may be killed (default = 90)
  --dse-optimize-memoryssa                                        - Allow DSE to optimize memory accesses.
  --dwarf-extended-loc=<value>                                    - Disable emission of the extended flags in .loc directives.
    =Default                                                      -   Default for platform
    =Enable                                                       -   Enabled
    =Disable                                                      -   Disabled
  --dwarf-inlined-strings=<value>                                 - Use inlined strings rather than string section.
    =Default                                                      -   Default for platform
    =Enable                                                       -   Enabled
    =Disable                                                      -   Disabled
  --dwarf-linkage-names=<value>                                   - Which DWARF linkage-name attributes to emit.
    =Default                                                      -   Default for platform
    =All                                                          -   All
    =Abstract                                                     -   Abstract subprograms
  --dwarf-op-convert=<value>                                      - Enable use of the DWARFv5 DW_OP_convert operator
    =Default                                                      -   Default for platform
    =Enable                                                       -   Enabled
    =Disable                                                      -   Disabled
  --dwarf-sections-as-references=<value>                          - Use sections+offset as references rather than labels.
    =Default                                                      -   Default for platform
    =Enable                                                       -   Enabled
    =Disable                                                      -   Disabled
  --eagerly-invalidate-analyses                                   - Eagerly invalidate more analyses in default pipelines
  --early-ifcvt-limit=<uint>                                      - Maximum number of instructions per speculated block.
  --early-live-intervals                                          - Run live interval analysis earlier in the pipeline
  --earlycse-debug-hash                                           - Perform extra assertion checking to verify that SimpleValue's hash function is well-behaved w.r.t. its isEqual predicate
  --earlycse-mssa-optimization-cap=<uint>                         - Enable imprecision in EarlyCSE in pathological cases, in exchange for faster compile. Caps the MemorySSA clobbering calls.
  --emulate-old-livedebugvalues                                   - Act like old LiveDebugValues did
  --enable-aa-sched-mi                                            - Enable use of AA during MI DAG construction
  --enable-amdgpu-aa                                              - Enable AMDGPU Alias Analysis
  --enable-andcmp-sinking                                         - Enable sinkinig and/cmp into branches.
  --enable-block-placement-stats                                  - Collect probability-driven block placement stats
  --enable-chr                                                    - Enable control height reduction optimization (CHR)
  --enable-cold-section                                           - Enable placement of extracted cold functions into a separate section after hot-cold splitting.
  --enable-coldcc-stress-test                                     - Enable stress test of coldcc by adding calling conv to all internal functions.
  --enable-cond-stores-vec                                        - Enable if predication of stores during vectorization.
  --enable-constraint-elimination                                 - Enable pass to eliminate conditions based on linear constraints.
  --enable-cse-in-irtranslator                                    - Should enable CSE in irtranslator
  --enable-cse-in-legalizer                                       - Should enable CSE in Legalizer
  --enable-deferred-spilling                                      - Instead of spilling a variable right away, defer the actual code insertion to the end of the allocation. That way the allocator might still find a suitable coloring for this variable because of other evicted variables.
  --enable-dfa-jump-thread                                        - Enable DFA jump threading.
  --enable-double-float-shrink                                    - Enable unsafe double to float shrinking for math lib calls
  --enable-dse-partial-overwrite-tracking                         - Enable partial-overwrite tracking in DSE
  --enable-dse-partial-store-merging                              - Enable partial store merging in DSE
  --enable-epilogue-vectorization                                 - Enable vectorization of epilogue loops.
  --enable-ext-tsp-block-placement                                - Enable machine block placement based on the ext-tsp model, optimizing I-cache utilization.
  --enable-fs-discriminator                                       - Enable adding flow sensitive discriminators
  --enable-function-specialization                                - Enable Function Specialization pass
  --enable-gvn-hoist                                              - Enable the GVN hoisting pass (default = off)
  --enable-gvn-memdep                                             - 
  --enable-gvn-sink                                               - Enable the GVN sinking pass (default = off)
  --enable-heap-to-stack-conversion                               - 
  --enable-if-conversion                                          - Enable if-conversion during vectorization.
  --enable-implicit-null-checks                                   - Fold null checks into faulting memory operations
  --enable-import-metadata                                        - Enable import metadata like 'thinlto_src_module'
  --enable-ind-var-reg-heur                                       - Count the induction variable only once when interleaving
  --enable-interleaved-mem-accesses                               - Enable vectorization on interleaved memory accesses in a loop
  --enable-ipra                                                   - Enable interprocedural register allocation to reduce load/store at procedure calls.
  --enable-knowledge-retention                                    - enable preservation of attributes throughout code transformation
  --enable-legalize-types-checking                                - 
  --enable-linkonceodr-ir-outlining                               - Enable the IR outliner on linkonceodr functions
  --enable-linkonceodr-outlining                                  - Enable the machine outliner on linkonceodr functions
  --enable-load-in-loop-pre                                       - 
  --enable-load-pre                                               - 
  --enable-loadstore-runtime-interleave                           - Enable runtime interleaving until load/store ports are saturated
  --enable-local-reassign                                         - Local reassignment can yield better allocation decisions, but may be compile time intensive
  --enable-loop-distribute                                        - Enable the new, experimental LoopDistribution Pass
  --enable-loop-flatten                                           - Enable the LoopFlatten Pass
  --enable-loop-simplifycfg-term-folding                          - 
  --enable-loop-versioning-licm                                   - Enable the experimental Loop Versioning LICM pass
  --enable-loopinterchange                                        - Enable the experimental LoopInterchange Pass
  --enable-lsr-phielim                                            - Enable LSR phi elimination
  --enable-machine-outliner                                       - Enable the machine outliner
  --enable-machine-outliner=<value>                               - Enable the machine outliner
    =always                                                       -   Run on all functions guaranteed to be beneficial
    =never                                                        -   Disable all outlining
  --enable-masked-interleaved-mem-accesses                        - Enable vectorization on masked interleaved memory accesses in a loop
  --enable-matrix                                                 - Enable lowering of the matrix intrinsics
  --enable-mem-access-versioning                                  - Enable symbolic stride memory access versioning
  --enable-mem-prof                                               - Enable memory profiler
  --enable-memcpy-dag-opt                                         - Gang up loads and stores generated by inlining of memcpy
  --enable-memcpyopt-without-libcalls                             - Enable memcpyopt even when libcalls are disabled
  --enable-merge-functions                                        - Enable function merging as part of the optimization pipeline
  --enable-misched                                                - Enable the machine instruction scheduling pass.
  --enable-ml-inliner=<value>                                     - Enable ML policy for inliner. Currently trained for -Oz only
    =default                                                      -   Heuristics-based inliner version.
    =development                                                  -   Use development mode (runtime-loadable model).
    =release                                                      -   Use release mode (AOT-compiled model).
  --enable-module-inliner                                         - Enable module inliner
  --enable-name-compression                                       - Enable name/filename string compression
  --enable-newgvn                                                 - Run the NewGVN pass
  --enable-no-rerun-simplification-pipeline                       - Prevent running the simplification pipeline on a function more than once in the case that SCC mutations cause a function to be visited multiple times as long as the function has not been changed
  --enable-noalias-to-md-conversion                               - Convert noalias attributes to metadata during inlining.
  --enable-nonnull-arg-prop                                       - Try to propagate nonnull argument attributes from callsites to caller functions.
  --enable-nontrivial-unswitch                                    - Forcibly enables non-trivial loop unswitching rather than following the configuration passed into the pass.
  --enable-npm-O3-nontrivial-unswitch                             - Enable non-trivial loop unswitching for -O3
  --enable-npm-pgo-inline-deferral                                - Enable inline deferral during PGO
  --enable-npm-synthetic-counts                                   - Run synthetic function entry count generation pass
  --enable-objc-arc-opts                                          - enable/disable all ARC Optimizations
  --enable-order-file-instrumentation                             - Enable order file instrumentation (default = off)
  --enable-partial-inlining                                       - Run Partial inlinining pass
  --enable-patchpoint-liveness                                    - Enable PatchPoint Liveness Analysis Pass
  --enable-phi-of-ops                                             - 
  --enable-pipeliner                                              - Enable Software Pipelining
  --enable-pipeliner-opt-size                                     - Enable SWP at Os.
  --enable-post-misched                                           - Enable the post-ra machine instruction scheduling pass.
  --enable-pre                                                    - 
  --enable-scc-inline-advisor-printing                            - 
  --enable-scoped-noalias                                         - 
  --enable-selectiondag-sp                                        - 
  --enable-shrink-wrap                                            - enable the shrink-wrapping pass
  --enable-split-backedge-in-load-pre                             - 
  --enable-split-machine-functions                                - Split out cold blocks from machine functions based on profile information.
  --enable-store-refinement                                       - 
  --enable-subreg-liveness                                        - Enable subregister liveness tracking.
  --enable-tail-merge                                             - 
  --enable-tbaa                                                   - 
  --enable-unroll-and-jam                                         - Enable Unroll And Jam Pass
  --enable-unsafe-globalsmodref-alias-results                     - 
  --enable-unswitch-cost-multiplier                               - Enable unswitch cost multiplier that prohibits exponential explosion in nontrivial unswitch.
  --enable-vfe                                                    - Enable virtual function elimination
  --enable-vplan-native-path                                      - Enable VPlan-native vectorization path with support for outer loop vectorization.
  --epilogue-vectorization-force-VF=<uint>                        - When epilogue vectorization is enabled, and a value greater than 1 is specified, forces the given VF for all applicable epilogue loops.
  --epilogue-vectorization-minimum-VF=<uint>                      - Only loops with vectorization factor equal to or larger than the specified value are considered for epilogue vectorization.
  --exhaustive-register-search                                    - Exhaustive Search for registers bypassing the depth and interference cutoffs of last chance recoloring
  --expand-constant-exprs                                         - Expand constant expressions to instructions for testing purposes
  --expandvp-override-evl-transform=<string>                      - Options: <empty>|Legal|Discard|Convert. If non-empty, ignore TargetTransformInfo and always use this transformation for the %evl parameter (Used in testing).
  --expandvp-override-mask-transform=<string>                     - Options: <empty>|Legal|Discard|Convert. If non-empty, Ignore TargetTransformInfo and always use this transformation for the %mask parameter (Used in testing).
  --experimental-debug-variable-locations                         - Use experimental new value-tracking variable locations
  --ext-tsp-apply-without-profile                                 - Whether to apply ext-tsp placement for instances w/o profile
  --ext-tsp-backward-distance=<uint>                              - The maximum distance (in bytes) of a backward jump for ExtTSP
  --ext-tsp-backward-weight=<number>                              - The weight of backward jumps for ExtTSP value
  --ext-tsp-chain-split-threshold=<uint>                          - The maximum size of a chain to apply splitting
  --ext-tsp-enable-chain-split-along-jumps                        - The maximum size of a chain to apply splitting
  --ext-tsp-forward-distance=<uint>                               - The maximum distance (in bytes) of a forward jump for ExtTSP
  --ext-tsp-forward-weight=<number>                               - The weight of forward jumps for ExtTSP value
  --ext-tsp-max-chain-size=<uint>                                 - The maximum size of a chain to create.
  --extra-vectorizer-passes                                       - Run cleanup optimization passes after vectorization.
  --extract-blocks-erase-funcs                                    - Erase the existing functions
  --extract-blocks-file=<filename>                                - A file containing list of basic blocks to extract
  --fast-cluster-threshold=<uint>                                 - The threshold for fast cluster
  --fast-isel                                                     - Enable the "fast" instruction selector
  --fast-isel-abort=<int>                                         - Enable abort calls when "fast" instruction selection fails to lower an instruction: 0 disable the abort, 1 will abort but for args, calls and terminators, 2 will also abort for argument lowering, and 3 will never fallback to SelectionDAG.
  --fast-isel-report-on-fallback                                  - Emit a diagnostic when "fast" instruction selection falls back to SelectionDAG.
  --filter-print-funcs=<function names>                           - Only print IR for functions whose name match this for all print-[before|after][-all] options
  --filter-view-dags=<string>                                     - Only display the basic block whose name matches this for all view-*-dags options
  --fixup-allow-gcptr-in-csr                                      - Allow passing GC Pointer arguments in callee saved registers
  --fixup-max-csr-statepoints=<uint>                              - Max number of statepoints allowed to pass GC Ptrs in registers
  --fixup-scs-enable-copy-propagation                             - Enable simple copy propagation during register reloading
  --fixup-scs-extend-slot-size                                    - Allow spill in spill slot of greater size than register size
  --flat-loop-tripcount-threshold=<uint>                          - If the runtime tripcount for the loop is lower than the threshold, the loop is considered as flat and will be less aggressively unrolled.
  --flattened-profile-used                                        - Indicate the sample profile being used is flattened, i.e., no inline hierachy exists in the profile. 
  --float2int-max-integer-bw=<uint>                               - Max integer bitwidth to consider in float2int(default=64)
  --force-attribute=<string>                                      - Add an attribute to a function. This should be a pair of 'function-name:attribute-name', for example -force-attribute=foo:noinline. This option can be specified multiple times.
  --force-chr                                                     - Apply CHR for all functions
  --force-fast-cluster                                            - Switch to fast cluster algorithm with the lost of some fusion opportunities
  --force-function-specialization                                 - Force function specialization for every call site with a constant argument
  --force-fuse-matrix                                             - Force matrix instruction fusion even if not profitable.
  --force-hardware-loop-guard                                     - Force generation of loop guard intrinsic
  --force-hardware-loop-phi                                       - Force hardware loop counter to be updated through a phi
  --force-hardware-loops                                          - Force hardware loops intrinsics to be inserted
  --force-import-all                                              - Import functions with noinline attribute
  --force-instr-ref-livedebugvalues                               - Use instruction-ref based LiveDebugValues with normal DBG_VALUE inputs
  --force-legal-indexing                                          - Force all indexed operations to be legal for the GlobalISel combiner
  --force-loop-cold-block                                         - Force outlining cold blocks from loops.
  --force-nested-hardware-loop                                    - Force allowance of nested hardware loops
  --force-ordered-reductions                                      - Enable the vectorisation of loops with in-order (strict) FP reductions
  --force-pgso                                                    - Force the (profiled-guided) size optimizations. 
  --force-precise-rotation-cost                                   - Force the use of precise cost loop rotation strategy.
  --force-remove-attribute=<string>                               - Remove an attribute from a function. This should be a pair of 'function-name:attribute-name', for example -force-remove-attribute=foo:noinline. This option can be specified multiple times.
  --force-split-store                                             - Force store splitting no matter what the target query says.
  --force-summary-edges-cold=<value>                              - Force all edges in the function summary to cold
    =none                                                         -   None.
    =all-non-critical                                             -   All non-critical edges.
    =all                                                          -   All edges.
  --force-target-instruction-cost=<uint>                          - A flag that overrides the target's expected cost for an instruction to a single constant value. Mostly useful for getting consistent testing.
  --force-target-max-scalar-interleave=<uint>                     - A flag that overrides the target's max interleave factor for scalar loops.
  --force-target-max-vector-interleave=<uint>                     - A flag that overrides the target's max interleave factor for vectorized loops.
  --force-target-num-scalar-regs=<uint>                           - A flag that overrides the target's number of scalar registers.
  --force-target-num-vector-regs=<uint>                           - A flag that overrides the target's number of vector registers.
  --force-target-supports-scalable-vectors                        - Pretend that scalable vectors are supported, even if the target does not support them. This flag should only be used for testing.
  --force-vector-interleave=<uint>                                - Sets the vectorization interleave count. Zero is autoselect.
  --force-vector-width=<uint>                                     - Sets the SIMD width. Zero is autoselect.
  --forget-scev-loop-unroll                                       - Forget everything in SCEV when doing LoopUnroll, instead of just the current top-most loop. This is sometimes preferred to reduce compile time.
  --forward-switch-cond                                           - Forward switch condition to phi ops (default = false)
  --freeze-loop-unswitch-cond                                     - If enabled, the freeze instruction will be added to condition of loop unswitch to prevent miscompilation.
  --fs-no-final-discrim                                           - Do not insert FS-AFDO discriminators before emit.
  --fs-profile-debug-bw-threshold=<uint>                          - Only show debug message if the source branch weight is greater  than this value.
  --fs-profile-debug-prob-diff-threshold=<uint>                   - Only show debug message if the branch probility is greater than this value (in percentage).
  --fs-profile-file=<filename>                                    - Flow Sensitive profile file name.
  --fs-remapping-file=<filename>                                  - Flow Sensitive profile remapping file name.
  --fs-viewbfi-after                                              - View BFI after MIR loader
  --fs-viewbfi-before                                             - View BFI before MIR loader
  --func-specialization-avg-iters-cost=<uint>                     - Average loop iteration count cost
  --func-specialization-max-clones=<uint>                         - The maximum number of clones allowed for a single function specialization
  --func-specialization-max-iters=<uint>                          - The maximum number of iterations function specialization is run
  --func-specialization-on-address                                - Enable function specialization on the address of global values
  --func-specialization-size-threshold=<uint>                     - Don't specialize functions that have less than this theshold number of instructions
  --function-specialization-for-literal-constant                  - Enable specialization of functions that take a literal constant as an argument.
  --fuse-matrix                                                   - Enable/disable fusing matrix instructions.
  --fuse-matrix-tile-size=<uint>                                  - Tile size for matrix instruction fusion using square-shaped tiles.
  --fuse-matrix-use-loops                                         - Generate loop nest for tiling.
  --gcov-atomic-counter                                           - Make counter updates atomic
  --generate-arange-section                                       - Generate dwarf aranges
  --generate-merged-base-profiles                                 - When generating nested context-sensitive profiles, always generate extra base profile for function with all its context profiles merged into it.
  --generate-type-units                                           - Generate DWARF4 type units.
  --global-isel                                                   - Enable the "global" instruction selector
  --global-isel-abort=<value>                                     - Enable abort calls when "global" instruction selection fails to lower/select an instruction
    =0                                                            -   Disable the abort
    =1                                                            -   Enable the abort
    =2                                                            -   Disable the abort but emit a diagnostic on failure
  --greedy-regclass-priority-trumps-globalness                    - Change the greedy register allocator's live range priority calculation to make the AllocationPriority of the register class more important then whether the range is global
  --greedy-reverse-local-assignment                               - Reverse allocation order of local live ranges, such that shorter local live ranges will tend to be allocated first
  --grow-region-complexity-budget=<ulong>                         - growRegion() does not scale with the number of BB edges, so limit its budget and bail out once we reach the limit.
  --guard-widening-widen-branch-guards                            - Whether or not we should widen guards  expressed as branches by widenable conditions
  --guards-predicate-pass-branch-weight=<uint>                    - The probability of a guard failing is assumed to be the reciprocal of this value (default = 1 << 20)
  --gvn-add-phi-translation                                       - Enable phi-translation of add instructions
  --gvn-hoist-max-bbs=<int>                                       - Max number of basic blocks on the path between hoisting locations (default = 4, unlimited = -1)
  --gvn-hoist-max-chain-length=<int>                              - Maximum length of dependent chains to hoist (default = 10, unlimited = -1)
  --gvn-hoist-max-depth=<int>                                     - Hoist instructions from the beginning of the BB up to the maximum specified depth (default = 100, unlimited = -1)
  --gvn-max-block-speculations=<uint>                             - Max number of blocks we're willing to speculate on (and recurse into) when deducing if a value is fully available or not in GVN (default = 600)
  --gvn-max-hoisted=<int>                                         - Max number of instructions to hoist (default unlimited = -1)
  --gvn-max-num-deps=<uint>                                       - Max number of dependences to attempt Load PRE (default = 100)
  --hardware-loop-counter-bitwidth=<uint>                         - Set the loop counter bitwidth
  --hardware-loop-decrement=<uint>                                - Set the loop decrement value
  --hash-based-counter-split                                      - Rename counter variable of a comdat function based on cfg hash
  --hints-allow-reordering                                        - Allow enabling loop hints to reorder FP operations during vectorization.
  --hoist-cheap-insts                                             - MachineLICM should hoist even cheap instructions
  --hoist-common-insts                                            - hoist common instructions (default = false)
  --hoist-const-stores                                            - Hoist invariant stores
  --hot-callsite-rel-freq=<int>                                   - Minimum block frequency, expressed as a multiple of caller's entry frequency, for a callsite to be hot in the absence of profile information.
  --hot-callsite-threshold=<int>                                  - Threshold for hot callsites 
  --hot-cold-split                                                - Enable hot-cold splitting pass
  --hot-cold-static-analysis                                      - 
  --hotcoldsplit-cold-section-name=<string>                       - Name for the section containing cold functions extracted by hot-cold splitting.
  --hotcoldsplit-max-params=<int>                                 - Maximum number of parameters for a split function
  --hotcoldsplit-threshold=<int>                                  - Base penalty for splitting cold code (as a multiple of TCC_Basic)
  --huge-size-for-split=<uint>                                    - A threshold of live range size which may cause high compile time cost in global splitting.
  --hwasan-experimental-use-page-aliases                          - Use page aliasing in HWASan
  --hwasan-generate-tags-with-calls                               - generate new tags with runtime library calls
  --hwasan-globals                                                - Instrument globals
  --hwasan-inline-all-checks                                      - inline all checks
  --hwasan-instrument-atomics                                     - instrument atomic instructions (rmw, cmpxchg)
  --hwasan-instrument-byval                                       - instrument byval arguments
  --hwasan-instrument-landing-pads                                - instrument landing pads
  --hwasan-instrument-mem-intrinsics                              - instrument memory intrinsics
  --hwasan-instrument-personality-functions                       - instrument personality functions
  --hwasan-instrument-reads                                       - instrument read instructions
  --hwasan-instrument-stack                                       - instrument stack (allocas)
  --hwasan-instrument-with-calls                                  - instrument reads and writes with callbacks
  --hwasan-instrument-writes                                      - instrument write instructions
  --hwasan-kernel                                                 - Enable KernelHWAddressSanitizer instrumentation
  --hwasan-kernel-mem-intrinsic-prefix                            - Use prefix for memory intrinsics in KASAN mode
  --hwasan-mapping-offset=<ulong>                                 - HWASan shadow mapping offset [EXPERIMENTAL]
  --hwasan-match-all-tag=<int>                                    - don't report bad accesses via pointers with this tag
  --hwasan-memory-access-callback-prefix=<string>                 - Prefix for memory access callbacks
  --hwasan-record-stack-history=<value>                           - Record stack frames with tagged allocations in a thread-local ring buffer
    =none                                                         -   Do not record stack ring history
    =instr                                                        -   Insert instructions into the prologue for storing into the stack ring buffer directly
    =libcall                                                      -   Add a call to __hwasan_add_frame_record for storing into the stack ring buffer
  --hwasan-recover                                                - Enable recovery mode (continue-after-error).
  --hwasan-uar-retag-to-zero                                      - Clear alloca tags before returning from the function to allow non-instrumented and instrumented function calls mix. When set to false, allocas are retagged before returning from the function to detect use after return.
  --hwasan-use-after-scope                                        - detect use after scope within function
  --hwasan-use-short-granules                                     - use short granules in allocas and outlined checks
  --hwasan-use-stack-safety                                       - Use Stack Safety analysis results
  --hwasan-with-ifunc                                             - Access dynamic shadow through an ifunc global on platforms that support this
  --hwasan-with-tls                                               - Access dynamic shadow through an thread-local pointer on platforms that support this
  --icp-call-only                                                 - Run indirect-call promotion for call instructions only
  --icp-csskip=<uint>                                             - Skip Callsite up to this number for this compilation
  --icp-cutoff=<uint>                                             - Max number of promotions for this compilation
  --icp-dumpafter                                                 - Dump IR after transformation happens
  --icp-invoke-only                                               - Run indirect-call promotion for invoke instruction only
  --icp-lto                                                       - Run indirect-call promotion in LTO mode
  --icp-max-annotations=<uint>                                    - Max number of annotations for a single indirect call callsite
  --icp-max-prom=<uint>                                           - Max number of promotions for a single indirect call callsite
  --icp-remaining-percent-threshold=<uint>                        - The percentage threshold against remaining unpromoted indirect call count for the promotion
  --icp-samplepgo                                                 - Run indirect-call promotion in SamplePGO mode
  --icp-total-percent-threshold=<uint>                            - The percentage threshold against total count for the promotion
  --ifcvt-branch-fold                                             - 
  --ifcvt-fn-start=<int>                                          - 
  --ifcvt-fn-stop=<int>                                           - 
  --ifcvt-limit=<int>                                             - 
  --ignore-tti-inline-compatible                                  - Ignore TTI attributes compatibility check between callee/caller during inline cost calculation
  --imp-null-check-page-size=<int>                                - The page size of the target in bytes
  --imp-null-max-insts-to-consider=<uint>                         - The max number of instructions to consider hoisting loads over (the algorithm is quadratic over this number)
  --import-all-index                                              - Import all external functions in index.
  --import-cold-multiplier=<N>                                    - Multiply the 'import-instr-limit' threshold for cold callsites
  --import-constants-with-refs                                    - Import constant global variables with references
  --import-critical-multiplier=<x>                                - Multiply the 'import-instr-limit' threshold for critical callsites
  --import-cutoff=<N>                                             - Only import first N functions if N>=0 (default -1)
  --import-full-type-definitions                                  - Import full type definitions for ThinLTO.
  --import-hot-evolution-factor=<x>                               - As we import functions called from hot callsite, multiply the 'import-instr-limit' threshold by this factor before processing newly imported functions
  --import-hot-multiplier=<x>                                     - Multiply the 'import-instr-limit' threshold for hot callsites
  --import-instr-evolution-factor=<x>                             - As we import functions, multiply the 'import-instr-limit' threshold by this factor before processing newly imported functions
  --import-instr-limit=<N>                                        - Only import functions with less than N instructions
  --indvars-post-increment-ranges                                 - Use post increment control-dependent ranges in IndVarSimplify
  --indvars-predicate-loops                                       - Predicate conditions in read only loops
  --indvars-widen-indvars                                         - Allow widening of indvars to eliminate s/zext
  --info-output-file=<filename>                                   - File to append -stats and -timer output to
  --initial-synthetic-count=<int>                                 - Initial value of synthetic entry count
  --inline-call-penalty=<int>                                     - Call penalty that is applied per callsite when inlining
  --inline-caller-superset-nobuiltin                              - Allow inlining when caller has a superset of callee's nobuiltin attributes.
  --inline-cold-callsite-threshold=<int>                          - Threshold for inlining cold callsites
  --inline-cost-full                                              - Compute the full inline cost of a call site even when the cost exceeds the threshold.
  --inline-deferral                                               - Enable deferred inlining
  --inline-deferral-scale=<int>                                   - Scale to limit the cost of inline deferral
  --inline-enable-cost-benefit-analysis                           - Enable the cost-benefit analysis for the inliner
  --inline-instr-cost=<int>                                       - Cost of a single instruction when inlining
  --inline-max-stacksize=<ulong>                                  - Do not inline functions with a stack size that exceeds the specified limit
  --inline-memaccess-cost=<int>                                   - Cost of load/store instruction when inlining
  --inline-priority-mode=<value>                                  - Choose the priority mode to use in module inline
    =no priority                                                  -   Use no priority, visit callsites in bottom-up.
    =size                                                         -   Use callee size priority.
    =cost                                                         -   Use inline cost priority.
  --inline-remark-attribute                                       - Enable adding inline-remark attribute to callsites processed by inliner but decided to be not inlined
  --inline-savings-multiplier=<int>                               - Multiplier to multiply cycle savings by during inlining
  --inline-size-allowance=<int>                                   - The maximum size of a callee that get's inlined without sufficient cycle savings
  --inline-synthetic-count=<int>                                  - Initial synthetic entry count for inline functions.
  --inline-threshold=<int>                                        - Control the amount of inlining to perform (default = 225)
  --inlinecold-threshold=<int>                                    - Threshold for inlining functions with cold attribute
  --inlinedefault-threshold=<int>                                 - Default amount of inlining to perform
  --inlinehint-threshold=<int>                                    - Threshold for inlining functions with inline hint
  --inliner-function-import-stats=<value>                         - Enable inliner stats for imported functions
    =basic                                                        -   basic statistics
    =verbose                                                      -   printing of statistics for each inlined function
  --instcombine-code-sinking                                      - Enable code sinking
  --instcombine-guard-widening-window=<uint>                      - How wide an instruction window to bypass looking for another guard
  --instcombine-infinite-loop-threshold=<uint>                    - Number of instruction combining iterations considered an infinite loop
  --instcombine-lower-dbg-declare=<uint>                          - 
  --instcombine-max-iterations=<uint>                             - Limit the maximum number of instruction combining iterations
  --instcombine-max-num-phis=<uint>                               - Maximum number phis to handle in intptr/ptrint folding
  --instcombine-max-sink-users=<uint>                             - Maximum number of undroppable users for instruction sinking
  --instcombine-maxarray-size=<uint>                              - Maximum array size considered when doing a combine
  --instcombine-negator-enabled                                   - Should we attempt to sink negations?
  --instcombine-negator-max-depth=<uint>                          - What is the maximal lookup depth when trying to check for viability of negation sinking.
  --instrprof-atomic-counter-update-all                           - Make all profile counter updates atomic (for testing only)
  --interleave-loops                                              - Enable loop interleaving in Loop vectorization passes
  --interleave-small-loop-scalar-reduction                        - Enable interleaving for loops with small iteration counts that contain scalar reductions to expose ILP.
  --internalize-public-api-file=<filename>                        - A file containing list of symbol names to preserve
  --internalize-public-api-list=<list>                            - A list of symbol names to preserve
  --intra-scc-cost-multiplier=<int>                               - Cost multiplier to multiply onto inlined call sites where the new call was previously an intra-SCC call (not relevant when the original call was already intra-SCC). This can accumulate over multiple inlinings (e.g. if a call site already had a cost multiplier and one of its inlined calls was also subject to this, the inlined call would have the original multiplier multiplied by intra-scc-cost-multiplier). This is to prevent tons of inlining through a child SCC which can cause terrible compile times
  --ipt-expensive-asserts                                         - Perform expensive assert validation on every query to Instruction Precedence Tracking
  --ir-outliner                                                   - Enable ir outliner pass
  --irce-allow-narrow-latch                                       - If set to true, IRCE may eliminate wide range checks in loops with narrow latch condition.
  --irce-allow-unsigned-latch                                     - 
  --irce-loop-size-cutoff=<uint>                                  - 
  --irce-min-runtime-iterations=<uint>                            - 
  --irce-print-changed-loops                                      - 
  --irce-print-range-checks                                       - 
  --irce-skip-profitability-checks                                - 
  --iterative-bfi-max-iterations-per-block=<uint>                 - Iterative inference: maximum number of update iterations per block
  --iterative-bfi-precision=<number>                              - Iterative inference: delta convergence precision; smaller values typically lead to better results at the cost of worsen runtime
  --iterative-counter-promotion                                   - Allow counter promotion across the whole loop nest.
  --join-globalcopies                                             - Coalesce copies that span blocks (default=subtarget)
  --join-liveintervals                                            - Coalesce copies (default=true)
  --join-splitedges                                               - Coalesce copies on split edges (default=subtarget)
  --jump-inst-cost=<uint>                                         - Cost of jump instructions.
  --jump-is-expensive                                             - Do not create extra branches to split comparison logic.
  --jump-table-density=<uint>                                     - Minimum density for building a jump table in a normal function
  --jump-threading-across-loop-headers                            - Allow JumpThreading to thread across loop headers, for testing
  --jump-threading-implication-search-threshold=<uint>            - The number of predecessors to search for a stronger condition to use to thread over a weaker condition
  --jump-threading-threshold=<uint>                               - Max block size to duplicate for jump threading
  --keep-inline-advisor-for-printing                              - 
  --keep-loops                                                    - Preserve canonical loop structure (default = true)
  --large-interval-freq-threshold=<uint>                          - For a large interval, if it is coalesed with other live intervals many times more than the threshold, stop its coalescing to control the compile time. 
  --large-interval-size-threshold=<uint>                          - If the valnos size of an interval is larger than the threshold, it is regarded as a large interval. 
  --late-remat-update-threshold=<uint>                            - During rematerialization for a copy, if the def instruction has many other copy uses to be rematerialized, delay the multiple separate live interval update work and do them all at once after all those rematerialization are done. It will save a lot of repeated work. 
  --lcr-max-depth=<uint>                                          - Last chance recoloring max depth
  --lcr-max-interf=<uint>                                         - Last chance recoloring maximum number of considered interference at a time
  --ldstmemcpy-glue-max=<int>                                     - Number limit for gluing ld/st of memcpy.
  --licm-control-flow-hoisting                                    - Enable control flow (and PHI) hoisting in LICM
  --licm-max-num-uses-traversed=<uint>                            - Max num uses visited for identifying load invariance in loop using invariant start (default = 8)
  --licm-mssa-max-acc-promotion=<uint>                            - [LICM & MemorySSA] When MSSA in LICM is disabled, this has no effect. When MSSA in LICM is enabled, then this is the maximum number of accesses allowed to be present in a loop in order to enable memory promotion.
  --licm-mssa-optimization-cap=<uint>                             - Enable imprecision in LICM in pathological cases, in exchange for faster compile. Caps the MemorySSA clobbering calls.
  --licm-versioning-invariant-threshold=<number>                  - LoopVersioningLICM's minimum allowed percentageof possible invariant instructions per loop
  --licm-versioning-max-depth-threshold=<uint>                    - LoopVersioningLICM's threshold for maximum allowed loop nest/depth
  --likely-branch-weight=<uint>                                   - Weight of the branch likely to be taken (default = 2000)
  --limit-float-precision=<uint>                                  - Generate low-precision inline sequences for some float libcalls
  --live-debug-variables                                          - Enable the live debug variables pass
  --livedebugvalues-input-bb-limit=<uint>                         - Maximum input basic blocks before DBG_VALUE limit applies
  --livedebugvalues-input-dbg-value-limit=<uint>                  - Maximum input DBG_VALUE insts supported by debug range extension
  --livedebugvalues-max-stack-slots=<uint>                        - livedebugvalues-stack-ws-limit
  --locally-hot-callsite-threshold=<int>                          - Threshold for locally hot callsites 
  --loop-deletion-enable-symbolic-execution                       - Break backedge through symbolic execution of 1st iteration attempting to prove that the backedge is never taken
  --loop-distribute-non-if-convertible                            - Whether to distribute into a loop that may not be if-convertible by the loop vectorizer
  --loop-distribute-scev-check-threshold=<uint>                   - The maximum number of SCEV checks allowed for Loop Distribution
  --loop-distribute-scev-check-threshold-with-pragma=<uint>       - The maximum number of SCEV checks allowed for Loop Distribution for loop marked with #pragma loop distribute(enable)
  --loop-distribute-verify                                        - Turn on DominatorTree and LoopInfo verification after Loop Distribution
  --loop-flatten-assume-no-overflow                               - Assume that the product of the two iteration trip counts will never overflow
  --loop-flatten-cost-threshold=<uint>                            - Limit on the cost of instructions that can be repeated due to loop flattening
  --loop-flatten-widen-iv                                         - Widen the loop induction variables, if possible, so overflow checks won't reject flattening
  --loop-fusion-dependence-analysis=<value>                       - Which dependence analysis should loop fusion use?
    =scev                                                         -   Use the scalar evolution interface
    =da                                                           -   Use the dependence analysis interface
    =all                                                          -   Use all available analyses
  --loop-fusion-peel-max-count=<uint>                             - Max number of iterations to be peeled from a loop, such that fusion can take place
  --loop-fusion-verbose-debug                                     - Enable verbose debugging for Loop Fusion
  --loop-interchange-threshold=<int>                              - Interchange if you gain more than this number
  --loop-load-elimination-scev-check-threshold=<uint>             - The maximum number of SCEV checks allowed for Loop Load Elimination
  --loop-predication-enable-count-down-loop                       - 
  --loop-predication-enable-iv-truncation                         - 
  --loop-predication-latch-probability-scale=<number>             - scale factor for the latch probability. Value should be greater than 1. Lower values are ignored
  --loop-predication-predicate-widenable-branches-to-deopt        - Whether or not we should predicate guards expressed as widenable branches to deoptimize blocks
  --loop-predication-skip-profitability-checks                    - 
  --loop-prefetch-writes                                          - Prefetch write addresses
  --loop-rotate-multi                                             - Allow loop rotation multiple times in order to reach a better latch exit
  --loop-to-cold-block-ratio=<uint>                               - Outline loop blocks from loop chain if (frequency of loop) / (frequency of block) is greater than this ratio
  --loop-vectorize-with-block-frequency                           - Enable the use of the block frequency analysis to access PGO heuristics minimizing code growth in cold regions and being more aggressive in hot regions.
  --loop-version-annotate-no-alias                                - Add no-alias annotation for instructions that are disambiguated by memchecks
  --lower-interleaved-accesses                                    - Enable lowering interleaved accesses to intrinsics
  --lowertypetests-avoid-reuse                                    - Try to avoid reuse of byte array addresses using aliases
  --lowertypetests-drop-type-tests                                - Simply drop type test assume sequences
  --lowertypetests-read-summary=<string>                          - Read summary from given YAML file before running pass
  --lowertypetests-summary-action=<value>                         - What to do with the summary when running this pass
    =none                                                         -   Do nothing
    =import                                                       -   Import typeid resolutions from summary and globals
    =export                                                       -   Export typeid resolutions to summary and globals
  --lowertypetests-write-summary=<string>                         - Write summary to given YAML file after running pass
  --lsr-complexity-limit=<uint>                                   - LSR search space complexity limit
  --lsr-exp-narrow                                                - Narrow LSR complex solution using expectation of registers number
  --lsr-filter-same-scaled-reg                                    - Narrow LSR search space by filtering non-optimal formulae with the same ScaledReg and Scale
  --lsr-insns-cost                                                - Add instruction count to a LSR cost model
  --lsr-preferred-addressing-mode=<value>                         - A flag that overrides the target's preferred addressing mode.
    =none                                                         -   Don't prefer any addressing mode
    =preindexed                                                   -   Prefer pre-indexed addressing mode
    =postindexed                                                  -   Prefer post-indexed addressing mode
  --lsr-setupcost-depth-limit=<uint>                              - The limit on recursion depth for LSRs setup cost
  --machine-combiner-dump-subst-intrs                             - Dump all substituted intrs
  --machine-combiner-inc-threshold=<uint>                         - Incremental depth computation will be used for basic blocks with more instructions.
  --machine-combiner-verify-pattern-order                         - Verify that the generated patterns are ordered by increasing latency
  --machine-outliner-reruns=<uint>                                - Number of times to rerun the outliner after the initial outline
  --machine-sink-bfi                                              - Use block frequency info to find successors to sink
  --machine-sink-cycle-limit=<uint>                               - The maximum number of instructions considered for cycle sinking.
  --machine-sink-load-blocks-threshold=<uint>                     - Do not try to find alias store for a load if the block number in the straight line is higher than this threshold.
  --machine-sink-load-instrs-threshold=<uint>                     - Do not try to find alias store for a load if there is a in-path block whose instruction number is higher than this threshold.
  --machine-sink-split                                            - Split critical edges during machine sinking
  --machine-sink-split-probability-threshold=<uint>               - Percentage threshold for splitting single-instruction critical edge. If the branch threshold is higher than this threshold, we allow speculative execution of up to 1 instruction to avoid branching to splitted critical edge
  --mandatory-inlining-first                                      - Perform mandatory inlinings module-wide, before performing inlining.
  --matrix-allow-contract                                         - Allow the use of FMAs if available and profitable. This may result in different results, due to less rounding error.
  --matrix-default-layout=<value>                                 - Sets the default matrix layout
    =column-major                                                 -   Use column-major layout
    =row-major                                                    -   Use row-major layout
  --max-bytes-for-alignment=<uint>                                - Forces the maximum bytes allowed to be emitted when padding for alignment
  --max-counter-promotions=<int>                                  - Max number of allowed counter promotions
  --max-counter-promotions-per-loop=<uint>                        - Max number counter promotions per loop to avoid increasing register pressure too much
  --max-deopt-or-unreachable-succ-check-depth=<uint>              - Set the maximum path length when checking whether a basic block is followed by a block that either has a terminating deoptimizing call or is terminated with an unreachable
  --max-dependences=<uint>                                        - Maximum number of dependences collected by loop-access analysis (default = 100)
  --max-forked-scev-depth=<uint>                                  - Maximum recursion depth when finding forked SCEVs (default = 5)
  --max-heap-to-stack-size=<int>                                  - 
  --max-inst-checked-for-throw-during-inlining=<uint>             - the maximum number of instructions analyzed for may throw during attribute inference in inlined body
  --max-interleave-group-factor=<uint>                            - Maximum factor for an interleaved access group (default = 8)
  --max-jump-table-size=<uint>                                    - Set maximum size of jump tables.
  --max-loads-per-memcmp=<uint>                                   - Set maximum number of loads used in expanded memcmp
  --max-loads-per-memcmp-opt-size=<uint>                          - Set maximum number of loads used in expanded memcmp for -Os/Oz
  --max-nested-scalar-reduction-interleave=<uint>                 - The maximum interleave count to use when interleaving a scalar reduction in a nested loop.
  --max-num-inline-blocks=<uint>                                  - Max number of blocks to be partially inlined
  --max-partial-inlining=<int>                                    - Max number of partial inlining. The default is unlimited
  --max-prefetch-iters-ahead=<uint>                               - Max number of iterations to prefetch ahead
  --max-registers-for-gc-values=<uint>                            - Max number of VRegs allowed to pass GC pointer meta args in
  --max-sched-reorder=<int>                                       - Number of instructions to allow ahead of the critical path in sched=list-ilp
  --max-speculation-depth=<uint>                                  - Limit maximum recursion depth when calculating costs of speculatively executed instructions
  --max-switch-cases-per-result=<uint>                            - Limit cases to analyze when converting a switch to select
  --max-uses-for-sinking=<uint>                                   - Do not sink instructions that have too many uses.
  --mcp-use-is-copy-instr                                         - 
  --memcmp-num-loads-per-block=<uint>                             - The number of loads per basic block for inline expansion of memcmp that is only being compared against zero.
  --memdep-block-number-limit=<uint>                              - The number of blocks to scan during memory dependency analysis (default = 1000)
  --memdep-block-scan-limit=<uint>                                - The number of instructions to scan in a block in memory dependency analysis (default = 100)
  --memop-max-annotations=<uint>                                  - Max number of preicise value annotations for a single memopintrinsic
  --memop-value-prof-max-opt-size=<uint>                          - Optimize the memop size <= this value
  --memory-check-merge-threshold=<uint>                           - Maximum number of comparisons done when trying to merge runtime memory checks. (default = 100)
  --memprof-debug=<int>                                           - debug
  --memprof-debug-func=<string>                                   - Debug func
  --memprof-debug-max=<int>                                       - Debug max inst
  --memprof-debug-min=<int>                                       - Debug min inst
  --memprof-guard-against-version-mismatch                        - Guard against compiler/runtime version mismatch.
  --memprof-instrument-atomics                                    - instrument atomic instructions (rmw, cmpxchg)
  --memprof-instrument-reads                                      - instrument read instructions
  --memprof-instrument-stack                                      - Instrument scalar stack variables
  --memprof-instrument-writes                                     - instrument write instructions
  --memprof-mapping-granularity=<int>                             - granularity of memprof shadow mapping
  --memprof-mapping-scale=<int>                                   - scale of memprof shadow mapping
  --memprof-memory-access-callback-prefix=<string>                - Prefix for memory access callbacks
  --memprof-use-callbacks                                         - Use callbacks instead of inline instrumentation sequences.
  --memssa-check-limit=<uint>                                     - The maximum number of stores/phis MemorySSAwill consider trying to walk past (default = 100)
  --mergefunc-preserve-debug-info                                 - Preserve debug info in thunk when mergefunc transformations are made.
  --mergefunc-use-aliases                                         - Allow mergefunc to create aliases
  --mergefunc-verify=<uint>                                       - How many functions in a module could be used for MergeFunctions to pass a basic correctness check. '0' disables this check. Works only with '-debug' key.
  --mfs-count-threshold=<uint>                                    - Minimum number of times a block must be executed to be retained.
  --mfs-psi-cutoff=<uint>                                         - Percentile profile summary cutoff used to determine cold blocks. Unused if set to zero.
  --min-block-execution=<uint>                                    - Minimum block executions to consider its BranchProbabilityInfo valid
  --min-jump-table-entries=<uint>                                 - Set minimum number of entries to use a jump table.
  --min-prefetch-stride=<uint>                                    - Min stride to add prefetches
  --min-region-size-ratio=<number>                                - Minimum ratio comparing relative sizes of each outline candidate and original function
  --minimize-addr-in-v5=<value>                                   - Always use DW_AT_ranges in DWARFv5 whenever it could allow more address pool entry sharing to reduce relocations/object size
    =Default                                                      -   Default address minimization strategy
    =Ranges                                                       -   Use rnglists for contiguous ranges if that allows using a pre-existing base address
    =Expressions                                                  -   Use exprloc addrx+offset expressions for any address with a prior base address
    =Form                                                         -   Use addrx+offset extension form for any address with a prior base address
    =Disabled                                                     -   Stuff
  --mir-debug-loc                                                 - Print MIR debug-locations
  --mir-strip-debugify-only                                       - Should mir-strip-debug only strip debug info from debugified modules by default
  --mir-vreg-namer-use-stable-hash                                - Use Stable Hashing for MIR VReg Renaming
  --misched=<value>                                               - Machine instruction scheduler to use
    =r600                                                         -   Run R600's custom scheduler
    =gcn-iterative-ilp                                            -   Run GCN iterative scheduler for ILP scheduling (experimental)
    =gcn-iterative-minreg                                         -   Run GCN iterative scheduler for minimal register usage (experimental)
    =gcn-iterative-max-occupancy-experimental                     -   Run GCN scheduler to maximize occupancy (experimental)
    =gcn-max-ilp                                                  -   Run GCN scheduler to maximize ilp
    =gcn-max-occupancy                                            -   Run GCN scheduler to maximize occupancy
    =si                                                           -   Run SI's custom scheduler
    =default                                                      -   Use the target's default scheduler choice.
    =converge                                                     -   Standard converging scheduler.
    =ilpmax                                                       -   Schedule bottom-up for max ILP
    =ilpmin                                                       -   Schedule bottom-up for min ILP
    =shuffle                                                      -   Shuffle machine instructions alternating directions
  --misched-bottomup                                              - Force bottom-up list scheduling
  --misched-cluster                                               - Enable memop clustering.
  --misched-cutoff=<uint>                                         - Stop scheduling after N instructions
  --misched-cyclicpath                                            - Enable cyclic critical path analysis.
  --misched-dcpl                                                  - Print critical path length to stdout
  --misched-fusion                                                - Enable scheduling for macro fusion.
  --misched-limit=<uint>                                          - Limit ready list to N instructions
  --misched-only-block=<uint>                                     - Only schedule this MBB#
  --misched-only-func=<string>                                    - Only schedule this function
  --misched-postra                                                - Run MachineScheduler post regalloc (independent of preRA sched)
  --misched-print-dags                                            - Print schedule DAGs
  --misched-regpressure                                           - Enable register pressure scheduling.
  --misched-topdown                                               - Force top-down list scheduling
  --misexpect-tolerance=<uint>                                    - Prevents emiting diagnostics when profile counts are within N% of the threshold..
  --misfetch-cost=<uint>                                          - Cost that models the probabilistic risk of an instruction misfetch due to a jump comparing to falling through, whose cost is zero.
  --mispredict-default-rate=<uint>                                - Default mispredict rate (initialized to 25%).
  --mlir-debug-counter=<string>                                   - Comma separated list of debug counter skip and count arguments
  --mlir-disable-threading                                        - Disable multi-threading within MLIR, overrides any further call to MLIRContext::enableMultiThreading()
  --mlir-elide-elementsattrs-if-larger=<uint>                     - Elide ElementsAttrs with "..." that have more elements than the given upper limit
  --mlir-pass-pipeline-crash-reproducer=<string>                  - Generate a .mlir reproducer file at the given output path if the pass manager crashes or fails
  --mlir-pass-pipeline-local-reproducer                           - When generating a crash reproducer, attempt to generated a reproducer with the smallest pipeline.
  --mlir-pass-statistics                                          - Display the statistics of each pass
  --mlir-pass-statistics-display=<value>                          - Display method for pass statistics
    =list                                                         -   display the results in a merged list sorted by pass name
    =pipeline                                                     -   display the results with a nested pipeline view
  --mlir-pretty-debuginfo                                         - Print pretty debug info in MLIR output
  --mlir-print-assume-verified                                    - Skip op verification when using custom printers
  --mlir-print-debug-counter                                      - Print out debug counter information after all counters have been accumulated
  --mlir-print-debuginfo                                          - Print debug info in MLIR output
  --mlir-print-elementsattrs-with-hex-if-larger=<long>            - Print DenseElementsAttrs with a hex string that have more elements than the given upper limit (use -1 to disable)
  --mlir-print-ir-after=<pass-arg>                                - Print IR after specified passes
  --mlir-print-ir-after-all                                       - Print IR after each pass
  --mlir-print-ir-after-change                                    - When printing the IR after a pass, only print if the IR changed
  --mlir-print-ir-after-failure                                   - When printing the IR after a pass, only print if the pass failed
  --mlir-print-ir-before=<pass-arg>                               - Print IR before specified passes
  --mlir-print-ir-before-all                                      - Print IR before each pass
  --mlir-print-ir-module-scope                                    - When printing IR for print-ir-[before|after]{-all} always print the top-level operation
  --mlir-print-local-scope                                        - Print with local scope and inline information (eliding aliases for attributes, types, and locations
  --mlir-print-op-generic                                         - Print the generic op form
  --mlir-print-op-on-diagnostic                                   - When a diagnostic is emitted on an operation, also print the operation as an attached note
  --mlir-print-stacktrace-on-diagnostic                           - When a diagnostic is emitted, also print the stack trace as an attached note
  --mlir-print-value-users                                        - Print users of operation results and block arguments as a comment
  --mlir-timing                                                   - Display execution times
  --mlir-timing-display=<value>                                   - Display method for timing data
    =list                                                         -   display the results in a list sorted by total time
    =tree                                                         -   display the results ina with a nested tree view
  --module-summary-dot-file=<filename>                            - File to emit dot graph of new summary into.
  --msan-and-mask=<ulong>                                         - Define custom MSan AndMask
  --msan-check-access-address                                     - report accesses through a pointer which has poisoned shadow
  --msan-check-constant-shadow                                    - Insert checks for constant shadow values
  --msan-disable-checks                                           - Apply no_sanitize to the whole file
  --msan-dump-strict-instructions                                 - print out instructions with default strict semantics
  --msan-eager-checks                                             - check arguments and return values at function call boundaries
  --msan-handle-asm-conservative                                  - conservative handling of inline assembly
  --msan-handle-icmp                                              - propagate shadow through ICmpEQ and ICmpNE
  --msan-handle-icmp-exact                                        - exact handling of relational integer ICmp
  --msan-handle-lifetime-intrinsics                               - when possible, poison scoped variables at the beginning of the scope (slower, but more precise)
  --msan-instrumentation-with-call-threshold=<int>                - If the function being instrumented requires more than this number of checks and origin stores, use callbacks instead of inline checks (-1 means never use callbacks).
  --msan-keep-going                                               - keep going after reporting a UMR
  --msan-kernel                                                   - Enable KernelMemorySanitizer instrumentation
  --msan-origin-base=<ulong>                                      - Define custom MSan OriginBase
  --msan-poison-stack                                             - poison uninitialized stack variables
  --msan-poison-stack-pattern=<int>                               - poison uninitialized stack variables with the given pattern
  --msan-poison-stack-with-call                                   - poison uninitialized stack variables with a call
  --msan-poison-undef                                             - poison undef temps
  --msan-shadow-base=<ulong>                                      - Define custom MSan ShadowBase
  --msan-track-origins=<int>                                      - Track origins (allocation sites) of poisoned memory
  --msan-with-comdat                                              - Place MSan constructors in comdat sections
  --msan-xor-mask=<ulong>                                         - Define custom MSan XorMask
  --no-discriminators                                             - Disable generation of discriminator information.
  --no-dwarf-ranges-section                                       - Disable emission .debug_ranges section.
  --no-pgo-warn-mismatch                                          - Use this option to turn off/on warnings about profile cfg mismatch.
  --no-pgo-warn-mismatch-comdat-weak                              - The option is used to turn on/off warnings about hash mismatch for comdat or weak functions.
  --no-phi-elim-live-out-early-exit                               - Do not use an early exit if isLiveOutPastPHIs returns true.
  --no-stack-coloring                                             - Disable stack coloring
  --no-stack-slot-sharing                                         - Suppress slot sharing during stack coloring
  --no-warn-sample-unused                                         - Use this option to turn off/on warnings about function with samples but without debug information to use those samples. 
  --non-global-value-max-name-size=<uint>                         - Maximum size for the name of non-global values.
  --nvptx-fma-level=<uint>                                        - NVPTX Specific: FMA contraction (0: don't do it 1: do it  2: do it aggressively
  --nvptx-no-f16-math                                             - NVPTX Specific: Disable generation of f16 math ops.
  --nvptx-prec-divf32=<int>                                       - NVPTX Specifies: 0 use div.approx, 1 use div.full, 2 use IEEE Compliant F32 div.rnd if available.
  --nvptx-prec-sqrtf32                                            - NVPTX Specific: 0 use sqrt.approx, 1 use sqrt.rn.
  --nvptx-sched4reg                                               - NVPTX Specific: schedule for register pressue
  --nvptx-short-ptr                                               - Use 32-bit pointers for accessing const/local/shared address spaces.
  --nvvm-intr-range-sm=<uint>                                     - SM variant
  --nvvm-reflect-enable                                           - NVVM reflection, enabled by default
  -o <filename>                                                   - Output filename
  --only-simple-regions                                           - Show only simple regions in the graphviz viewer
  --opaque-pointers                                               - Use opaque pointers
  --openmp-hide-memory-transfer-latency                           - [WIP] Tries to hide the latency of host to device memory transfers
  --openmp-ir-builder-optimistic-attributes                       - Use optimistic attributes describing 'as-if' properties of runtime calls.
  --openmp-ir-builder-unroll-threshold-factor=<number>            - Factor for the unroll threshold to account for code simplifications still taking place
  --openmp-opt-disable                                            - Disable OpenMP specific optimizations.
  --openmp-opt-disable-barrier-elimination                        - Disable OpenMP optimizations that eliminate barriers.
  --openmp-opt-disable-deglobalization                            - Disable OpenMP optimizations involving deglobalization.
  --openmp-opt-disable-folding                                    - Disable OpenMP optimizations involving folding.
  --openmp-opt-disable-internalization                            - Disable function internalization.
  --openmp-opt-disable-spmdization                                - Disable OpenMP optimizations involving SPMD-ization.
  --openmp-opt-disable-state-machine-rewrite                      - Disable OpenMP optimizations that replace the state machine.
  --openmp-opt-enable-merging                                     - Enable the OpenMP region merging optimization.
  --openmp-opt-inline-device                                      - Inline all applicible functions on the device.
  --openmp-opt-max-iterations=<uint>                              - Maximal number of attributor iterations.
  --openmp-opt-print-module-after                                 - Print the current module after OpenMP optimizations.
  --openmp-opt-print-module-before                                - Print the current module before OpenMP optimizations.
  --openmp-opt-shared-limit=<uint>                                - Maximum amount of shared memory to use.
  --openmp-opt-verbose-remarks                                    - Enables more verbose remarks.
  --openmp-print-gpu-kernels                                      - 
  --openmp-print-icv-values                                       - 
  --opt-bisect-limit=<int>                                        - Maximum optimization to perform
  --optimize-regalloc                                             - Enable optimized register allocation compilation path.
  --optsize-jump-table-density=<uint>                             - Minimum density for building a jump table in an optsize function
  --orderfile-write-mapping=<string>                              - Dump functions and their MD5 hash to deobfuscate profile data
  --outline-region-freq-percent=<int>                             - Relative frequency of outline region to the entry block
  --overwrite-existing-weights                                    - Ignore existing branch weights on IR and always overwrite.
  --partial-inlining-extra-penalty=<uint>                         - A debug option to add additional penalty to the computed one.
  --partial-profile                                               - Specify the current profile is used as a partial profile.
  --partial-sample-profile-working-set-size-scale-factor=<number> - The scale factor used to scale the working set size of the partial sample profile along with the partial profile ratio. This includes the factor of the profile counter per block and the factor to scale the working set size to use the same shared thresholds as PGO.
  --partial-unrolling-threshold=<uint>                            - Threshold for partial unrolling
  --pass-remarks=<pattern>                                        - Enable optimization remarks from passes whose name match the given regular expression
  --pass-remarks-analysis=<pattern>                               - Enable optimization analysis remarks from passes whose name match the given regular expression
  --pass-remarks-missed=<pattern>                                 - Enable missed optimization remarks from passes whose name match the given regular expression
  --pgo-emit-branch-prob                                          - When this option is on, the annotated branch probability will be emitted as optimization remarks: -{Rpass|pass-remarks}=pgo-instrumentation
  --pgo-fix-entry-count                                           - Fix function entry count in profile use.
  --pgo-function-entry-coverage                                   - Use this option to enable function entry coverage instrumentation.
  --pgo-instr-memop                                               - Use this option to turn on/off memory intrinsic size profiling.
  --pgo-instr-old-cfg-hashing                                     - Use the old CFG function hashing
  --pgo-instr-select                                              - Use this option to turn on/off SELECT instruction instrumentation. 
  --pgo-instrument-entry                                          - Force to instrument function entry basicblock.
  --pgo-memop-count-threshold=<uint>                              - The minimum count to optimize memory intrinsic calls
  --pgo-memop-max-version=<uint>                                  - The max version for the optimized memory  intrinsic calls
  --pgo-memop-optimize-memcmp-bcmp                                - Size-specialize memcmp and bcmp calls
  --pgo-memop-percent-threshold=<uint>                            - The percentage threshold for the memory intrinsic calls optimization
  --pgo-memop-scale-count                                         - Scale the memop size counts using the basic  block count value
  --pgo-test-profile-file=<filename>                              - Specify the path of profile data file. This ismainly for test purpose.
  --pgo-test-profile-remapping-file=<filename>                    - Specify the path of profile remapping file. This is mainly for test purpose.
  --pgo-trace-func-hash=<function name>                           - Trace the hash of the function with this name.
  --pgo-verify-bfi                                                - Print out mismatched BFI counts after setting profile metadata The print is enabled under -Rpass-analysis=pgo, or internal option -pass-remakrs-analysis=pgo.
  --pgo-verify-bfi-cutoff=<uint>                                  - Set the threshold for pgo-verify-bfi: skip the counts whose profile count value is below.
  --pgo-verify-bfi-ratio=<uint>                                   - Set the threshold for pgo-verify-bfi:  only print out mismatched BFI if the difference percentage is greater than this value (in percentage).
  --pgo-verify-hot-bfi                                            - Print out the non-match BFI count if a hot raw profile count becomes non-hot, or a cold raw profile count becomes hot. The print is enabled under -Rpass-analysis=pgo, or internal option -pass-remakrs-analysis=pgo.
  --pgo-view-counts=<value>                                       - A boolean option to show CFG dag or text with block profile counts and branch probabilities right after PGO profile annotation step. The profile counts are computed using branch probabilities from the runtime profile data and block frequency propagation algorithm. To view the raw counts from the profile, use option -pgo-view-raw-counts instead. To limit graph display to only one function, use filtering option -view-bfi-func-name.
    =none                                                         -   do not show.
    =graph                                                        -   show a graph.
    =text                                                         -   show in text.
  --pgo-view-raw-counts=<value>                                   - A boolean option to show CFG dag or text with raw profile counts from profile data. See also option -pgo-view-counts. To limit graph display to only one function, use filtering option -view-bfi-func-name.
    =none                                                         -   do not show.
    =graph                                                        -   show a graph.
    =text                                                         -   show in text.
  --pgo-warn-misexpect                                            - Use this option to turn on/off warnings about incorrect usage of llvm.expect intrinsics.
  --pgo-warn-missing-function                                     - Use this option to turn on/off warnings about missing profile data for functions.
  --pgso                                                          - Enable the profile guided size optimizations. 
  --pgso-cold-code-only                                           - Apply the profile guided size optimizations only to cold code.
  --pgso-cold-code-only-for-instr-pgo                             - Apply the profile guided size optimizations only to cold code under instrumentation PGO.
  --pgso-cold-code-only-for-partial-sample-pgo                    - Apply the profile guided size optimizations only to cold code under partial-profile sample PGO.
  --pgso-cold-code-only-for-sample-pgo                            - Apply the profile guided size optimizations only to cold code under sample PGO.
  --pgso-cutoff-instr-prof=<int>                                  - The profile guided size optimization profile summary cutoff for instrumentation profile.
  --pgso-cutoff-sample-prof=<int>                                 - The profile guided size optimization profile summary cutoff for sample profile.
  --pgso-lwss-only                                                - Apply the profile guided size optimizations only if the working set size is large (except for cold code.)
  --phi-elim-split-all-critical-edges                             - Split all critical edges during PHI elimination
  --phi-node-folding-threshold=<uint>                             - Control the amount of phi node folding to perform (default = 2)
  --phicse-debug-hash                                             - Perform extra assertion checking to verify that PHINodes's hash function is well-behaved w.r.t. its isEqual predicate
  --phicse-num-phi-smallsize=<uint>                               - When the basic block contains not more than this number of PHI nodes, perform a (faster!) exhaustive search instead of set-driven one.
  --pi-force-live-exit-outline                                    - Force outline regions with live exits
  --pi-mark-coldcc                                                - Mark outline function calls with ColdCC
  --pipeliner-annotate-for-testing                                - Instead of emitting the pipelined code, annotate instructions with the generated schedule for feeding into the -modulo-schedule-test pass
  --pipeliner-dbg-res                                             - 
  --pipeliner-experimental-cg                                     - Use the experimental peeling code generator for software pipelining
  --pipeliner-max=<int>                                           - 
  --pipeliner-max-mii=<int>                                       - Size limit for the MII.
  --pipeliner-max-stages=<int>                                    - Maximum stages allowed in the generated scheduled.
  --pipeliner-prune-deps                                          - Prune dependences between unrelated Phi nodes.
  --pipeliner-prune-loop-carried                                  - Prune loop carried order dependences.
  --pipeliner-show-mask                                           - 
  --poison-checking-function-local                                - Check that returns are non-poison (for testing)
  --post-RA-scheduler                                             - Enable scheduling after register allocation
  --postra-sched-debugdiv=<int>                                   - Debug control MBBs that are scheduled
  --postra-sched-debugmod=<int>                                   - Debug control MBBs that are scheduled
  --pragma-unroll-and-jam-threshold=<uint>                        - Unrolled size limit for loops with an unroll_and_jam(full) or unroll_count pragma.
  --pragma-unroll-threshold=<uint>                                - Unrolled size limit for loops with an unroll(full) or unroll_count pragma.
  --pragma-vectorize-scev-check-threshold=<uint>                  - The maximum number of SCEV checks allowed with a vectorize(enable) pragma
  --pre-RA-sched=<value>                                          - Instruction schedulers available (before register allocation):
    =default                                                      -   Best scheduler for the target
    =list-burr                                                    -   Bottom-up register reduction list scheduling
    =source                                                       -   Similar to list-burr but schedules in source order when possible
    =list-hybrid                                                  -   Bottom-up register pressure aware list scheduling which tries to balance latency and register pressure
    =list-ilp                                                     -   Bottom-up register pressure aware list scheduling which tries to balance ILP and register pressure
    =fast                                                         -   Fast suboptimal list scheduling
    =linearize                                                    -   Linearize DAG, no scheduling
    =vliw-td                                                      -   VLIW scheduler
  --precise-rotation-cost                                         - Model the cost of loop rotation more precisely by using profile data.
  --precompute-phys-liveness                                      - Eagerly compute live intervals for all physreg units.
  --prefer-inloop-reductions                                      - Prefer in-loop vector reductions, overriding the targets preference.
  --prefer-predicate-over-epilogue=<value>                        - Tail-folding and predication preferences over creating a scalar epilogue loop.
    =scalar-epilogue                                              -   Don't tail-predicate loops, create scalar epilogue
    =predicate-else-scalar-epilogue                               -   prefer tail-folding, create scalar epilogue if tail folding fails.
    =predicate-dont-vectorize                                     -   prefers tail-folding, don't attempt vectorization if tail-folding fails.
  --prefer-predicated-reduction-select                            - Prefer predicating a reduction operation over an after loop select.
  --prefetch-distance=<uint>                                      - Number of instructions to prefetch ahead
  --preinline-threshold=<int>                                     - Control the amount of inlining in pre-instrumentation inliner (default = 75)
  --preserve-alignment-assumptions-during-inlining                - Convert align attributes to assumptions during inlining.
  --print-after=<string>                                          - Print IR after specified passes
  --print-after-all                                               - Print IR after each pass
  --print-after-isel                                              - Print machine instrs after ISel
  --print-before=<string>                                         - Print IR before specified passes
  --print-before-all                                              - Print IR before each pass
  --print-bfi                                                     - Print the block frequency info.
  --print-bfi-func-name=<string>                                  - The option to specify the name of the function whose block frequency info is printed.
  --print-bpi                                                     - Print the branch probability info.
  --print-bpi-func-name=<string>                                  - The option to specify the name of the function whose branch probability info is printed.
  --print-changed                                                 - Print changed IRs
  --print-changed=<value>                                         - Print changed IRs
    =quiet                                                        -   Run in quiet mode
    =diff                                                         -   Display patch-like changes
    =diff-quiet                                                   -   Display patch-like changes in quiet mode
    =cdiff                                                        -   Display patch-like changes with color
    =cdiff-quiet                                                  -   Display patch-like changes in quiet mode with color
    =dot-cfg                                                      -   Create a website with graphical changes
    =dot-cfg-quiet                                                -   Create a website with graphical changes in quiet mode
  --print-changed-diff-path=<string>                              - system diff used by change reporters
  --print-debug-counter                                           - Print out debug counter info after all counters accumulated
  --print-gc                                                      - Dump garbage collector data
  --print-import-failures                                         - Print information for functions rejected for importing
  --print-imports                                                 - Print imported functions
  --print-instruction-comments                                    - Prints comments for instruction based on inline cost analysis
  --print-isel-input                                              - Print LLVM IR input to isel pass
  --print-lsr-output                                              - Print LLVM IR produced by the loop-reduce pass
  --print-lvi-after-jump-threading                                - Print the LazyValueInfo cache after JumpThreading
  --print-machine-bfi                                             - Print the machine block frequency info.
  --print-module-scope                                            - When printing IR for print-[before|after]{-all} always print a module IR
  --print-pipeline-passes                                         - Print a '-passes' compatible string describing the pipeline (best-effort only).
  --print-region-style=<value>                                    - style of printing regions
    =none                                                         -   print no details
    =bb                                                           -   print regions in detail with block_iterator
    =rn                                                           -   print regions in detail with element_iterator
  --print-regmask-num-regs=<int>                                  - Number of registers to limit to when printing regmask operands in IR dumps. unlimited = -1
  --print-regusage                                                - print register usage details collected for analysis.
  --print-slotindexes                                             - When printing machine IR, annotate instructions and blocks with SlotIndexes when available
  --print-summary-global-ids                                      - Print the global id for each value when reading the module summary
  --profile-accurate-for-symsinlist                               - For symbols in profile symbol list, regard their profiles to be accurate. It may be overriden by profile-sample-accurate. 
  --profile-guided-section-prefix                                 - Use profile info to add section prefix for hot/cold functions
  --profile-isfs                                                  - Profile uses flow sensitive discriminators
  --profile-likely-prob=<uint>                                    - branch probability threshold in percentage to be considered very likely when profile is available
  --profile-sample-accurate                                       - If the sample profile is accurate, we will mark all un-sampled callsite and function as having 0 samples. Otherwise, treat un-sampled callsites and functions conservatively as unknown. 
  --profile-sample-block-accurate                                 - If the sample profile is accurate, we will mark all un-sampled branches and calls as having 0 samples. Otherwise, treat them conservatively as unknown. 
  --profile-summary-contextless                                   - Merge context profiles before calculating thresholds.
  --profile-summary-cutoff-cold=<int>                             - A count is cold if it is below the minimum count to reach this percentile of total counts.
  --profile-summary-cutoff-hot=<int>                              - A count is hot if it exceeds the minimum count to reach this percentile of total counts.
  --profile-summary-huge-working-set-size-threshold=<uint>        - The code working set size is considered huge if the number of blocks required to reach the -profile-summary-cutoff-hot percentile exceeds this count.
  --profile-summary-large-working-set-size-threshold=<uint>       - The code working set size is considered large if the number of blocks required to reach the -profile-summary-cutoff-hot percentile exceeds this count.
  --profile-symbol-list-cutoff=<ulong>                            - Cutoff value about how many symbols in profile symbol list will be used. This is very useful for performance debugging
  --profile-unknown-in-special-section                            - In profiling mode like sampleFDO, if a function doesn't have profile, we cannot tell the function is cold for sure because it may be a function newly added without ever being sampled. With the flag enabled, compiler can put such profile unknown functions into a special section, so runtime system can choose to handle it in a different way than .text section, to save RAM for example. 
  --propagate-attrs                                               - Propagate attributes in index
  --protect-from-escaped-allocas                                  - Do not optimize lifetime zones that are broken
  --r600-ir-structurize                                           - Use StructurizeCFG IR pass
  --rafast-ignore-missing-defs                                    - 
  --reassociate-geps-verify-no-dead-code                          - Verify this pass produces no dead code
  --recurrence-chain-limit=<uint>                                 - Maximum length of recurrence chain when evaluating the benefit of commuting operands
  --recursive-inline-max-stacksize=<ulong>                        - Do not inline recursive functions with a stack size that exceeds the specified limit
  --regalloc=<value>                                              - Register allocator to use
    =default                                                      -   pick register allocator based on -O option
    =fast                                                         -   fast register allocator
    =basic                                                        -   basic register allocator
    =greedy                                                       -   greedy register allocator
  --regalloc-csr-first-time-cost=<uint>                           - Cost for first time use of callee-saved register.
  --regalloc-enable-advisor=<value>                               - Enable regalloc advisor mode
    =default                                                      -   Default
    =release                                                      -   precompiled
    =development                                                  -   for training
  --regalloc-eviction-max-interference-cutoff=<uint>              - Number of interferences after which we declare an interference unevictable and bail out. This is a compilation cost-saving consideration. To disable, pass a very large number.
  Mode of the RegBankSelect pass
      --regbankselect-fast                                           - Run the Fast mode (default mapping)
      --regbankselect-greedy                                         - Use the Greedy mode (best local mapping)
  --remarks-section                                               - Emit a section containing remark diagnostics metadata. By default, this is enabled for the following formats: yaml-strtab, bitstream.
  --rename-exclude-alias-prefixes=<string>                        - Prefixes for aliases that don't need to be renamed, separated by a comma
  --rename-exclude-function-prefixes=<string>                     - Prefixes for functions that don't need to be renamed, separated by a comma
  --rename-exclude-global-prefixes=<string>                       - Prefixes for global values that don't need to be renamed, separated by a comma
  --rename-exclude-struct-prefixes=<string>                       - Prefixes for structs that don't need to be renamed, separated by a comma
  --replexitval=<value>                                           - Choose the strategy to replace exit value in IndVarSimplify
    =never                                                        -   never replace exit value
    =cheap                                                        -   only replace exit value when the cost is cheap
    =unusedindvarinloop                                           -   only replace exit value when it is an unused induction variable in the loop and has cheap replacement cost
    =noharduse                                                    -   only replace exit values when loop def likely dead
    =always                                                       -   always replace exit value whenever possible
  --reroll-loops                                                  - Run the loop rerolling pass
  --reroll-num-tolerated-failed-matches=<uint>                    - The maximum number of failures to tolerate during fuzzy matching. (default: 400)
  --restrict-statepoint-remat                                     - Restrict remat for statepoint operands
  --rewrite-map-file=<filename>                                   - Symbol Rewrite Map
  --rewrite-phi-limit=<uint>                                      - Limit the length of PHI chains to lookup
  --rng-seed=<seed>                                               - Seed for the random number generator
  --rotation-max-header-size=<uint>                               - The default maximum header size for automatic loop rotation
  --rotation-prepare-for-lto                                      - Run loop-rotation in the prepare-for-lto stage. This option should be used for testing only.
  --rs4gc-allow-statepoint-with-no-deopt-info                     - 
  --rs4gc-clobber-non-live                                        - 
  --runtime-check-per-loop-load-elim=<uint>                       - Max number of memchecks allowed per eliminated load on average
  --runtime-counter-relocation                                    - Enable relocating counters at runtime.
  --runtime-memory-check-threshold=<uint>                         - When performing memory disambiguation checks at runtime do not generate more than this number of comparisons (default = 8).
  --safe-stack-coloring                                           - enable safe stack coloring
  --safe-stack-layout                                             - enable safe stack layout
  --safepoint-ir-verifier-print-only                              - 
  --safestack-use-pointer-address                                 - 
  --sample-profile-check-record-coverage=<N>                      - Emit a warning if less than N% of records in the input profile are matched to the IR.
  --sample-profile-check-sample-coverage=<N>                      - Emit a warning if less than N% of samples in the input profile are matched to the IR.
  --sample-profile-cold-inline-threshold=<int>                    - Threshold for inlining cold callsites
  --sample-profile-even-count-distribution                        - Try to evenly distribute counts when there are multiple equally likely options.
  --sample-profile-file=<filename>                                - Profile file loaded by -sample-profile
  --sample-profile-hot-inline-threshold=<int>                     - Hot callsite threshold for proirity-based sample profile loader inlining.
  --sample-profile-icp-max-prom=<uint>                            - Max number of promotions for a single indirect call callsite in sample profile loader
  --sample-profile-icp-relative-hotness=<uint>                    - Relative hotness percentage threshold for indirect call promotion in proirity-based sample profile loader inlining.
  --sample-profile-icp-relative-hotness-skip=<uint>               - Skip relative hotness check for ICP up to given number of targets.
  --sample-profile-infer-entry-count                              - Use profi to infer function entry count.
  --sample-profile-inline-growth-limit=<int>                      - The size growth ratio limit for proirity-based sample profile loader inlining.
  --sample-profile-inline-limit-max=<int>                         - The upper bound of size growth limit for proirity-based sample profile loader inlining.
  --sample-profile-inline-limit-min=<int>                         - The lower bound of size growth limit for proirity-based sample profile loader inlining.
  --sample-profile-inline-replay=<filename>                       - Optimization remarks file containing inline remarks to be replayed by inlining from sample profile loader.
  --sample-profile-inline-replay-fallback=<value>                 - How sample profile inline replay treats sites that don't come from the replay. Original: defers to original advisor, AlwaysInline: inline all sites not in replay, NeverInline: inline no sites not in replay
    =Original                                                     -   All decisions not in replay send to original advisor (default)
    =AlwaysInline                                                 -   All decisions not in replay are inlined
    =NeverInline                                                  -   All decisions not in replay are not inlined
  --sample-profile-inline-replay-format=<value>                   - How sample profile inline replay file is formatted
    =Line                                                         -   <Line Number>
    =LineColumn                                                   -   <Line Number>:<Column Number>
    =LineDiscriminator                                            -   <Line Number>.<Discriminator>
    =LineColumnDiscriminator                                      -   <Line Number>:<Column Number>.<Discriminator> (default)
  --sample-profile-inline-replay-scope=<value>                    - Whether inline replay should be applied to the entire Module or just the Functions (default) that are present as callers in remarks during sample profile inlining.
    =Function                                                     -   Replay on functions that have remarks associated with them (default)
    =Module                                                       -   Replay on the entire module
  --sample-profile-inline-size                                    - Inline cold call sites in profile loader if it's beneficial for code size.
  --sample-profile-max-dfs-calls=<uint>                           - Maximum number of dfs iterations for even count distribution.
  --sample-profile-max-propagate-iterations=<uint>                - Maximum number of iterations to go through when propagating sample block/edge weights through the CFG.
  --sample-profile-merge-inlinee                                  - Merge past inlinee's profile to outline version if sample profile loader decided not to inline a call site. It will only be enabled when top-down order of profile loading is enabled. 
  --sample-profile-prioritized-inline                             - Use call site prioritized inlining for sample profile loader.Currently only CSSPGO is supported.
  --sample-profile-profi-cost-dec=<uint>                          - A cost of decreasing a block's count by one.
  --sample-profile-profi-cost-dec-entry=<uint>                    - A cost of decreasing the entry block's count by one.
  --sample-profile-profi-cost-inc=<uint>                          - A cost of increasing a block's count by one.
  --sample-profile-profi-cost-inc-entry=<uint>                    - A cost of increasing the entry block's count by one.
  --sample-profile-profi-cost-inc-zero=<uint>                     - A cost of increasing a count of zero-weight block by one.
  --sample-profile-recursive-inline                               - Allow sample loader inliner to inline recursive calls.
  --sample-profile-remapping-file=<filename>                      - Profile remapping file loaded by -sample-profile
  --sample-profile-top-down-load                                  - Do profile annotation and inlining for functions in top-down order of call graph during sample profile loading. It only works for new pass manager. 
  --sample-profile-use-preinliner                                 - Use the preinliner decisions stored in profile context.
  --sample-profile-use-profi                                      - Use profi to infer block and edge counts.
  --sanitizer-coverage-inline-8bit-counters                       - increments 8-bit counter for every edge
  --sanitizer-coverage-inline-bool-flag                           - sets a boolean flag for every edge
  --sanitizer-coverage-level=<int>                                - Sanitizer Coverage. 0: none, 1: entry block, 2: all blocks, 3: all blocks and critical edges
  --sanitizer-coverage-pc-table                                   - create a static PC table
  --sanitizer-coverage-prune-blocks                               - Reduce the number of instrumented blocks
  --sanitizer-coverage-stack-depth                                - max stack depth tracing
  --sanitizer-coverage-trace-compares                             - Tracing of CMP and similar instructions
  --sanitizer-coverage-trace-divs                                 - Tracing of DIV instructions
  --sanitizer-coverage-trace-geps                                 - Tracing of GEP instructions
  --sanitizer-coverage-trace-loads                                - Tracing of load instructions
  --sanitizer-coverage-trace-pc                                   - Experimental pc tracing
  --sanitizer-coverage-trace-pc-guard                             - pc tracing with a guard
  --sanitizer-coverage-trace-stores                               - Tracing of store instructions
  --scalable-vectorization=<value>                                - Control whether the compiler can use scalable vectors to vectorize a loop
    =off                                                          -   Scalable vectorization is disabled.
    =preferred                                                    -   Scalable vectorization is available and favored when the cost is inconclusive.
    =on                                                           -   Scalable vectorization is available and favored when the cost is inconclusive.
  --scalar-evolution-classify-expressions                         - When printing analysis, include information on every instruction
  --scalar-evolution-finite-loop                                  - Handle <= and >= in finite loops
  --scalar-evolution-huge-expr-threshold=<uint>                   - Size of the expression which is considered huge
  --scalar-evolution-max-add-rec-size=<uint>                      - Max coefficients in AddRec during evolving
  --scalar-evolution-max-arith-depth=<uint>                       - Maximum depth of recursive arithmetics
  --scalar-evolution-max-cast-depth=<uint>                        - Maximum depth of recursive SExt/ZExt/Trunc
  --scalar-evolution-max-constant-evolving-depth=<uint>           - Maximum depth of recursive constant evolving
  --scalar-evolution-max-scc-analysis-depth=<uint>                - Maximum amount of nodes to process while searching SCEVUnknown Phi strongly connected components
  --scalar-evolution-max-scev-compare-depth=<uint>                - Maximum depth of recursive SCEV complexity comparisons
  --scalar-evolution-max-scev-operations-implication-depth=<uint> - Maximum depth of recursive SCEV operations implication analysis
  --scalar-evolution-max-value-compare-depth=<uint>               - Maximum depth of recursive value complexity comparisons
  --scalar-evolution-use-context-for-no-wrap-flag-strenghening    - Infer nuw/nsw flags using context where suitable
  --scalar-evolution-use-expensive-range-sharpening               - Use more powerful methods of sharpening expression ranges. May be costly in terms of compile time
  --scalarize-load-store                                          - Allow the scalarizer pass to scalarize loads and store
  --scalarize-variable-insert-extract                             - Allow the scalarizer pass to scalarize insertelement/extractelement with variable index
  --scale-partial-sample-profile-working-set-size                 - If true, scale the working set size of the partial sample profile by the partial profile ratio to reflect the size of the program being compiled.
  --scev-addops-inline-threshold=<uint>                           - Threshold for inlining addition operands into a SCEV
  --scev-cheap-expansion-budget=<uint>                            - When performing SCEV expansion only if it is cheap to do, this controls the budget that is considered cheap (default = 4)
  --scev-mulops-inline-threshold=<uint>                           - Threshold for inlining multiplication operands into a SCEV
  --scev-verify-ir                                                - Verify IR correctness when making sensitive SCEV queries (slow)
  --sched-avg-ipc=<uint>                                          - Average inst/cycle whan no target itinerary exists.
  --sched-high-latency-cycles=<int>                               - Roughly estimate the number of cycles that 'long latency'instructions take for targets with no itinerary
  --scheditins                                                    - Use InstrItineraryData for latency lookup
  --schedmodel                                                    - Use TargetSchedModel for latency lookup
  --select-opti-loop-cycle-gain-threshold=<uint>                  - Minimum gain per loop (in cycles) threshold.
  --select-opti-loop-gradient-gain-threshold=<uint>               - Gradient gain threshold (%).
  --select-opti-loop-relative-gain-threshold=<uint>               - Minimum relative gain per loop threshold (1/X). Defaults to 12.5%
  --sgpr-regalloc=<value>                                         - Register allocator to use for SGPRs
    =default                                                      -   pick SGPR register allocator based on -O option
    =basic                                                        -   basic register allocator
    =greedy                                                       -   greedy register allocator
    =fast                                                         -   fast register allocator
  Compiler passes to run
    --pass-pipeline                                               -   A textual description of a pass pipeline to run
    Passes:
      --affine-data-copy-generate                                 -   Generate explicit copying for affine memory operations
        --fast-mem-capacity=<ulong>                               - Set fast memory space capacity in KiB (default: unlimited)
        --fast-mem-space=<uint>                                   - Fast memory space identifier for copy generation (default: 1)
        --generate-dma                                            - Generate DMA instead of point-wise copy
        --min-dma-transfer=<int>                                  - Minimum DMA transfer size supported by the target in bytes
        --skip-non-unit-stride-loops                              - Testing purposes: avoid non-unit stride loop choice depths for copy placement
        --slow-mem-space=<uint>                                   - Slow memory space identifier for copy generation (default: 0)
        --tag-mem-space=<uint>                                    - Tag memory space identifier for copy generation (default: 0)
      --affine-loop-coalescing                                    -   Coalesce nested loops with independent bounds into a single loop
      --affine-loop-fusion                                        -   Fuse affine loop nests
        --fusion-compute-tolerance=<number>                       - Fractional increase in additional computation tolerated while fusing
        --fusion-fast-mem-space=<uint>                            - Faster memory space number to promote fusion buffers to
        --fusion-local-buf-threshold=<ulong>                      - Threshold size (KiB) for promoting local buffers to fast memory space
        --fusion-maximal                                          - Enables maximal loop fusion
        --mode=<value>                                            - fusion mode to attempt
    =greedy                                                 -   Perform greedy (both producer-consumer and sibling)  fusion
    =producer                                               -   Perform only producer-consumer fusion
    =sibling                                                -   Perform only sibling fusion
      --affine-loop-invariant-code-motion                         -   Hoist loop invariant instructions outside of affine loops
      --affine-loop-normalize                                     -   Apply normalization transformations to affine loop-like ops
      --affine-loop-tile                                          -   Tile affine loop nests
        --cache-size=<ulong>                                      - Set size of cache to tile for in KiB (default: 512)
        --separate                                                - Separate full and partial tiles (default: false)
        --tile-size=<uint>                                        - Use this tile size for all loops
        --tile-sizes=<uint>                                       - List of tile sizes for each perfect nest (overridden by -tile-size)
      --affine-loop-unroll                                        -   Unroll affine loops
        --unroll-factor=<uint>                                    - Use this unroll factor for all loops being unrolled
        --unroll-full                                             - Fully unroll loops
        --unroll-full-threshold=<uint>                            - Unroll all loops with trip count less than or equal to this
        --unroll-num-reps=<uint>                                  - Unroll innermost loops repeatedly this many times
        --unroll-up-to-factor                                     - Allow unrolling up to the factor specified
      --affine-loop-unroll-jam                                    -   Unroll and jam affine loops
        --unroll-jam-factor=<uint>                                - Use this unroll jam factor for all loops (default 4)
      --affine-parallelize                                        -   Convert affine.for ops into 1-D affine.parallel
        --max-nested=<uint>                                       - Maximum number of nested parallel loops to produce. Defaults to unlimited (UINT_MAX).
        --parallel-reductions                                     - Whether to parallelize reduction loops. Defaults to false.
      --affine-pipeline-data-transfer                             -   Pipeline non-blocking data transfers between explicitly managed levels of the memory hierarchy
      --affine-scalrep                                            -   Replace affine memref acceses by scalars by forwarding stores to loads and eliminating redundant loads
      --affine-simplify-structures                                -   Simplify affine expressions in maps/sets and normalize memrefs
      --affine-super-vectorize                                    -   Vectorize to a target independent n-D vector abstraction
        --test-fastest-varying=<long>                             - Specify a 1-D, 2-D or 3-D pattern of fastest varying memory dimensions to match. See defaultPatterns in Vectorize.cpp for a description and examples. This is used for testing purposes
        --vectorize-reductions                                    - Vectorize known reductions expressed via iter_args. Switched off by default.
        --virtual-vector-size=<long>                              - Specify an n-D virtual vector size for vectorization
      --affine-super-vectorizer-test                              -   Tests vectorizer standalone functionality.
      --arith-bufferize                                           -   Bufferize Arithmetic dialect ops.
        --alignment=<uint>                                        - Create global memrefs with a specified alignment
      --arith-expand                                              -   Legalize Arithmetic ops to be convertible to LLVM.
      --arith-unsigned-when-equivalent                            -   Replace signed ops with unsigned ones where they are proven equivalent
      --arm-neon-2d-to-intr                                       -   Convert Arm NEON structured ops to intrinsics
      --async-parallel-for                                        -   Convert scf.parallel operations to multiple async compute ops executed concurrently for non-overlapping iteration ranges
        --async-dispatch                                          - Dispatch async compute tasks using recursive work splitting. If 'false' async compute tasks will be launched using simple for loop in the caller thread.
        --min-task-size=<int>                                     - The minimum task size for sharding parallel operation.
        --num-workers=<int>                                       - The number of available workers to execute async operations. If '-1' the value will be retrieved from the runtime.
      --async-runtime-policy-based-ref-counting                   -   Policy based reference counting for Async runtime operations
      --async-runtime-ref-counting                                -   Automatic reference counting for Async runtime operations
      --async-runtime-ref-counting-opt                            -   Optimize automatic reference counting operations for theAsync runtime by removing redundant operations
      --async-to-async-runtime                                    -   Lower high level async operations (e.g. async.execute) to theexplicit async.runtime and async.coro operations
        --eliminate-blocking-await-ops                            - Rewrite functions with blocking async.runtime.await as coroutines with async.runtime.await_and_resume.
      --buffer-deallocation                                       -   Adds all required dealloc operations for all allocations in the input program
      --buffer-hoisting                                           -   Optimizes placement of allocation operations by moving them into common dominators and out of nested regions
      --buffer-loop-hoisting                                      -   Optimizes placement of allocation operations by moving them out of loop nests
      --buffer-results-to-out-params                              -   Converts memref-typed function results to out-params
      --bufferization-bufferize                                   -   Bufferize the 'bufferization' dialect
      --canonicalize                                              -   Canonicalize operations
        --disable-patterns=<string>                               - Labels of patterns that should be filtered out during application
        --enable-patterns=<string>                                - Labels of patterns that should be used during application, all other patterns are filtered out
        --max-iterations=<long>                                   - Seed the worklist in general top-down order
        --region-simplify                                         - Seed the worklist in general top-down order
        --top-down                                                - Seed the worklist in general top-down order
      --control-flow-sink                                         -   Sink operations into conditional blocks
      --convert-affine-for-to-gpu                                 -   Convert top-level AffineFor Ops to GPU kernels
        --gpu-block-dims=<uint>                                   - Number of GPU block dimensions for mapping
        --gpu-thread-dims=<uint>                                  - Number of GPU thread dimensions for mapping
      --convert-amdgpu-to-rocdl                                   -   Convert AMDGPU dialect to ROCDL dialect
        --chipset=<string>                                        - Chipset that these operations will run on
      --convert-arith-to-llvm                                     -   Convert Arithmetic dialect to LLVM dialect
        --index-bitwidth=<uint>                                   - Bitwidth of the index type, 0 to use size of machine word
      --convert-arith-to-spirv                                    -   Convert Arithmetic dialect to SPIR-V dialect
        --emulate-non-32-bit-scalar-types                         - Emulate non-32-bit scalar types with 32-bit ones if missing native support
      --convert-async-to-llvm                                     -   Convert the operations from the async dialect into the LLVM dialect
      --convert-bufferization-to-memref                           -   Convert operations from the Bufferization dialect to the MemRef dialect
      --convert-cf-to-llvm                                        -   Convert ControlFlow operations to the LLVM dialect
        --index-bitwidth=<uint>                                   - Bitwidth of the index type, 0 to use size of machine word
      --convert-cf-to-spirv                                       -   Convert ControlFlow dialect to SPIR-V dialect
        --emulate-non-32-bit-scalar-types                         - Emulate non-32-bit scalar types with 32-bit ones if missing native support
      --convert-complex-to-libm                                   -   Convert Complex dialect to libm calls
      --convert-complex-to-llvm                                   -   Convert Complex dialect to LLVM dialect
      --convert-complex-to-standard                               -   Convert Complex dialect to standard dialect
      --convert-elementwise-to-linalg                             -   Convert ElementwiseMappable ops to linalg
      --convert-func-to-llvm                                      -   Convert from the Func dialect to the LLVM dialect
        --data-layout=<string>                                    - String description (LLVM format) of the data layout that is expected on the produced module
        --index-bitwidth=<uint>                                   - Bitwidth of the index type, 0 to use size of machine word
        --use-bare-ptr-memref-call-conv                           - Replace FuncOp's MemRef arguments with bare pointers to the MemRef element types
      --convert-func-to-spirv                                     -   Convert Func dialect to SPIR-V dialect
        --emulate-non-32-bit-scalar-types                         - Emulate non-32-bit scalar types with 32-bit ones if missing native support
      --convert-gpu-launch-to-vulkan-launch                       -   Convert gpu.launch_func to vulkanLaunch external call
      --convert-gpu-to-nvvm                                       -   Generate NVVM operations for gpu operations
        --index-bitwidth=<uint>                                   - Bitwidth of the index type, 0 to use size of machine word
      --convert-gpu-to-rocdl                                      -   Generate ROCDL operations for gpu operations
        --chipset=<string>                                        - Chipset that these operations will run on
        --index-bitwidth=<uint>                                   - Bitwidth of the index type, 0 to use size of machine word
        --runtime=<value>                                         - Runtime code will be run on (default is Unknown, can also use HIP or OpenCl)
    =unknown                                                -   Unknown (default)
    =HIP                                                    -   HIP
    =OpenCL                                                 -   OpenCL
        --use-bare-ptr-memref-call-conv                           - Replace memref arguments in GPU functions with bare pointers.All memrefs must have static shape
      --convert-gpu-to-spirv                                      -   Convert GPU dialect to SPIR-V dialect
      --convert-linalg-to-affine-loops                            -   Lower the operations from the linalg dialect into affine loops
      --convert-linalg-to-llvm                                    -   Convert the operations from the linalg dialect into the LLVM dialect
      --convert-linalg-to-loops                                   -   Lower the operations from the linalg dialect into loops
      --convert-linalg-to-parallel-loops                          -   Lower the operations from the linalg dialect into parallel loops
      --convert-linalg-to-spirv                                   -   Convert Linalg dialect to SPIR-V dialect
      --convert-linalg-to-std                                     -   Convert the operations from the linalg dialect into the Standard dialect
      --convert-math-to-libm                                      -   Convert Math dialect to libm calls
      --convert-math-to-llvm                                      -   Convert Math dialect to LLVM dialect
      --convert-math-to-spirv                                     -   Convert Math dialect to SPIR-V dialect
      --convert-memref-to-llvm                                    -   Convert operations from the MemRef dialect to the LLVM dialect
        --index-bitwidth=<uint>                                   - Bitwidth of the index type, 0 to use size of machine word
        --use-aligned-alloc                                       - Use aligned_alloc in place of malloc for heap allocations
        --use-generic-functions                                   - Use generic allocation and deallocation functions instead of the classic 'malloc', 'aligned_alloc' and 'free' functions
      --convert-memref-to-spirv                                   -   Convert MemRef dialect to SPIR-V dialect
        --bool-num-bits=<int>                                     - The number of bits to store a boolean value
      --convert-nvgpu-to-nvvm                                     -   Convert NVGPU dialect to NVVM dialect
      --convert-openacc-to-llvm                                   -   Convert the OpenACC ops to LLVM dialect
      --convert-openacc-to-scf                                    -   Convert the OpenACC ops to OpenACC with SCF dialect
      --convert-openmp-to-llvm                                    -   Convert the OpenMP ops to OpenMP ops with LLVM dialect
      --convert-parallel-loops-to-gpu                             -   Convert mapped scf.parallel ops to gpu launch operations
      --convert-pdl-to-pdl-interp                                 -   Convert PDL ops to PDL interpreter ops
      --convert-scf-to-cf                                         -   Convert SCF dialect to ControlFlow dialect, replacing structured control flow with a CFG
      --convert-scf-to-openmp                                     -   Convert SCF parallel loop to OpenMP parallel + workshare constructs.
      --convert-scf-to-spirv                                      -   Convert SCF dialect to SPIR-V dialect.
      --convert-shape-constraints                                 -   Convert shape constraint operations to the standard dialect
      --convert-shape-to-std                                      -   Convert operations from the shape dialect into the standard dialect
      --convert-spirv-to-llvm                                     -   Convert SPIR-V dialect to LLVM dialect
      --convert-tensor-to-linalg                                  -   Convert some Tensor dialect ops to Linalg dialect
      --convert-tensor-to-spirv                                   -   Convert Tensor dialect to SPIR-V dialect
        --emulate-non-32-bit-scalar-types                         - Emulate non-32-bit scalar types with 32-bit ones if missing native support
      --convert-vector-to-gpu                                     -   Lower the operations from the vector dialect into the GPU dialect
        --use-nvgpu                                               - convert to NvGPU ops instead of GPU dialect ops
      --convert-vector-to-llvm                                    -   Lower the operations from the vector dialect into the LLVM dialect
        --enable-amx                                              - Enables the use of AMX dialect while lowering the vector dialect.
        --enable-arm-neon                                         - Enables the use of ArmNeon dialect while lowering the vector dialect.
        --enable-arm-sve                                          - Enables the use of ArmSVE dialect while lowering the vector dialect.
        --enable-x86vector                                        - Enables the use of X86Vector dialect while lowering the vector dialect.
        --force-32bit-vector-indices                              - Allows compiler to assume vector indices fit in 32-bit if that yields faster code
        --reassociate-fp-reductions                               - Allows llvm to reassociate floating-point reductions for speed
      --convert-vector-to-scf                                     -   Lower the operations from the vector dialect into the SCF dialect
        --full-unroll                                             - Perform full unrolling when converting vector transfers to SCF
        --lower-permutation-maps                                  - Replace permutation maps with vector transposes/broadcasts before lowering transfer ops
        --lower-tensors                                           - Lower transfer ops that operate on tensors
        --target-rank=<uint>                                      - Target vector rank to which transfer ops should be lowered
      --convert-vector-to-spirv                                   -   Convert Vector dialect to SPIR-V dialect
      --cse                                                       -   Eliminate common sub-expressions
      --decorate-spirv-composite-type-layout                      -   Decorate SPIR-V composite type with layout info
      --drop-equivalent-buffer-results                            -   Remove MemRef return values that are equivalent to a bbArg
      --eliminate-alloc-tensors                                   -   Try to eliminate all alloc_tensor ops.
      --finalizing-bufferize                                      -   Finalize a partial bufferization
      --fold-memref-subview-ops                                   -   Fold memref.subview ops into consumer load/store ops
      --func-bufferize                                            -   Bufferize func/call/return ops
      --gpu-async-region                                          -   Make GPU ops async
      --gpu-kernel-outlining                                      -   Outline gpu.launch bodies to kernel functions
        --data-layout-str=<string>                                - String containing the data layout specification to be attached to the GPU kernel module
      --gpu-launch-sink-index-computations                        -   Sink index computations into gpu.launch body
      --gpu-map-parallel-loops                                    -   Greedily maps loops to GPU hardware dimensions.
      --gpu-to-hsaco                                              -   Lower GPU kernel function to HSACO binary annotations
        --chip=<string>                                           - Target architecture
        --features=<string>                                       - Target features
        --gpu-binary-annotation=<string>                          - Annotation attribute string for GPU binary
        --opt-level=<int>                                         - Optimization level for HSACO compilation
        --rocm-path=<string>                                      - Path to ROCm install
        --triple=<string>                                         - Target triple
      --gpu-to-llvm                                               -   Convert GPU dialect to LLVM dialect with GPU runtime calls
        --gpu-binary-annotation=<string>                          - Annotation attribute string for GPU binary
        --use-bare-pointers-for-kernels                           - Use bare pointers to pass memref arguments to kernels. The kernel must use the same setting for this option.
      --inline                                                    -   Inline function calls
        --default-pipeline=<string>                               - The default optimizer pipeline used for callables
        --max-iterations=<uint>                                   - Maximum number of iterations when inlining within an SCC
        --op-pipelines=<pass-manager>                             - Callable operation specific optimizer pipelines (in the form of 'dialect.op(pipeline)')
      --launch-func-to-vulkan                                     -   Convert vulkanLaunch external call to Vulkan runtime external calls
      --linalg-bufferize                                          -   Bufferize the linalg dialect
      --linalg-detensorize                                        -   Detensorize linalg ops
        --aggressive-mode                                         - Detensorize all ops that qualify for detensoring along with branch operands and basic-block arguments.
      --linalg-fold-unit-extent-dims                              -   Remove unit-extent dimension in Linalg ops on tensors
        --fold-one-trip-loops-only                                - Only folds the one-trip loops from Linalg ops on tensors (for testing purposes only)
      --linalg-fuse-elementwise-ops                               -   Fuse elementwise operations on tensors
      --linalg-generalize-named-ops                               -   Convert named ops into generic ops
      --linalg-init-tensor-to-alloc-tensor                        -   Replace all init_tensor ops by alloc_tensor ops.
      --linalg-inline-scalar-operands                             -   Inline scalar operands into linalg generic ops
      --linalg-named-op-conversion                                -   Convert from one named linalg op to another.
      --linalg-strategy-decompose-pass                            -   Configurable pass to apply pattern-based generalization.
        --anchor-func=<string>                                    - Which func op is the anchor to latch on.
      --linalg-strategy-enable-pass                               -   Configurable pass to enable the application of other pattern-based linalg passes.
        --anchor-func=<string>                                    - Which func op is the anchor to latch on.
      --linalg-strategy-generalize-pass                           -   Configurable pass to apply pattern-based generalization.
        --anchor-func=<string>                                    - Which func op is the anchor to latch on.
        --anchor-op=<string>                                      - Which linalg op within the func is the anchor to latch on.
      --linalg-strategy-interchange-pass                          -   Configurable pass to apply pattern-based iterator interchange.
        --anchor-func=<string>                                    - Which func op is the anchor to latch on.
      --linalg-strategy-lower-vectors-pass                        -   Configurable pass to lower vector operations.
        --anchor-func=<string>                                    - Which func op is the anchor to latch on.
      --linalg-strategy-pad-pass                                  -   Configurable pass to apply padding and hoisting.
        --anchor-func=<string>                                    - Which func op is the anchor to latch on.
        --anchor-op=<string>                                      - Which linalg op within the func is the anchor to latch on.
      --linalg-strategy-peel-pass                                 -   Configurable pass to apply pattern-based linalg peeling.
        --anchor-func=<string>                                    - Which func op is the anchor to latch on.
        --anchor-op=<string>                                      - Which linalg op within the func is the anchor to latch on.
      --linalg-strategy-remove-markers-pass                       -   Cleanup pass that drops markers.
        --anchor-func=<string>                                    - Which func op is the anchor to latch on.
      --linalg-strategy-tile-and-fuse-pass                        -   Configurable pass to apply pattern-based tiling and fusion.
        --anchor-func=<string>                                    - Which func op is the anchor to latch on.
        --anchor-op=<string>                                      - Which linalg op within the func is the anchor to latch on.
      --linalg-strategy-tile-pass                                 -   Configurable pass to apply pattern-based linalg tiling.
        --anchor-func=<string>                                    - Which func op is the anchor to latch on.
        --anchor-op=<string>                                      - Which linalg op within the func is the anchor to latch on.
      --linalg-strategy-vectorize-pass                            -   Configurable pass to apply pattern-based linalg vectorization.
        --anchor-func=<string>                                    - Which func op is the anchor to latch on.
        --anchor-op=<string>                                      - Which linalg op within the func is the anchor to latch on.
        --vectorize-padding                                       - Enable vectorization of padding ops.
      --linalg-tile                                               -   Tile operations in the linalg dialect
        --loop-type=<string>                                      - Specify the type of loops to generate: for, parallel
        --tile-sizes=<long>                                       - Tile sizes
      --llvm-legalize-for-export                                  -   Legalize LLVM dialect to be convertible to LLVM IR
      --llvm-optimize-for-nvvm-target                             -   Optimize NVVM IR
      --llvm-request-c-wrappers                                   -   Request C wrapper emission for all functions
      --loop-invariant-code-motion                                -   Hoist loop invariant instructions outside of the loop
      --lower-affine                                              -   Lower Affine operations to a combination of Standard and SCF operations
      --lower-host-to-llvm                                        -   Lowers the host module code and 'gpu.launch_func' to LLVM
      --map-memref-spirv-storage-class                            -   Map numeric MemRef memory spaces to SPIR-V storage classes
        --client-api=<string>                                     - The client API to use for populating mappings
      --memref-expand                                             -   Legalize memref operations to be convertible to LLVM.
      --normalize-memrefs                                         -   Normalize memrefs
      --nvgpu-optimize-shared-memory                              -   Optimizes accesses to shard memory memrefs in order to reduce bank conflicts.
      --one-shot-bufferize                                        -   One-Shot Bufferize
        --allow-return-allocs                                     - Allows returning/yielding new allocations from a block.
        --allow-unknown-ops                                       - Allows unknown (not bufferizable) ops in the input IR.
        --analysis-fuzzer-seed=<uint>                             - Test only: Analyze ops in random order with a given seed (fuzzer)
        --bufferize-function-boundaries                           - Bufferize function boundaries (experimental).
        --create-deallocs                                         - Specify if buffers should be deallocated. For compatibility with core bufferization passes.
        --dialect-filter=<string>                                 - Restrict bufferization to ops from these dialects.
        --function-boundary-type-conversion=<string>              - Controls layout maps when bufferizing function signatures.
        --must-infer-memory-space                                 - The memory space of an memref types must always be inferred. If unset, a default memory space of 0 is used otherwise.
        --print-conflicts                                         - Test only: Annotate IR with RaW conflicts. Requires test-analysis-only.
        --test-analysis-only                                      - Test only: Only run inplaceability analysis and annotate IR
        --unknown-type-conversion=<string>                        - Controls layout maps for non-inferrable memref types.
      --print-op-stats                                            -   Print statistics of operations
        --json                                                    - print the stats as JSON
      --promote-buffers-to-stack                                  -   Promotes heap-based allocations to automatically managed stack-based allocations
        --max-alloc-size-in-bytes=<uint>                          - Maximal size in bytes to promote allocations to stack.
        --max-rank-of-allocated-memref=<uint>                     - Maximal memref rank to promote dynamic buffers.
      --reconcile-unrealized-casts                                -   Simplify and eliminate unrealized conversion casts
      --remove-shape-constraints                                  -   Replace all cstr_ ops with a true witness
      --resolve-ranked-shaped-type-result-dims                    -   Resolve memref.dim of result values of ranked shape type
      --resolve-shaped-type-result-dims                           -   Resolve memref.dim of result values
      --sccp                                                      -   Sparse Conditional Constant Propagation
      --scf-bufferize                                             -   Bufferize the scf dialect.
      --scf-for-loop-canonicalization                             -   Canonicalize operations within scf.for loop bodies
      --scf-for-loop-peeling                                      -   Peel 'for' loops at their upper bounds.
        --skip-partial                                            - Do not peel loops inside of the last, partial iteration of another already peeled loop.
      --scf-for-loop-range-folding                                -   Fold add/mul ops into loop range
      --scf-for-loop-specialization                               -   Specialize 'for' loops for vectorization
      --scf-for-to-while                                          -   Convert SCF for loops to SCF while loops
      --scf-parallel-loop-collapsing                              -   Collapse parallel loops to use less induction variables
        --collapsed-indices-0=<uint>                              - Which loop indices to combine 0th loop index
        --collapsed-indices-1=<uint>                              - Which loop indices to combine into the position 1 loop index
        --collapsed-indices-2=<uint>                              - Which loop indices to combine into the position 2 loop index
      --scf-parallel-loop-fusion                                  -   Fuse adjacent parallel loops
      --scf-parallel-loop-specialization                          -   Specialize parallel loops for vectorization
      --scf-parallel-loop-tiling                                  -   Tile parallel loops
        --no-min-max-bounds                                       - Perform tiling with fixed upper bound with inbound check inside the internal loops
        --parallel-loop-tile-sizes=<long>                         - Factors to tile parallel loops by
      --shape-bufferize                                           -   Bufferize the shape dialect.
      --shape-to-shape-lowering                                   -   Legalize Shape dialect to be convertible to Arithmetic
      --slice-analysis-test                                       -   Test Slice analysis functionality.
      --snapshot-op-locations                                     -   Generate new locations from the current IR
        --filename=<string>                                       - The filename to print the generated IR
        --tag=<string>                                            - A tag to use when fusing the new locations with the original. If unset, the locations are replaced.
      --sparse-tensor-conversion                                  -   Apply conversion rules to sparse tensor primitives and types
        --s2s-strategy=<int>                                      - Set the strategy for sparse-to-sparse conversion
      --sparsification                                            -   Automatically generate sparse tensor code from sparse tensor types
        --enable-simd-index32                                     - Enable i32 indexing into vectors (for efficiency)
        --enable-vla-vectorization                                - Enable vector length agnostic vectorization
        --parallelization-strategy=<int>                          - Set the parallelization strategy
        --vectorization-strategy=<int>                            - Set the vectorization strategy
        --vl=<int>                                                - Set the vector length
      --spirv-canonicalize-gl                                     -   Run canonicalization involving GLSL ops
      --spirv-lower-abi-attrs                                     -   Decorate SPIR-V composite type with layout info
      --spirv-rewrite-inserts                                     -   Rewrite sequential chains of spv.CompositeInsert operations into spv.CompositeConstruct operations
      --spirv-unify-aliased-resource                              -   Unify access of multiple aliased resources into access of one single resource
      --spirv-update-vce                                          -   Deduce and attach minimal (version, capabilities, extensions) requirements to spv.module ops
      --strip-debuginfo                                           -   Strip debug info from all operations
      --symbol-dce                                                -   Eliminate dead symbols
      --symbol-privatize                                          -   Mark symbols private
        --exclude=<string>                                        - Comma separated list of symbols that should not be marked private
      --tensor-bufferize                                          -   Bufferize the 'tensor' dialect
      --tensor-copy-insertion                                     -   Make all tensor IR inplaceable by inserting copies
        --allow-return-allocs                                     - Allows returning/yielding new allocations from a block.
        --bufferize-function-boundaries                           - Bufferize function boundaries (experimental).
        --create-deallocs                                         - Specify if new allocations should be deallocated.
        --must-infer-memory-space                                 - The memory space of an memref types must always be inferred. If unset, a default memory space of 0 is used otherwise.
      --test-affine-data-copy                                     -   Tests affine data copy utility functions.
        --for-memref-region                                       - Test copy generation for a single memref region
        --memref-filter                                           - Enable memref filter testing in affine data copy optimization
      --test-affine-loop-unswitch                                 -   Tests affine loop unswitching / if/else hoisting
      --test-affine-parametric-tile                               -   Tile affine loops using SSA values as tile sizes
      --test-alias-analysis                                       -   Test alias analysis results.
      --test-alias-analysis-modref                                -   Test alias analysis ModRef results.
      --test-clone                                                -   Test clone of op
      --test-commutativity-utils                                  -   Test the functionality of the commutativity utility
      --test-compose-subview                                      -   Test combining composed subviews
      --test-constant-fold                                        -   Test operation constant folding
      --test-control-flow-sink                                    -   Test control-flow sink pass
      --test-convert-call-op                                      -   Tests conversion of 'func.call' to 'llvm.call' in presence of custom types
      --test-data-layout-query                                    -   Test data layout queries
      --test-dead-code-analysis                                   -   
      --test-decompose-call-graph-types                           -   Decomposes types at call graph boundaries.
      --test-derived-attr                                         -   Run test derived attributes
      --test-diagnostic-filter                                    -   Test diagnostic filtering support.
        --filters=<string>                                        - Specifies the diagnostic file name filters.
      --test-dynamic-pipeline                                     -   Tests the dynamic pipeline feature by applying a pipeline on a selected set of functions
        --dynamic-pipeline=<string>                               - The pipeline description that will run on the filtered function.
        --op-name=<string>                                        - List of function name to apply the pipeline to
        --run-on-nested-operations                                - This will apply the pipeline on nested operations under the visited operation.
        --run-on-parent                                           - This will apply the pipeline on the parent operation if it exist, this is expected to fail.
      --test-elements-attr-interface                              -   Test ElementsAttr interface support.
      --test-expand-math                                          -   Test expanding math
      --test-extract-fixed-outer-loops                            -   test application of parametric tiling to the outer loops so that the ranges of outer loops become static
        --test-outer-loop-sizes=<long>                            - fixed number of iterations that the outer loops should have
      --test-foo-analysis                                         -   
      --test-func-erase-arg                                       -   Test erasing func args.
      --test-func-erase-result                                    -   Test erasing func results.
      --test-func-insert-arg                                      -   Test inserting func args.
      --test-func-insert-result                                   -   Test inserting func results.
      --test-func-set-type                                        -   Test FunctionOpInterface::setType.
      --test-function-pass                                        -   Test a function pass in the pass manager
      --test-generic-ir-block-visitors-interrupt                  -   Test generic IR visitors with interrupts, starting with Blocks.
      --test-generic-ir-region-visitors-interrupt                 -   Test generic IR visitors with interrupts, starting with Regions.
      --test-generic-ir-visitors                                  -   Test generic IR visitors.
      --test-generic-ir-visitors-interrupt                        -   Test generic IR visitors with interrupts.
      --test-gpu-memory-promotion                                 -   Promotes the annotated arguments of gpu.func to workgroup memory.
      --test-gpu-rewrite                                          -   Applies all rewrite patterns within the GPU dialect.
      --test-gpu-to-cubin                                         -   Lower GPU kernel function to CUBIN binary annotations
        --chip=<string>                                           - Target architecture
        --features=<string>                                       - Target features
        --gpu-binary-annotation=<string>                          - Annotation attribute string for GPU binary
        --triple=<string>                                         - Target triple
      --test-gpu-to-hsaco                                         -   Lower GPU kernel function to HSAco binary annotations
        --chip=<string>                                           - Target architecture
        --features=<string>                                       - Target features
        --gpu-binary-annotation=<string>                          - Annotation attribute string for GPU binary
        --triple=<string>                                         - Target triple
      --test-inline                                               -   Test inlining region calls
      --test-int-range-inference                                  -   Test integer range inference analysis
      --test-interface-pass                                       -   Test an interface pass (running on FunctionOpInterface) in the pass manager
      --test-ir-visitors                                          -   Test various visitors.
      --test-last-modified                                        -   
      --test-legalize-patterns                                    -   Run test dialect legalization patterns
      --test-legalize-type-conversion                             -   Test various type conversion functionalities in DialectConversion
      --test-legalize-unknown-root-patterns                       -   Test public remapped value mechanism in ConversionPatternRewriter
      --test-linalg-decompose-ops                                 -   Test Linalg decomposition patterns
      --test-linalg-elementwise-fusion-patterns                   -   Test Linalg element wise operation fusion patterns
        --control-fusion-by-expansion                             - Test controlling fusion of reshape with generic op by expansion
        --fuse-generic-ops                                        - Test fusion of generic operations.
        --fuse-with-reshape-by-collapsing                         - Test linalg expand_shape -> generic fusion patterns that collapse the iteration space of the consumer
        --fuse-with-reshape-by-collapsing-control                 - Test controlling the linalg expand_shape -> generic fusion patterns that collapse the iteration space of the consumer
        --fuse-with-reshape-by-expansion                          - Test fusion of generic operations with reshape by expansion
      --test-linalg-greedy-fusion                                 -   Test Linalg fusion by applying a greedy test transformation.
      --test-linalg-hoisting                                      -   Test Linalg hoisting functions.
        --test-hoist-redundant-transfers                          - Test hoisting transfer_read/transfer_write pairs
      --test-linalg-pad-fusion                                    -   Test PadOp fusion
      --test-linalg-transform-patterns                            -   Test Linalg transformation patterns by applying them greedily.
        --loop-type=<string>                                      - Specify the type of loops to generate: for, parallel or tiled_loop
        --peeled-loops=<long>                                     - Loops to be peeled when test-tile-pattern
        --skip-partial                                            - Skip loops inside partial iterations during peeling
        --test-bubble-up-extract-slice-op-pattern                 - Test rewrite of linalgOp + extract_slice into extract_slice + linalgOp
        --test-generalize-pad-tensor                              - Test transform pad tensor by copying with generic ops
        --test-linalg-to-vector-patterns                          - Test a set of patterns that rewrite a linalg contraction in vector.contract form
        --test-patterns                                           - Test a mixed set of patterns
        --test-split-reduction                                    - Test split reduction transformation
        --test-swap-subtensor-padtensor                           - Test rewrite of subtensor(tensor.pad) into tensor.pad(subtensor)
        --test-tile-and-distribute-options                        - Test tile and distribute options
        --test-tile-fuse-and-distribute-options                   - Test tile, fuse and distribute options
        --test-tile-pattern                                       - Test tile pattern
        --test-tile-scalarize-dynamic-dims                        - Test tiling of dynamic dims by 1
        --test-transform-pad-tensor                               - Test transform pad tensor by copying with generic ops
        --test-vector-transfer-forwarding-patterns                - Test a fused pass that forwards memref.copy to vector.transfer
        --tile-sizes=<long>                                       - Linalg tile sizes for test-tile-pattern
      --test-loop-fusion                                          -   Tests loop fusion utility functions.
      --test-loop-permutation                                     -   Tests affine loop permutation utility
        --permutation-map=<uint>                                  - Specify the loop permutation
      --test-loop-unrolling                                       -   Tests loop unrolling transformation
        --annotate                                                - Annotate unrolled iterations.
        --loop-depth=<uint>                                       - Loop depth.
        --unroll-factor=<ulong>                                   - Loop unroll factor.
        --unroll-up-to-factor                                     - Loop unroll up to factor.
      --test-mapping-to-processing-elements                       -   test mapping a single loop on a virtual processor grid
      --test-match-reduction                                      -   Test the match reduction utility.
      --test-matchers                                             -   Test C++ pattern matchers.
      --test-math-algebraic-simplification                        -   Test math algebraic simplification
      --test-math-polynomial-approximation                        -   Test math polynomial approximations
        --enable-avx2                                             - Enable approximations that emit AVX2 intrinsics via the X86Vector dialect
      --test-memref-bound-check                                   -   Check memref access bounds
      --test-memref-dependence-check                              -   Checks dependences between all pairs of memref accesses.
      --test-memref-stride-calculation                            -   Test operation constant folding
      --test-merge-blocks                                         -   Test Merging operation in ConversionPatternRewriter
      --test-mlir-reducer                                         -   Tests MLIR Reduce tool by generating failures
      --test-module-pass                                          -   Test a module pass in the pass manager
      --test-multi-buffering                                      -   Test multi buffering transformation
        --multiplier=<uint>                                       - Decide how many versions of the buffer should be created,
      --test-nvgpu-mmasync-f32-to-tf32-patterns                   -   Test patterns to convert mma.sync on f32 with tf32 precision
        --precision=<string>                                      - Target nvgpu.mma.sync on f32 input with tf32 or tf32x3 precision
      --test-opaque-loc                                           -   Changes all leaf locations to opaque locations
      --test-operations-equality                                  -   Test operations equality.
      --test-options-pass                                         -   Test options parsing capabilities
        --list=<int>                                              - Example list option
        --string=<string>                                         - Example string option
        --string-list=<string>                                    - Example string list option
      --test-pass-crash                                           -   Test a pass in the pass manager that always crashes
      --test-pass-create-invalid-ir                               -   Test pass that adds an invalid operation in a function body
        --emit-invalid-ir                                         - Emit invalid IR
        --signal-pass-failure                                     - Trigger a pass failure
      --test-pass-failure                                         -   Test a pass in the pass manager that always fails
      --test-pass-invalid-parent                                  -   Test a pass in the pass manager that makes the parent operation invalid
      --test-pattern-selective-replacement                        -   Test selective replacement in the PatternRewriter
      --test-patterns                                             -   Run test dialect patterns
        --top-down                                                - Seed the worklist in general top-down order
      --test-pdl-bytecode-pass                                    -   Test PDL ByteCode functionality
      --test-pdll-pass                                            -   Test PDLL functionality
      --test-print-callgraph                                      -   Print the contents of a constructed callgraph.
      --test-print-defuse                                         -   Test various printing.
      --test-print-dominance                                      -   Print the dominance information for multiple regions.
      --test-print-invalid                                        -   Test printing invalid ops.
      --test-print-liveness                                       -   Print the contents of a constructed liveness information.
      --test-print-nesting                                        -   Test various printing.
      --test-print-topological-sort                               -   Print operations in topological order
      --test-recursive-types                                      -   Test support for recursive types
      --test-remapped-value                                       -   Test public remapped value mechanism in ConversionPatternRewriter
      --test-return-type                                          -   Run return type functions
      --test-rewrite-dynamic-op                                   -   Test rewritting on dynamic operations
      --test-scf-for-utils                                        -   test scf.for utils
        --test-replace-with-new-yields                            - Test replacing a loop with a new loop that returns new additional yeild values
      --test-scf-if-utils                                         -   test scf.if utils
      --test-scf-pipelining                                       -   test scf.forOp pipelining
        --annotate                                                - Annote operations during loop pipelining transformation
        --no-epilogue-peeling                                     - Use predicates instead of peeling the epilogue.
      --test-shape-function-report                                -   Test pass to report associated shape functions
      --test-side-effects                                         -   Test side effects interfaces
      --test-spirv-entry-point-abi                                -   Set the spv.entry_point_abi attribute on GPU kernel function within the module, intended for testing only
        --workgroup-size=<int>                                    - Workgroup size to use for all gpu.func kernels in the module, specified with x-dimension first, y-dimension next and z-dimension last. Unspecified dimensions will be set to 1
      --test-spirv-module-combiner                                -   Tests SPIR-V module combiner library
      --test-spirv-op-availability                                -   Test SPIR-V op availability
      --test-spirv-target-env                                     -   Test SPIR-V target environment
      --test-stats-pass                                           -   Test pass statistics
      --test-strict-pattern-driver                                -   Run strict mode of pattern driver
      --test-symbol-rauw                                          -   Test replacement of symbol uses
      --test-symbol-uses                                          -   Test detection of symbol uses
      --test-take-body                                            -   Test Region's takeBody
      --test-target-materialization-with-no-uses                  -   Test a special case of target materialization in DialectConversion
      --test-tensor-transform-patterns                            -   Test Tensor transformation patterns by applying them greedily.
        --test-fold-constant-extract-slice                        - Test folding arith.constant and tensor.extract_slice
        --test-split-padding-patterns                             - Test patterns to split tensor.pad ops
      --test-tiling-interface                                     -   Test tiling using TilingInterface
        --lower-to-scalar-using-scf-for                           - Test lowering to scalar implementation using TilingInterface with scf.for operations
        --tile-consumer-and-fuse-producer-using-scf-for           - Test tile and fuse transformation using TilingInterface with scf.for operations
        --tile-using-scf-for                                      - Test tiling using TilingInterface with scf.for operations
      --test-trait-folder                                         -   Run trait folding
      --test-transform-dialect-interpreter                        -   apply transform dialect operations one by one
        --enable-expensive-checks                                 - perform expensive checks to better report errors in the transform IR
      --test-type-interfaces                                      -   Test type interface support.
      --test-vector-contraction-lowering                          -   Test lowering patterns that lower contract ops in the vector dialect
        --vector-filter-outerproduct                              - Lower vector.contract to vector.outerproduct but not for vectors of size 4.
        --vector-lower-matrix-intrinsics                          - Lower vector.contract to llvm.intr.matrix.multiply
        --vector-outerproduct                                     - Lower vector.contract to vector.outerproduct
        --vector-parallel-arith                                   - Lower vector.contract to elementwise vector ops.
      --test-vector-distribute-patterns                           -   Test lowering patterns to distribute vector ops in the vector dialect
        --distribution-multiplicity=<int>                         - Set the multiplicity used for distributing vector
      --test-vector-multi-reduction-lowering-patterns             -   Test lowering patterns to lower vector.multi_reduction to other vector ops
        --use-outer-reductions                                    - Move reductions to outer most dimensions
      --test-vector-reduction-to-contract-patterns                -   Test patterns to convert multireduce op to contract and combine broadcast/transpose to contract
      --test-vector-scan-lowering                                 -   Test lowering patterns that lower the scan op in the vector dialect
      --test-vector-to-forloop                                    -   Test lowering patterns to break up a vector op into a for loop
        --distribution-multiplicity=<int>                         - Set the multiplicity used for distributing vector
      --test-vector-to-vector-lowering                            -   Test lowering patterns between ops in the vector dialect
        --unroll                                                  - Include unrolling
      --test-vector-transfer-collapse-inner-most-dims             -   Test lowering patterns that reducedes the rank of the vector transfer memory and vector operands.
      --test-vector-transfer-drop-unit-dims-patterns              -   
      --test-vector-transfer-flatten-patterns                     -   Test patterns to rewrite contiguous row-major N-dimensional vector.transfer_{read,write} ops into 1D transfers
      --test-vector-transfer-full-partial-split                   -   Test lowering patterns to split transfer ops via scf.if + linalg ops
        --use-memref-copy                                         - Split using a unmasked vector.transfer + linalg.fill + memref.copy operations.
      --test-vector-transfer-lowering-patterns                    -   Test lowering patterns to lower transfer ops to other vector ops
      --test-vector-transfer-unrolling-patterns                   -   Test lowering patterns to unroll transfer ops in the vector dialect
        --reverse-unroll-order                                    - reverse the order of unrolling of vector transfer operations
      --test-vector-transferop-opt                                -   Test optimization transformations for transfer ops
      --test-vector-transpose-lowering                            -   Test lowering patterns that lower contract ops in the vector dialect
        --avx2                                                    - Lower vector.transpose to avx2-specific patterns
        --eltwise                                                 - Lower 2-D vector.transpose to eltwise insert/extract
        --flat                                                    - Lower 2-D vector.transpose to vector.flat_transpose
        --shuffle                                                 - Lower 2-D vector.transpose to shape_cast + shuffle
      --test-vector-unrolling-patterns                            -   Test lowering patterns to unroll contract ops in the vector dialect
        --unroll-based-on-type                                    - Set the unroll factor based on type of the operation
        --unroll-order=<long>                                     - set the unroll order
      --test-vector-warp-distribute                               -   Test vector warp distribute transformation and lowering patterns
        --distribute-transfer-write                               - Test distribution of transfer write
        --hoist-uniform                                           - Test hoist uniform
        --propagate-distribution                                  - Test distribution propgation
        --rewrite-warp-ops-to-scf-if                              - Lower vector.warp_execute_on_lane0 to scf.if op
      --topological-sort                                          -   Sort regions without SSA dominance in topological order
      --tosa-infer-shapes                                         -   Propagate shapes across TOSA operations
      --tosa-layerwise-constant-fold                              -   Fold layerwise operations on constant tensors
      --tosa-make-broadcastable                                   -   TOSA rank Reshape to enable Broadcasting
      --tosa-optional-decompositions                              -   Applies Tosa operations optional decompositions
      --tosa-test-quant-utils                                     -   TOSA Test: Exercise the APIs in QuantUtils.cpp.
      --tosa-to-arith                                             -   Lower TOSA to the Arith dialect
        --include-apply-rescale                                   - Whether to include the lowering for tosa.apply_rescale to arith
        --use-32-bit                                              - Whether to prioritze lowering to 32-bit operations
      --tosa-to-linalg                                            -   Lower TOSA to LinAlg on tensors
      --tosa-to-linalg-named                                      -   Lower TOSA to LinAlg named operations
      --tosa-to-scf                                               -   Lower TOSA to the SCF dialect
      --tosa-to-tensor                                            -   Lower TOSA to the Tensor dialect
      --transform-dialect-check-uses                              -   warn about potential use-after-free in the transform dialect
      --vector-bufferize                                          -   Bufferize Vector dialect ops
      --view-op-graph                                             -   Print Graphviz visualization of an operation
        --max-label-len=<uint>                                    - Limit attribute/type length to number of chars
        --print-attrs                                             - Print attributes of operations
        --print-control-flow-edges                                - Print control flow edges
        --print-data-flow-edges                                   - Print data flow edges
        --print-result-types                                      - Print result types of operations
    Pass Pipelines:
      --sparse-compiler                                           -   The standard pipeline for taking sparsity-agnostic IR using the sparse-tensor type, and lowering it to LLVM IR with concrete representations and algorithms for sparse tensors.
        --enable-amx                                              - Enables the use of AMX dialect while lowering the vector dialect.
        --enable-arm-neon                                         - Enables the use of ArmNeon dialect while lowering the vector dialect.
        --enable-arm-sve                                          - Enables the use of ArmSVE dialect while lowering the vector dialect.
        --enable-index-optimizations                              - Allows compiler to assume indices fit in 32-bit if that yields faster code
        --enable-simd-index32                                     - Enable i32 indexing into vectors (for efficiency)
        --enable-vla-vectorization                                - Enable vector length agnostic vectorization
        --enable-x86vector                                        - Enables the use of X86Vector dialect while lowering the vector dialect.
        --parallelization-strategy=<int>                          - Set the parallelization strategy
        --reassociate-fp-reductions                               - Allows llvm to reassociate floating-point reductions for speed
        --s2s-strategy=<int>                                      - Set the strategy for sparse-to-sparse conversion
        --test-bufferization-analysis-only                        - Run only the inplacability analysis
        --vectorization-strategy=<int>                            - Set the vectorization strategy
        --vl=<int>                                                - Set the vector length
      --test-dump-pipeline                                        -   Dumps the pipeline build so far for debugging purposes
      --test-options-pass-pipeline                                -   Parses options using pass pipeline registration
        --list=<int>                                              - Example list option
        --string=<string>                                         - Example string option
        --string-list=<string>                                    - Example string list option
      --test-pm-nested-pipeline                                   -   Test a nested pipeline in the pass manager
      --test-textual-pm-nested-pipeline                           -   Test a nested pipeline in the pass manager
  --show-dialects                                                 - Print the list of registered dialects
  --show-fs-branchprob                                            - Print setting flow sensitive branch probabilities
  --simple-loop-unswitch-drop-non-trivial-implicit-null-checks    - If enabled, drop make.implicit metadata in unswitched implicit null checks to save time analyzing if we can keep it.
  --simple-loop-unswitch-guards                                   - If enabled, simple loop unswitching will also consider llvm.experimental.guard intrinsics as unswitch candidates.
  --simple-loop-unswitch-memoryssa-threshold=<uint>               - Max number of memory uses to explore during partial unswitching analysis
  --simplify-mir                                                  - Leave out unnecessary information when printing MIR
  --simplifycfg-branch-fold-common-dest-vector-multiplier=<uint>  - Multiplier to apply to threshold when determining whether or not to fold branch to common destination when vector operations are present
  --simplifycfg-branch-fold-threshold=<uint>                      - Maximum cost of combining conditions when folding branches
  --simplifycfg-hoist-common                                      - Hoist common instructions up to the parent block
  --simplifycfg-hoist-cond-stores                                 - Hoist conditional stores if an unconditional store precedes
  --simplifycfg-max-small-block-size=<int>                        - Max size of a block which is still considered small enough to thread through
  --simplifycfg-merge-compatible-invokes                          - Allow SimplifyCFG to merge invokes together when appropriate
  --simplifycfg-merge-cond-stores                                 - Hoist conditional stores even if an unconditional store does not precede - hoist multiple conditional stores into a single predicated store
  --simplifycfg-merge-cond-stores-aggressively                    - When merging conditional stores, do so even if the resultant basic blocks are unlikely to be if-converted as a result
  --simplifycfg-require-and-preserve-domtree                      - Temorary development switch used to gradually uplift SimplifyCFG into preserving DomTree,
  --simplifycfg-sink-common                                       - Sink common instructions down to the end block
  --sink-common-insts                                             - Sink common instructions (default = false)
  --sink-freq-percent-threshold=<uint>                            - Do not sink instructions that require cloning unless they execute less than this percent of the time.
  --sink-insts-to-avoid-spills                                    - Sink instructions into cycles to avoid register spills
  --skip-ret-exit-block                                           - Suppress counter promotion if exit blocks contain ret.
  --slp-max-look-ahead-depth=<int>                                - The maximum look-ahead depth for operand reordering scores
  --slp-max-reg-size=<int>                                        - Attempt to vectorize for this register size in bits
  --slp-max-root-look-ahead-depth=<int>                           - The maximum look-ahead depth for searching best rooting option
  --slp-max-store-lookup=<int>                                    - Maximum depth of the lookup for consecutive stores.
  --slp-max-vf=<uint>                                             - Maximum SLP vectorization factor (0=unlimited)
  --slp-min-reg-size=<int>                                        - Attempt to vectorize for this register size in bits
  --slp-min-tree-size=<uint>                                      - Only vectorize small trees if they are fully vectorizable
  --slp-recursion-max-depth=<uint>                                - Limit the recursion depth when building a vectorizable tree
  --slp-schedule-budget=<int>                                     - Limit the size of the SLP scheduling region per block
  --slp-threshold=<int>                                           - Only vectorize if you gain more than this number 
  --slp-vectorize-hor                                             - Attempt to vectorize horizontal reductions
  --slp-vectorize-hor-store                                       - Attempt to vectorize horizontal reductions feeding into a store
  --small-loop-cost=<uint>                                        - The cost of a loop that is considered 'small' by the interleaver.
  --sort-profiled-scc-member                                      - Sort profiled recursion by edge weights.
  --sort-timers                                                   - In the report, sort the timers in each group in wall clock time order
  --spec-exec-max-not-hoisted=<uint>                              - Speculative execution is not applied to basic blocks where the number of instructions that would not be speculatively executed exceeds this limit.
  --spec-exec-max-speculation-cost=<uint>                         - Speculative execution is not applied to basic blocks where the cost of the instructions to speculatively execute exceeds this limit.
  --spec-exec-only-if-divergent-target                            - Speculative execution is applied only to targets with divergent branches, even if the pass was configured to apply only to all targets.
  --speculate-one-expensive-inst                                  - Allow exactly one expensive instruction to be speculatively executed
  --speculative-counter-promotion-max-exiting=<uint>              - The max number of exiting blocks of a loop to allow  speculative counter promotion
  --speculative-counter-promotion-to-loop                         - When the option is false, if the target block is in a loop, the promotion will be disallowed unless the promoted counter  update can be further/iteratively promoted into an acyclic  region.
  --split-dwarf-cross-cu-references                               - Enable cross-cu references in DWO files
  --split-input-file                                              - Split the input file into pieces and process each chunk independently
  --split-spill-mode=<value>                                      - Spill mode for splitting live ranges
    =default                                                      -   Default
    =size                                                         -   Optimize for size
    =speed                                                        -   Optimize for speed
  --spp-print-base-pointers                                       - 
  --spp-print-liveset                                             - 
  --spp-print-liveset-size                                        - 
  --spp-rematerialization-threshold=<uint>                        - 
  --sroa-strict-inbounds                                          - 
  --ssc-dce-limit=<int>                                           - 
  --stack-safety-max-iterations=<int>                             - 
  --stack-safety-print                                            - 
  --stack-safety-run                                              - 
  --stackcoloring-lifetime-start-on-first-use                     - Treat stack lifetimes as starting on first use, not on START marker.
  --stackmap-version=<int>                                        - Specify the stackmap encoding version (default = 3)
  --start-after=<pass-name>                                       - Resume compilation after a specific pass
  --start-before=<pass-name>                                      - Resume compilation before a specific pass
  --static-func-full-module-prefix                                - Use full module build paths in the profile counter names for static functions.
  --static-func-strip-dirname-prefix=<uint>                       - Strip specified level of directory name from source path in the profile counter name for static functions.
  --static-likely-prob=<uint>                                     - branch probability threshold in percentageto be considered very likely
  --stats                                                         - Enable statistics output from program (available with Asserts)
  --stats-json                                                    - Display statistics as json data
  --stop-after=<pass-name>                                        - Stop compilation after a specific pass
  --stop-before=<pass-name>                                       - Stop compilation before a specific pass
  --store-to-load-forwarding-conflict-detection                   - Enable conflict detection in loop-access analysis
  --stress-cgp-ext-ld-promotion                                   - Stress test ext(promotable(ld)) -> promoted(ext(ld)) optimization in CodeGenPrepare
  --stress-cgp-store-extract                                      - Stress test store(extract) optimizations in CodeGenPrepare
  --stress-early-ifcvt                                            - Turn all knobs to 11
  --stress-ivchain                                                - Stress test LSR IV chains
  --stress-regalloc=<N>                                           - Limit all regclasses to N registers
  --stress-sched                                                  - Stress test instruction scheduling
  --structurizecfg-relaxed-uniform-regions                        - Allow relaxed uniform region checks
  --structurizecfg-skip-uniform-regions                           - Force whether the StructurizeCFG pass skips uniform regions
  --summary-file=<string>                                         - The summary file to use for function importing.
  --switch-peel-threshold=<uint>                                  - Set the case probability threshold for peeling the case from a switch statement. A value greater than 100 will void this optimization
  --switch-range-to-icmp                                          - Convert switches into an integer range comparison (default = false)
  --switch-to-lookup                                              - Convert switches to lookup tables (default = false)
  --tail-dup-indirect-size=<uint>                                 - Maximum instructions to consider tail duplicating blocks that end with indirect branches.
  --tail-dup-limit=<uint>                                         - 
  --tail-dup-placement                                            - Perform tail duplication during placement. Creates more fallthrough opportunites in outline branches.
  --tail-dup-placement-aggressive-threshold=<uint>                - Instruction cutoff for aggressive tail duplication during layout. Used at -O3. Tail merging during layout is forced to have a threshold that won't conflict.
  --tail-dup-placement-penalty=<uint>                             - Cost penalty for blocks that can avoid breaking CFG by copying. Copying can increase fallthrough, but it also increases icache pressure. This parameter controls the penalty to account for that. Percent as integer.
  --tail-dup-placement-threshold=<uint>                           - Instruction cutoff for tail duplication during layout. Tail merging during layout is forced to have a threshold that won't conflict.
  --tail-dup-profile-percent-threshold=<uint>                     - If profile count information is used in tail duplication cost model, the gained fall through number from tail duplication should be at least this percent of hot count.
  --tail-dup-size=<uint>                                          - Maximum instructions to consider tail duplicating
  --tail-dup-verify                                               - Verify sanity of PHI instructions during taildup
  --tail-merge-size=<uint>                                        - Min number of instructions to consider tail merging
  --tail-merge-threshold=<uint>                                   - Max number of predecessors to consider tail merging
  --temporal-reuse-threshold=<uint>                               - Use this to specify the max. distance between array elements accessed in a loop so that the elements are classified to have temporal reuse
  --terminal-rule                                                 - Apply the terminal rule
  --test-legalize-mode=<value>                                    - The legalization mode to use with the test driver
    =analysis                                                     -   Perform an analysis conversion
    =full                                                         -   Perform a full conversion
    =partial                                                      -   Perform a partial conversion
  --time-passes                                                   - Time each pass, printing elapsed time for each on exit
  --time-passes-per-run                                           - Time each pass run, printing elapsed time for each run on exit
  --tiny-trip-count-interleave-threshold=<uint>                   - We don't interleave loops with a estimated constant trip count below this number
  --tls-load-hoist                                                - hoist the TLS loads in PIC model to eliminate redundant TLS address calculation.
  --track-memory                                                  - Enable -time-passes memory tracking (this may be slow)
  --trap-unreachable                                              - Enable generating trap for unreachable
  --treat-scalable-fixed-error-as-warning                         - Treat issues where a fixed-width property is requested from a scalable type as a warning, instead of an error
  --triangle-chain-count=<uint>                                   - Number of triangle-shaped-CFG's that need to be in a row for the triangle tail duplication heuristic to kick in. 0 to disable.
  --trim-var-locs                                                 - 
  --tsan-compound-read-before-write                               - Emit special compound instrumentation for reads-before-writes
  --tsan-distinguish-volatile                                     - Emit special instrumentation for accesses to volatiles
  --tsan-handle-cxx-exceptions                                    - Handle C++ exceptions (insert cleanup blocks for unwinding)
  --tsan-instrument-atomics                                       - Instrument atomics
  --tsan-instrument-func-entry-exit                               - Instrument function entry and exit
  --tsan-instrument-memintrinsics                                 - Instrument memintrinsics (memset/memcpy/memmove)
  --tsan-instrument-memory-accesses                               - Instrument memory accesses
  --tsan-instrument-read-before-write                             - Do not eliminate read instrumentation for read-before-writes
  --two-entry-phi-node-folding-threshold=<uint>                   - Control the maximal total instruction cost that we are willing to speculatively execute to fold a 2-entry PHI node into a select (default = 4)
  --twoaddr-reschedule                                            - Coalesce copies by rescheduling (default=true)
  --type-based-intrinsic-cost                                     - Calculate intrinsics cost based only on argument types
  --unlikely-branch-weight=<uint>                                 - Weight of the branch unlikely to be taken (default = 1)
  --unroll-allow-loop-nests-peeling                               - Allows loop nests to be peeled.
  --unroll-allow-partial                                          - Allows loops to be partially unrolled until -unroll-threshold loop size is reached.
  --unroll-allow-peeling                                          - Allows loops to be peeled when the dynamic trip count is known to be low.
  --unroll-allow-remainder                                        - Allow generation of a loop remainder (extra iterations) when unrolling a loop.
  --unroll-and-jam-count=<uint>                                   - Use this unroll count for all loops including those with unroll_and_jam_count pragma values, for testing purposes
  --unroll-and-jam-threshold=<uint>                               - Threshold to use for inner loop when doing unroll and jam.
  --unroll-count=<uint>                                           - Use this unroll count for all loops including those with unroll_count pragma values, for testing purposes
  --unroll-force-peel-count=<uint>                                - Force a peel count regardless of profiling information.
  --unroll-full-max-count=<uint>                                  - Set the max unroll count for full unrolling, for testing purposes
  --unroll-max-count=<uint>                                       - Set the max unroll count for partial and runtime unrolling, fortesting purposes
  --unroll-max-iteration-count-to-analyze=<uint>                  - Don't allow loop unrolling to simulate more than this number ofiterations when checking full unroll profitability
  --unroll-max-percent-threshold-boost=<uint>                     - The maximum 'boost' (represented as a percentage >= 100) applied to the threshold when aggressively unrolling a loop due to the dynamic cost savings. If completely unrolling a loop will reduce the total runtime from X to Y, we boost the loop unroll threshold to DefaultThreshold*std::min(MaxPercentThresholdBoost, X/Y). This limit avoids excessive code bloat.
  --unroll-max-upperbound=<uint>                                  - The max of trip count upper bound that is considered in unrolling
  --unroll-optsize-threshold=<uint>                               - The cost threshold for loop unrolling when optimizing for size
  --unroll-partial-threshold=<uint>                               - The cost threshold for partial loop unrolling
  --unroll-peel-count=<uint>                                      - Set the unroll peeling count, for testing purposes
  --unroll-peel-max-count=<uint>                                  - Max average trip count which will cause loop peeling.
  --unroll-remainder                                              - Allow the loop remainder to be unrolled.
  --unroll-revisit-child-loops                                    - Enqueue and re-visit child loops in the loop PM after unrolling. This shouldn't typically be needed as child loops (or their clones) were already visited.
  --unroll-runtime                                                - Unroll loops with run-time trip counts
  --unroll-runtime-epilog                                         - Allow runtime unrolled loops to be unrolled with epilog instead of prolog.
  --unroll-runtime-multi-exit                                     - Allow runtime unrolling for loops with multiple exits, when epilog is generated
  --unroll-runtime-other-exit-predictable                         - Assume the non latch exit block to be predictable
  --unroll-threshold=<uint>                                       - The cost threshold for loop unrolling
  --unroll-threshold-aggressive=<uint>                            - Threshold (max size of unrolled loop) to use in aggressive (O3) optimizations
  --unroll-threshold-default=<uint>                               - Default threshold (max size of unrolled loop), used in all but O3 optimizations
  --unroll-verify-domtree                                         - Verify domtree after unrolling
  --unroll-verify-loopinfo                                        - Verify loopinfo after unrolling
  --unswitch-num-initial-unscaled-candidates=<int>                - Number of unswitch candidates that are ignored when calculating cost multiplier.
  --unswitch-siblings-toplevel-div=<int>                          - Toplevel siblings divisor for cost multiplier.
  --unswitch-threshold=<int>                                      - The cost threshold for unswitching a loop.
  --update-pseudo-probe                                           - Update pseudo probe distribution factor
  --update-return-attrs                                           - Update return attributes on calls within inlined body
  --use-cfl-aa=<value>                                            - Enable the new, experimental CFL alias analysis
    =none                                                         -   Disable CFL-AA
    =steens                                                       -   Enable unification-based CFL-AA
    =anders                                                       -   Enable inclusion-based CFL-AA
    =both                                                         -   Enable both variants of CFL-AA
  --use-cfl-aa-in-codegen=<value>                                 - Enable the new, experimental CFL alias analysis in CodeGen
    =none                                                         -   Disable CFL-AA
    =steens                                                       -   Enable unification-based CFL-AA
    =anders                                                       -   Enable inclusion-based CFL-AA
    =both                                                         -   Enable both variants of CFL-AA
  --use-dbg-addr                                                  - Use llvm.dbg.addr for all local variables
  --use-dereferenceable-at-point-semantics=<uint>                 - Deref attributes and metadata infer facts at definition only
  --use-dwarf-ranges-base-address-specifier                       - Use base address specifiers in debug_ranges
  --use-gnu-debug-macro                                           - Emit the GNU .debug_macro format with DWARF <5
  --use-gpu-divergence-analysis                                   - turn the LegacyDivergenceAnalysis into a wrapper for GPUDivergenceAnalysis
  --use-gvn-after-vectorization                                   - Run GVN instead of Early CSE after vectorization passes
  --use-iterative-bfi-inference                                   - Apply an iterative post-processing to infer correct BFI counts
  --use-leb128-directives                                         - Disable the usage of LEB128 directives, and generate .byte instead.
  --use-lir-code-size-heurs                                       - Use loop idiom recognition code size heuristics when compilingwith -Os/-Oz
  --use-mbpi                                                      - use Machine Branch Probability Info
  --use-noalias-intrinsic-during-inlining                         - Use the llvm.experimental.noalias.scope.decl intrinsic during inlining.
  --use-profiled-call-graph                                       - Process functions in a top-down order defined by the profiled call graph when -sample-profile-top-down-load is on.
  --use-registers-for-deopt-values                                - Allow using registers for non pointer deopt args
  --use-registers-for-gc-values-in-landing-pad                    - Allow using registers for gc pointer in landing pad
  --use-segment-set-for-physregs                                  - Use segment set for the computation of the live ranges of physregs.
  --use-source-filename-for-promoted-locals                       - Uses the source file name instead of the Module hash. This requires that the source filename has a unique name / path to avoid name collisions.
  --use-tbaa-in-sched-mi                                          - Enable use of TBAA during MI DAG construction
  --use-unknown-locations=<value>                                 - Make an absence of debug location information explicit.
    =Default                                                      -   At top of block or after label
    =Enable                                                       -   In all cases
    =Disable                                                      -   Never
  --vector-combine-max-scan-instrs=<uint>                         - Max number of instructions to scan for vector combining.
  --vector-library=<value>                                        - Vector functions library
    =none                                                         -   No vector functions library
    =Accelerate                                                   -   Accelerate framework
    =Darwin_libsystem_m                                           -   Darwin libsystem_m
    =LIBMVEC-X86                                                  -   GLIBC Vector Math library
    =MASSV                                                        -   IBM MASS vector library
    =SVML                                                         -   Intel SVML library
  --vectorize-loops                                               - Run the Loop vectorization passes
  --vectorize-memory-check-threshold=<uint>                       - The maximum allowed number of runtime memory checks
  --vectorize-num-stores-pred=<uint>                              - Max number of stores to be predicated behind an if.
  --vectorize-scev-check-threshold=<uint>                         - The maximum number of SCEV checks allowed.
  --vectorize-slp                                                 - Run the SLP vectorization passes
  --vectorizer-maximize-bandwidth                                 - Maximize bandwidth when selecting vectorization factor which will be determined by the smallest type in loop.
  --vectorizer-min-trip-count=<uint>                              - Loops with a constant trip count that is smaller than this value are vectorized only if no scalar iteration overheads are incurred.
  --verify-assumption-cache                                       - Enable verification of assumption cache
  --verify-cfiinstrs                                              - Verify Call Frame Information instructions
  --verify-coalescing                                             - Verify machine instrs before and after register coalescing
  --verify-diagnostics                                            - Check that emitted diagnostics match expected-* lines on the corresponding line
  --verify-dom-info                                               - Verify dominator info (time consuming)
  --verify-each                                                   - Run the verifier after each transformation pass
  --verify-indvars                                                - Verify the ScalarEvolution result after running indvars. Has no effect in release builds. (Note: this adds additional SCEV queries potentially changing the analysis result)
  --verify-legalizer-debug-locs=<value>                           - Verify that debug locations are handled
    =none                                                         -   No verification
    =legalizations                                                -   Verify legalizations
    =legalizations+artifactcombiners                              -   Verify legalizations and artifact combines
  --verify-loop-info                                              - Verify loop info (time consuming)
  --verify-loop-lcssa                                             - Verify loop lcssa form (time consuming)
  --verify-machine-dom-info                                       - Verify machine dominator info (time consuming)
  --verify-machineinstrs                                          - Verify generated machine code
  --verify-memoryssa                                              - Enable verification of MemorySSA.
  --verify-misched                                                - Verify machine instrs before and after machine scheduling
  --verify-noalias-scope-decl-dom                                 - Ensure that llvm.experimental.noalias.scope.decl for identical scopes are not dominating
  --verify-predicateinfo                                          - Verify PredicateInfo in legacy printer pass.
  --verify-pseudo-probe                                           - Do pseudo probe verification
  --verify-pseudo-probe-funcs=<string>                            - The option to specify the name of the functions to verify.
  --verify-regalloc                                               - Verify during register allocation
  --verify-region-info                                            - Verify region info (time consuming)
  --verify-scev                                                   - Verify ScalarEvolution's backedge taken counts (slow)
  --verify-scev-maps                                              - Verify no dangling value in ScalarEvolution's ExprValueMap (slow)
  --verify-scev-strict                                            - Enable stricter verification with -verify-scev is passed
  --vgpr-regalloc=<value>                                         - Register allocator to use for VGPRs
    =basic                                                        -   basic register allocator
    =greedy                                                       -   greedy register allocator
    =fast                                                         -   fast register allocator
  --view-bfi-func-name=<string>                                   - The option to specify the name of the function whose CFG will be displayed.
  --view-block-freq-propagation-dags=<value>                      - Pop up a window to show a dag displaying how block frequencies propagation through the CFG.
    =none                                                         -   do not display graphs.
    =fraction                                                     -   display a graph using the fractional block frequency representation.
    =integer                                                      -   display a graph using the raw integer fractional block frequency representation.
    =count                                                        -   display a graph using the real profile count if available.
  --view-block-layout-with-bfi=<value>                            - Pop up a window to show a dag displaying MBP layout and associated block frequencies of the CFG.
    =none                                                         -   do not display graphs.
    =fraction                                                     -   display a graph using the fractional block frequency representation.
    =integer                                                      -   display a graph using the raw integer fractional block frequency representation.
    =count                                                        -   display a graph using the real profile count if available.
  --view-dag-combine-lt-dags                                      - Pop up a window to show dags before the post legalize types dag combine pass
  --view-dag-combine1-dags                                        - Pop up a window to show dags before the first dag combine pass
  --view-dag-combine2-dags                                        - Pop up a window to show dags before the second dag combine pass
  --view-edge-bundles                                             - Pop up a window to show edge bundle graphs
  --view-hot-freq-percent=<uint>                                  - An integer in percent used to specify the hot blocks/edges to be displayed in red: a block or edge whose frequency is no less than the max frequency of the function multiplied by this percent.
  --view-isel-dags                                                - Pop up a window to show isel dags as they are selected
  --view-legalize-dags                                            - Pop up a window to show dags before legalize
  --view-legalize-types-dags                                      - Pop up a window to show dags before legalize types
  --view-machine-block-freq-propagation-dags=<value>              - Pop up a window to show a dag displaying how machine block frequencies propagate through the CFG.
    =none                                                         -   do not display graphs.
    =fraction                                                     -   display a graph using the fractional block frequency representation.
    =integer                                                      -   display a graph using the raw integer fractional block frequency representation.
    =count                                                        -   display a graph using the real profile count if available.
  --view-misched-cutoff=<uint>                                    - Hide nodes with more predecessor/successor than cutoff
  --view-misched-dags                                             - Pop up a window to show MISched dags after they are processed
  --view-sched-dags                                               - Pop up a window to show sched dags as they are processed
  --view-slp-tree                                                 - Display the SLP trees with Graphviz
  --view-sunit-dags                                               - Pop up a window to show SUnit dags after they are processed
  --vp-counters-per-site=<number>                                 - The average number of profile counters allocated per value profiling site.
  --vp-static-alloc                                               - Do static counter allocation for value profiler
  --vplan-build-stress-test                                       - Build VPlan for every supported loop nest in the function and bail out right after the build (stress test the VPlan H-CFG construction in the VPlan-native vectorization path).
  --vplan-print-in-dot-format                                     - Use dot format instead of plain text when dumping VPlans
  --vplan-verify-hcfg                                             - Verify VPlan H-CFG.
  --whole-program-visibility                                      - Enable whole program visibility
  --wholeprogramdevirt-branch-funnel-threshold=<uint>             - Maximum number of call targets per call site to enable branch funnels
  --wholeprogramdevirt-check=<value>                              - Type of checking for incorrect devirtualizations
    =none                                                         -   No checking
    =trap                                                         -   Trap when incorrect
    =fallback                                                     -   Fallback to indirect when incorrect
  --wholeprogramdevirt-print-index-based                          - Print index-based devirtualization messages
  --wholeprogramdevirt-read-summary=<string>                      - Read summary from given bitcode or YAML file before running pass
  --wholeprogramdevirt-skip=<string>                              - Prevent function(s) from being devirtualized
  --wholeprogramdevirt-summary-action=<value>                     - What to do with the summary when running this pass
    =none                                                         -   Do nothing
    =import                                                       -   Import typeid resolutions from summary and globals
    =export                                                       -   Export typeid resolutions to summary and globals
  --wholeprogramdevirt-write-summary=<string>                     - Write summary to given bitcode or YAML file after running pass. Output file format is deduced from extension: *.bc means writing bitcode, otherwise YAML
  --write-relbf-to-summary                                        - Write relative block frequency to function summary 

Generic Options:

  -h                                                              - Alias for --help
  --help                                                          - Display available options (--help-hidden for more)
  --help-hidden                                                   - Display all available options
  --help-list                                                     - Display list of available options (--help-list-hidden for more)
  --help-list-hidden                                              - Display list of all available options
  --print-all-options                                             - Print all option values after command line parsing
  --print-options                                                 - Print non-default options after command line parsing
  --version                                                       - Display the version of this program

GlobalISel Combiner:
Control the rules which are enabled. These options all take a comma separated list of rules to disable and may be specified by number or number range (e.g. 1-10). They may also be specified by name.

  --amdgpupostlegalizercombinerhelper-disable-rule=<string>       - Disable one or more combiner rules temporarily in the AMDGPUPostLegalizerCombinerHelper pass
  --amdgpupostlegalizercombinerhelper-only-enable-rule=<string>   - Disable all rules in the AMDGPUPostLegalizerCombinerHelper pass then re-enable the specified ones
  --amdgpuprelegalizercombinerhelper-disable-rule=<string>        - Disable one or more combiner rules temporarily in the AMDGPUPreLegalizerCombinerHelper pass
  --amdgpuprelegalizercombinerhelper-only-enable-rule=<string>    - Disable all rules in the AMDGPUPreLegalizerCombinerHelper pass then re-enable the specified ones
  --amdgpuregbankcombinerhelper-disable-rule=<string>             - Disable one or more combiner rules temporarily in the AMDGPURegBankCombinerHelper pass
  --amdgpuregbankcombinerhelper-only-enable-rule=<string>         - Disable all rules in the AMDGPURegBankCombinerHelper pass then re-enable the specified ones

affine-super-vectorizer-test options:

  --backward-slicing                                              - Enable testing backward static slicing and topological sort functionalities
  --compose-maps                                                  - Enable testing the composition of AffineMap where each AffineMap in the composition is specified as the affine_map attribute in a constant op.
  --forward-slicing                                               - Enable testing forward static slicing and topological sort functionalities
  --slicing                                                       - Enable testing static slicing and topological sort functionalities
  --vector-shape-ratio=<int>                                      - Specify the HW vector size for vectorization
  --vectorize-affine-loop-nest                                    - Enable testing for the 'vectorizeAffineLoopNest' utility by vectorizing the outermost loops found

test-loop-fusion options:

  --test-loop-fusion-dependence-check                             - Enable testing of loop fusion dependence check
  --test-loop-fusion-slice-computation                            - Enable testing of loop fusion slice computation
  --test-loop-fusion-transformation                               - Enable testing of loop fusion transformation
`

export function help() : HelpDoc<Tk.MlirCpuRunner,string> {
  return {
    tool:Core.actor(Tk.MlirCpuRunner()),
    content:Content
}
}

