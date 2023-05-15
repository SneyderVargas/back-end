const mongoose = require('mongoose')

const BusinessScheme = new mongoose.Schema({
    users_id: {type: String},
    name: {type: String},
    type: {type: String},
    data: {type: Object},
    confirmed: {type: Number, default: 0},  
    createRegisterDate: {type: Date, default: Date.now()},
    updateRegisterDate: {type: Date, default: Date.now()},
    activeRegister: {type: Number, default: 1}
})
module.exports = mongoose.model('businesss', BusinessScheme)