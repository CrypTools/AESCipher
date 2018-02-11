/********************************************
*
* Use: "7wLYjsECTlqEj3WjyF1urctafZ4=".decrypt("key")
*      "7wLYjsECTlqEj3WjyF1urctafZ4=".decrypt("key", 256) // specify AES 256 / 128 / 192
* => "Hello World!"
*
********************************************/
// Make sure that lib.js is in your folder.
const {Aes, AesCtr} = require("./lib");

String.prototype.decrypt = function (key, bits=256) {
	return AesCtr.decrypt(this, key, bits)
};
