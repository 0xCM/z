export type EnvRoot='b:'
export type TsProject=`toolsets`
export type TsRoot=`${EnvRoot}/devops/modules/${TsProject}`
export type Parent=`${EnvRoot}/devops/modules`
export type TsIndex=`${TsRoot}/index.ts`
export type Global=`${EnvRoot}/tools`

export type CsProject=`tools`
type ZDev='d:/drives/z/dev/z0'
type CsRoot=`${ZDev}/libs/${CsProject}`

const tsProject:TsProject ='toolsets'
const root:EnvRoot = 'b:'
const csProject:CsProject = 'tools'
const zDev:ZDev='d:/drives/z/dev/z0'
const env:EnvRoot='b:'
export const global:Global=`${root}/tools`
const tsRoot:TsRoot=`${env}/devops/modules/${tsProject}`
const csRoot:CsRoot=`${zDev}/libs/${csProject}`
const tsIndex:TsIndex=`${tsRoot}/index.ts`

export type Config = {
    tsProject:TsProject,
    tsRoot:TsRoot,
    csProject:CsProject,
    csRoot:CsRoot,
    tsIndex:TsIndex
}

export const config : Config = {
    tsProject:tsProject,
    tsRoot:tsRoot,
    csProject:csProject,
    csRoot:csRoot,
    tsIndex:tsIndex
}

export interface Tool<T,G,D,P> {
    tool:T,
    group:G,
    dist:D,
    path:P
}

