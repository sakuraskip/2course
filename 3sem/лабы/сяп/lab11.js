class Task
{
    constructor(id,name,done)
    {
        this.id = id;
        this.name = name;
        this.done = done
    }
    changename(name)
    {
        this.name = name
    }
    changedone(done)
    {
        this.done = done
    }
}
class Todolist
{
    constructor(id,name)
    {
        this.id = id;
        this.name = name;
        this.tasks = []
    }
    changename(name)
    {
        this.name = name;
    }
    addTask(task)
    {
        this.tasks.push(task);
    }
    filtertasks(done)
    {
        return this.tasks.filter(task=> task.done === done);
    }
    
}

const todo1 = new Todolist(1,"важные дела очень");
const todo2 = new Todolist(2,"орехи?");

const task1 = new Task(1,"мыть полы", false);
const task2 = new Task(2,"убирать посуду",true);

todo1.addTask(task1);
todo1.addTask(task2);
todo2.addTask(task1);

console.log(todo1.filtertasks(true));

task2.changedone(false);
console.log(task2);

task2.changename("убрал посуду");
console.log(task2);