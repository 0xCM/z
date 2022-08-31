import * as Env from "../env"
export type ProjectId = `tools`
export type Root = `${Env.Root}/${ProjectId}`
export function root(): Root {
    return `${Env.root()}/tools`
}
