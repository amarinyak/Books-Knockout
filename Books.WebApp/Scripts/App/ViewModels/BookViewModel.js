"use strict";

var BookViewModel = function (book) {
	var self = this;

	self.id = ko.observable(book.id);

	self.title = ko.observable(book.title);
	self.title.extend({
		required: true,
		maxLength: 30
	});

	self.pageCount = ko.observable(book.pageCount);
	self.pageCount.extend({
		required: true,
		min: 1,
		max: 10000
	});

	self.publisher = ko.observable(book.publisher);
	self.publisher.extend({
		maxLength: 30
	});

	self.year = ko.observable(book.year);
	self.year.extend({
		required: true,
		min: 1800,
		max: 9999
	});

	self.isbn = ko.observable(book.isbn);
	self.isbn.extend({
		checkIsbn: true
	});

	self.createDate = ko.observable(book.createDate);

	self.editDate = ko.observable(book.editDate);

	self.coverImageUploaderValue = ko.observable(null);

	self.image = ko.observable(book.image);

	self.hasImage = ko.pureComputed(function () {
		return self.image() != null;
	});

	self.authors = ko.observableArray();

	updateAuthors(book.authors);

	self.update = function (updBook) {
		if (updBook == null) return;

		self.id(updBook.id);
		self.title(updBook.title);
		self.pageCount(updBook.pageCount);
		self.publisher(updBook.publisher);
		self.year(updBook.year);
		self.isbn(updBook.isbn);
		self.image(updBook.image);
		self.createDate(updBook.createDate);
		self.editDate(updBook.editDate);

		updateAuthors(updBook.authors);
	}

	function updateAuthors(authors) {
		self.authors.removeAll();
		if (authors != null) {
			ko.utils.arrayForEach(authors, function (author) {
				self.authors.push(new AuthorViewModel(author));
			});
		}
	}

	self.addAuthor = function () {
		self.authors.push(new AuthorViewModel({
			bookId: self.id()
		}));
	}

	self.deleteAuthor = function (author) {
		self.authors.remove(author);
	}

	self.uploadImage = function (myBook, e) {
		var file = e.target.files[0];

		if (!/^image\/jpeg$/.test(file.type)) {
			alert(booksApp.resources.validation.imageFormatError);
			self.coverImageUploaderValue(null);
			return;
		}

		if ((file.size / 1024) > 200) {
			alert(booksApp.resources.validation.imageSizeError);
			self.coverImageUploaderValue(null);
			return;
		}

		var reader = new FileReader();

		reader.addEventListener("load", function () {
			self.image(reader.result);
		});

		reader.readAsDataURL(file);
	}

	self.deleteImage = function () {
		self.image(null);
		self.coverImageUploaderValue(null);
	}

	self.isValid = function () {
		var errors = ko.validation.group(self, { deep: true });

		if (errors().length === 0) return true;

		errors.showAllMessages();
		return false;
	}
}