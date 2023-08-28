# syntax=docker/dockerfile:1

FROM node:lts-alpine as build

WORKDIR /app

COPY package*.json ./

EXPOSE 3000

RUN npm ci

COPY . .

ENV NODE_ENV production

RUN npm run build

FROM node:lts-alpine as production

WORKDIR /app

COPY --from=build /app/package*.json .
COPY --from=build /app/build ./build

EXPOSE 3000

RUN npm ci --omit dev

CMD ["node", "./build"]