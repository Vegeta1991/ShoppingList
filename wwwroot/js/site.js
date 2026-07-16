
const input = document.getElementById("input");
const addButton = document.getElementById("add-button");
const removeButton = document.getElementById("remove-button");
const editButton = document.getElementById("edit-button");
const list = document.getElementById("list");

addButton.addEventListener("click", function () {
    const text = input.value.trim();

    if (text === "") {
        return;
    }

    const li = document.createElement("li");
    li.classList.add("item");

    const checkbox = document.createElement("input");
    checkbox.type = "checkbox";
    checkbox.classList.add("checkbox");

    const productName = document.createElement("span");
    productName.textContent = text;
    productName.classList.add("product-name");

    li.appendChild(checkbox);
    li.appendChild(productName);

    checkbox.addEventListener("click", function (event) {
        event.stopPropagation();
    });

    checkbox.addEventListener("change", function () {
        productName.classList.toggle("bought", checkbox.checked);
    });

    li.addEventListener("click", function () {
        const selected = document.querySelector(".selected");

        if (selected) {
            selected.classList.remove("selected");
        }

        li.classList.add("selected");
    });

    list.appendChild(li);

    input.value = "";
    input.focus();
});

removeButton.addEventListener("click", function () {
    const selected = document.querySelector(".selected");

    if (selected) {
        selected.remove();
    }
});

editButton.addEventListener("click", function () {
    const selected = document.querySelector(".selected");

    if (!selected) {
        alert("Chose one element");
        return;
    }

    const newText = prompt("New name:", selected.textContent);
    if (newText !== null && newText.trim() !== "") {
        selected.textContent = newText;
    }
});