"use strict";

var BooksDataProvider = (function () {
    return {
        getList: function () {
	        return $.ajax({
		        method: "GET",
		        url: "/Api/Books/GetList",
		        content: "json"
	        });
        },
        getById: function (id) {
	        return $.ajax({
		        method: "GET",
		        url: "/Api/Books/GetById",
		        data: {
			        id: id
		        },
		        content: "json"
	        });
        },
        create: function (book) {
	        return $.ajax({
		        method: "POST",
		        url: "/Api/Books/Create",
		        contentType: "application/json",
		        data: JSON.stringify(ko.toJS(book))
	        });
        },
        update: function (book) {
	        return $.ajax({
		        method: "POST",
		        url: "/Api/Books/Update",
		        contentType: "application/json",
		        data: JSON.stringify(ko.toJS(book))
	        });
        },
        delete: function (book) {
	        return $.ajax({
		        method: "POST",
		        url: "/Api/Books/Delete",
		        contentType: "application/json",
		        data: JSON.stringify({
			        id: book.id()
		        })
	        });
        }
    }
})();