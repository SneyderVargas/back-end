const { encrypt, compare } = require('../helpers/handleBcrypt')
const { pool } = require('../../config/mysql')
const promisePool = pool.promise();


const sqlAllGetItem = async (req, NAME_TABLE) => {
    try {
        let activeRegister = 1
        const [rows] = await promisePool.execute(`SELECT * FROM ${NAME_TABLE} t WHERE t.activeRegister=${activeRegister} AND t.id = ${req.params._id}`)
        return { success: true, data: rows }
    } catch (e) {
        return { success: false, data: e }
    }
}
const sqlAllGetItems = async (req, NAME_TABLE) => {
    // SELECT * FROM users u 
    // WHERE u.active = 1 
    // AND (u.name LIKE '%s%' OR u.email LIKE '%s%')
    // LIMIT 10 OFFSET 0 ;
    // SELECT COUNT(*) AS n FROM users u WHERE u.active = 0
    try {
        let serch = req.query.serch.split(" ").join("%");
        let query = req.query.query
        let addWhere = ''
        if (query != "") {
            let queryArray = query.split(',');
            addWhere = ` AND ( `
            for (let index = 0; index < queryArray.length; index++) {
                const element = queryArray[index];
                if (queryArray.length - 1 == index) {
                    addWhere = addWhere + `t.${element} LIKE '%${serch}%' )`
                } else {
                    addWhere = addWhere + `t.${element} LIKE '%${serch}%' OR `
                }
            }
        }
        const limit = req.query.limit
        const offset = req.query.offset - 1
        const activeRegister = req.query.activeRegister
        let sqlCount = `SELECT COUNT(*) AS n FROM ${NAME_TABLE} t `
        let sqlData = `SELECT * FROM ${NAME_TABLE} t `
        let where = `WHERE t.activeRegister = ${activeRegister} AND t.tenancys = ${req.query._tenancys} `
        let pagination = `LIMIT ${limit} OFFSET ${offset} `
        const [count] = await promisePool.execute(sqlCount + where + addWhere + pagination)
        const [rows, fields] = await promisePool.execute(sqlData + where + addWhere + pagination)
        const pages = count[0].n / limit
        const result = {
            "rows": rows,
            "pages": Math.ceil(pages),
            "realPages": offset + 1,
            "totalRows": count[0].n
        }
        return { success: true, data: result }
    } catch (e) {
        return { success: false, data: e }
    }
}

const sqlAllCreateItem = async (req, NAME_TABLE) => {
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
        return { success: true, data: rows }
    } catch (e) {
        return { success: false, data: e }
    }
}

const sqlAllUpdateItem = async (req, NAME_TABLE) => {
    try {
        let _id = req.params._id
        let obj = req.body
        let dataRow = new Object()
        let stringUpdate = ''
        for (let index = 0; index < Object.keys(obj).length; index++) {
            const element = Object.keys(obj)[index];
            const elementData = Object.values(obj)[index];
            if (Object.keys(obj).length - 1 == index) {
                if (element.toString() == "password") {
                    const passwordHash = await encrypt(elementData)
                    dataRow[`${element}`] = passwordHash
                    stringUpdate = stringUpdate + `${element}='${passwordHash}'`
                } else {
                    dataRow[`${element}`] = elementData
                    stringUpdate = stringUpdate + `${element}='${elementData}'`
                }
            } else {
                if (element.toString() == "password") {
                    const passwordHash = await encrypt(elementData)
                    dataRow[`${element}`] = passwordHash
                    stringUpdate = stringUpdate + `${element}='${passwordHash}', `
                } else {
                    dataRow[`${element}`] = elementData
                    stringUpdate = stringUpdate + `${element}='${elementData}', `

                }
            }
        }
        //const passwordHash = await encrypt(req.body.password)
        const [rows, fields] = await promisePool.execute(`UPDATE ${NAME_TABLE} SET ${stringUpdate} WHERE id=${_id}`,)
        return { success: true, data: rows }
    } catch (e) {
        return { success: false, data: e }
    }
}

const sqlAllDeleteItem = async (req, NAME_TABLE) => {
    try {
        let _id = req.params._id
        let activeRegister = req.body._activeRegister
        let tenancys = req.body._tenancys
        const [rows, fields] = await promisePool.execute(`UPDATE ${NAME_TABLE} SET activeRegister=${activeRegister} WHERE id=${_id} AND tenancys=${tenancys}`,)
        return { success: true, data: rows }
    } catch (e) {
        return { success: false, data: e }
    }
}


//const userModel = require('../models/users')
/*
const getItems = async (req, res) => {
    try {
        const findResult = await userModel.find({})
        httpSuccess(res, findResult)
    } catch (e) {
        httpError(res, e)
    }
}

const getItem = async (req, res) => {
    try {
        const findResult = await userModel.findOne({
            _id: req.params._id
        })
        httpSuccess(res, findResult)
    } catch (e) {
        httpError(res, e)
    }
}

const createItem = async (req, res) => {
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
}



const updateItem = async (req, res) => {
    try {
        const passwordHash = await encrypt(req.body.password)
        const query = {
            _id: req.params._id
        }
        const updateDocument = {
            $set: {
                email: req.body.email,
                name: req.body.name,
                password: passwordHash,
                data: req.body.data,
                active: req.body.active
            }
        }
        const resultUpdateItem = await userModel.updateOne(query, updateDocument)
        httpSuccess(res, resultUpdateItem)
    } catch (e) {
        httpError(res, e)
    }
}

const deleteItem = async (req, res) => {
    try {
        const query = {
            _id: req.params._id
        }
        const updateDocument = {
            activeRegister: req.body.activeRegister
        }
        const resultUpdateItem = await userModel.updateOne(query, updateDocument)
        httpSuccess(res, resultUpdateItem)
    } catch (e) {
        httpError(res, e)
    }
}

const filter = async (req, res) => {
    let query = req.body.query
    try {
        const findResult = await userModel.find(query)
        httpSuccess(res, findResult)
    } catch (e) {
        httpError(res, e)
    }
}*/
module.exports = {
    sqlAllGetItem,
    sqlAllGetItems,
    sqlAllCreateItem,
    sqlAllDeleteItem,
    sqlAllUpdateItem,
    //filter
}