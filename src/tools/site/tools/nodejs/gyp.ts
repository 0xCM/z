import {Actor} from "../imports"
export type Name = 'gyp'
export type Tool = Actor<Name>

export interface Options {

}

export type Syntax = `gyp [options ...] [build_file ...]`

export const HelpDoc = 
`
usage: usage: gyp [options ...] [build_file ...]

optional arguments:
  -h, --help            show this help message and exit
  --build CONFIGS       configuration for build after project generation
  --check               check format of gyp files
  --config-dir CONFIG_DIR
                        The location for configuration files like
                        include.gypi.
  -d DEBUGMODE, --debug DEBUGMODE
                        turn on a debugging mode for debugging GYP. Supported
                        modes are "variables", "includes" and "general" or
                        "all" for all of them.
  -D VAR=VAL            sets variable VAR to value VAL
  --depth PATH          set DEPTH gyp variable to a relative path to PATH
  -f FORMATS, --format FORMATS
                        output formats to generate
  -G FLAG=VAL           sets generator flag FLAG to VAL
  --generator-output DIR
                        puts generated build files under DIR
  --ignore-environment  do not read options from environment variables
  -I INCLUDE, --include INCLUDE
                        files to include in all loaded .gyp files
  --no-circular-check   don't check for circular relationships between files
  --no-duplicate-basename-check
                        don't check for duplicate basenames
  --no-parallel         Disable multiprocessing
  -S SUFFIX, --suffix SUFFIX
                        suffix to add to generated files
  --toplevel-dir DIR    directory to use as the root of the source tree
  -R TARGET, --root-target TARGET
                        include only TARGET and its deep dependencies
`