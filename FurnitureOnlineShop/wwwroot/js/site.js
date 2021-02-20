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

