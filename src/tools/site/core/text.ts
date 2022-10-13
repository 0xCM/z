import {Literal} from "./literals"
import * as A from "./utf7"
import { DQuote,LBrace,RBrace} from "./utf7"

export type Text<N> = {
    value:String,
    max:N
}

export type Fence<L extends Literal,C extends Literal, R extends Literal> = `${L}${C}${R}`

export function fence<L extends Literal,C extends Literal, R extends Literal>(left:L, content:C, right:R) : Fence<L,C,R> {
    return `${left}${content}${right}`
}

export type Quoted<C extends Literal> = Fence<DQuote, C, DQuote>

export function quote<C extends Literal>(content:C) : Quoted<C> {
    return `${DQuote}${content}${DQuote}`
}

export type Embraced<C extends Literal> = Fence<LBrace,C,RBrace>
