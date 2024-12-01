debugger;
function basicOperation(operation,value1,value2)
{
    switch(operation)
    {
        case '-': return value1+value2;
        case '+': return value1-value2;
        case '/': return value1*value2;
        case '*': return value1/value2;
        default: console.log("оператор не подходит");
    }

}
function cubic(n)
{
    let result = 0;
    for(let i=0;i<=n;i++)
    {
        result+= Math.pow(i,3);
    }
    return result;
}

function average(array)
{
    let sum = 0;
    for(let i=0;i<array.length;i++)
    {
        sum +=array[i];
    }
    return Math.ceil(sum/array.length);
}
function reverseStr(string)
{
    let buff = "";
    for(let i = string.length-1;i>=0;i--)
    {
        buff +=string[i];
    }
    buff = buff.replace(/[^a-zA-Z]+/g,'');
    return buff;
}
console.log(reverseStr("олегсергейстанисла      в???211231lfosаваыflsd"));
function repeatString(n,string)
{
    if(n<0)
    {
        return "";
    }
    let buf = "";
    for(let i=0;i<n;i++)
    {
        buf+=string;
    }
    return buf;
}
console.log(repeatString(3,"тапочек"));

function stringArray(arr1,arr2)
{
    let arr3 = [];
    let index = 0;
    for(let i=0;i<arr1.length;i++)
    {
        if(arr2.includes(arr1[i]) === false)
        {
            arr3[index++] = arr1[i];
        }
    }
    return arr3;
}
console.log(stringArray(["ddss","qwee","fdgfd"],["ddss","2r2wfw","fdfd"]));

