import {Actor} from "../core"
export type Name = `node`
export type Tool = Actor<Name>

export function Name(): Name {
    return 'node'
}
