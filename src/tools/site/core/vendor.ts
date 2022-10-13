import { Root } from "./root"

export type VendorKey = 
    | 'ms'
    | 'intel'
    
export type Vendor<K extends VendorKey,B> = Root<'vendor',B>


export function vendor<K extends VendorKey,B>(key:K, base:B) {
    return {
        key,
        base
    }
}
