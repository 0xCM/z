import {Literal} from "./literals"

export type EnvVar<N,V> = {
    name:N
    value:V
}

export function EnvVar<N,V>(name:N,value:V) : EnvVar<N,V> {
    return {
        name,
        value
    }
}

export type SetEnvVar<N extends Literal,V extends Literal> = `${N}=${V}`
