# syntax=docker/dockerfile:1

FROM node:18-alpine as builder

WORKDIR /app

COPY package.json ./
COPY package-lock.json ./

RUN npm install 

COPY . ./

RUN npm run build

FROM caddy:2.7.3-alpine

EXPOSE 80

COPY ./Caddyfile /etc/caddy/Caddyfile
COPY --from=builder /app/build /var/www/html