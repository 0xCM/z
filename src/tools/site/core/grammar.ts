import {Mapper} from "./common"

import {Symbol} from "./utf7"

export type Binder<S> = Mapper<S,string>

export type Required<E extends string> = `<${E}>`

export type Optional<E extends string> = `[${E}]`

export type Eiter<L extends string,R extends string> = `${L} | ${R}`

export function bind<S>(src:S) : string {
    return `${src}`
}

export function required<E extends string>(e:E) : Binder<Required<E>> {
    return e => bind(e)
}

export function optional<E extends string>(e:E) : Binder<Optional<E>> {
    return e => bind(e)
}

export type Join<K extends Symbol,E0 extends string, E1 extends string> = `${E0}${K}${E1}`

export function join<K extends Symbol,E0 extends string,E1 extends string>(kind:K,e0:E0,e1:E1) : Join<K,E0,E1> {
    return `${e0}${kind}${e1}`
}
