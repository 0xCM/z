import {Nat} from "./nats"

export interface Int<N extends Nat,T> {
    width:N
    value:T
}

export type UInt<N extends Nat,T> = {
    width:N
    value:T
}

export type Sign = 0 | 1

export type SInt<N extends Nat,T> = {
    width:N
    value:T
    sign?:Sign
}

export type Sum<N extends Nat,T> = {    
    a:Int<N,T>
    b:Int<N,T>
}

export type int8<V> = SInt<8,V>
export type uint8<V> = UInt<8,V>

export type int16<T> = SInt<16,T>
export type uint16<T> = UInt<16,T>

export type int32<T> = SInt<32,T>
export type uint32<T> = UInt<32,T>

export type int64<T> = SInt<64,T>
export type uint64<T> = UInt<64,T>

export function u8<T>(value:T) : uint8<T> {
    return {
        width:8,
        value
    }
}

export function u16<T>(value:T) : uint16<T> {
    return {
        width:16,
        value
    }
}

export function u32<T>(value:T) : uint32<T> {
    return {
        width:32,
        value
    }
}

export function u64<T>(value:T) : int64<T> {
    return {
        width:64,
        value
    }
}

export function i8<T>(value:T, negative?:boolean) : int8<T> {
    return {
        width:8,
        value,
        sign:negative ? 1 : 0
    }
}

export function i16<T>(value:T, negative?:boolean) : int16<T> {
    return {
        width:16,
        value,
        sign:negative ? 1 : 0
    }
}

export function i32<T>(value:T, negative?:boolean) : int32<T> {
    return {
        width:32,
        value,
        sign:negative ? 1 : 0
    }
}

export function i64<T>(value:T, negative?:boolean) : int64<T> {
    return {
        width:64,
        value,
        sign:negative ? 1 : 0
    }
}
