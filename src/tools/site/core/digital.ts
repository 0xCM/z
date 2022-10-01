import {Nat} from "./nats"

export type Base<B extends Nat> = {
    value:B
}

export type Base2 = Base<2>;

export type Base8 = Base<8>

export type Base10 = Base<10>

export type Base16 = Base<16>

export type Base64 = Base<64>

export type Base2Value = 0 | 1

export type Base8Value = 0 | 1 | 2 | 3 | 4 |5 |6 | 7

export type Base10Value = 0 | 1 | 2 | 3 | 4 |5 |6 | 7 | 8 | 9

export type Base16Value = 0 | 1 | 2 | 3 | 4 |5 |6 | 7 | 8 | 9 | 10 | 11 | 12 | 13 | 14 | 15

export function base<B extends Nat>(b:B) : Base<B> {
    return {
        value:b
    }
}

export type BasedValue<B extends Nat,V extends Nat> = {
    base:B
    value:V
}
    
export function value<B extends Nat,V extends Nat>(base:B,value:V) : BasedValue<B,V>  {
    return {
        base,
        value
    }
}

export function base2<V extends Base2Value>(src:V) : BasedValue<2,V>{
    return value(2, src);
}

export function base8<V extends Base2Value>(src:V) : BasedValue<8,V>{
    return value(8, src);
}

export function base10<V extends Base2Value>(src:V) : BasedValue<10,V>{
    return value(10, src);
}

export function base16<V extends Base2Value>(src:V) : BasedValue<16,V>{
    return value(16, src);
}

export const Base8:Base8 = base(8);
export const Base10:Base10 = base(10);
export const Base16:Base16 = base(16);
export const Base64:Base64 = base(64);

export type BinarySymbol = | '0' | '1'

export type OctalSymbol = | '0' | '1' | '2' | '3' | '4' | '5' | '6' | '7' 

export type DecimalSymbol = | '0' | '1' | '2' | '3' | '4' | '5' | '6' | '7' | '8' | '9'

export type HexSymbol = | '0' | '1' | '2' | '3' | '4' | '5' | '6' | '7' | '8' | '9' | 'a' | 'b' | 'c' | 'd' | 'e' | 'f' | 'A' | 'B' | 'C' | 'D' | 'E' | 'F'

export type DigitSymbol = | '0' | '1' | '2' | '3' | '4' | '5' | '6' | '7' | '8' | '9' | 'a' | 'b' | 'c' | 'd' | 'e' | 'f' | 'A' | 'B' | 'C' | 'D' | 'E' | 'F'

export type NumericBase = Base2 | Base8 | Base10 | Base16

export type Digital<D extends DigitSymbol,V extends NumericBase> = {
    symbol:D
    value:V
}

export type Digits<D extends DigitSymbol, V extends NumericBase> = Array<Digital<D,V>>

export function digit<S extends DigitSymbol,V extends NumericBase>(symbol:S,value:V) :Digital<S,V> {
    return {
        symbol,
        value
    }
}
export type HexVal<V extends Base16> = {
    value:V
}

export function hexval<V extends Base16>(value:V) : HexVal<V> {
    return {
        value:value
    }    
}

export type HexDigit<S extends HexSymbol, V extends Base16> = Digital<S,V>

export function hex<S extends HexSymbol, V extends Base16>(symbol:S,value:V) : HexDigit<S,V> {
    return  {
        symbol,
        value
    }
}

export type Binary<V extends Base2> = {
    value:V
}

export type Octal<V extends Base8> = {
    value:V
}

export type Decimal<V extends Base10> = {
    value:V
}


export function binary<V extends Base2>(value:V) : Binary<V> {
    return {
        value:value
    }    
}

export function octal<V extends Base8>(value:V) : Octal<V> {
    return {
        value:value
    }    
}

export function decimal<V extends Base10>(value:V) : Decimal<V> {
    return {
        value:value
    }    
}
