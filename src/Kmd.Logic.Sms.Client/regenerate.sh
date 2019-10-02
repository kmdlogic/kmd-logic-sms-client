#!/usr/bin/env bash
autorest --csharp --input-file=./swagger-v2.json --output-folder=./Generated --clear-output-folder --override-client-name=SmsClient --namespace=Kmd.Logic.Sms.Client --add-credentials
