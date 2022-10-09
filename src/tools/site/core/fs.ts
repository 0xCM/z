import { EmptyString, List } from "./common"
import { FSlash,BSlash} from "./tokens"
import {Link} from "./links"
import {Literal} from "./literals"
import { Kinded } from "./kinds"

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
    location:L    
}

export interface Folder<L extends Literal> extends Kinded<ObjectKind> {
    location:L
}

export type FileName = File<string>

export type FolderName = Folder<string>

export type Path<L extends Literal> = Folder<L> | File<L> | DriveLetter


export interface SymLink<L extends Literal> extends Link<ObjectKind,Path<L>> {

} 

export type Folders = List<FolderName>

export type Files = List<FileName>


export function path<L extends Literal>(kind:ObjectKind,location:L) : Path<L> {
    return {
        kind,
        location
    }
}

export function symlink<K,P extends Literal>(kind:ObjectKind, source:Path<P>, target:Path<P>) : SymLink<P> {
     return {
        kind,
        source,
        target,
     }
 }

export function folder<L extends Literal>(location:L) : Folder<L> {
    return {
        kind:ObjectKind.Folder,
        location
    }
}

export function file<L extends Literal>(location:L) : File<L> {
    return {
        kind:ObjectKind.Folder,
        location
    }
}

export function drive<L extends DriveLetter>(location:L) : Drive<L> {
    return location
}
