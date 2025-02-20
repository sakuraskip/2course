const array = [
    {id: 1, name: 'Vasya', group: 10}, 
    {id: 2, name: 'Ivan', group: 11},
    {id: 3, name: 'Masha', group: 12},
    {id: 4, name: 'Petya', group: 10},
    {id: 5, name: 'Kira', group: 11},
]

interface Student
{
    id:number,
    name:string,
    group:number;
}

let student1:Student = array[0];
console.log(student1);

/////
type CarsType = 
{
    manufacturer?:string,
    model?:string;
}
type ArrayCarsType = 
{
    cars:Array<CarsType>
}

let car: CarsType = {}; //объект создан!
car.manufacturer = "manufacturer";
car.model = 'model';
console.log(car);
const car1: CarsType = {}; //объект создан!
car1.manufacturer = "manufacturer";
car1.model = 'model';

const car2: CarsType = {}; //объект создан!
car2.manufacturer = "manufacturer";
car2.model = 'model';

const arrayCars: Array<ArrayCarsType> = [{
    cars: [car1, car2]
}];

type MarkFilterType = 1 | 2|3|4|5|6|7|8|9|10;
type GroupFilterType = 1|2|3|4|5|6|7|8|9|10|11|12;
type DoneType = 'completed'|'not completed';

type MarkType = {
    subject: string,
    mark: MarkFilterType, // может принимать значения от 1 до 10
    done: DoneType,
}
type StudentType = {
    id: number,
    name: string,
    group: GroupFilterType, // может принимать значения от 1 до 12
    marks: Array<MarkType>,
}
type GroupType = {
    students: Array<StudentType>// массив студентов типа StudentType
    studentsFilter: (group: number) => Array<StudentType>, // фильтр по группе
    marksFilter: (mark: number) => Array<StudentType>, // фильтр по  оценке
    deleteStudent: (id: number) => void, // удалить студента по id из  исходного массива
    mark: MarkFilterType,
    group: GroupFilterType,
   
}
let stud1:StudentType ={
    id: 1,
    name: "олег",
    group: 9,
    marks: [{subject:"математика",mark:9,done:"completed"},{subject:"русский язык",mark:6,done:"completed"}]
}
let stud2:StudentType ={
    id: 3,
    name: "сергей",
    group: 11,
    marks: [{subject:"физика",mark:8,done:"completed"},{subject:"русский язык",mark:8,done:"completed"}]
}
const group1:GroupType = {
    students: [],
    studentsFilter: function(group:number):Array<StudentType>
    {
        return this.students.filter(st=>st.group === group);
    },
    marksFilter:function(mark:number):Array<StudentType>
    {
        return this.students.filter(st=>st.marks.some(m=>m.mark === mark));
    },
    deleteStudent:function(id:number):void
    {
        let index:number = this.students.findIndex(st=>st.id === id);
        if(index !== -1)
        {
            this.students.splice(index,1);
        }
    },
    group:1,
    mark: 0 as MarkFilterType
}
group1.students.push(stud1);
group1.students.push(stud2);

console.log(group1.marksFilter(8));
group1.deleteStudent(3);
console.log("\n");
group1.students.forEach(std => {
    console.log(std);
});