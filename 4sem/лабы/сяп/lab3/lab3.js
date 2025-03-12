"use strict";
class BaseUser {
    constructor(id, name) {
        this.id = id;
        this.name = name;
    }
}
class Guest extends BaseUser {
    constructor(id, name) {
        super(id, name);
        this.role = "Guest";
        this.permissions = ["просмотр контента"];
    }
    getRole() {
        return this.role;
    }
}
class User extends BaseUser {
    constructor(id, name) {
        super(id, name);
        this.role = "User";
        this.permissions = ["просмотр контента", "может оставлять комментарии"];
    }
    getRole() {
        return this.role;
    }
}
class Admin extends BaseUser {
    constructor(id, name) {
        super(id, name);
        this.role = "Admin";
        this.permissions = ["просмотр контента", "может оставлять комментарии", "удаление комментариев", "управление пользователями"];
    }
    getRole() {
        return this.role;
    }
}
class HTMLReport {
    constructor(title, content) {
        this.title = title;
        this.content = content;
    }
    generate() {
        return `<h1>${this.title}</h1><p>${this.content}</p>`;
    }
}
class JSONReport {
    constructor(title, content) {
        this.title = title;
        this.content = content;
    }
    generate() {
        return { title: this.title, content: this.content };
    }
}
const report1 = new HTMLReport("отчет номер 1", "содержание отчета 1");
console.log(report1.generate());
const report2 = new JSONReport("отчет номер 2", "содержание отчета номер 2");
console.log(report2.generate());
class CacheБ {
    constructor() {
        this.cache = new Map();
    }
    add(key, value, ttl) {
        let livetime = Date.now() + ttl;
        this.cache.set(key, { value, livetime });
    }
    get(key) {
        let obj = this.cache.get(key);
        if (!obj || obj.livetime < Date.now()) {
            return null;
        }
        return obj.value;
    }
    clearExpired() {
        let time = Date.now();
        this.cache.forEach((item, key) => {
            if (item.livetime < time) {
                this.cache.delete(key);
            }
        });
    }
}
const cache = new CacheБ();
cache.add("price", 100, 2000);
console.log(cache.get("price"));
setTimeout(() => {
    console.log(cache.get("price"));
}, 1000);
setTimeout(() => {
    console.log(cache.get("price"));
}, 2000);
function createInstance(cls, ...args) {
    return new cls(...args);
}
const p = createInstance(User, 31132, "ааааа");
console.log(p);
var LogLevel;
(function (LogLevel) {
    LogLevel[LogLevel["INFO"] = 0] = "INFO";
    LogLevel[LogLevel["WARNING"] = 1] = "WARNING";
    LogLevel[LogLevel["ERROR"] = 2] = "ERROR";
})(LogLevel || (LogLevel = {}));
function logEvent(event) {
    let [date, loglevel, info] = event;
    console.log(`${date} [${LogLevel[loglevel]}]: ${info}`);
}
logEvent([new Date(), LogLevel.WARNING, "жееесть"]);
var HttpStatus;
(function (HttpStatus) {
    HttpStatus[HttpStatus["ok"] = 200] = "ok";
    HttpStatus[HttpStatus["badRequest"] = 400] = "badRequest";
    HttpStatus[HttpStatus["unauthorized"] = 401] = "unauthorized";
    HttpStatus[HttpStatus["InternalServerError"] = 500] = "InternalServerError";
})(HttpStatus || (HttpStatus = {}));
function success(data) {
    let response = [HttpStatus.ok, data];
    return response;
}
function error(message, status) {
    let response = [status, null, message];
    return response;
}
console.log(success({ user: "Андрюха" }));
console.log(error("не найдено", HttpStatus.badRequest));
