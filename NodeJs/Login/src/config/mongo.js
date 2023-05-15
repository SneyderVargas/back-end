const mongoose = require('mongoose')

const dbConnectMongo = () => {
    const DB_URI = process.env.DB_URI
    mongoose.connect(DB_URI, {
        useNewUrlParser: true,
        useUnifiedTopology: true
    }, (e, res) => {
        if (!e) {
            console.log('Success connection mongo db')
        } else {
            console.log(`Error connection mongo db ${e}`)
        }
    })
}

module.exports = {
    dbConnectMongo
}