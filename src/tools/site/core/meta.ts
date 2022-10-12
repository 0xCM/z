import { Literal } from "./literals";

export type Name<T extends Literal> = T

export type TypeExport<N extends Literal,T extends Literal> 
    = `export type ${Name<N>}='${T}'`

export function LiteralExport<N extends Literal,T extends Literal>(name:Name<N>, t:T) : TypeExport<N,T> {
    return `export type ${name}='${t}'`
}

export type ConstExport<N extends Literal, V extends Literal> 
    = `export const ${Name<N>}:${V} = '${V}'`
    export function ConstExport<N extends Literal,V extends Literal>(name:Name<N>, value:V) : ConstExport<N,V> {
    return `export const ${name}:${value} = '${value}'`
}


// export type CharDecl<C extends Literal> = 
// `
// export type ${C} = '${C}'
// export const ${C}:${C} = '${C}'
// `

export type NewLine = '\n'

export const NewLine:NewLine = '\n'

export function Char<C extends Literal>(c:C) {
    return  `export type ${c} = '${c}'` + `${NewLine}` + `export const ${c}:${c} = '${c}'`    
}