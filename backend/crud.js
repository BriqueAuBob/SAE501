const form = require("./form");
const db = require("./db");

const generateCrud = (name, app, fields) => {
  app.get("/" + name, (req, res) => {
    db.all("SELECT * FROM " + name, (err, rows) => {
      res.json(rows);
    });
  });

  app.post("/" + name, (req, res) => {
    if (req.body.password !== process.env.AUTHORIZATION) {
      res.status(401).json({ status: "unauthorized" });
      return;
    }

    const body = req.body;

    db.run(
      "INSERT INTO " +
        name +
        " (" +
        fields.join(", ") +
        ") VALUES (" +
        fields.map(() => "?").join(", ") +
        ")",
      fields.map((field) => body[field]),
      (err) => {
        res.json({ status: "ok" });
      }
    );
  });

  app.get("/" + name + "/form", (req, res) => {
    res.send(
      form(
        fields.map((field) => ({
          name: field,
          label: field,
          type: field === "content" ? "textarea" : "text",
        })),
        "/" + name
      )
    );
  });

  app.get("/" + name + "/:id", (req, res) => {
    db.get(
      "SELECT * FROM " + name + " WHERE id = ?",
      [req.params.id],
      (err, row) => {
        res.json(row);
      }
    );
  });

  app.get("/" + name + "/:id/form", (req, res) => {
    db.get(
      "SELECT * FROM " + name + " WHERE id = ?",
      [req.params.id],
      (err, row) => {
        res.send(
          form(
            fields.map((field) => ({
              name: field,
              label: field,
              type: field === "content" ? "textarea" : "text",
              value: row[field],
            })),
            "/" + name + "/" + req.params.id
          )
        );
      }
    );
  });

  app.post("/" + name + "/:id", (req, res) => {
    if (req.body.password !== process.env.AUTHORIZATION) {
      res.status(401).json({ status: "unauthorized" });
      return;
    }

    const body = req.body;

    db.run(
      "UPDATE " +
        name +
        " SET " +
        fields.map((field) => field + " = ?").join(", ") +
        " WHERE id = ?",
      [...fields.map((field) => body[field]), req.params.id],
      (err) => {
        res.json({ status: "ok" });
      }
    );
  });
};

module.exports = generateCrud;
