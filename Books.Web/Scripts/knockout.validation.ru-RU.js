/**
 * Localization file for Russian - Russia (ru-RU)
 */
(function(factory) {
	// Module systems magic dance.
	/*global require,ko.validation,define,module*/
	if (typeof require === 'function' && typeof exports === 'object' && typeof module === 'object') {
		// CommonJS or Node
        module.exports = factory(require('../'));
	} else if (typeof define === 'function' && define['amd']) {
		// AMD anonymous module
		define(['knockout.validation'], factory);
	} else {
		// <script> tag: use the global `ko.validation` object
		factory(ko.validation);
	}
}(function(kv) {
	if (!kv || typeof kv.defineLocale !== 'function') {
		throw new Error('Knockout-Validation is required, please ensure it is loaded before this localization file');
	}
	return kv.defineLocale('ru-RU', {
		required: 'Обязательное поле',
		min: 'Введите число большее или равное {0}',
		max: 'Введите число меньшее или равное {0}',
		minLength: 'Ввведите по крайней мере {0} символов',
		maxLength: 'Введите не больше чем {0} символов',
		pattern: 'Неправильный формат поля',
		step: 'Значение должно быть кратным {0}',
		email: 'Укажите здесь правильный адрес электронной почты',
		date: 'Введите правильную дату',
		dateISO: 'Введите правильную дату в формате ISO',
		number: 'Введите число',
		digit: 'Введите цифры',
		phoneUS: 'Укажите правильный телефонный номер',
		equal: 'Значения должны быть равны',
		notEqual: 'Выберите другое значение',
		unique: 'Укажите уникальное значение'
	});
}));
