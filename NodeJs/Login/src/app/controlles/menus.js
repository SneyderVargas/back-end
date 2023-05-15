const { httpError } = require('../helpers/handleError')
const { httpSuccess } = require('../helpers/handleSuccess')
const { pool } = require('../../config/mysql')
const { sqlAllGetItem, sqlAllGetItems, sqlAllCreateItem, sqlAllUpdateItem, sqlAllDeleteItem } = require('./sqlAll')
const promisePool = pool.promise();

const NAME_TABLE = 'menus'

const getItem = async (req, res) => {
    try {
        const resp = await sqlAllGetItem(req, NAME_TABLE)
        if (resp.success != true) {
            httpError(res, resp.data)
        } else {
            httpSuccess(res, resp.data)
        }
    } catch (e) {
        httpError(res, e)
    }
}
const getItems = async (req, res) => {
    try {
        const resp = await sqlAllGetItems(req, NAME_TABLE)
        if (resp.success != true) {
            httpError(res, resp.data)
        } else {
            httpSuccess(res, resp.data)
        }
    } catch (e) {
        httpError(res, e)
    }
}

const createItem = async (req, res) => {
    try {
        const resp = await sqlAllCreateItem(req, NAME_TABLE)
        if (resp.success != true) {
            httpError(res, resp.data)
        } else {
            httpSuccess(res, resp.data)
        }
    } catch (e) {
        httpError(res, e)
    }
}

const updateItem = async (req, res) => {
    try {
        const resp = await sqlAllUpdateItem(req, NAME_TABLE)
        if (resp.success != true) {
            httpError(res, resp.data)
        } else {
            httpSuccess(res, resp.data)
        }
    } catch (e) {
        httpError(res, e)
    }
}

const deleteItem = async (req, res) => {
    try {
        const resp = await sqlAllDeleteItem(req, NAME_TABLE)
        if (resp.success != true) {
            httpError(res, resp.data)
        } else {
            httpSuccess(res, resp.data)
        }
    } catch (e) {
        httpError(res, e)
    }
}

const getMenuUser = async (req, res) => {
    // SELECT * FROM users u 
    // WHERE u.active = 1 
    // AND (u.name LIKE '%s%' OR u.email LIKE '%s%')
    // LIMIT 10 OFFSET 0 ;
    // SELECT COUNT(*) AS n FROM users u WHERE u.active = 0
    let sql = `
    SELECT JSON_OBJECT('tenancys',m.tenancys,'id',m.id,'menu',(
    SELECT JSON_ARRAYAGG(JSON_OBJECT('id',gm.id,'ubication',gm.ubication,'title',gm.title,'icon',gm.icon,'href',gm.href,'code',gm.code,'items',(
    SELECT JSON_ARRAYAGG(JSON_OBJECT('id',fm.id,'ubication',fm.ubication,'title',fm.title,'icon',fm.icon,'href',fm.href,'code',fm.code,'items',(
    SELECT JSON_ARRAYAGG(JSON_OBJECT('id',cm.id,'ubication',cm.ubication,'title',cm.title,'icon',cm.icon,'href',cm.href,'code',cm.code))
    FROM childsMenus cm
    WHERE cm.activeRegister = '${req.body.activeRegister}' AND cm.fathersMenus = fm.id))) 
    FROM fathersMenus fm
    WHERE fm.activeRegister = '${req.body.activeRegister}' AND fm.grandfathersMenus = gm.id  )))
    FROM grandfathersMenus gm
    WHERE gm.activeRegister = '${req.body.activeRegister}' AND gm.menus = m.id )) 
    FROM  menus m 
    WHERE m.tenancys IN (${req.body.tenancys}) AND m.activeRegister = '${req.body.activeRegister}';
    `
    try {
        //const [rows, fields] = await promisePool.execute(`SELECT * FROM ${NAME_TABLE} t WHERE t.activeRegister='${req.body.activeRegister}' AND t.tenancys='${req.body.tenancys}'`,)
        const [rows, fields] = await promisePool.execute(sql,)
        httpSuccess(res, rows)
    } catch (e) {
        httpError(res, e)
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
    getItem,
    getItems,
    createItem,
    deleteItem,
    updateItem,
    getMenuUser
    //filter
}