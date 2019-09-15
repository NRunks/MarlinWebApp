
function increaseValue() {
    var value = parseInt(document.getElementById('number').value, 10);
    value = isNaN(value) ? 0 : value;
    value = value + 1;
    document.getElementById('number').value = value;
}
function reduceValue() {
    var value = parseInt(document.getElementById('number').value, 10);
    value = isNaN(value) ? 0 : value;
    value = value - 1;
    document.getElementById('number').value = value;
}

$('#categorySelect').on("change", function (ev) {
    console.log(ev);
    window.location = "/Search/Index?category=" + this.value;
});

$('#subCategorySelect').on("change", function (ev) {
    console.log(ev);
    window.location = window.location.href.split("&subcategory=")[0] + '&subcategory=' + this.value;
    $("#search-input").prop("disabled", false);
});
