import {Actor,Tk} from "../imports"
export type Name = `ninja`
export type Tool = Actor<Name>

export type Browse = 'browse'
export type Msvc = 'msvc'
export type Clean = 'clean'
export type Commands = 'commands'
export type Deps = 'deps'
export type Graph = 'graph'
export type Query = 'query'
export type Targets = 'targets'
export type CompDb = 'compdb'
export type Restat = 'restat'
export type Rules = 'rules'
export type Recompact = 'recompact'
export type CleanDead = 'cleandead'

export type SubCmd =
    | Browse
    | Msvc
    | Clean
    | Commands
    | Deps
    | Graph
    | Query
    | Targets
    | CompDb
    | Recompact
    | Restat
    | Rules
    | CleanDead

export type Option =
    | `--${Tk.Version}`
    | `--${Tk.Verbose}`

export const HelpCmd= [
    'ninja --help 2> ninja.help',
    'ninja -t list > ninja.tools.help'
]