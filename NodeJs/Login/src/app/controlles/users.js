const { httpError } = require('../helpers/handleError')
const { httpSuccess } = require('../helpers/handleSuccess')
const { pool } = require('../../config/mysql')
const { sqlAllGetItem, sqlAllGetItems, sqlAllCreateItem, sqlAllUpdateItem, sqlAllDeleteItem } = require('./sqlAll')
const promisePool = pool.promise();

const NAME_TABLE = 'users'

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

const queryUserEmail = async (req) => {
    try {
        let activeRegister = 1
        //SELECT * FROM users u WHERE u.email = 'sneyr845@gmail.com'
        const [rows, fields] = await promisePool.execute(`SELECT * FROM ${NAME_TABLE} t WHERE t.activeRegister='${activeRegister}' AND t.email='${req.body.email}'`,)
        let results = {
            error: false,
            data: rows
        }
        return results
    } catch (e) {
        let results = {
            error: true,
            data: e
        }
        return results
    }
}
module.exports = {
    getItem,
    getItems,
    createItem,
    deleteItem,
    updateItem,
    queryUserEmail,
    //filter
}