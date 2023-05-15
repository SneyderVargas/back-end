const mysql = require('mysql2');


require('dotenv').config();
var pool = mysql.createPool({
    host: process.env.DB_URI_MYSQL_CON,
    user: process.env.DB_URI_MYSQL_USE,
    password: process.env.DB_URI_MYSQL_PAS,
    port: process.env.DB_URI_MYSQL_POR,
    database: process.env.DB_URI_MYSQL_DBS,
    waitForConnections: true,
    connectionLimit: 10,
    queueLimit: 0
});

const dbConnectMysql = () => {
    pool.getConnection((e, c) => {
        if (!e) {
            console.log('Success connection mysql db')
        } else {
            console.log(`Error connection mysql db ${e}`)
        }
    })
}




module.exports = {
    dbConnectMysql,
    pool
}