#!/bin/bash

rm -rf ./nats-rust-server-client

set -e
ag --install --output "./nats-rust-server-client" "./blackhawk-asyncapi-documents/Rust_server.json" "../../../dotnet-nats-template" --force-write 

cd nats-rust-server-client

rm -rf ./Dotnet.Nats.Client/bin/Debug
dotnet build

cd ..
