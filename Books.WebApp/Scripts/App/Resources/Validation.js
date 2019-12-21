"use strict";

extend(booksApp, {
	resources: {
		validation: {
			imageFormatError: "Only jpeg images are supported",
			imageSizeError: "The image shouldn't be more than 200KB",
			isbnError: "Incorrect ISBN number, example: 978-0804139021"
		}
	}
});