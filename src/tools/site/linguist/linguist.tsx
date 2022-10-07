import {Lang} from "../pkg"
import {Dist} from "../core/tokens"

export type Linguist = `${Lang}/linguist`
export type LinguistDist =`${Linguist}/${Dist}`
export type LinguistGrammars = `${LinguistDist}/grammars`

export function Linguist() : Linguist {
    return `${Lang()}/linguist`
}

export function LinguistDist() : LinguistDist {
    return `${Linguist()}/dist`
}

export function LinguistGrammars() : LinguistGrammars {
    return `${LinguistDist()}/grammars`
}
