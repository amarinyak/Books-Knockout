"use strict";

var BooksDataProvider = (function () {
    return {
        getList: function () {
	        return $.ajax({
		        method: "GET",
		        url: "/Api/v1/Books",
		        content: "json"
	        });
        },
        getById: function (id) {
	        return $.ajax({
		        method: "GET",
		        url: "/Api/v1/Books/" + id,
		        content: "json"
	        });
        },
        create: function (book) {
	        return $.ajax({
		        method: "POST",
		        url: "/Api/v1/Books",
		        contentType: "application/json",
		        data: JSON.stringify(ko.toJS(book))
	        });
        },
        update: function (book) {
	        return $.ajax({
		        method: "PUT",
		        url: "/Api/v1/Books",
		        contentType: "application/json",
		        data: JSON.stringify(ko.toJS(book))
	        });
        },
        delete: function (book) {
	        return $.ajax({
		        method: "DELETE",
		        url: "/Api/v1/Books/" + book.id(),
		        contentType: "application/json"
	        });
        }
    }
})();