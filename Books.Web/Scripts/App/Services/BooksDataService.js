var BooksDataService = (function () {
    return {
        getList: function (sortField, descSort, successCallback) {
            $.ajax({
                method: "GET",
                url: "/Api/Books/GetList",
                data: {
                    sortField: sortField,
                    descSort: descSort
                },
                content: "json",
                success: successCallback
            });
        },
        getById: function (id, successCallback) {
            $.ajax({
                method: "GET",
                url: "/Api/Books/GetById",
                data: { id: id },
                content: "json",
                success: successCallback
            });
        },
        saveOrUpdate: function (book, successCallback) {
            $.ajax({
                method: "POST",
                url: "/Api/Books/CreateOrUpdate",
                contentType: "application/json",
                data: JSON.stringify(ko.toJS(book)),
                success: successCallback
            });
        },
        delete: function (book, successCallback) {
            $.ajax({
                method: "POST",
                url: "/Api/Books/Delete",
                contentType: "application/json",
                data: JSON.stringify({ id: book.id() }),
                success: successCallback
            });
        }
    }
})();