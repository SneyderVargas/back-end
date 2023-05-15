FROM node:14

RUN mkdir -p /usr/src/app

WORKDIR /usr/src/app

COPY package*.json ./

RUN npm install -g nodemon

RUN npm install

EXPOSE 3000

COPY . /usr/src/app

CMD ["npm", "start"]