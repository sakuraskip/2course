

let obj1 = {size: "big",shape:"square", color: "yellow"}
let obj2 = {...obj1, size: "small"}

let obj3 = {...obj1, shape : "circle", color: "none"}
let obj4 = {...obj3,color: "green" }

let obj5 = {...obj1, shape: "triangle",color:"none", lines: 1}
let obj6 = {...obj5, lines:3}

let diffFromObj1 = Object.entries(obj4).filter(([key, value])=> obj1[key] !== value);
console.log(diffFromObj1)

let diffTriangle3Lines = Object.entries(obj6).filter(([key,value])=> obj1[key]!== value);
console.log(diffTriangle3Lines)

console.log(obj2.hasOwnProperty('color') && obj2.color !== obj1.color)

class Human {
    constructor(name,surname,address,yearofbirth)
    {
        this.name = name;
        this.surname = surname;
        this._yearofbirth = yearofbirth
        this.address = address;
    }
    changeAge(age)
    {
        this.age = age;
    }
    changeAddress(address)
    {
        this.address = address;
    }
    get age()
    {
        return 2024 - this._yearofbirth
    }
    set yearofbirth(year)
    {
        this._yearofbirth = year;
    }
}
class Student extends Human{
    constructor(faculty, course, group,number )
    {
        this.faculty = faculty;
        this.course = course;
        this.group = group;
        this.number = number;
    }
    course(course)
    {
        this.course = course;
    }
     group(group)
    {
        this.group = group
    }
    getFullName()
    {
        return this.name +" "+ this.surname;
    }
}
class Faculty
{
    constructor(facultyname, groupamount,studentsamount)
    {
        this.facultyname = facultyname;
        this.groupamount = groupamount;
        this.studentsamount = studentsamount;
    }
    groupamount(groups)
    {
        this.groupamount = groups;
    }
    studentsamount(amount)
    {
        this.studentsamount = amount;
    }
    getDev(students)
    {
        let result =0
        students.forEach(student => {
            if(student.number[1] === 3)
            {
                result++;
            }
        });
        return result;
    }
    getGroup(students, group)
    {
        let result = [];
        students.forEach(student => {
            if(student.group === group)
            {
                result.push(student)
            }
        });
    }
}