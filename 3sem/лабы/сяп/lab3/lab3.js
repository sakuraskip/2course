debugger;
let array1 = [1,[1,2,[3,4]],[2,4]];
let array2 = [1,[4,[7,2],3],5];

let result05 = array1.reduce((result,current) =>
{
    return result.concat(current);
},[]);
let result1 = result05.reduce((result,current) =>
{
    return result.concat(current);
},[]);
console.log(result1);
/////////////////////////////////////////////////

let result15 = array2.reduce((result,current) =>
{
    return result.concat(current);
},[]);
let result2 = result15.reduce((result,current) =>
{
    return result.concat(current);
},[]);
console.log(result2);
/////////////////////////////////////////////////
function arraySum(array)
{
    let result = 0;

    for(const num of array)
    {
        if(Array.isArray(num))
        {
            result = result +arraySum(num);
        }
        else
        {
            result = result+num;
        }
    }
    return result;
}
let array3 = [1,2,3,4];
let result3 = array3.reduce((result,current)=>
{
    return result+current

});
console.log(result3);
console.log(arraySum(array1));

function oldStudents(students)
{
    let result = {};
    for(const student of students)
    {
        if(student.age > 17)
        {
            if(!result[student.groupId])
            {
                result[student.groupId] = [];
            }
            result[student.groupId].push(student);
        }
    }
    return result;
}
let students =
    [
        {name: "олег",age:18,groupId:3},
        {name:"серега",age:19,groupId: 2},
        {name: "виталик",age :31, groupId: 3}
    ];
console.log(oldStudents(students));
//////////////////////////////////////////
let string = 'ABCD';
let total1 = "";
for(let i =0;i<string.length;i++)
{
    total1 = total1 +string.charCodeAt(i);
}
const total2 = total1.replace(/7/g,'1');

console.log(Number(total1) - Number(total2));

function extend(...obj)
{
    let result = {};
    Object.assign(result,...obj);
    return result;
}
console.log(extend({a:1,b:2},{c:3},{b:6}));
function pyramid(floors)
{
    let result = [];
    for(let i=1;i<=floors;i++)
    {
        let space = ' ';
        for(let j=0;j<floors-i;j++)
        {
            space = space+' ';
        }
        let stars = ''
        for(let j=0;j<(2*i-1);j++)
        {
            stars = stars+'*';
        }
        result.push(space+stars)
    }
    return result;
}
console.log(pyramid(5).join('\n'));
