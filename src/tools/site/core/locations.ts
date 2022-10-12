import {Literal} from "./literals"
export interface Locatable<L> {
    location:L
}

export interface Locator<L extends Literal>  {
    readonly locate: (locatable: L) => URL
}