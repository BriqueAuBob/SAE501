const sqlite = require("sqlite3");
const express = require("express");

require("dotenv").config();

const db = new sqlite.Database("./db.sqlite");

db.serialize(() => {
  db.run(
    "CREATE TABLE IF NOT EXISTS members (id INTEGER PRIMARY KEY, name VARCHAR(50), role TEXT)"
  );

  db.run(
    "CREATE TABLE IF NOT EXISTS news (id INTEGER PRIMARY KEY, title TEXT, description TEXT, content TEXT, date TEXT)"
  );

  db.get(
    'SELECT * FROM members WHERE name = "Brandon Clément" LIMIT 1',
    (err, row) => {
      if (row) {
        return;
      }
      db.run(
        'INSERT INTO members (name, role) VALUES ("Brandon Clément", "Développeur")'
      );
    }
  );
});

const app = express();
app.use(express.json());

app.get("/members", (req, res) => {
  db.all("SELECT * FROM members", (err, rows) => {
    res.json(rows);
  });
});

app.post("/members", (req, res) => {
  if (req.headers.authorization !== process.env.AUTHORIZATION) {
    res.status(401).json({ status: "unauthorized" });
    return;
  }

  const { name, role } = req.body;

  db.run(
    "INSERT INTO members (name, role) VALUES (?, ?)",
    [name, role],
    (err) => {
      res.json({ status: "ok" });
    }
  );
});

app.get("/news", (req, res) => {
  db.all("SELECT * FROM news", (err, rows) => {
    res.json(rows);
  });
});

app.post("/news", (req, res) => {
  if (req.headers.authorization !== process.env.AUTHORIZATION) {
    res.status(401).json({ status: "unauthorized" });
    return;
  }

  const { title, description, content, date } = req.body;
  db.run(
    "INSERT INTO news (title, description, content, date) VALUES (?, ?, ?, ?)",
    [title, description, content, date],
    (err) => {
      res.json({ status: "ok" });
    }
  );
});

app.listen(process.env.PORT, () => {
  console.log("Server is running on port " + process.env.PORT);
});
