import * as Install from "./install-ghc"

export interface GhcUpCmd<I,N> {
    id:I
    name:N
    template:string
}

export const InstallGhcCmd : GhcUpCmd<Install.CmdId,Install.CmdName>  = {
    id:Install.id(),
    name:Install.name(),
    template:`${Install.id()}=${Install.template()}`
}
