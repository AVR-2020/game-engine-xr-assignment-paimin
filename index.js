const express = require('express')
const port = 3000
const app = express()
const bodyParser = require('body-parser')
app.use(bodyParser.urlencoded({ extended: true }))
const { Sequelize, DataTypes } = require('sequelize');
const sequelize = new Sequelize('Geweher', 'root', '', {
  host: 'localhost',
  dialect: 'mysql',
  define: {
    timestamps: false
  }
});
const Score = sequelize.define('scores', {
  // Model attributes are defined here
  id: {
    type: DataTypes.INTEGER,
    autoIncrement: true,
    primaryKey: true
  },
  name: {
    type: DataTypes.STRING,
    allowNull: false
  },
  value_score: {
    type: DataTypes.INTEGER,
    allowNull: false
  }
}, {
})

app.get('/score', function (req, res) {
  Score.findAll().then(function (object) {
    if (object.length>0) {
      res.send(object)
    } else res.send('Empty')
  }).catch(function (error) {
    res.send(error)
  })
})

app.post('/score', function (req, res) {
  Score.create({ name: req.body.name, value_score: req.body.value_score })
    .then(object => {
      res.send('success')
    })
    .catch(error => {
      res.send(error)
    })
})

app.listen(port, () => {
  console.log(`listening at http://localhost:${port}`)
})