export type Tool = 'symstore'
export type Add = 'add'
export type Del = 'del'
export type Query = 'query'
export type SubCmd = Add | Del | Query

export type Spec =
    | '/p'
    | '/r'
    | '/l'
    | '/a'
    | '/o'
    | '/f'
    | '/s'
    | '/t'
    | '/v'
    | '/c'
    | '/d'
    | '/g'
    | '/x'

export type SpecHelpEntry = Kvp<Spec,string>


export type SpecHelp = Lookup<Spec,SpecHelpEntry>

export type Flag =
    | '/p'
    | '/r'
    | '/l'
    | '/a'
    | '/o'

export type File = `/f {File}`
export type Store = '/s {Store}'
export type Product = '/t {Product}'
export type Version = '/v {Version'
export type Comment = '/c {Comment}'
export type LogFile = '/d {LogFile}'
export type Share = '/g {Share}'
export type IndexFile = '/x {IndexFile}'

export type Option =
    | File
    | Store
    | Product
    | Version
    | Comment
    | LogFile
    | Share

import {Lookup, Kvp, kvp, KeyedValues} from "../common"

export function tool() : Tool {
    return 'symstore'
}

export function add() : Add {
    return 'add'
}

export function del() : Del {
    return 'del'
}

export function query() : Query {
    return 'query'
}

export function p() {
    return '/p'
}

export type Syntax =
    | ''
    | `${Add} [/r] [/p] [/l] /f File /s Store /t Product [/v Version] [/c Comment] [/d LogFile] [/compress [type]]`
    | `${Add} [/r] [/p] [/l] [/q] /g Share /f File /x IndexFile [/a] [/d LogFile]`
    | `${Add} /y IndexFile /g Share /s Store [/p] /t Product [/v Version] [/c Comment] [/d LogFile] [/compress [type]]`
    | `${Del} /i ID /s Store [/d LogFile]`
    | `${Query} [/r] [/o] /f File /s Store`


export function syntax(index:number) : Syntax {
    var dst:Syntax = ''
    switch(index)
    {
        case 1:dst = 'add [/r] [/p] [/l] /f File /s Store /t Product [/v Version] [/c Comment] [/d LogFile] [/compress [type]]'
        case 2:dst = 'add [/r] [/p] [/l] [/q] /g Share /f File /x IndexFile [/a] [/d LogFile]'
        case 3:dst = 'add /y IndexFile /g Share /s Store [/p] /t Product [/v Version] [/c Comment] [/d LogFile] [/compress [type]]'
        case 4:dst='del /i ID /s Store [/d LogFile]'
        case 5:dst='query [/r] [/o] /f File /s Store'
    }
    return dst;
}

export type FlagHelpEntry = {
    flag:Flag
    description:string
}

function spec(spec:Spec, desc:string) : SpecHelpEntry {
    return kvp(spec,desc)
}

export type ToolHelp = {
    tool:Tool
    specs:KeyedValues<Spec,string>
}


export const Help : ToolHelp = {
    tool:tool(),
    specs:[
        spec('/a',''),
        spec('/f','')
    ]
}
