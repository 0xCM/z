import {Actor} from "../imports"
export type Name = `node`
export type Tool = Actor<Name>

export function Name(): Name {
    return 'node'
}
