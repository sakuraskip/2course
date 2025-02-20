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
    getRole():string{
        return this.role;
    }
}
class Guest extends BaseUser
{
    role = "Guest";
    constructor(id:number,name:string)
    {
        super(id,name);
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
    permissions:Array<string> = ["просмотр контента","может оставлять комментарии"];

}
class Admin extends BaseUser
{
    role = "Admin";
    constructor(id:number,name:string)
    {
        super(id,name);
    }
    permissions:Array<string> = ["просмотр контента","может оставлять комментарии","удаление комментариев","управление пользователями"];
}
//////////////////////////////
interface IReport
{
    title:string;
    content:string;
    generate():string;
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
    generate():string
    {
        return `{title: "${this.title}", content: "${this.content}}"`;
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
cache.add("price",100,5000);
console.log(cache.get("price"));
setTimeout(() => {
    console.log(cache.get("price"))
}, 1000);

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
type LogEntry = [Date,LogLevel,string]//псевдоним

function logEvent(event:LogEntry):void
{
    let [date,loglevel,info] = event;
    console.log(`${date} [${loglevel.toLocaleString()}]: ${info}`);
}
logEvent([new Date(),LogLevel.WARNING,"жееесть"])

