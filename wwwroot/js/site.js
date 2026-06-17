const input = document.getElementById("input");

const buttonAdd = document.getElementById("add-button");

const buttonRemove = document.getElementById("remove-button");

const list = document.getElementById("list");

buttonAdd.addEventListener("click", function () {

    const value = input.value;
    const li = document.createElement("li");
    li.textContent = value;
    list.appendChild(li);
    input.value = "";


});
buttonRemove.addEventListener("click", function () {
    const items = list.getElementsByTagName("li");  
    if (items.length > 0) {
        list.removeChild(items[items.length - 1]);
    }
});



