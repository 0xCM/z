import { EmptyString, List } from "./common"
import { FSlash,BSlash} from "./tokens"
import {Link} from "./links"
import {Literal,Kinded} from "./literals"

export type PathSep = EmptyString | BSlash | FSlash

export function sep(kind:PathSep) {
    var sep :PathSep = ''
    switch(kind)
    {
        case '/':
            sep = '/'
        break;
        case '\\':
            sep = '\\'
        break;
    }
    return `${sep}`
}


export type DriveLetter = 
    | ''
    | `A:` 
    | 'B:' 
    | 'C:' 
    | 'D:' 
    | 'E:' 
    | 'F:' 
    | 'G:' 
    | 'H:' 
    | 'I:' 
    | 'J:' 
    | 'K:' 
    | 'L:' 
    | 'M:' 
    | 'N:' 
    | 'N:' 
    | 'O:'
    | 'P:'
    | 'Q:'
    | 'R:'
    | 'S:'
    | 'T:'
    | 'U:' 
    | 'V:' 
    | 'W:'
    | 'X:'
    | 'Y:'
    | 'Z:'

export type Drive<K extends DriveLetter> = K
    
export type Volume<V> = V

export type Mount<P,R> = {
        protocol:P
        root:R
    }
    
export type WslMount<M> = Mount<`\\\\wsl$`,M>

export type NtfsMount<P extends DriveLetter,R> = Mount<P,R>

export enum ObjectKind  {
    None,

    Folder,

    File,

    Drive,
}

export interface File<L extends Literal> extends Kinded<ObjectKind>{
    path:L    
}

export interface Folder<L extends Literal> extends Kinded<ObjectKind> {
    path:L
}

export type FileName<N extends Literal> = N

export type FolderName<N extends Literal> = N

export type Path<L extends Literal> = Folder<L> | File<L> | DriveLetter

export interface SymLink<L extends Literal> extends Link<ObjectKind,Path<L>> {

} 

export interface FSO<K extends ObjectKind,L extends Literal> {
    kind:K
    path:L
}

export type Folders = List<string>

export type Files = List<string>

export function fso<K extends ObjectKind, L extends Literal>(kind:K, path:L) : FSO<K,L> {
    return {
        kind,
        path
    }
}

export function symlink<K,P extends Literal>(source:Path<P>, target:Path<P>) : SymLink<P> {
     return {
        kind:ObjectKind.Folder,
        source,
        target,
     }
 }

export function folder<L extends Literal>(path:L) : FSO<ObjectKind.Folder, L> {
    return {
        kind:ObjectKind.Folder,
        path
    }
}

export function file<L extends Literal>(path:L) : FSO<ObjectKind.File, L> {
    return {
        kind:ObjectKind.File,
        path
    }
}

export function drive<L extends DriveLetter>(name:L) : Drive<L> {
    return name
}
