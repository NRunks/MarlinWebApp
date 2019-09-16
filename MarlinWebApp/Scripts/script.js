

/*function slide () {
    $("#slider-range").slider({
        range: true,
        min: 0,
        max: 500,
        values: [75, 300],
        slide: function (event, ui) {
            if (ui.values[0] == ui.values[1]) {
                return false;
            }
            $(".PropertyFrom").val(ui.values[0]);
            $(".PropertyTo").val(ui.values[1]);
        }
    });
    $(".PropertyFrom").val($("#slider-range").slider("values", 0));
    $(".PropertyTo").val($("#slider-range").slider("values", 1));
}; */

$('#categorySelect').on("change", function (ev) {
    console.log(ev);
    window.location = "/Search/Index?category=" + this.value;
});

$('#subCategorySelect').on("change", function (ev) {
    console.log(ev);
    window.location = window.location.href.split("&subcategory=")[0] + '&subcategory=' + this.value;
    $("#search-input").prop("disabled", false);
});

