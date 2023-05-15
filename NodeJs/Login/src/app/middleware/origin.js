const { httpDefault } = require('../helpers/handleDefault')
const checkOrigin = (req, res, next) => {
    try {
        const token = req.headers.authorization.split(' ').pop()
        if (token === '123456') {
            next()
        } else {
            httpDefault(res, 409, false, 'No tiene autorización', null)
        }

    } catch (e) {
        next()
    }

}

module.exports = checkOrigin