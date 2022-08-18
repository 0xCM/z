export {}

import { Nat } from "./nats"
import { AsciDigit } from "./asci"

export type BinaryDigit = | '0' | '1'
export type BinaryDigitValue = Nat<0 | 1>

export type DecimalDigit = AsciDigit
export type DecimalDigitValue = Nat<0 | 1 | 2 | 3 | 4 | 5 | 6 | 7 | 8 | 9>

export type OctalDigit = |'0' | '1' | '2' | '3' | '4' | '5' | '6' | '7'
export type OctalDigitValue = Nat<0 | 1 | 2 | 3 | 4 | 5 | 6 | 7 >

export type HexDigit = AsciDigit | 'a' | 'b' | 'c' | 'd' | 'e' | 'f' | 'A' | 'B' | 'C' | 'D' | 'E' | 'F' 
export type HexDigitValue = Nat<0 | 1 | 2 | 3 | 4 | 5 | 6 | 7 | 8 | 9 | 10 | 11 | 12 | 13 | 14 | 15>

export type Digit<D extends BinaryDigit | OctalDigit | DecimalDigit | HexDigit> = D

export type DigitValue<V extends BinaryDigitValue | OctalDigitValue | DecimalDigitValue | HexDigitValue> = V
