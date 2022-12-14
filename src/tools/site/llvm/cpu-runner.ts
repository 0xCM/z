import {HelpDoc} from "../core"
import * as Core from "../core"
import {LlvmTool } from "./tokens"

const Content  = `
OVERVIEW: MLIR CPU execution driver

USAGE: mlir-cpu-runner.exe [options] <input file>

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
  --allow-unroll-and-jam                                          - Allows loops to be unroll-and-jammed.
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
    =attributor-manifest                                          -   Determine what attributes are manifested in the IR
    =machine-cp-fwd                                               -   Controls which register COPYs are forwarded
    =conds-eliminated                                             -   Controls which conditions are eliminated
    =dse-memoryssa                                                -   Controls which MemoryDefs are eliminated.
    =div-rem-pairs-transform                                      -   Controls transformations in div-rem-pairs pass
    =early-cse                                                    -   Controls which instructions are removed
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
  --debug-orc-print-callable                                      - debug print callable symbols defined by materialization units
  --debug-orc-print-data                                          - debug print data symbols defined by materialization units
  --debug-orc-print-hidden                                        - debug print hidden symbols defined by materialization units
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
  --disable-spill-fusing                                          - Disable fusing of spill code into instructions
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
  --disable-x86-domain-reassignment                               - X86: Disable Virtual Register Reassignment.
  --disable-x86-lea-opt                                           - X86: Disable LEA optimizations.
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
  --dump-object-file                                              - Dump JITted-compiled object to file specified with -object-filename (<input file>.o by default).
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
  -e <<function name>>                                            - The function to be called
  --eagerly-invalidate-analyses                                   - Eagerly invalidate more analyses in default pipelines
  --early-ifcvt-limit=<uint>                                      - Maximum number of instructions per speculated block.
  --early-live-intervals                                          - Run live interval analysis earlier in the pipeline
  --earlycse-debug-hash                                           - Perform extra assertion checking to verify that SimpleValue's hash function is well-behaved w.r.t. its isEqual predicate
  --earlycse-mssa-optimization-cap=<uint>                         - Enable imprecision in EarlyCSE in pathological cases, in exchange for faster compile. Caps the MemorySSA clobbering calls.
  --emulate-old-livedebugvalues                                   - Act like old LiveDebugValues did
  --enable-aa-sched-mi                                            - Enable use of AA during MI DAG construction
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
  --enable-x86-scalar-amx                                         - X86: enable AMX scalarizition.
  --entry-point-result=<f32 | i32 | i64 | void>                   - Textual description of the function type to be called
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
  --fixup-byte-word-insts                                         - Change byte and word instructions to larger sizes
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
  --mark-data-regions                                             - Mark code section jump table data regions.
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
  --mul-constant-optimization                                     - Replace 'mul x, Const' with more effective instructions like SHIFT, LEA, etc.
  --no-discriminators                                             - Disable generation of discriminator information.
  --no-dwarf-ranges-section                                       - Disable emission .debug_ranges section.
  --no-pgo-warn-mismatch                                          - Use this option to turn off/on warnings about profile cfg mismatch.
  --no-pgo-warn-mismatch-comdat-weak                              - The option is used to turn on/off warnings about hash mismatch for comdat or weak functions.
  --no-phi-elim-live-out-early-exit                               - Do not use an early exit if isLiveOutPastPHIs returns true.
  --no-stack-coloring                                             - Disable stack coloring
  --no-stack-slot-sharing                                         - Suppress slot sharing during stack coloring
  --no-warn-sample-unused                                         - Use this option to turn off/on warnings about function with samples but without debug information to use those samples. 
  --no-x86-call-frame-opt                                         - Avoid optimizing x86 call frames for size
  --non-global-value-max-name-size=<uint>                         - Maximum size for the name of non-global values.
  --object-filename=<string>                                      - Dump JITted-compiled object to file <input file>.o
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
  --partial-reg-update-clearance=<uint>                           - Clearance between two register writes for inserting XOR to avoid partial register update
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
  --prefetch-hints-file=<string>                                  - Path to the prefetch hints profile. See also -x86-discriminate-memops
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
  --print-failed-fuse-candidates                                  - Print instructions that the allocator wants to fuse, but the X86 backend currently can't
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
  --rafast-ignore-missing-defs                                    - 
  --rdf-liveness-max-rec=<uint>                                   - Maximum recursion level
  --reassociate-geps-verify-no-dead-code                          - Verify this pass produces no dead code
  --recurrence-chain-limit=<uint>                                 - Maximum length of recurrence chain when evaluating the benefit of commuting operands
  --recursive-inline-max-stacksize=<ulong>                        - Do not inline recursive functions with a stack size that exceeds the specified limit
  --regalloc=<value>                                              - Register allocator to use
    =greedy                                                       -   greedy register allocator
    =default                                                      -   pick register allocator based on -O option
    =fast                                                         -   fast register allocator
    =basic                                                        -   basic register allocator
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
  --remat-pic-stub-load                                           - Re-materialize load from stub in PIC mode
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
  --undef-reg-clearance=<uint>                                    - How many idle instructions we would like before certain undef register reads
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
  --verify-dom-info                                               - Verify dominator info (time consuming)
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
  --x86-align-branch=<string>                                     - Specify types of branches to align (plus separated list of types):
                                                                    jcc      indicates conditional jumps
                                                                    fused    indicates fused conditional jumps
                                                                    jmp      indicates direct unconditional jumps
                                                                    call     indicates direct and indirect calls
                                                                    ret      indicates rets
                                                                    indirect indicates indirect unconditional jumps
  --x86-align-branch-boundary=<uint>                              - Control how the assembler should align branches with NOP. If the boundary's size is not 0, it should be a power of 2 and no less than 32. Branches will be aligned to prevent from being across or against the boundary of specified size. The default value 0 does not align branches.
  --x86-and-imm-shrink                                            - Enable setting constant bits to reduce size of mask immediates
  --x86-asm-syntax=<value>                                        - Choose style of code to emit from X86 backend:
    =att                                                          -   Emit AT&T-style assembly
    =intel                                                        -   Emit Intel-style assembly
  --x86-branches-within-32B-boundaries                            - Align selected instructions to mitigate negative performance impact of Intel's micro code update for errata skx102.  May break assumptions about labels corresponding to particular instructions, and should be used with caution.
  --x86-bypass-prefetch-instructions                              - When discriminating instructions with memory operands, ignore prefetch instructions. This ensures the other memory operand instructions have the same identifiers after inserting prefetches, allowing for successive insertions.
  --x86-cmov-converter                                            - Enable the X86 cmov-to-branch optimization.
  --x86-cmov-converter-force-all                                  - Convert all cmovs to branches.
  --x86-cmov-converter-force-mem-operand                          - Convert cmovs to branches whenever they have memory operands.
  --x86-cmov-converter-threshold=<uint>                           - Minimum gain per loop (in cycles) threshold.
  --x86-disable-avoid-SFB                                         - X86: Disable Store Forwarding Blocks fixup.
  --x86-discriminate-memops                                       - Generate unique debug info for each instruction with a memory operand. Should be enabled for profile-driven cache prefetching, both in the build of the binary being profiled, as well as in the build of the binary consuming the profile.
  --x86-early-ifcvt                                               - Enable early if-conversion on X86
  --x86-experimental-lvi-inline-asm-hardening                     - Harden inline assembly code that may be vulnerable to Load Value Injection (LVI). This feature is experimental.
  --x86-experimental-pref-innermost-loop-alignment=<int>          - Sets the preferable loop alignment for experiments (as log2 bytes) for innermost loops only. If specified, this option overrides alignment set by x86-experimental-pref-loop-alignment.
  --x86-experimental-unordered-atomic-isel                        - Use LoadSDNode and StoreSDNode instead of AtomicSDNode for unordered atomic loads and stores respectively.
  --x86-indirect-branch-tracking                                  - Enable X86 indirect branch tracking pass.
  --x86-lvi-load-dot                                              - For each function, emit a dot graph depicting potential LVI gadgets
  --x86-lvi-load-dot-only                                         - For each function, emit a dot graph depicting potential LVI gadgets, and do not insert any fences
  --x86-lvi-load-dot-verify                                       - For each function, emit a dot graph to stdout depicting potential LVI gadgets, used for testing purposes only
  --x86-lvi-load-no-cbranch                                       - Don't treat conditional branches as disclosure gadgets. This may improve performance, at the cost of security.
  --x86-lvi-load-opt-plugin=<string>                              - Specify a plugin to optimize LFENCE insertion
  --x86-machine-combiner                                          - Enable the machine combiner pass
  --x86-pad-for-align                                             - Pad previous instructions to implement align directives
  --x86-pad-for-branch-align                                      - Pad previous instructions to implement branch alignment
  --x86-pad-max-prefix-size=<uint>                                - Maximum number of prefixes to use for padding
  --x86-promote-anyext-load                                       - Enable promoting aligned anyext load to wider load
  --x86-seses-enable-without-lvi-cfi                              - Force enable speculative execution side effect suppression. (Note: User must pass -mlvi-cfi in order to mitigate indirect branches and returns.)
  --x86-seses-omit-branch-lfences                                 - Omit all lfences before branch instructions.
  --x86-seses-one-lfence-per-bb                                   - Omit all lfences other than the first to be placed in a basic block.
  --x86-seses-only-lfence-non-const                               - Only lfence before groups of terminators where at least one branch instruction has an input to the addressing mode that is a register other than %rip.
  --x86-sfb-inspection-limit=<uint>                               - X86: Number of instructions backward to inspect for store forwarding blocks.
  --x86-slh-fence-call-and-ret                                    - Use a full speculation fence to harden both call and ret edges rather than a lighter weight mitigation.
  --x86-slh-indirect                                              - Harden indirect calls and jumps against using speculatively stored attacker controlled addresses. This is designed to mitigate Spectre v1.2 style attacks.
  --x86-slh-ip                                                    - Harden interprocedurally by passing our state in and out of functions in the high bits of the stack pointer.
  --x86-slh-lfence                                                - Use LFENCE along each conditional edge to harden against speculative loads rather than conditional movs and poisoned pointers.
  --x86-slh-loads                                                 - Sanitize loads from memory. When disable, no significant security is provided.
  --x86-slh-post-load                                             - Harden the value loaded *after* it is loaded by flushing the loaded bits to 1. This is hard to do in general but can be done easily for GPRs.
  --x86-speculative-load-hardening                                - Force enable speculative load hardening
  --x86-tile-ra                                                   - Enable the tile register allocation pass
  --x86-use-base-pointer                                          - Enable use of a base pointer for complex stack frames
  --x86-use-fsrm-for-memcpy                                       - Use fast short rep mov in memcpy lowering
  --x86-use-vzeroupper                                            - Minimize AVX to SSE transition penalty

Generic Options:

  -h                                                              - Alias for --help
  --help                                                          - Display available options (--help-hidden for more)
  --help-hidden                                                   - Display all available options
  --help-list                                                     - Display list of available options (--help-list-hidden for more)
  --help-list-hidden                                              - Display list of all available options
  --print-all-options                                             - Print all option values after command line parsing
  --print-options                                                 - Print non-default options after command line parsing
  --version                                                       - Display the version of this program

linking options:

  --shared-libs=<string>                                          - Libraries to link dynamically

opt-like flags:

  --O0                                                            - Run opt passes and codegen at O0
  --O1                                                            - Run opt passes and codegen at O1
  --O2                                                            - Run opt passes and codegen at O2
  --O3                                                            - Run opt passes and codegen at O3
`

export function help() : HelpDoc<LlvmTool,string> {
    return {
        tool:Core.actor('mlir-opt'),
        content:Content
    }
}
