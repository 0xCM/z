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
    | 'push'
    | 'restore'
    | 'search'
    | 'setApiKey'
    | 'sign'
    | 'sources'
    | 'spec'
    | 'trusted-signers'
    | 'update'
    | 'verify'
