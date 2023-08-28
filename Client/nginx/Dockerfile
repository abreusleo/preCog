# syntax=docker/dockerfile:1

FROM nginx:latest

RUN rm /etc/nginx/conf.d/default.conf

COPY nginx.conf.template /etc/nginx/templates/nginx.conf.template

EXPOSE 80

CMD ["nginx", "-g", "daemon off;"]