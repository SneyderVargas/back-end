const { httpError } = require('../helpers/handleError')
const { httpSuccess } = require('../helpers/handleSuccess')
const { pool } = require('../../config/mysql')
const { sqlAllGetItem, sqlAllGetItems, sqlAllCreateItem, sqlAllUpdateItem, sqlAllDeleteItem } = require('./sqlAll')

const NAME_TABLE = 'tenancys'

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
    //filter
}