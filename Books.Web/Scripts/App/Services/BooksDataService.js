var BooksDataService = (function () {
    return {
        getList: function (successCallback) {
            $.ajax({
                method: "GET",
                url: "/Api/Books/GetList",
                content: "json",
                success: successCallback
            });
        },
        getById: function (id, successCallback) {
            $.ajax({
                method: "GET",
                url: "/Api/Books/GetById",
                data: {
	                id: id
                },
                content: "json",
                success: successCallback
            });
        },
        create: function (book, successCallback) {
            $.ajax({
                method: "POST",
                url: "/Api/Books/Create",
                contentType: "application/json",
                data: JSON.stringify(ko.toJS(book)),
                success: successCallback
            });
        },
        update: function (book, successCallback) {
	        $.ajax({
		        method: "POST",
		        url: "/Api/Books/Update",
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
                data: JSON.stringify({
					id: book.id()
                }),
                success: successCallback
            });
        }
    }
})();