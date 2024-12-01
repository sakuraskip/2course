//const prompt = require('prompt-sync')();
debugger;
let a1 = 5;
console.log("тип a1 : ",typeof(a1));
let name = "Name";
console.log("тип name : ",typeof(name));
let i =0;
let double = 0.23;
console.log("тип double: ",typeof(double));
let result = 1/0;
console.log("тип result: ", typeof(result));
let answerbool = true; //infinity
console.log("тип answerbool: ", typeof(answerbool));
let no = null // object
console.log("тип no: ", typeof(no));
let quadrArea = 45*21;
let square = 5*5;
let answer = Math.floor(quadrArea/square);
console.log(answer);

let i1 = 2;
let a = ++i1;
let b = i1++;
if(a > b)
{
    console.log("a > b");
}
else if(a<b)
{
    console.log("a<b");
}
else if(a === b)
{
    console.log("a == b");
}

console.log("Котик" > "котик" ? "больше": "не больше");
console.log("Котик" > "китик"? "больше": "не больше");
console.log("Кот" > "Котик" ? "больше" : "не больше");
console.log(73 == "53" ? "одинаковые" : "не одинаковые");
console.log("Привет" === "Пока" ? "одинаковые" : "не одинаковые");
console.log(false == 0 ? "одинаковые": "не одинаковые");
console.log(54 === true ? "однаковые": "не одинаковые");
console.log(123 === false ? "однаковые": "не одинаковые");
console.log(true == "3"? "однаковые": "не одинаковые");
console.log(3 == "5мм" ? "однаковые": "не одинаковые");
console.log(8 == "-2"? "однаковые": "не одинаковые");
console.log(34 == "34"? "однаковые": "не одинаковые");
console.log(null == undefined ? "однаковые": "не одинаковые");

const teacherName = "Алина";
const userName = prompt("введите ваше имя: ");
const dividedUserName = userName.trim().toLowerCase().split(" ");


if(dividedUserName.includes(teacherName.toLowerCase()))
{
    console.log("введены верные данные");
}
else
{
    console.log("введены неверные данные");
}
const test23 = confirm("подвердить?");
const russian = true;
const math = true;
const english = true;

if(russian && math && english)
{
    console.log("переведен на следующий курс");
}
else if(!russian && !math && !english)
{
    console.log("студент отчислен");
}
else
{
    console.log("пересдача");
}
console.log(true+true);
console.log(0+"5");
console.log(5+"мм");
console.log(8/Infinity);
console.log(9*"\n9");
console.log(null-1);
console.log("5"-2);
console.log("5px"-3);
console.log(true-3);
console.log(7||0);

for(let i = 1;i<=10;i++)
{
    if(i%2===0)
    {
        console.log(i+2);
    }
    else
    {
        console.log(i+"мм");
    }
}
let userDay = prompt("введите номер дня(от 1 до 7): ");
if(userDay < 1 || userDay >7)
{
    console.log("неверный номер дня")
}
else
{
    let objDays = {1:"понедельник",2:"вторник",3:"среда",4:"четверг",5:"пятница", 6:"суббота",7:"воскресенье"};
    console.log(objDays[userDay]);
    let arrayDays = ["понедельник","вторник","среда","четверг","пятница","суббота","воскресенье"];
    console.log(arrayDays[userDay-1]);
}

function task10(parm1 = "по умолчанию",parm2,parm3)
{
    parm3 = prompt("введите третий параметр: ");
    return parm1+" "+parm2+" "+parm3;
}
task10();
let rectA = 4;
let rectB = 5;

function params(a,b)
{
    if(a === b)
    {
        return a*4;
    }
    return a*b;
}
const funcExpression = function(a,b)
{
    if(a===b)
    {
        return a*4;
    }
    return a*b;
}
let arrowFunc = (a,b) =>
{
    if(a===b)
    {
        return b*4;
    }
    return a*b;
}






