// export type NUGET_PACKAGES = 'NUGET_PACKAGES'

// export type VCPKG_ROOT = 'VCPKG_ROOT'

// export type JAVA_HOME = 'JAVA_HOME'

// export type DOTNET_ROOT = 'DOTNET_ROOT'


export type DotNetSdk = `${SdkRoot}/dotnet`
export type DotNetRoot = `${DotNetSdk}/root`
export type DotNetTools = `${DotNetSdk}/tools`

import {Literal,Tk} from "./imports"

export type DevRoot = 'D:/dev-i'
export function DevRoot() : DevRoot{
    return 'D:/dev-i'
}

export type DevTools = `B:/${Tk.Tools}`
export function DevTools() : DevTools {
    return `B:/tools`
}

export type Lang = `I:/${Tk.Lang}`
export function Lang() : Lang {
    return `I:/${Tk.Lang()}`
}

export type EnvRoot = `D:/${Tk.Env}`
export function EnvRoot() : EnvRoot {
    return 'D:/env'
}

export type DocSources = `B:/docs`
export function DocSources() : DocSources {
    return 'B:/docs'
}

export type DocTargets = 'F:/build/docs'
export function DocTargets() : DocTargets {
    return 'F:/build/docs'
}

// export type DevTool<T extends Literal> = `${DevTools}/${T}`
// export function DevTool<T extends Literal>(tool:T) : DevTool<T> {
//     return `${DevTools()}/${tool}`
// }

// export type Path<P extends Literal> = `${P}`
// export function Path<P extends Literal>(src:P) : Path<P> {
//     return `${src}`
// }

// export type Paths<P0 extends Literal,P1 extends Literal> = `${P0};${P1}`
// export function Paths<P0 extends Literal,P1 extends Literal>(p0:P0, p1:P1) : Paths<P0,P1> {
//     return `${p0};${p1}`
// }


export type PkgKind =
    | Tk.Nuget
    | 'native'
    | 'wix'
    | 'msi'
    | 'exe'
    | Tk.Zip
    | Tk.Tar
    | Tk.Gz
    | Tk._7z
    | Tk.Zip
    | Tk.Data

export type PkgCaches = `${EnvRoot}/${Tk.Pkg}/${Tk.Cache}`
export function PkgCaches() : PkgCaches {
    return `${EnvRoot()}/${Tk.Pkg()}/${Tk.Cache()}`
}

export type PkgCache<K extends PkgKind> = `${PkgCaches}/${K}`

export function PkgCache<K extends PkgKind>(kind:K) : PkgCache<K> {
    return `${PkgCaches()}/${kind}`
}

export type NUGET_PACKAGES = PkgCache<Tk.Nuget>

export function NUGET_PACKAGES() : NUGET_PACKAGES {
    return PkgCache('nuget')
}

export type SdkRoot = `${EnvRoot}/${Tk.Sdks}`
export function SdkRoot() : SdkRoot {
    return `${EnvRoot()}/sdks`
}


export function DotNetSdk() : DotNetSdk {
    return `${SdkRoot()}/dotnet`
}

export function DotNetRoot() : DotNetRoot {
    return `${DotNetSdk()}/root`
}

// export function DotNetTools() : DotNetTools {
//     return `${DotNetSdk()}/${Tools()}`
// }

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

// export type MsJdkBin = `${MsJdkHome}/${Bin}`
// export function MsJdkBin() : MsJdkBin {
//     return `${MsJdkHome()}/${Bin()}`
// }
// export type ZuluJdkRoot = `${JavaSdks}/zulu`
// export function ZuluSdkRoot() : ZuluJdkRoot {
//     return `${JavaSdks()}/zulu`
// }

// export type ZuluJdkBin = `${ZuluJdkRoot}/bin/current`
// export function ZuluJdkBin() : ZuluJdkBin {
//     return `${ZuluSdkRoot()}/${Bin()}/current`
// }


export type LlvmSdk = `${SdkRoot}/llvm/sdk`

export function LlvmSdk() : LlvmSdk  {
    return `${SdkRoot()}/llvm/sdk`
}

export type LlvmSdkPath<L extends string> = `${LlvmSdk}/${L}`

export function LlvmSdkPath<L extends string>(part:L) : LlvmSdkPath<L>{
    return `${SdkRoot()}/llvm/sdk/${part}`
}
