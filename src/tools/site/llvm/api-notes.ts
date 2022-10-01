import {LlvmTool} from "./LlvmNames"
import {HelpDoc} from "../core"

const Content=
`USAGE: apinotes-test.exe [options] [<apinotes> ...]

OPTIONS:

Color Options:

  --color                                 - Use colors in output (default=autodetect)

General options:

  --crash-diagnostics-dir=<directory>     - Directory for crash diagnostic files.
  --debug                                 - Enable debug output
  --debug-buffer-size=<uint>              - Buffer the last N characters of debug output until program termination. [default 0 -- immediate print-out]
  -debug-counter                          - Comma separated list of debug counter skip and count
  --debug-only=<debug string>             - Enable a specific type of debug output (comma separated list of types)
  --disable-symbolication                 - Disable symbolizing crash backtraces.
  --info-output-file=<filename>           - File to append -stats and -timer output to
  -o <filename>                           - output filename
  --print-debug-counter                   - Print out debug counter info after all counters accumulated
  --rng-seed=<seed>                       - Seed for the random number generator
  --sort-timers                           - In the report, sort the timers in each group in wall clock time order
  --stats                                 - Enable statistics output from program (available with Asserts)
  --stats-json                            - Display statistics as json data
  --track-memory                          - Enable -time-passes memory tracking (this may be slow)
  --treat-scalable-fixed-error-as-warning - Treat issues where a fixed-width property is requested from a scalable type as a warning, instead of an error

Generic Options:

  -h                                      - Alias for --help
  --help                                  - Display available options (--help-hidden for more)
  --help-hidden                           - Display all available options
  --help-list                             - Display list of available options (--help-list-hidden for more)
  --help-list-hidden                      - Display list of all available options
  --print-all-options                     - Print all option values after command line parsing
  --print-options                         - Print non-default options after command line parsing
  --version                               - Display the version of this program
`

export function help() : HelpDoc<LlvmTool> {
  return {
      tool:'mlir-cpu-runner',
      content:Content
  }
}