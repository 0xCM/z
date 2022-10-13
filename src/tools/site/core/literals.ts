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


export interface Valued<V> {
    value:V
}


export type Context<C> = {
    context:C
}

export type Scope<C,S> = {
    context:Context<C>
    scope:S
}

export type Names<K extends Literal> = {
    names:Array<K>
}

export interface Kinded<K> {
    kind:K
}

export interface Class<K,C> extends Kinded<K> {
    class:C
}
export type Const<T> = T

export type EmptyString = Const<''>

export type Null<T=null> = Const<null>


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

export interface Named<N extends Literal> {
    name:N
}

export interface Locatable<L extends Literal> {
    location:L
}

export interface Locator<L extends Literal>  {
    readonly locate: (locatable: L) => URL
}