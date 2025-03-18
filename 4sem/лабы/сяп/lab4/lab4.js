"use strict";
let myPromise = new Promise((res, rej) => {
    setTimeout(() => res(console.log(Math.random())), 3000);
});
function task3(delay) {
    return new Promise((res, rej) => {
        setTimeout(() => res(Math.random()), delay);
    });
}
Promise.all([task3(1000), task3(500), task3(2500)]).then((values) => {
    console.log(values);
});
let pr = new Promise((res, rej) => {
    rej('kus');
});
pr.
    then(() => console.log(1))
    .catch(() => console.log(2))
    .catch(() => console.log(3))
    .then(() => console.log(4))
    .then(() => console.log(5));
