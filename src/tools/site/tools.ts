import * as Pip from "./pip"
import * as RoboCopy from "./robocopy"
import * as Python from "./python"
import {actor as _tool} from "./core"

export type ToolName =
    | Pip.Name
    | RoboCopy.Name
    | Python.Name


export function tool<T extends ToolName>(name:T)  {
        return _tool(name)
    }
    
export const Tools = [
        tool('pip'),
        tool('python'),
        tool('robocopy')
    ]

