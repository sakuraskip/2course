"use strict";
//7-8
let promise = new Promise((res, rej) => {
    res('resolved promise 1');
});
promise.then((res) => {
    console.log('resolved promise 2');
    return 'OK';
})
    .then((res) => {
    console.log(res);
});
console.log("\n\n");
