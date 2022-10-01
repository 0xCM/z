
import {Literal} from "../core"
import {Tk} from "../core"

export type DevRoot = 'd:/dev'
export function DevRoot() : DevRoot{
    return 'd:/dev'
}

export type DevTools = `b:/${Tk.Tools}`
export function DevTools() : DevTools {
    return `b:/tools`
}

export type DevTool<T extends Literal> = `${DevTools}/${T}`
export function DevTool<T extends Literal>(tool:T) : DevTool<T> {
    return `${DevTools()}/${tool}`
}

export type Path<P extends Literal> = `${P}`
export function Path<P extends Literal>(src:P) : Path<P> {
    return `${src}`
}

export type Paths<P0 extends Literal,P1 extends Literal> = `${P0};${P1}`
export function Paths<P0 extends Literal,P1 extends Literal>(p0:P0, p1:P1) : Paths<P0,P1> {
    return `${p0};${p1}`
}

export type Lang = `I:/${Tk.Lang}`
export function Lang() : Lang {
    return `I:/${Tk.Lang()}`
}

export type EnvRoot = `d:/${Tk.Env}`
export function EnvRoot() : EnvRoot {
    return 'd:/env'
}

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


// export type JAVA_HOME = `${Env.MsJdkHome}`
// export function JAVA_HOME() : JAVA_HOME {
//     return `${Env.MsJdkHome()}`    
// }

// export type JavaBin = `${Env.MsJdkBin}`
// export function JavaBin() : JavaBin {
//     return `${Env.MsJdkBin()}`
// }

// export type PATH = `${JavaBin}`

// export function PATH() : PATH {
//     return `${JavaBin()}`
// }
