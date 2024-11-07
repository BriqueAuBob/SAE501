const sqlite = require("sqlite3");
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

module.exports = db;
