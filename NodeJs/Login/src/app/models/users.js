const mongoose = require('mongoose')

const UserScheme = new mongoose.Schema({
    email: { type: String, unique: true },
    name: { type: String },
    password: { type: String, select: true },
    typeUsers: { type: Number, default: 0 },
    data: { type: Object },
    lastLogin: Date,
    active: { type: Number, default: 0 },
    createRegisterDate: { type: Date, default: Date.now() },
    updateRegisterDate: { type: Date, default: Date.now() },
    activeRegister: { type: Number, default: 1 }
})



module.exports = mongoose.model('users', UserScheme)