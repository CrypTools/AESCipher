/********************************************
*
* Use: "Hello World!".encrypt("key")
*      "Hello World!".encrypt("key", 256) // specify AES 256 / 128 / 192
* => "7wLYjsECTlqEj3WjyF1urctafZ4="
*
********************************************/
// Make sure that lib.js is in your folder.
const {Aes, AesCtr} = require("./lib.js");

String.prototype.encrypt = function (key, bits=256) {
	return AesCtr.encrypt(this, key, bits)
};
