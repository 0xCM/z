import {Actor,Folder, Literal,Text} from "../imports"
export type Name = `symlink`

export function Name() : Name {
    return  'symlink'
}
export type Tool = Actor<Name>


export type Syntax<S extends Literal, T extends Literal> = `${Name} ${Text.Quoted<S>} ${Text.Quoted<T>}`

export function symlink<S extends Literal, T extends Literal>(source:S, target:T) : Syntax<S,T> {
    return `${Name()} ${Text.quote(source)} ${Text.quote(target)}`
}