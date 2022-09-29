export type Tool = 'git'
export type SubCmd = 'submodule'
export type Quiet = '--quiet'
export type Cached = '--cached'
export type Add = 'add'
export type Status = 'status'
export type Init = 'init'
export type Deinit = 'deinit'
export type Update = 'update'
export type SetBranch = 'set-branch'
export type SetUrl = 'set-url'
export type Summary = 'summary'
export type ForEach = 'foreach'
export type Sync = 'sync'
export type Recursive = '--recursive'
export type Path= '<path>'
export type Force = '--force'
export type AbsorbGitDirs = 'absorbgitdirs'
export type Options = '<options>'
export type Repository = '<repository>'
export type Command = '<command>'
export type DashDash = '--'
export type TripleDot = '...'
export type NewUrl = '<newurl>'
export type All = '--all'
export type Empty = ''
export type Action = 
    | Empty
    | Add
    | Status
    | Init
    | Deinit
    | Update
    | SetBranch
    | SetUrl
    | Summary
    | ForEach
    | Sync
    | AbsorbGitDirs

export type Syntax =
    | ''
    | `${Tool} ${SubCmd} [${Quiet}] [${Cached}]`
    | `${Tool} ${SubCmd} [${Quiet}] ${Add} [${Options}] [${DashDash}] ${Repository} [${Path}]`
    | `${Tool} ${SubCmd} [${Quiet}] ${Status} [${Cached}] [${Recursive}] [${DashDash}] [${Path}${TripleDot}]`
    | `${Tool} ${SubCmd} [${Quiet}] ${Init} [${DashDash}] [${Path}${TripleDot}​​]`
    | `${Tool} ${SubCmd} [${Quiet}] ${Deinit} [${Force}] (${All}|[${DashDash}] ${Path}${TripleDot}​)`
    | `${Tool} ${SubCmd} [${Quiet}] ${Update} [${Options}] [${DashDash}] [${Path}${TripleDot}​]`
    | `${Tool} ${SubCmd} [${Quiet}] ${SetBranch} [${Options}] [${DashDash}] ${Path}`
    | `${Tool} ${SubCmd} [${Quiet}] ${SetUrl} [${DashDash}] ${Path} ${NewUrl}`
    | `${Tool} ${SubCmd} [${Quiet}] ${Summary} [${Options}] [${DashDash}] [${Path}${TripleDot}​]`
    | `${Tool} ${SubCmd} [${Quiet}] ${ForEach} [${Recursive}] ${Command}`
    | `${Tool} ${SubCmd} [${Quiet}] ${Sync} [${Recursive}] [${DashDash}] [${Path}${TripleDot}​]`
    | `${Tool} ${SubCmd} [${Quiet}] ${AbsorbGitDirs} [${DashDash}] [${Path}${TripleDot}​]`

export type SyntaxSpec = {
    action:Action
    syntax:Syntax
}

export function add() : Syntax {
    return 'git submodule [--quiet] add [<options>] [--] <repository> [<path>]';
}

export function status() : Syntax {
    return 'git submodule [--quiet] summary [<options>] [--] [<path>...​]';
}

export function init() : Syntax {
    return 'git submodule [--quiet] init [--] [<path>...​​]';
}

export function deinit() : Syntax {
    return 'git submodule [--quiet] deinit [--force] (--all|[--] <path>...​)';
}
    
export function update() : Syntax {
    return 'git submodule [--quiet] update [<options>] [--] [<path>...​]';
}
    
export function summary() : Syntax {
    return 'git submodule [--quiet] summary [<options>] [--] [<path>...​]';
}

export function setBranch() : Syntax {
    return 'git submodule [--quiet] set-branch [<options>] [--] <path>';
}

export function sync() : Syntax {
    return 'git submodule [--quiet] sync [--recursive] [--] [<path>...​]';
}

export function foreach() : Syntax {
    return 'git submodule [--quiet] foreach [--recursive] <command>';
}
    
export function quiet() : Quiet {
    return '--quiet'
}

export function cached() : Cached {
    return '--cached'
}

export function docurl() : URL {
    return new URL('https://git-scm.com/docs/git-submodule')
}


const _List = [
    add(),
    status(),
    init(),
    deinit(),
    update(),
    summary(),
    sync(),
    foreach(),
    setBranch(),
]

export type SubCmds = {
    doc:URL,
    syntax:Array<Syntax>
}

export function syntax() : SubCmds {
    return {
        doc:docurl(),
        syntax:_List
    }
}