const httpDefault = (res, status, success, message, data) => {
    res.status(status)
    res.send({
        success: success,
        message: message,
        data: data
    })
}

module.exports = { httpDefault }