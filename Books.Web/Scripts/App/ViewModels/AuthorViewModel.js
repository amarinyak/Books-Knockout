"use strict";

var AuthorViewModel = function(author) {
	var self = this;

    self.id = ko.observable(author.id);

    self.firstName = ko.observable(author.firstName);
    self.firstName.extend({
        required: true,
        maxLength: 20
    });

    self.lastName = ko.observable(author.lastName);
    self.lastName.extend({
        required: true,
        maxLength: 20
    });

    self.bookId = ko.observable(author.bookId);

    self.update = function (updAuthor) {
        if (updAuthor == null) return;

        self.firstName(updAuthor.firstName);
        self.lastName(updAuthor.lastName);
    }
}