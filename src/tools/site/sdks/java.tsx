import {SdkRoot} from "./root"
import {Bin} from "../core/tokens"

export type JavaSdks = `${SdkRoot}/jdk`
export function JavaSdks() : JavaSdks{
    return `${SdkRoot()}/jdk`
}

export type MsJdkRoot = `${JavaSdks}/ms`
export function MsJdkRoot() : MsJdkRoot {
    return `${JavaSdks()}/ms`
}

export type MsJdkVer = 'v17.0.4.1'
export function MsJdkVer() : MsJdkVer {
    return 'v17.0.4.1'
}

export type MsJdkHome = `${MsJdkRoot}/${MsJdkVer}`
export function MsJdkHome() : MsJdkHome {
    return `${MsJdkRoot()}/${MsJdkVer()}`    
}

export type MsJdkBin = `${MsJdkHome}/${Bin}`
export function MsJdkBin() : MsJdkBin {
    return `${MsJdkHome()}/${Bin()}`
}
export type ZuluJdkRoot = `${JavaSdks}/zulu`
export function ZuluSdkRoot() : ZuluJdkRoot {
    return `${JavaSdks()}/zulu`
}

export type ZuluJdkBin = `${ZuluJdkRoot}/bin/current`
export function ZuluJdkBin() : ZuluJdkBin {
    return `${ZuluSdkRoot()}/${Bin()}/current`
}
