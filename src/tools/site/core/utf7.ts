export type Comma = ','

export type Dot = '.'

export type Space = ' '

export type Colon = ':'

export type FSlash = '/'

export type BSlash = '\\'

export type Plus = '+'

export type Lower = 
    | 'a' 
    | 'b' 
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
