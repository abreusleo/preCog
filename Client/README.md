## Build using docker

`docker build . -t {tag}`

## Run using docker

`docker run -p {port}:3000 --network {existing_network} --name {container_name} {tag}`

Obs: You have to create a network or use an existing one

## Run locally with Node

`npm i` to install dependencies
`npm run dev` to start local development server
