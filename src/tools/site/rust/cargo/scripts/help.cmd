@echo off
call %~dp0..\config.cmd
cargo help > %ToolDocs%\cargo.help
cargo help rustc > %ToolDocs%\cargo-rustc.help
cargo help build > %ToolDocs%\cargo-build.help
rustc --print target-list > %ToolDocs%\rustc-targets.list
: cargo rustc -- --emit asm -C llvm-args=-x86-asm-syntax=intel