let person = {name:"олег",age:123,
    greet()
    {
        console.log("привет "+this.name)
    },
    ageAfterYears(years)
    {
        return years+this.age;
    }
}
person.greet()
person.name = "максим"
console.log(person.ageAfterYears(10));
let car = {model:"на колесах",year:2010,
    getInfo()
    {
        console.log("модель машины: "+this.model+" год: "+this.year)
    }
}
console.log(car.model);
car.getInfo()
function Book(title,author)
{
    this.title = title;
    this.author = author;

    this.getTitle = function()
    {
        return this.title
    }
    this.getAuthor = function()
    {
        return this.author;
    }
}

const book = new Book("колобок","народ")
console.log(book.getAuthor())

let team = {
    players:[
        {name:"серега",salary:"5 мильярдов",age:31},
        {name:"дима",salary:"сухари",age:100},
        {name:"генадий",salary:"100 тысяч",age:12}
    ],
    getInfo:function()
    {
        this.players.forEach(player =>{
            console.log("Имя: "+ player.name + ", зарплата: "+player.salary + ", возраст: "+player.age);
        });
    }
}
team.players[1].age = 50;
team.getInfo()

let counter = (function(){
    let obj = {
        count: 0,
     
        increment()
        {
            this.count++;
            return this.count
        },
        decrement()
        {
            this.count--;
            return this.count
        },
        getCount()
        {
           return this.count;
        }
    }

    return obj;
})();

console.log(counter.increment());
console.log(counter.increment());
console.log(counter.decrement());
console.log(counter.getCount());

let item = {}

Object.defineProperty(item,'price',{
    value:5000,
    writable:true,
    configurable:true
});

item.price = 123;
Object.defineProperty(item,'price',{
    writable:false,
    configurable:false
});

let object = {
    _radius:2,

    get area()
    {
        return 3.14*this.radius*this.radius
    },
    get radius()
    {
        return this._radius;
    },
    set radius(value)
    {
        this._radius = value;
    }
};
console.log(object.area)
let car1 = {make:"ваз",model:"2109",year:1987};

Object.defineProperty(car1,'make',
    {
        writable: false,
        configurable: false
    });
Object.defineProperty(car1,'model',{
    writable:false,
    configurable:false
    
});
Object.defineProperty(car1,'year',{
    writable: false,
    configurable:false
});

const task9 = [5,7,9];
Object.defineProperty(task9,'sum',{
    get()
    {
        return task9.reduce((result,num)=> result+num,0);
    },
    enumerable: false,
    configurable:false
});

console.log(task9.sum);

let rectangle = {_width:5,_height:10,
get area()
{
    return this._width*this._height;
},
get width()
{
    return this._width;
},
set width(value)
{
    this._width = value
},
get height()
{
    return this._height;
},
set height(value)
{
    this._height = value;
}
};
console.log(rectangle.height = 15);
console.log(rectangle.height);
console.log(rectangle.area);

let user1 = {
    firstname: "олег", lastname: "олег",
    get fullname()
    {
        return this.firstname + " " + this.lastname;
    },
    set fullname(name)
    {
        let nameparts = name.split(' ');
        this.firstname = nameparts[0];
        this.lastname = nameparts[1];
    }
};
console.log(user1.fullname)













