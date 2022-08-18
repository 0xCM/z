export {}

export type int8 = number

export type uint8 = number

export type int32 = number

export type uint32 = number

export type int64 = number

export type uint64 = number

export type int16 = number

export enum HeapKind {
    Blob,
    SystemString,
    UserString,
    Guid
}

export interface HeapIndex  {
    Kind:HeapKind
    Value:uint32
}

export interface BlobIndex extends HeapIndex {
    Kind:HeapKind.Blob
}

export interface GuidIndex extends HeapIndex {
    Kind:HeapKind.Guid
}

export interface StringIndex extends HeapIndex {
    Kind:HeapKind.SystemString
}

export interface UserStringIndex extends HeapIndex {
    Kind:HeapKind.UserString
}

export interface MetadataTable<T>
{

}




