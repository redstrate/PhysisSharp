#!/bin/sh

# build libphysis
cd libphysis &&
cargo build --features visual_data &&

# build the rust layer
cd ../rust &&
cargo build &&

# now compile the solution
cd ../ &&
dotnet build
