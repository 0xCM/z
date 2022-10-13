export type Tool = 'symcheck'
export type SymbolPath = '/s'
export type Recursive = '/r'
export type FileNames = `{FileNames}`
export type Symbols = `{Symbols}`

import {Script} from "../imports"

function tool() : Tool {
    return 'symcheck'
}

export function s() : SymbolPath {
    return '/s'
}

export function r() : Recursive {
    return `/r`
}

export type Syntax = `${Tool} [${Recursive}] ${FileNames} ${SymbolPath} ${Symbols}`

export function script(symbols:SymbolPath, recursive?:Recursive) : Script {
    
    var cmd = `${tool()} ${s()} ${symbols}`
    if(recursive != null && recursive)
        cmd += ` ${r()}`
    return cmd;
}

export function syntax() : Syntax {
    return 'symcheck [/r] {FileNames} /s {Symbols}'
}