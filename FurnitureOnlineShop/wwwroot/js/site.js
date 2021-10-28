var categories;

function alertForDelete(id) {
    if (confirm('Сигурни ли сте че искате да изтриете тази категория')) {
        callDeleteCategoryMethod(id);
    } else {

    }
}

function callDeleteCategoryMethod(id) {
    $.ajax({
        url: "DeleteCategory?categoryId=" + id,
        type: "GET",
        data: {},
        dataType: "json",
        success: function (responce) {
            alert('Успешно изтрихте избраната категория');
            window.location.href = responce.url;
        },
        error: function () { }
    });
}

function getSubCategoryItems(id) {
    $.ajax({
        url: "GetSubCategories?categoryId=" + id,
        type: "GET",
        data: {},
        dataType: "Json",
        success: function (responce) {
            var list1 = document.getElementById("subCategoryDropDown");
            clearList(list1);
            for (var i = 0; i < responce.length; i++) {
                var opt = responce[i].text;
                var el = document.createElement("option");
                el.textContent = opt;
                el.value = responce[i].value;
                list1.appendChild(el);
            }
        },
        error: function () { }
    });
}

function clearList(list1) {
    while (list1.options.length) {
        list1.options.remove(0);
    }
}

function addColor() {
    var text = document.getElementById("colorName").value;

    $.ajax({
        url: "AddColor?color=" + text,
        type: "GET",
        data: {},
        dataType: "Json",
        success: function (colors) {
            var colorsSelect = document.getElementById("colorsSelect");
            clearList(colorsSelect);
            for (var i = 0; i < colors.length; i++) {
                var opt = colors[i].text;
                var el = document.createElement("option");
                el.textContent = opt;
                el.value = colors[i].value;
                colorsSelect.appendChild(el);
            }
        },
        error: function () {

        }

    })

}

function productDetails(id) {
    $.ajax({
        url: '@Url.Content("~/Products/ProductDetails?id=" + id)',
        type: 'GET',
        contentType: 'application/json',
        success: function (data) {

        },
        error: function (error) {

        }
    });
}

