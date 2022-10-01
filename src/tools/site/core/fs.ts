import { EmptyString, EmptyType } from "./common"
import {uint32} from "./integers"
import {Edge} from "./graphs"
import {ForwardSlash,BackSlash} from "./tokens"

export type PathSep = EmptyType<''>| BackSlash | ForwardSlash

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

export type Drive = 
    | ''
    | 'A:' 
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
    

export type Volume<V> = V

export type Mount<P,R> = {
        protocol:P
        root:R
    }
    
export type WslMount<M> = Mount<`\\\\wsl$`,M>

export type NtfsMount<P extends Drive,R> = Mount<P,R>

export type Path<A,B=null,C=null,D=null,E=null,F=null,G=null,H=null> = {
    a:A
    b?:B
    c?:C
    d?:D
    e?:E
    f?:F
    g?:G
    h?:H
}

export function path<A, B=null, C=null, D=null, E=null, F=null, G=null, H=null> (
    a:A, b?:B, c?:C, d?:D, e?:E, f?:F, g?:G, h?:H) : Path<A,B,C,D,E,F,G,H> {    
        return {
            a:a,
            b:b,
            c:c,
            d:d,
            e:e,
            f:f,
            g:g,
            h:h
        }
}

export function format<A,B,C,D,E,F,G,H>(sep:string, src:Path<A,B,C,D,E,F,G,H>) {
    const empty:EmptyString = ''
    return `${src.a}` 
        + (src.b == undefined ? empty : sep + src.b)
        + (src.c == undefined ? empty : sep + src.c)
        + (src.d == undefined ? empty : sep + src.d)
        + (src.e == undefined ? empty : sep + src.e)
        + (src.f == undefined ? empty : sep + src.f)
        + (src.g == undefined ? empty : sep + src.g)
        + (src.h == undefined ? empty : sep + src.h)
}

export type File = {
    name:string
}

export type Folder = {
    name:string
}

export type Link<L,F> = Edge<L,F,F>

export type FileLink<K> = Link<K,File>

export type FolderLink<K> = Link<K,Folder>

export function link<K,F>(kind:K, source:F, target:F) : Link<K,F> {
    return {
        kind,
        source,
        target
    }
}

export function file(name:string) : File {
    return {
        name:name
    }
}

export function folder(name:string) : Folder {
    return {
        name:name
    }
}

export type Archive<K,R> = {
    kind:K
    root:R
}

export type ArchiveKind = 
    | 'git'
    | 'zip'
    | 'fs'

export type FileArchive<R> = Archive<0,R>


export type LineSpan<S,T> ={
    source:S
    min:uint32<T>
    max:uint32<T>
}

export function lines<S,T>(source:S, min:uint32<T>, max:uint32<T>) : LineSpan<S,T> {
    return {
        source,
        min,
        max
    }
}



/*
https://github.com/MicrosoftDocs/windows-powershell-docs/blob/main/docset/winserver2019-ps/storage/Get-DiskImage.md
ByImagePath (Default)
Get-DiskImage [-ImagePath] <String[]> [-StorageType <StorageType>] [-CimSession <CimSession[]>]
[-ThrottleLimit <Int32>] [-AsJob] [<CommonParameters>]
ByVolume
Get-DiskImage [-Volume <CimInstance>] [-StorageType <StorageType>] [-CimSession <CimSession[]>]
[-ThrottleLimit <Int32>] [-AsJob] [<CommonParameters>]
ByDevicePath
Get-DiskImage -DevicePath <String[]> [-StorageType <StorageType>] [-CimSession <CimSession[]>]
[-ThrottleLimit <Int32>] [-AsJob] [<CommonParameters>]

```pwershell
Get-Volume | Get-DiskImage | Select DevicePath,ImagePath
```
Get-DiskImage -ImagePath E:\vhd1.vhdx | Get-Disk | Get-Partition | Get-Volume
Get-Volume | Get-DiskImage | Get-Disk | Get-Partition | Get-Volume
*/