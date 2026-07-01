
const input = document.getElementById("input");
const buttonAdd = document.getElementById("add-button");
const buttonRemove = document.getElementById("remove-button");
const list = document.getElementById("list");

console.log(input, buttonAdd, buttonRemove, list);

buttonAdd.addEventListener("click", function () {
    console.log("Klik Add");

    const value = input.value;

    if (value.trim() === "") {
        return;
    }

    const li = document.createElement("li");
    li.textContent = value;
    li.classList.add("item");

    li.addEventListener("click", function () {
        console.log("Klik li:", li.textContent);
        li.classList.toggle("selected");
    });

    list.appendChild(li);
    input.value = "";
});

buttonRemove.addEventListener("click", function () {
    console.log("Klik Delete");

    const selected = list.querySelector(".selected");
    console.log("Selected:", selected);

    if (selected) {
        selected.remove();
    }
})



