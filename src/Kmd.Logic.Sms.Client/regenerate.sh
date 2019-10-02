#!/usr/bin/env bash
autorest --input-file=./swagger-v2.json --output-folder=./Generated --clear-output-folder --namespace=Kmd.Logic.Sms.Client --csharp --add-credentials
