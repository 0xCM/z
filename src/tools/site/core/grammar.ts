import {Mapper,Literal} from "./common"

import {Symbol} from "./utf7"

export type Binder<S> = Mapper<S,Literal>

export type Required<E extends Literal> = `<${E}>`

export type Optional<E extends Literal> = `[${E}]`

export type Eiter<L extends Literal,R extends Literal> = `${L} | ${R}`

export function bind<S>(src:S) : Literal {
    return `${src}`
}

export function required<E extends string>(e:E) : Binder<Required<E>> {
    return e => bind(e)
}

export function optional<E extends string>(e:E) : Binder<Optional<E>> {
    return e => bind(e)
}

export type Join<K extends Symbol,E0 extends Literal, E1 extends Literal> = `${E0}${K}${E1}`

export function join<K extends Symbol,E0 extends Literal,E1 extends Literal>(kind:K,e0:E0,e1:E1) : Join<K,E0,E1> {
    return `${e0}${kind}${e1}`
}

export function oneof<A,B,C=null>(a:A,b:B,c?:C) : Literal {    
    var dst = `${a}|${b}`
    if(c != null)
        dst += `|${c}`
    return dst
}

