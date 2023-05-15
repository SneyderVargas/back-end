const epxress = require('express')
const router = epxress.Router()
const users = require('./users')
const auth = require('./auth')
const menus = require('./menus')
const grandfathersMenus = require('./grandfathersMenus')
const fathersMenus = require('./fathersMenus')
const childsMenus = require('./childsMenus')
const steps = require('./steps')
const permissions = require('./permissions')
const roles = require('./roles')
const tenancys = require('./tenancys')
const usersSteps = require('./usersSteps')

/*const fs = require('fs')

const pathRouter = `${__dirname}`

const removeExtension = (fileName) => {
    return fileName.split('.').shift()
}

fs.readdirSync(pathRouter).filter((file) => {
    const fileWithOutExt = removeExtension(file)
    const skip = ['index'].includes(fileWithOutExt)
    if (!skip) {
        router.use(`/${fileWithOutExt}`, require(`./${fileWithOutExt}`)) //TODO: localhost/users
        console.log('CARGAR RUTA ---->', fileWithOutExt)
    }
})
*/
router.use('/users', users)
router.use('/auth', auth)
router.use('/menus', menus)
router.use('/grandfathersMenus', grandfathersMenus)
router.use('/fathersMenus', fathersMenus)
router.use('/childsMenus', childsMenus)
router.use('/steps', steps)
router.use('/permissions', permissions)
router.use('/roles', roles)
router.use('/tenancys', tenancys)
router.use('/usersSteps', usersSteps)
router.get('/status', (req, res) => {
    res.status(200)
    res.send('Server Online')
})
/*router.get('*', (req, res) => {
    res.status(404)
    res.send({ error: 'Not found' })
})*/


module.exports = router