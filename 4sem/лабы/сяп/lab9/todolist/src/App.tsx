'use strict'

import React, { useState } from "react";
import { useSelector, useDispatch, Provider } from "react-redux";
import { addTask, toggleTask, editTask, deleteTask } from "./redux/actions";
interface task{
  id:number,
  text:string,
  completed:boolean
}

const App: React.FC = () => {
    const [inputValue, setInputValue] = useState("");
    const [editId, setEditId] = useState<number | null>(null);
    const tasklist = useSelector((state: { tasklist: task[] }) => state.tasklist);
    const dispatch = useDispatch();

    const handleAdd = () => {
        if (inputValue.trim()) {
            dispatch(addTask(inputValue));
            setInputValue("");
        }
    };

    const handleEdit = (task: task) => {
        setInputValue(task.text);
        setEditId(task.id);
    };

    const handleUpdate = () => {
        if (inputValue.trim() && editId) {
            dispatch(editTask(editId, inputValue));
            setInputValue("");
            setEditId(null);
        }
    };

    const handleToggle = (id: number) => {
        dispatch(toggleTask(id));
    };

    const handleDelete = (id: number) => {
        dispatch(deleteTask(id));
    };

    return (
        <div className="taskContainer">
            <h1 className="aaa">Todo List</h1>
            <input
                type="text"
                value={inputValue}
                onChange={(e) => setInputValue(e.target.value)}
                className="taskName"
            />
            {editId ? (
                <button className="buttonSave" onClick={handleUpdate}>Сохранить</button>
            ) : (
                <button className="buttonAdd" onClick={handleAdd}>Добавить</button>
            )}
            <ul className="taskList">
                {tasklist.map(task => (
                    <li className="taskText" key={task.id} style={{ textDecoration: task.completed ? 'line-through' : 'none' }}>
                        <input
                            type="checkbox"
                            checked={task.completed}
                            onChange={() => handleToggle(task.id)}
                            className="checkboxclass"
                        />
                        {task.text}
                        <div className="undoredo">
                        <button className="buttonEdit" onClick={() => handleEdit(task)}>Редактировать</button>
                        <button className="buttonDelete" onClick={() => handleDelete(task.id)}>Удалить</button>
                        </div>
                        
                    </li>
                ))}
            </ul>
        </div>
    );
};

export default App;