"use strict";
var __awaiter = (this && this.__awaiter) || function (thisArg, _arguments, P, generator) {
    function adopt(value) { return value instanceof P ? value : new P(function (resolve) { resolve(value); }); }
    return new (P || (P = Promise))(function (resolve, reject) {
        function fulfilled(value) { try { step(generator.next(value)); } catch (e) { reject(e); } }
        function rejected(value) { try { step(generator["throw"](value)); } catch (e) { reject(e); } }
        function step(result) { result.done ? resolve(result.value) : adopt(result.value).then(fulfilled, rejected); }
        step((generator = generator.apply(thisArg, _arguments || [])).next());
    });
};
let pr1 = new Promise((res, rej) => {
    res(21);
});
pr1.then((value) => { console.log(value); return value; })
    .then((value) => console.log(value * 2));
function return21() {
    return __awaiter(this, void 0, void 0, function* () {
        return 21;
    });
}
function task6() {
    return __awaiter(this, void 0, void 0, function* () {
        let num = yield return21();
        console.log(num);
        console.log(num * 2);
    });
}
task6();
