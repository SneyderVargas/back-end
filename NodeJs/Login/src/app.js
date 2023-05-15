require('dotenv').config();
const express = require('express')
const bodyParser = require('body-parser')
const cors = require('cors')
const path = require("path");
const app = express()
const { dbConnectMongo } = require('./config/mongo')
const { dbConnectMysql } = require('./config/mysql')
const api = require('./app/routes')
const http = require('http');

app.use(cors())
const ORIGINS = process.env.ORIGINS

const PORT = process.env.PORT || 3001
app.use(bodyParser.urlencoded({ extended: true }))
app.use(bodyParser.json())
//app.use('/api/1.0', require('./app/routes'))
app.use('/api/1.0', api)
dbConnectMongo()
dbConnectMysql()

const server = http.createServer({}, app)

const io = require('socket.io')(server, {
    cors: {
        origins: [ORIGINS]
    }
});

io.on('connection', socket => {
    socket.on('disconnect', () => {
        console.log('user disconnected')
    })
    console.log('a user connected ' + socket.id);
    module.exports = socket
})


server.listen(PORT, () => {
    console.log('API LISTEN PORT ', PORT)
})