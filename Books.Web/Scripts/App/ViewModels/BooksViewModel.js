"use strict";

var BooksViewModel = function (booksTable, editModal, sortField, descSort) {
	var self = this;

    self.editModel = ko.observable();
    self.books = ko.observableArray();
    self.isLoading = ko.observable(true);
	self.headers = ko.observableArray();
    self.sortField = ko.observable(sortField);
    self.descSort = ko.observable(descSort);

    self.getBooks = function () {
	    booksApp.services.booksProvider.get().done(function (books) {
	        self.updateBooks(books);
            self.isLoading(false);
        });
    }

    self.updateBooks = function (books) {
        ko.utils.arrayForEach(books, function (book) {
            var isExists = false;

            for (var i = 0; i < self.books().length; i++) {
	            var myBook = self.books()[i];

	            if (book.id === myBook.id()) {
                    myBook.update(book);
                    isExists = true;
                }
            }

            if (!isExists) {
	            self.books.push(new BookViewModel(book));
            }
        });

        sortBooks(self.sortField(), self.descSort());
    }

    self.apply = function() {
        ko.applyBindings(self, booksTable[0]);
    }

    self.initHeaders = function () {
        self.headers.push(new TableHeaderViewModel(booksApp.resources.appUI.cover));
        self.headers.push(new TableHeaderViewModel(booksApp.resources.appUI.title, "title"));
        self.headers.push(new TableHeaderViewModel(booksApp.resources.appUI.author));
        self.headers.push(new TableHeaderViewModel(booksApp.resources.appUI.pageCount, "pageCount"));
        self.headers.push(new TableHeaderViewModel(booksApp.resources.appUI.year, "year"));
        self.headers.push(new TableHeaderViewModel(booksApp.resources.appUI.publisher, "publisher"));
        self.headers.push(new TableHeaderViewModel(booksApp.resources.appUI.isbn));
        self.headers.push(new TableHeaderViewModel(""));
    }

    self.sort = function (tableHeader) {
        if (!tableHeader.canSort()) return;

        if (self.descSort() === true || self.sortField() !== tableHeader.sortField) self.descSort(false);
        else self.descSort(true);

        self.sortField(tableHeader.sortField);
        sortBooks(tableHeader.sortField, self.descSort());

        history.replaceState({
            sortField: tableHeader.sortField,
            descSort: self.descSort()
        }, null, "?sortField=" + tableHeader.sortField + "&descSort=" + self.descSort());
    }

    self.delete = function (book) {
	    booksApp.services.booksProvider.delete(book).done(function () {
	        self.books.remove(book);
        });
    }

    self.edit = function (book) {
        openEditModal(book);
    }

    self.create = function () {
        openEditModal(null);
    }

    function openEditModal(book) {
        self.editModel(new BookEditViewModel(book, editModalSaveCallback));
        editModal.modal("show");
    }

	function editModalSaveCallback(bookId) {
		booksApp.services.booksProvider.getById(bookId).done(function (book) {
			self.updateBooks([book]);
		});

		editModal.modal("hide");
	}

    function sortBooks(sortField, descSort) {
        self.books.sort(function (l, r) {
	        if (!l[sortField] || !r[sortField]) return 0;
	        
	        return l[sortField]() === r[sortField]()
                ? 0
                : l[sortField]() < r[sortField]()
                    ? descSort ? 1 : -1
                    : descSort ? -1 : 1;
        });
    }
}