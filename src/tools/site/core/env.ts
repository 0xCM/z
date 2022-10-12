import {Literal} from "./literals"
import * as V from "./vars"

export type Var<N extends Literal> = V.Var<N>

export type BoundVar<N extends Literal,V extends Literal> = `${N}=${V}`

export function bind<N extends Literal,V extends Literal>(src:Var<N>, dst:V) : BoundVar<N,V> {
    return `${src.name}=${dst}`
}

