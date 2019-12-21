"use strict";

extend(booksApp, {
	services: {
		httpClient: (function () {
			function sendRequest(method, url, data) {
				return $.ajax({
					method: method,
					url: booksApp.appConfig.webApiUrl + url,
					data: data == null ? null : JSON.stringify(data),
					headers: {
						"Authorization": "Basic " + booksApp.appConfig.token
					},
					contentType: "application/json",
					dataType: "json"
				});
			}

			return {
				get: function (url, data) {
					return sendRequest("GET", url, data);
				},
				post: function (url, data) {
					return sendRequest("POST", url, data);
				},
				put: function (url, data) {
					return sendRequest("PUT", url, data);
				}
				,
				delete: function (url, data) {
					return sendRequest("DELETE", url, data);
				}
			}
		})()
	}
});