
const { verifyToken } = require('../helpers/generateToken')
const { httpDefault } = require('../helpers/handleDefault')

const checkAuth = async (req, res, next) => {
    try {
        //TODO: authorization: Bearer 1010101010101001010100 
        const token = req.headers.authorization.split(' ').pop() //TODO:123123213
        const tokenData = await verifyToken(token)
        if (tokenData._id) {
            next()
        } else {
            httpDefault(res, 409, false, 'No tiene autorización', null)
        }

    } catch (e) {
        httpDefault(res, 409, false, 'No tiene autorización', e)
    }

}

module.exports = checkAuth
