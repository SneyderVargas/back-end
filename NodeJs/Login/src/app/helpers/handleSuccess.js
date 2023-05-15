const httpSuccess = (res, data) => {
    res.status(200)
    res.send({
        success: true,
        message: 'Exito',
        data: data
    })
}

module.exports = { httpSuccess }