debugger;
const products = new Set();

function addProduct(product)
{
    products.add(product);
    console.log(product+" добавлен");
}
function removeProduct(product)
{
    if(products.has(product))
    {
        products.delete(product);
        console.log(product+" удален");
    }
    else
    {
        console.log(product+" не удален(его нет)");
    }
}
function checkProduct(product)
{
    if(products.has(product))
    {
        console.log(product+" есть")
    }
    else
    {
        console.log(product + " его нет");
    }
}
function productsAmount(set)
{
    console.log("кол-во товара: "+set.size)
}

let prod1 = "репейник"
addProduct(prod1)
checkProduct(prod1)
removeProduct(prod1)
checkProduct(prod1)
////////////////////////////////////
const students = new Set();
let student1 = {num:13,group:3,fio:"олег"}
let student2 = {num:7,group:2,fio:"серега"}
let student3 = {num:1231,group:1,fio:"шаман"}

addStudent(student1)
addStudent(student2)
addStudent(student3)

function addStudent(student)
{
    students.add(student);
    console.log(student.fio + " добавлен");
}
function removeStudentByNum(num)
{
    for(let student of students)
    {
        if(student.num === num)
        {
            students.delete(student);
            console.log(student+ " удален");
        }
    }
}
function filterStudents(group)
{
    return Array.from(students).filter((student)=> student.group === group);
}
console.log(filterStudents(2))
function sortByNum()
{
    return Array.from(students).sort((a,b)=> a.num - b.num);
}
console.log(sortByNum())
/////////////////////////////////////////////
const productsMap = new Map();
const prod2 = {id:1,name:"шиповник",amount:34,price:123};
const prod3 = {id:2,name:"грибы",amount:15,price:1700};
const prod4 = {id:3,name:"ягоды",amount:124,price:560};
addProd(prod2);
addProd(prod3);
addProd(prod4);
console.log("ааывывщзавышщатывщаыгщ")
console.log(productsMap.entries());
changeEveryProdAmount(150);
deleteByName("ягоды");
function addProd(product)
{
    const {id,name,amount,price} = product
    if(productsMap.has(id))
    {
        let temp = productsMap.get(id);
        temp.amount = temp.amount+amount;
        temp.price = price;
    }
    else
    {
        productsMap.set(id,{name,amount,price});
    }
    console.log("товар "+product.name +" добавлен");
}
function deleteById(id)
{
    if(productsMap.has(id))
    {
        productsMap.delete(id);
        console.log("удалено");
    }
    else
    {
        console.log("не удалено");
    }
}
function deleteByName(name)
{
    for(let [id,product] of productsMap)
    {
        if(product.name === name)
        {
            productsMap.delete(id);
        }
    }
    console.log("товар с названием "+name +" удален");
}
function changeEveryProdAmount(amount)
{
    productsMap.forEach(product =>
    {
        product.amount =amount;
    });
    console.log("кол-во товаров изменено");
}
function changePrice(id,price)
{
    let temp = productsMap.get(id);
    temp.price = price;
    console.log("цена "+temp+ " изменена");
}
function totalAmount()
{
    let result =0;
    productsMap.forEach(product =>
    {
        result+=product.amount;
    });
    return result;
}
function totalPrice()
{
    let result = 0;
    productsMap.forEach(product=>
    {
        result+=product.amount*product.price;
    });
    return result
}
console.log(totalAmount());
console.log(totalPrice());
/////////////////////////////////////
const weakmap = new WeakMap();

function calc(number)
{
    return number+5-4;
}

function cachingFunc2(key)
{
    if(weakmap.has(key))
    {
        console.log("берем с кеша")
        return weakmap.get(key)
    }
    const result = calc(key.key);
    weakmap.set(key,result);
    console.log("не берем с кеша")
    return result;
}
 obj5 = {key:5};
console.log(cachingFunc2(obj5));
console.log(cachingFunc2(obj5))
 obj5 = {key:6}
console.log(cachingFunc2(obj5))







