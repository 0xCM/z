import {Literal} from "./literals"
import * as V from "./vars"

export type EnvVar<N extends Literal> = V.Var<N>

export type BoundEnvVar<N extends Literal,V extends Literal> = `${N}=${V}`

export function envbind<N extends Literal,V extends Literal>(src:EnvVar<N>, dst:V) : BoundEnvVar<N,V> {
    return `${src.name}=${dst}`
}

