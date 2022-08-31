import * as Env from "../env"
type Area = `libs`
export function area() : Area {
    return 'libs'
}

export type Root = `${Env.SlnRoot}/${Area}`

export function root() : Root {
    return `${Env.parent()}/${area()}`
}