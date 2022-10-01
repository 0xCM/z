import * as Core from "../core"

export type Name = 'cmd'
export type Tool = Core.Tool<Name>

export function name() : Name {
    return 'cmd'
}

export function tool(name:Name = 'cmd') : Tool {
    return Core.tool(name)
}

export const Refs = 
    [
        'https://learn.microsoft.com/en-us/windows-server/administration/windows-commands/cmd',
        'https://ss64.com/nt/cmd.html'
    ]

export type Syntax = `cmd [/c|/k] [/s] [/q] [/d] [/a|/u] [/t:{<b><f> | <f>}] [/e:{on | off}] [/f:{on | off}] [/v:{on | off}] [<string>]`

