import {Bind as Binder,Reify as Reification, Bound} from "./vars"

export type Number = number | bigint
export type Numeric<T extends Number> = T

export type Bool = boolean
export type String = string
export type Literal =  String | Number | Bool | 'x'
export type Identifier = String
export type Literals<T extends Literal> = Array<T>
export type Strings = Literals<String>
export type Numbers = Literals<Number>
export type Bools = Literals<Bool>
export type LiteralExpr = String

export type Names<K extends Literal> = {
    names:Array<K>
}

export type LiteralBinder<S extends Identifier,T extends Literal> = Binder<S,T>

export type Assign<N extends Literal,V extends Literal> = `${N}=${V}`

export type Concat<A extends Literal,B extends Literal,C extends Literal = ''> = `${A}${B}${C}`

function bind<S extends Identifier,T extends Literal>(src:S,dst:T) : Bound<S,T> {
    return {
        src,
        dst
    }
}

export function LiteralBinder<S extends Identifier,T extends Literal>() : LiteralBinder<S,T> {
    return bind
}

export type AssignLiteral<S extends Identifier,T extends Literal> = Reification<S,T,LiteralExpr>

function assign<S extends Identifier,T extends Literal>(bound:Bound<S,T>) : LiteralExpr {
    return `${bound.src}=${bound.dst}`
}

export function AssignLiteral<S extends Identifier,T extends Literal>() : AssignLiteral<S,T> {
    return {
        reify:assign
    }
}
