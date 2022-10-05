export type Tool = 'nuget'
export type Add = 'add'
export type ClientCerts = 'client-certs'
export type Config = 'config'
export type Delete = 'delete'
export type Help = 'help'
export type Init = 'init'
export type Install = 'install'
export type List = 'list'
export type Locals = 'locals'
export type Pack = 'pack'
export type Push = 'push'
export type Restore = 'restore'
export type Search = 'search'
export type SetApiKey = 'setApiKey'
export type SubCmd = 
    | Add
    | ClientCerts
    | Config
    | Delete
    | Help
    | Init
    | Install
    | List
    | Locals
    | Pack
    | Push
    | Restore
    | Search
    | 'setApiKey'
    | 'sign'
    | 'sources'
    | 'spec'
    | 'trusted-signers'
    | 'update'
    | 'verify'

    export function expand(src:string, dst:string){
        return `nuget init "${src}" -expand "${dst}"`
    }
    
    function run(){
        return expand('D:/cache/packages/devpacks/nuget/incoming', 'D:/cache/packages/devpacks/nuget/packages')
    }
    
    console.log(run());    