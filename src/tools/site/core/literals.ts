import {Bind as Binder,Reify as Reification, Bound} from "./vars"
import {Null} from "./common"

export type Number = number | bigint
export type Bool = boolean
export type String = string
export type Literal =  String | Number | Bool | 'x'

export type Identifier = String
export type LiteralsSeq<T extends Literal> = Array<T>
export type Strings = LiteralsSeq<String>
export type Numbers = LiteralsSeq<Number>
export type Bools = LiteralsSeq<Bool>
export type Literals = Strings | Numbers | Bools
export type LiteralExpr = String

export type LiteralBinder<S extends Identifier,T extends Literal> = Binder<S,T>

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

export type Assign<N extends Literal,V extends Literal> = `${N}=${V}`


export type Concat<A extends Literal,B extends Literal,C extends Literal = ''> = `${A}${B}${C}`

