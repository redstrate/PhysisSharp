#!/bin/sh

# build libphysis
cd libphysis &&
cargo rustc --features visual_data --crate-type=cdylib &&

# build the rust layer
cd ../rust &&
cargo build &&

# now compile the solution
cd ../ &&
dotnet build
