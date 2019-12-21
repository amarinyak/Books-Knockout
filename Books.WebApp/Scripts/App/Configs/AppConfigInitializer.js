"use strict";

extend(booksApp, {
	appConfigInitializer: (function () {
		function initToken() {
			var def = $.Deferred();

			if (sessionStorage["token"] == null) {
				booksApp.services.authProvider.getToken().done(function (token) {
					booksApp.appConfig.token = token;
					sessionStorage["token"] = token;
					def.resolve();
				});
			} else {
				booksApp.appConfig.token = sessionStorage["token"];
				def.resolve();
			}

			return def.promise();
		}

		return {
			init: function (appConfigData) {
				var def = $.Deferred();

				$.extend(booksApp.appConfig, appConfigData);

				initToken().done(function () {
					def.resolve();
				});

				return def.promise();
			}
		}
	})()
});