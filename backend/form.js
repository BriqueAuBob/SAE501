const generateFormHtml = (form, action) => {
  const formHtml = form
    .map((field) => {
      if (field.name === "date") {
        field.type = "datetime-local";
      }
      return (
        `<div>
            <label for="${field.name}">${field.label}</label>
            ` +
        (field.type === "textarea"
          ? `<textarea id="${field.name}" name="${field.name}">${field.value}</textarea>`
          : `<input type="${field.type}" id="${field.name}" name="${field.name}" value="${field.value}" />`) +
        `
        </div>`
      );
    })
    .join("");

  return `<form method="POST" action="${action}">
    <input type="password" name="password" placeholder="Mot de passe" />
    ${formHtml}
    <button type="submit">Envoyer</button>
  </form>`;
};

module.exports = generateFormHtml;
