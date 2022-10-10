import {Folder, CmdFactory,CmdDef,Literal} from "../../core"
import {CmdKind} from "./common"

export type Name = 'create-ecma-index'

export function Name() : Name {
    return 'create-ecma-index'
}

export type Cmd<S extends Literal,T extends Literal> 
    = CmdDef<CmdKind,Name, Folder<S>, Folder<T>>

export function Cmd<S extends Literal,T extends Literal>(source:Folder<S>, target:Folder<T>) : Cmd<S,T>  {
    return CmdFactory.define(CmdKind(), Name(),source,target)
}
