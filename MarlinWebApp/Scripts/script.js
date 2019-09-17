

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

$('#compareButton').on("click", function () {
    var inputs = [];
    var promise = new Promise(function (resolve, reject) {
        inputs = $(".card-deck").find(".compare-input").map(function () {
            if ($(this).prop("checked") == true) {
                console.log($(this).parent().parent().find("input[name='Product_ID']").val())
                return $(this).parent().parent().find("input[name='Product_ID']").val();
            }
        }).get();
        if (inputs.length > 0)
            resolve();
        else reject();
    });
    promise.then(function (success) {
        $.ajax({
            type: "GET",
            url: "/ProductCompare",
            data: {
                'products': JSON.stringify(inputs.to)
            },
            contentType: "application/json",
            cache: false,
            success: function (result) {
                window.location.href = "/ProductCompare?products=" + JSON.stringify(inputs);
            },
            error: function (error) {
                console.log(error.message);
            }
        });
    }, function (failure) {
            //Do nothing
    });
    /*var inputs = $(".card-deck").find(".compare-input").map(function () {
        if ($(this).prop("checked") == true) {
            console.log($(this).parent().parent().find("input[name='Product_ID']").val())
            return this;
        }
    }).get().success(function () {
        console.log(inputs);
        $.ajax({
            type: "GET",
            url: "/ProductCompare",
            data: {
                'products': JSON.stringify(inputs)
            },
            contentType: "application/json",
            cache: false,
            success: function (result) {
                window.location.href = "/ProductCompare?products=" + JSON.stringify(inputs);
            },
            error: function (error) {
                console.log(error.message);
            }
        });
    });*/
})

