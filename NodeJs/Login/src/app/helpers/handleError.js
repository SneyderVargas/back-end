const httpError = (res, data) => {
    res.status(500)
    res.send({
        success: false,
        message: 'Error',
        data: data
    })
}

module.exports = { httpError }