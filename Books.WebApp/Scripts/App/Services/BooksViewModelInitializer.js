"use strict";

extend(booksApp, {
	services: {
		booksViewModelInitializer: (function () {
			return {
				init: function (booksTable, editModal, sortField, descSort) {
					var model = new BooksViewModel(booksTable, editModal, sortField, descSort);
					model.initHeaders();
					model.getBooks();
					model.apply();
				}
			}
		})()
	}
});