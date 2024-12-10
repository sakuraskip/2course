debugger;

let obj1 = {size: "big",shape:"square", color: "yellow"}
let obj2 = {__proto__: obj1,size:"small"}

let obj3 = {size: "big", shape : "circle", color: "none"}
let obj4 = {__proto__: obj3,color: "green" }

let obj5 = {size: "big", shape: "triangle",color:"none", lines: 1}
let obj6 = {__proto__: obj5, lines:3}

let diffFromObj1 = Object.entries(obj2).filter(([key, value])=> obj1[key] !== value);
console.log(diffFromObj1)

let diffTriangle3Lines = Object.entries(obj6).filter(([key,value])=> obj5[key]!== value);
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
       this._yearofbirth = 2024-age;
    }
    changeAddress(address)
    {
        this.address = address;
    }
    get age()
    {
        return 2024 - this._yearofbirth
    }
    set age(_age)
    {
        this._yearofbirth = 2024-_age
    }
}
const human1 = new Human("олег","владимирович","за мкадом",2004);
console.log(human1.age);
human1.changeAge(105);
console.log(human1.age = 25)
console.log(human1._yearofbirth);
class Student extends Human{
    constructor(name,surname,address,yearofbirth,faculty, course, group,number )
    {
        super(name,surname,address,yearofbirth);
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
const student1 = new Student("святослав","андреевич","тоже за мкадом",2001,"ФИТ","второй",2,73231727);
const student2 = new Student("oleg","сергеевич","минск",2002,"ИД","третий",4,63222728);

console.log(student1.getFullName())
console.log(student1.age);
class Faculty
{
    constructor(facultyname, groupamount,studentsamount)
    {
        this.facultyname = facultyname;
        this._groupamount = groupamount;
        this._studentsamount = studentsamount;
    }
    groupamount(groups)
    {
        this._groupamount = groups;
    }
    studentsamount(amount)
    {
        this._studentsamount = amount;
    }
    getDev(students)
    {
        let result =0
        students.forEach(student => {
            let numstr = student.number.toString();
            if(numstr[1] == 3)
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
            if(student.group == group)
            {
                result.push(student)
            }
        });
        return result
    }
}

const faculty1 = new Faculty("ит",10,200);
faculty1.groupamount(500)
console.log(faculty1._groupamount);
let students = [student1,student2];
console.log(faculty1.getDev(students))
console.log(faculty1.getGroup(students,2))
