"use strict";

extend(booksApp, {
	config: {
		validation: (function () {
			function getDigitArray(value) {
				var val = value.replace(/[^0-9]/g, "");

				var digits = [];

				for (var i = 0; i < val.length; i++) {
					digits.push(parseInt(val[i]));
				}

				return digits;
			}

			function checkIsbn(value) {
				if (value == null || value === "") return true;
				if (value.length !== 14) return false;
				if (!/^[0-9]{3}-[0-9]{10}$/.test(value)) return false;

				var digits = getDigitArray(value);

				var sum = 0;
				for (var i = 0; i < 12; i++) {
					var rate = i % 2 === 0 ? 1 : 3;
					sum += digits[i] * rate;
				}

				var result = sum % 10;

				if (result !== 0) result = 10 - result;

				return digits[12] === result;
			}

			return {
				initRules: function () {
					ko.validation.rules["checkIsbn"] = {
						validator: function (val, enabled) {
							if (!enabled) return true;
							return checkIsbn(val);
						},
						message: booksApp.resources.validation.isbnError
					};

					ko.validation.registerExtenders();
				}
			}
		})()
	}
});