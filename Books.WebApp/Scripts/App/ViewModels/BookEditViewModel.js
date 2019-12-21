"use strict";

var BookEditViewModel = function (book, saveCallback) {
	var self = this;
	var isEditMode = book != null;

	self.title = isEditMode
		? booksApp.resources.appUI.editBook
		: booksApp.resources.appUI.addBook;

	if (isEditMode) {
		self.book = new BookViewModel(ko.toJS(book));
	} else {
		self.book = new BookViewModel({});
	}

	if (self.book.authors().length === 0) {
		self.book.authors.push(new AuthorViewModel({}));
	}

	self.save = function (bookEdit) {
		if (!bookEdit.book.isValid()) return;

		if (isEditMode) {
			booksApp.services.booksProvider.update(bookEdit.book).done(function () {
				saveCallback(book.id());
			});
		} else {
			booksApp.services.booksProvider.create(bookEdit.book).then(function (bookId) {
				saveCallback(bookId);
			});
		}
	}
}