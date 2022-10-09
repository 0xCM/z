
export type Syntax = 
`
lit [-h] [--version] [-j N] [--config-prefix NAME] [-D NAME=VAL] [-q]
           [-s] [-v] [-vv] [-a] [-o PATH] [--no-progress-bar]
           [--show-excluded] [--show-skipped] [--show-unsupported]
           [--show-pass] [--show-flakypass] [--show-xfail] [--path PATH]
           [--vg] [--vg-leak] [--vg-arg ARG] [--time-tests] [--no-execute]
           [--xunit-xml-output XUNIT_XML_OUTPUT]
           [--resultdb-output RESULTDB_OUTPUT]
           [--time-trace-output TIME_TRACE_OUTPUT]
           [--timeout MAXINDIVIDUALTESTTIME] [--max-failures MAX_FAILURES]
           [--allow-empty-runs] [--ignore-fail] [--no-indirectly-run-check]
           [--max-tests N] [--max-time N] [--order {lexical,random,smart}]
           [--shuffle] [-i] [--filter REGEX] [--filter-out REGEX]
           [--xfail LIST] [--xfail-not LIST] [--num-shards M] [--run-shard N]
           [--debug] [--show-suites] [--show-tests] [--show-used-features]
           TEST_PATH [TEST_PATH ...]
`