"use strict";

extend(booksApp, {
    services: {
        booksProvider: (function () {
            return {
                get: function () {
                    return booksApp.services.httpClient.get("books");
                },
                getById: function (id) {
                    return booksApp.services.httpClient.get("books/" + id);
                },
                create: function (book) {
                    return booksApp.services.httpClient.post("books", ko.toJS(book));
                },
                update: function (book) {
                    return booksApp.services.httpClient.put("books", ko.toJS(book));
                },
                delete: function (book) {
                    return booksApp.services.httpClient.delete("books/" + book.id());
                }
            }
        })()
    }
});