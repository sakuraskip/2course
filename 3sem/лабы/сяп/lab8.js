let user = {name:'Masha',age:21}
let usercopy = {...user}

let numbers = [1,2,3];

let user1 = {
    name:'Masha',
    age:23,
    location: {
        city: 'Minsk',
        country: 'Belarus'
    }
};
let user1copy = {...user1,
    location: {...user1.location}
}


let user2 = {
    name:'Masha',
    age: 28,
    skills: ["HTML","CSS","JAVASCRIPT","React"]
};
let user2copy = {...user2,
    skills: [...user2.skills]
}

const array = [
    {id: 1, name: 'Vasya', group: 10},
    {id: 2, name: 'Ivan', group: 11},
    {id: 3, name: 'Masha', group: 12},
    {id: 4, name: 'Petya', group: 10},
    {id: 5, name: 'Kira', group: 11},
]
let arraycopy = array.map(obj =>(
    {...obj}
));
let user4 = {
    name: 'Masha',
    age: 19,
    studies: {
        university: 'BSTU',
        speciality: 'designer',
        year: 2020,
        exams: {
            maths: true,
            programming: false
        }
    }
};
let user4copy = {
    ...user4,
    studies : { ...user4.studies, exams: {...user4.studies.exams}}
}


let user5 = {
    name: 'Masha',
    age: 22,
    studies: {
        university: 'BSTU',
        speciality: 'designer',
        year: 2020,
        department: {
            faculty: 'FIT',
            group: 10,
        },
        exams: [
            { maths: true, mark: 8},
            { programming: true, mark: 4},
        ]
    }
};
let user5copy = {
    ...user5,
    studies:{ ...user5.studies, department: {...user5.studies.department},
    exams: user5.studies.exams.map(exam => ({...exam}))
}
}

let user6 = {
    name: 'Masha',
    age: 21,
    studies: {
        university: 'BSTU',
        speciality: 'designer',
        year: 2020,
        department: {
            faculty: 'FIT',
            group: 10,
        },
        exams: [
            {
                maths: true,
                mark: 8,
                professor: {
                    name: 'Ivan Ivanov ',
                    degree: 'PhD'
                }
            },
            {
                programming: true,
                mark: 10,
                professor: {
                    name: 'Petr Petrov',
                    degree: 'PhD'
                }
            },
        ]
    }
};
let user6copy = {
    ...user6,
    studies: {...user6.studies, exams: user6.studies.exams.map(exam =>({
        ...exam, professor: {...exam.professor},
    }))}
}
let user7 = {
    name: 'Masha',
    age: 20,
    studies: {
        university: 'BSTU',
        speciality: 'designer',
        year: 2020,
        department: {
            faculty: 'FIT',
            group: 10,
        },
        exams: [
            {
                maths: true,
                mark: 8,
                professor: {
                    name: 'Ivan Petrov',
                    degree: 'PhD',
                    articles: [
                        {title: "About HTML", pagesNumber: 3},
                        {title: "About CSS", pagesNumber: 5},
                        {title: "About JavaScript", pagesNumber: 1},
                    ]
                }
            },
            {
                programming: true,
                mark: 10,
                professor: {
                    name: 'Petr Ivanov',
                    degree: 'PhD',
                    articles: [
                        {title: "About HTML", pagesNumber: 3},
                        {title: "About CSS", pagesNumber: 5},
                        {title: "About JavaScript", pagesNumber: 1},
                    ]
                }
            },
        ]
    }
};
let user7copy = {
    ...user7,
    studies: 
    {
        ...user7.studies,
        department: {...user7.studies.department},
        exams: user7.studies.exams.map(exam =>({
            ...exam,
            professor : {
                ...exam.professor,
                articles : exam.professor.articles.map(article=>({...article}))
            }
        }))
    }
}

let store = {
    state: {
        profilePage: {
            posts: [
                {id:1,message:"Hi",likesCount:12},
                {id:2,message: "Bye",likesCount: 1},
            ],
            newPostText: 'about me',
        },
        dialogsPage: {
            dialogs: [
                {id:1,name:'valera'},
                {id:2,name:'andrey'},
                {id: 3,name:'sasha'},
                {id:4,name:'viktor'},
            ],
            messages: [
                {id:1,message:'hi'},
                {id:2,message:'hi hi'},
                {id:3,message:'hi hi hi'},
            ],
        },
        sidebar: [],
    },
}
let storecopy = {
    ...store,
    state: {
        ...store.state,
        profilePage: {
            ...store.state.profilePage,
            posts: [store.state.profilePage.posts[0],store.state.profilePage.posts[1]]
        },
        dialogsPage: {
            ...store.state.dialogsPage,
            dialogs: [store.state.dialogsPage.dialogs[0],store.state.dialogsPage.dialogs[1],store.state.dialogsPage.dialogs[2],store.state.dialogsPage.dialogs[3]],
            messages: [store.state.dialogsPage.messages[0],store.state.dialogsPage.messages[1],store.state.dialogsPage.messages[2]]
        },
        sidebar : [...store.state.sidebar],

    },
}

console.log(storecopy);
console.log(user7copy);
console.log("\n");

user5copy.studies.department.group = 12;
user5copy.studies.exams[1].mark = 10;

user6copy.studies.exams[0].professor.name = "олег";
user7copy.studies.exams[1].professor.articles[1].pagesNumber = 3;

storecopy.state.dialogsPage.messages = [{...store.state.dialogsPage.messages[0],message:"hellow"},{...store.state.dialogsPage.messages[1],message:"hellow"},{...store.state.dialogsPage.messages[2],message:"hellow"}]
console.log(storecopy)


