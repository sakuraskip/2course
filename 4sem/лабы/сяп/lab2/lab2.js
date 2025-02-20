"use strict";
const array = [
    { id: 1, name: 'Vasya', group: 10 },
    { id: 2, name: 'Ivan', group: 11 },
    { id: 3, name: 'Masha', group: 12 },
    { id: 4, name: 'Petya', group: 10 },
    { id: 5, name: 'Kira', group: 11 },
];
let student1 = array[0];
console.log(student1);
let car = {}; //объект создан!
car.manufacturer = "manufacturer";
car.model = 'model';
console.log(car);
const car1 = {}; //объект создан!
car1.manufacturer = "manufacturer";
car1.model = 'model';
const car2 = {}; //объект создан!
car2.manufacturer = "manufacturer";
car2.model = 'model';
const arrayCars = [{
        cars: [car1, car2]
    }];
let stud1 = {
    id: 1,
    name: "олег",
    group: 9,
    marks: [{ subject: "математика", mark: 9, done: "completed" }, { subject: "русский язык", mark: 6, done: "completed" }]
};
let stud2 = {
    id: 3,
    name: "сергей",
    group: 11,
    marks: [{ subject: "физика", mark: 8, done: "completed" }, { subject: "русский язык", mark: 8, done: "completed" }]
};
const group1 = {
    students: [],
    studentsFilter: function (group) {
        return this.students.filter(st => st.group === group);
    },
    marksFilter: function (mark) {
        return this.students.filter(st => st.marks.some(m => m.mark === mark));
    },
    deleteStudent: function (id) {
        let index = this.students.findIndex(st => st.id === id);
        if (index !== -1) {
            this.students.splice(index, 1);
        }
    },
    group: 1,
    mark: 0
};
group1.students.push(stud1);
group1.students.push(stud2);
console.log(group1.marksFilter(8));
group1.deleteStudent(3);
console.log("\n");
group1.students.forEach(std => {
    console.log(std);
});
