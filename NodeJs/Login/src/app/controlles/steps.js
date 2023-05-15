const { httpError } = require('../helpers/handleError')
const { httpSuccess } = require('../helpers/handleSuccess')
const { pool } = require('../../config/mysql')
const promisePool = pool.promise();
const { sqlAllGetItem, sqlAllGetItems, sqlAllCreateItem, sqlAllUpdateItem, sqlAllDeleteItem } = require('./sqlAll')

const NAME_TABLE = 'steps'

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

const getStepsUsers = async (req, res) => {
    try {
        let sqlSteps = `SELECT * FROM steps s WHERE s.tenancys IN (${req.body._tenancys}) AND s.activeRegister = ${req.body._activeRegister};`
        let sqlStepsUsers = `SELECT s.id, s.name, s.url, s.descripcions, us.activeRegister FROM usersSteps us INNER JOIN users u ON us.users = u.id INNER JOIN steps s ON us.steps = s.id WHERE u.id = ${req.body._user} AND u.activeRegister = ${req.body._activeRegister} AND u.tenancys IN (${req.body._tenancys});`
        const [rowsSqlSteps] = await promisePool.execute(sqlSteps)
        const [rowsSqlStepsUsers] = await promisePool.execute(sqlStepsUsers)
        let arrayRowsSqlSteps = []
        let arrayRowsSqlStepsUser = []
        let rowsSqlStepsRest = []
        if (rowsSqlStepsUsers.length != 0) {
            // creamos el arra para sacar los id de steps
            for (let index = 0; index < rowsSqlSteps.length; index++) {
                const element = rowsSqlSteps[index];
                arrayRowsSqlSteps.push(element.id)
            }
            // creamos array de step vigentes de usus
            for (let index = 0; index < rowsSqlStepsUsers.length; index++) {
                const element = rowsSqlStepsUsers[index];
                arrayRowsSqlStepsUser.push(element.id)
            }
            // saca los steps que el usuarios ya realizo realizado
            for (let indexStepsUser = 0; indexStepsUser < rowsSqlStepsUsers.length; indexStepsUser++) {
                const element = rowsSqlStepsUsers[indexStepsUser];
                if (arrayRowsSqlSteps.includes(element.id)) {
                    if (element.activeRegister != 1) {
                        rowsSqlStepsRest.push(element)
                    }

                }
            }
            for (let index = 0; index < rowsSqlSteps.length; index++) {
                const element = rowsSqlSteps[index];
                if (!arrayRowsSqlStepsUser.includes(element.id)) {
                    rowsSqlStepsRest.push(element)                  
                }
            }
            httpSuccess(res, rowsSqlStepsRest)
        } else {
            rowsSqlStepsRest = rowsSqlSteps
            httpSuccess(res, rowsSqlStepsRest)
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
    getStepsUsers,
    //filter
}