#!/usr/bin/env sh

appSettingsFile=$1
networkEditionUrl=$2

echo "{" > "$appSettingsFile"
echo "  \"network-edition-url\": \"$networkEditionUrl\"" >> "$appSettingsFile"
echo "}" >> "$appSettingsFile"

cat "$appSettingsFile"

nginx -g "daemon off;"