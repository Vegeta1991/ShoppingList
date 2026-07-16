
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
    //checkbox
    const checkbox = document.createElement("input");
    checkbox.type = "checkbox";
    checkbox.classList.add("fa-solid", "fa-check");
    //product name
    const productName = document.createElement("span");
    productName.textContent = text;
    productName.classList.add("product-name");
    // append checkbox and product name to li
    li.appendChild(checkbox);
    li.appendChild(productName);
    // add event listeners click and change but stop propagation of click event to li
    checkbox.addEventListener("click", function (event) {
        event.stopPropagation();
    });
    // toggle class bought on product name when checkbox is checked
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

    const productName = selected.querySelector(".product-name");// Get the product name span ( not li) element without checkbox

    const newText = prompt("New name:", productName.textContent);

    if (newText !== null && newText.trim() !== "") {
        productName.textContent = newText.trim();
    }
});