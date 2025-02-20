class Task
{
    constructor(id,name,status)
    {
        this.id = id;
        this.name = name;
        this.status = status
    }
    changename(name)
    {
        this.name = name
    }
    changeStatus(status)
    {
        this.status = status
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
    filtertasks(status)
    {
        return this.tasks.filter(task=> task.status === status);
    }
    printTask(task)
    {
        let tasklist = document.querySelector(".tasksList");

        let div = document.createElement("div");
        let divname = document.createElement("div");
        let checkbox = document.createElement("input");
        let paragraph = document.createElement("p");
        let divbuttons = document.createElement("div");
        let editbutton = document.createElement("button");
        let deletebutton = document.createElement("button");

        div.classList.add("task");
        div.id = `task-${task.id}`;
        let tskname = task.name;
        tskname = tskname.replace(/\s+/g, '');
        div.setAttribute('name',`${tskname}`);

        divname.classList.add("nameandbutton");

        checkbox.type = "checkbox";
        checkbox.name = "status";
        checkbox.checked = task.status;

        paragraph.textContent = task.name;

        divbuttons.classList.add("buttons");

        editbutton.name = "editbutton";
        editbutton.textContent = "редактировать";
        
        deletebutton.name = "deletebutton";
        deletebutton.textContent = "удалить..";

        checkbox.addEventListener("change",()=>
        {
            task.status = checkbox.checked;
        });
        editbutton.addEventListener('click',()=>
        {
            let name = prompt("новое название старого дела");
            task.changename(name);
            paragraph.textContent = name;
            div.setAttribute('name',`${name}`);
        });
        deletebutton.addEventListener('click',()=>
        {
            this.deleteTask(task);
        });
        divname.appendChild(checkbox);
        divname.appendChild(paragraph);
        divbuttons.appendChild(editbutton);
        divbuttons.appendChild(deletebutton);
        div.appendChild(divname);
        div.appendChild(divbuttons);

        tasklist.appendChild(div);
    }
    printTasks()
    {
        let tasklist = document.querySelector(".tasksList");
        tasklist.innerHTML = '';
        this.tasks.forEach((task)=>
        {
            this.printTask(task);
        });
    }
    deleteTask(task)
    {
        let index = this.tasks.indexOf(task);
        if(index !=-1)
        {
            this.tasks.splice(index,1);
            console.log(index); 
            let tskname = task.name;
        tskname = tskname.replace(/\s+/g, '');
            let div = document.querySelector(`[name =${tskname}]`);
            div.remove();
        }
    }
    showTrueTasks()
    {
        let buff = this.filtertasks(true);
        let tasklist = document.querySelector(".tasksList");
        tasklist.innerHTML = "";
        buff.forEach((task)=>
        {
            this.printTask(task);
        })
    }
    showFalseTask()
    {
        let buff = this.filtertasks(false);
        let tasklist = document.querySelector(".tasksList");
        tasklist.innerHTML = "";
        buff.forEach((task)=>
        {
            this.printTask(task);
        })
    }
}
let todolist = new Todolist(0,"дела");
var taskid = 0;
document.addEventListener('DOMContentLoaded',()=>
{
    let addbutton = document.getElementById("add");
    let input = document.getElementById("newtask");

    addbutton.addEventListener('click',()=>
    {
        let taskname = input.value.trim();
        input.value = '';
        if(taskname)
        {
            let task = new Task(taskid++,taskname,false);
            todolist.addTask(task);
            todolist.printTask(task);
        }
        else
        {
            alert("название пустым не бывает")
        }
       
    });
    let showall = document.getElementById('showall');
    showall.addEventListener('click',()=>
    {
        todolist.printTasks();
    });
    let showcompleted = document.getElementById('showcompleted');
    showcompleted.addEventListener('click',()=>
    {
        todolist.showTrueTasks();
    });
    let showuncompleted = document.getElementById('showuncompleted');
     showuncompleted.addEventListener('click',()=>
    {
         todolist.showFalseTask();
     });
});

