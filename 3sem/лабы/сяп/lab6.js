debugger

let numbers = [1,3,2,5]
let firstnum;
[firstnum] = numbers
console.log(firstnum)

let user = {name:"олег",age:332}
let admin = {admin:"да",...user}

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

let {
    state: {
        profilePage: {
            posts,
            newPostText
        },
        dialogsPage: {
            dialogs,
            messages
        },sidebar
    }
} = store;
console.log(dialogs[3].name)
console.log("likes count: ")
posts.forEach((post)=> console.log(post.likesCount))
///////////////////////////////////////////
console.log("filtered dialog: ")
let filteredDialogs = [];
dialogs.forEach((person)=>
    {
        if(person.id%2 === 0)
        {
            filteredDialogs.push(person);
        }
    }
)
console.log(filteredDialogs);

messages = messages.map(message =>({
        message: "hello user",
        ...message
    }
));
console.log(messages);
let tasks = [
    { id: 1, title: "HTML&CSS", isDone: true },
    { id: 2, title: "JS", isDone: true },
    { id: 3, title: "ReactJS", isDone: false },
    { id: 4, title: "Rest API", isDone: false },
    { id: 5, title: "GraphQL", isDone: false },
];
let newTask = {id:6, title:"картинки",idDone:false}
tasks = [...tasks,newTask];

function sumValues(x,y,z)
{
    return x+y+z;
}
let numbers12 = [3,5,7];
console.log(sumValues(...numbers12))





