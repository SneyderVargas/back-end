const { httpError } = require('../helpers/handleError')
const { httpDefault } = require('../helpers/handleDefault')
const { httpSuccess } = require('../helpers/handleSuccess')
const { encrypt, compare } = require('../helpers/handleBcrypt')
const { tokenSign } = require('../helpers/generateToken')
const userModel = require('../models/users')
const { pool } = require('../../config/mysql')
const { queryUserEmail, createItem } = require('../controlles/users')
const promisePool = pool.promise();

const NAME_TABLE = 'users'

// Create User
const registerCtrl = async (req, res) => {
    createItem(req, res)
    /*
    try {
        let obj = req.body
        let row = ''
        let ansRow = ''
        let dataRow = new Object()
        for (let index = 0; index < Object.keys(obj).length; index++) {
            const element = Object.keys(obj)[index];
            const elementData = Object.values(obj)[index];
            if (Object.keys(obj).length - 1 == index) {
                if (element.toString() == "password") {
                    const passwordHash = await encrypt(elementData)
                    row = row + element
                    ansRow = ansRow + '?'
                    dataRow[`${element}`] = passwordHash
                } else {
                    row = row + element
                    ansRow = ansRow + '?'
                    dataRow[`${element}`] = elementData
                }
            } else {
                if (element.toString() == "password") {
                    const passwordHash = await encrypt(elementData)
                    row = row + element + ', '
                    ansRow = ansRow + '?' + ', '
                    dataRow[`${element}`] = passwordHash
                } else {
                    row = row + element + ', '
                    ansRow = ansRow + '?' + ', '
                    dataRow[`${element}`] = elementData
                }
            }
        }
        //const passwordHash = await encrypt(req.body.password)
        const [rows, fields] = await promisePool.execute(`INSERT INTO ${NAME_TABLE} ( ${row} ) VALUES (${ansRow})`, Object.values(dataRow))
        httpSuccess(res, rows)
    } catch (e) {
        httpError(res, e)
    }*/
}

//TODO: Login!
const loginCtrl = async (req, res) => {
    try {
        let dataUser = await queryUserEmail(req)

        if(dataUser.error) {
            httpDefault(res, 500, false, 'Error consulta de usuario', dataUser.data)
            return
        }

        if (!dataUser.data.length != 0) {
            httpDefault(res, 404, false, 'No encontrado Usuario', null)
            return
        }

        const checkPassword = await compare(req.body.password, dataUser.data[0].password) //TODO: Contraseña!

        //TODO JWT 👉
        const tokenSession = await tokenSign(dataUser.data[0]) //TODO: 2d2d2d2d2d2d2

        if (checkPassword) {//TODO Contraseña es correcta!
            let obj = {
                user: dataUser.data[0],
                token: tokenSession
            }
            httpSuccess(res, obj)
            return
        }

        if (!checkPassword) {
            httpDefault(res, 409, false, 'Erro de contraseña', null)
            return
        }

    } catch (e) {
        httpError(res, e)
    }
}
/*
const loginCtrl = async (req, res) => {
    try {
        const findResult = await userModel.findOne({
            email: req.body.email
        })

        if (!findResult) {
            httpDefault(res, 404, false, 'No encontrado Usuario', null)
            return
        }

        const checkPassword = await compare(req.body.password, findResult.password) //TODO: Contraseña!

        //TODO JWT 👉
        const tokenSession = await tokenSign(findResult) //TODO: 2d2d2d2d2d2d2

        if (checkPassword) {//TODO Contraseña es correcta!
            let obj = {
                user: findResult,
                token: tokenSession
            }
            httpSuccess(res, obj)
            return
        }

        if (!checkPassword) {
            httpDefault(res, 409, false, 'Erro de contraseña', null)
            return
        }

    } catch (e) {
        httpError(res, e)
    }
}
*/
//TODO: Registramos usuario!
/*const registerCtrl = async (req, res) => {    
    try {
        const passwordHash = await encrypt(req.body.password)
        const users = new userModel({
            email: req.body.email,
            name: req.body.name,
            password: passwordHash,
            data: req.body.data
        })
        const data = [users]
        const insertManyResult = await userModel.insertMany(data)
        httpSuccess(res, insertManyResult)
    } catch (e) {
        httpError(res, e)
    }
}*/



module.exports = { loginCtrl, registerCtrl }