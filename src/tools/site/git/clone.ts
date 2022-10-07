import * as C from "./common"


export type Syntax 
    = `${C.Tool} ${C.Add} [--template=<template-directory>]`
    + `[-l] [-s] [--no-hardlinks] [-q] [-n] [--bare] [--mirror]`
    + `[-o <name>] [-b <name>] [-u <upload-pack>] [--reference <repository>]`
    + `[--dissociate] [--separate-git-dir <git-dir>]`
    + `[--depth <depth>] [--[no-]single-branch] [--no-tags]`
    + `[--recurse-submodules[=<pathspec>]] [--[no-]shallow-submodules]`
    + `[--[no-]remote-submodules] [--jobs <n>] [--sparse] [--[no-]reject-shallow]`
    + `[--filter=<filter> [--also-filter-submodules]] [--] <repository>`
    + `[<directory>]`

