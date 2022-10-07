import {Service,Provider} from "./services"

export interface Locatable<L> {
    location:L
}

export interface Locator<P extends Provider,L> extends Service<P> {

    readonly locate: (locatable: L) => URL
}