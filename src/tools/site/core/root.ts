import {Literal,Named} from "./literals"

export type RootKind =
    | 'env'
    | 'dev'
    | 'tools'
    | 'sdks'
    | 'lang'
    | 'project'
    | 'sln'
    | 'vendor'

export type Root<K extends RootKind,B> = {
    kind:K
    base:B
}

export type EnvRoot<R extends Literal> = Root<'env',R>
export type DevRoot<R extends Literal> = Root<'dev',R>
export type LangRoot<R extends Literal> = Root<'lang',R>
export type Sdks<R extends Literal> = Root<'sdks',R>
export type ToolRoot<R extends Literal> = Root<'tools',R>

export interface Sdk<N extends Literal> extends Named<N>{

}
