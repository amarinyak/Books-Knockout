"use strict";

extend(booksApp, {
    services: {
        authProvider: (function () {
            return {
                getToken: function () {
                    return booksApp.services.httpClient.get("auth/token");
                }
            }
        })()
    }
});