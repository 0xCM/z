import {Literal} from "./core"
import {root,DOTNET_ROOT} from "./dotnet"

export interface EnvProvider {
    DotNetRoot<R extends Literal>(root:R) : DOTNET_ROOT<R>
}
    
export const EnvProvider = {
    DotnetRoot:root
}

