export type CmdName = 'ghcup/install/ghc'
export type CmdId='ghcup-install-ghc'
export interface SymVer {
    major:number
    minor:number
    patch:number
}

export class SymVer implements SymVer {

   public format() {
        return `${this.major}.${this.minor}.${this.patch}`
   }
}

export function template() {
    return 'ghcup install ghc ${Version} --cache'
}

export function cmd(ver:SymVer) {
    return `ghcup install ghc ${ver.format()}`
}

export function name() : CmdName {
    return 'ghcup/install/ghc'
}

export function id() : CmdId {
    return 'ghcup-install-ghc'
}