const express = require("express");
const generateCrud = require("./crud");
require("./db");

require("dotenv").config();

const app = express();
app.use(express.json());
app.use(express.urlencoded({ extended: true }));
app.use((req, res, next) => {
  res.header("Access-Control-Allow-Origin", "*");
  next();
});

generateCrud("members", app, ["name", "role"]);
generateCrud("news", app, ["title", "description", "content", "date"]);

app.listen(process.env.PORT, () => {
  console.log("Server is running on port " + process.env.PORT);
});
