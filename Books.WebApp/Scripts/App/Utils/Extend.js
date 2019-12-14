function extend(destination, source) {
	var toString = Object.prototype.toString;
	var objTest = toString.call({});
 
	for (var property in source ) {
		if (source.hasOwnProperty(property)) {
			if (source[property] && objTest === toString.call(source[property])) {
				destination[property] = destination[property] || {};
				extend(destination[property], source[property]);
			} else {
				destination[property] = source[property];
			}
		}
	}

	return destination;
};