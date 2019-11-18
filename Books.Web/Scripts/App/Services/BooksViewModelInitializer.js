"use strict";

var BooksViewModelInitializer = (function () {
    return {
        init: function () {
	        var booksTable = $(".js-books-table");
	        var editModal = $(".js-books-edit-modal");
	        var sortField = $("#SortField").val();
	        var descSort = $("#DescSort").val() === "true";

	        var model = new BooksViewModel(booksTable, editModal, sortField, descSort);
            model.initHeaders();
            model.getBooks();
            model.apply();
        }
    }
})();