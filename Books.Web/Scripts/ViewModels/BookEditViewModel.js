var BookEditViewModel = function(book, createOrUpdateCallBack) {
	var self = this;
	var isEditMode = book != null;
	
    self.title = isEditMode
	    ? resources.appUI.editBook
	    : resources.appUI.addBook;

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
		    BooksDataService.update(bookEdit.book, function() {
			    createOrUpdateCallBack(book.id());
		    });
	    } else {
		    BooksDataService.create(bookEdit.book, function(bookId) {
			    createOrUpdateCallBack(bookId);
		    });
	    }
    }
}