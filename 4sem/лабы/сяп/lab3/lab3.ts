abstract class BaseUser
{
    id:number;
    name:string;
    role!:string;
    constructor(id:number,name:string)
    {
        this.id = id;
        this.name = name;
    }
    abstract getRole():string
}
class Guest extends BaseUser
{
    role = "Guest";
    constructor(id:number,name:string)
    {
        super(id,name);
    }
    getRole()
    {
        return this.role;
    }
    permissions:Array<string> = ["просмотр контента"];
}
class User extends BaseUser
{
    role = "User";
    constructor(id:number,name:string)
    {
        super(id,name);
    }
    getRole()
    {
        return this.role;
    }
    permissions:Array<string> = ["просмотр контента","может оставлять комментарии"];

}
class Admin extends BaseUser
{
    role = "Admin";
    constructor(id:number,name:string)
    {
        super(id,name);
    }
    getRole()
    {
        return this.role;
    }
    permissions:Array<string> = ["просмотр контента","может оставлять комментарии","удаление комментариев","управление пользователями"];
}
//////////////////////////////
interface IReport
{
    title:string;
    content:string;
    generate():string|object;
}
class HTMLReport implements IReport
{
    title: string;
    content:string;
    constructor(title:string,content:string)
    {
        this.title = title;
        this.content = content;
    }
    generate():string
    {
        return `<h1>${this.title}</h1><p>${this.content}</p>`
    }
}
class JSONReport implements IReport
{
    title:string;
    content:string;
    constructor(title:string,content:string)
    {
        this.title = title;
        this.content = content;
    }
    generate():object
    {
        return {title: this.title, content: this.content};
    }
}
const report1 = new HTMLReport("отчет номер 1","содержание отчета 1");
console.log(report1.generate());
const report2 = new JSONReport("отчет номер 2","содержание отчета номер 2");
console.log(report2.generate());

class CacheБ<T>
{
    cache:Map<string,{value:T,livetime:number}>= new Map();
   
    
    add(key:string,value:T,ttl:number)
    {
        let livetime:number = Date.now()+ttl;
        this.cache.set(key,{value,livetime});
    }
    get(key:string):T|null
    {
        let obj = this.cache.get(key);
        if(!obj || obj.livetime < Date.now())
        {
            return null;
        }
        return obj.value;
    }
    clearExpired()
    {
        let time = Date.now();
        this.cache.forEach((item,key)=>
        {
            if(item.livetime < time)
            {
                this.cache.delete(key);
            }
        })
    }
}
const cache = new CacheБ<number>();
cache.add("price",100,2000);
console.log(cache.get("price"));
setTimeout(() => {
    console.log(cache.get("price"))
}, 1000);

setTimeout(()=>
{
    console.log(cache.get("price"))
},2000)

function createInstance<T>(cls: new (...args:any[])=>T,...args:any[]):T
{
    return new cls(...args);
}
const p = createInstance(User,31132,"ааааа");
console.log(p);

enum LogLevel
{
    INFO,WARNING,ERROR
}
type LogEntry = [Date,LogLevel,string]

function logEvent(event:LogEntry):void
{
    let [date,loglevel,info] = event;
    console.log(`${date} [${LogLevel[loglevel]}]: ${info}`);
}
logEvent([new Date(),LogLevel.WARNING,"жееесть"])

enum HttpStatus
{
    ok = 200,
    badRequest = 400,
    unauthorized = 401,
    InternalServerError =500
}

type ApiResponse<T> = [status:HttpStatus,data: T|null,error?:string]

function success<T>(data:T): ApiResponse<T>
{
    let response:ApiResponse<T> = [HttpStatus.ok,data];
    return response;
}
function error(message:string,status:HttpStatus):ApiResponse<null>
{
    let response:ApiResponse<null> = [status,null,message];
    return response;
}
console.log(success({user:"Андрюха"}));
console.log(error("не найдено",HttpStatus.badRequest));