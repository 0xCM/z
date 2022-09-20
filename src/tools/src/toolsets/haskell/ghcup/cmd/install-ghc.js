"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
exports.id = exports.name = exports.cmd = exports.template = exports.SymVer = void 0;
class SymVer {
    format() {
        return `${this.major}.${this.minor}.${this.patch}`;
    }
}
exports.SymVer = SymVer;
function template() {
    return 'ghcup install ghc ${Version} --cache';
}
exports.template = template;
function cmd(ver) {
    return `ghcup install ghc ${ver.format()}`;
}
exports.cmd = cmd;
function name() {
    return 'ghcup/install/ghc';
}
exports.name = name;
function id() {
    return 'ghcup-install-ghc';
}
exports.id = id;
