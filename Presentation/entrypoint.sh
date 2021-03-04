#!/usr/bin/env sh
echo "{" > /usr/local/webapp/nginx/html/appsettings.json
echo "  \"network-edition-url\": \"${NETWORK_EDITION_URL}\"" >> /usr/local/webapp/nginx/html/appsettings.json
echo "}" >> /usr/local/webapp/nginx/html/appsettings.json

cat /usr/local/webapp/nginx/html/appsettings.json

nginx -g "daemon off;"