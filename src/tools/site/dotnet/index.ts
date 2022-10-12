import {Literal,FolderName} from "./../core"
import { BoundVar,Var,bind } from "../core/env"

export const DOTNET_ROOT:Var<'DOTNET_ROOT'> = {
    name:'DOTNET_ROOT'
}

export type DOTNET_ROOT<R extends Literal> = BoundVar<'DOTNET_ROOT',FolderName<R>>

export function root<R extends Literal>(root:R) : DOTNET_ROOT<R>{
    return bind(DOTNET_ROOT,root)
}

