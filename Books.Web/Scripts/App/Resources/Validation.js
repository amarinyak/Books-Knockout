"use strict";

extend(booksApp, {
	resources: {
		validation: {
			imageFormatError: "Unsupported image format, only jpeg images are supported",
			isbnError: "Incorrect ISBN number, example: 978-0804139021"
		}
	}
});