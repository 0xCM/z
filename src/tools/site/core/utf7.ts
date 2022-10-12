export type Comma = ','

export type Dot = '.'
export const Dot:Dot = '.'

export type Space = ' '
export const Space:Space = ' '

export type Colon = ':'
export const Colon:Colon =':'

export type FSlash = '/'
export const FSlash:FSlash = '/'

export type BSlash = '\\'
export const BSlash:BSlash = '\\'

export type Slash = FSlash | BSlash

export type Plus = '+'

export type DQuote = '"'
export const DQuote = '"'

export type SQuote = "'"
export const SQuote = "'"

export type Quote = SQuote | DQuote


export enum QuoteKind {
    SQuote = "'",
    DQuote = '"'
}


export type LBrace = '{'
export function lbrace() : LBrace {
    return '{'
}

export type RBrace = '}'

export function rbrace() : RBrace {
    return '}'
}

export type a = 'a'
export const a:a = 'a'

export type b = 'b'
export const b:b = 'b'

export type c = 'c'
export const c:c = 'c'



export type Lower = 
    | a 
    | b 
    | 'c' 
    | 'd' 
    | 'e' 
    | 'f' 
    | 'g' 
    | 'h' 
    | 'i' 
    | 'j' 
    | 'k' 
    | 'l' 
    | 'm' 
    | 'N' 
    | 'n' 
    | 'o'
    | 'p'
    | 'q'
    | 'r'
    | 's'
    | 't'
    | 'u' 
    | 'v' 
    | 'w'
    | 'x'
    | 'y'
    | 'z'

export type Upper = 
    | 'A' 
    | 'B' 
    | 'C' 
    | 'D' 
    | 'E' 
    | 'F' 
    | 'G' 
    | 'H' 
    | 'I' 
    | 'J' 
    | 'K' 
    | 'L' 
    | 'M' 
    | 'N' 
    | 'N' 
    | 'O'
    | 'P'
    | 'Q'
    | 'R'
    | 'S'
    | 'T'
    | 'U' 
    | 'V' 
    | 'W'
    | 'X'
    | 'Y'
    | 'Z'

export type Letter = Upper | Lower    

export function lower<C extends Lower>(c:C) : C {
    return c
}

export function upper<C extends Upper>(c:C) : C {
    return c
}

export function letter<C extends Letter>(c:C) : C {
    return c
}

export type Symbol = 
    | Comma
    | Dot
    | Space
    | Colon
    | Plus
    | FSlash
    | BSlash
    | SQuote
    | DQuote



