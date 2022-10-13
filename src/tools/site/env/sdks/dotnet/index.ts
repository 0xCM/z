import {Literal,FolderName,BoundVar,Var,bind } from "../imports"

export const DOTNET_ROOT:Var<'DOTNET_ROOT'> = {
    name:'DOTNET_ROOT'
}

export type DOTNET_ROOT<E extends Literal,R extends Literal> = BoundVar<E,'DOTNET_ROOT',FolderName<R>>

// export function root<E,R extends Literal>(env:E,root:R) : DOTNET_ROOT<E,R>{
//     return bind(env,DOTNET_ROOT,root)
// }

