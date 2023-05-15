const express = require('express')
const router = express.Router()
const checkOrigin = require('../middleware/origin')
const checkAuth = require('../middleware/auth')
const checkRoleAuth = require('../middleware/roleAuth')
const { getItems, getItem, createItem, deleteItem, updateItem, getStepsUsers } = require('../controlles/steps')
const { validateCreate } = require('../validators/users')

//router.get('/', checkAuth, checkRoleAuth(['admin']), getItems)
// get items
//router.get('/', checkAuth, getItems)
router.get('/',checkAuth, getItems)
// get item
//router.get('/:_id', checkAuth, getItem)
router.get('/:_id', checkAuth, getItem)
//Create Items
// router.post('/', checkAuth, createItem)
router.post('/', checkAuth, createItem)
// update items
//router.patch('/:_id', checkAuth, updateItem)
router.patch('/:_id', checkAuth, updateItem)
//router.delete('/:_id', checkAuth, deleteItem)
router.delete('/:_id', checkAuth, deleteItem)
router.post('/user', checkAuth, getStepsUsers)
//Filter 
//router.post('/filter', checkAuth, filter)
//router.delete('/:_id', checkAuth, deleteItem)


module.exports = router