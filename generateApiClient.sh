#!/bin/bash

#rm -rf ./Oxide.Ext.GamingApi/IO

set -e -x
rm -rf ./blackhawk-api-client
openapi-generator generate -g csharp -i ../definitions/rust_public_api.json -o ./blackhawk-api-client 