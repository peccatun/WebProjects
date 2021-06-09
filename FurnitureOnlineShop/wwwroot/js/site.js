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

