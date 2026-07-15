const input = document.getElementById("input");
const addButton = document.getElementById("add-button");
const removeButton = document.getElementById("remove-button");
const editButton = document.getElementById("edit-button");
const list = document.getElementById("list");

addButton.addEventListener("click", function () {
    if (input.value.trim() === "") { // Space check before and after txt than equal to empty string
        return;
    }

    const li = document.createElement("li");
    li.textContent = input.value;
    li.classList.add("item");// add class to li element for css styling

    li.addEventListener("click", function () {
        const selected = document.querySelector(".selected");

        if (selected) {
            selected.classList.remove("selected");
        }

        li.classList.add("selected");// add class to li element for selection styling(blue background)
    });

    list.appendChild(li);
    input.value = "";
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
        alert("Wybierz element do edycji.");
        return;
    }

    const newText = prompt("Nowa nazwa:", selected.textContent);

    if (newText !== null && newText.trim() !== "") {
        selected.textContent = newText;
    }
});