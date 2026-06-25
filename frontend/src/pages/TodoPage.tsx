import { useState } from "react";
import { useTodos } from "../hooks/useTodos"
import { createTodo, deleteTodo, updateTodo } from "../api/todoApi";
import type { Todo } from "../types/Todo";

export function TodoPage()
{
    const {todos,loading,reload} = useTodos();
    const [title,setTitle] = useState("");

    async function handleCreateTodo()
    {
      if(!title.trim())
      {
        return;
      }

      await createTodo(title);
      setTitle("");
      await reload();
    }

    async function handleDeleteTodo(id:string)
    {
      await deleteTodo(id);
      await reload();
    }

    async function handleToggleTodo(todo:Todo,isCompleted:boolean)
    {
      const updatedTodo = {
        ...todo,isCompleted
      }

      await updateTodo(updatedTodo);
      await reload();
    }

    if(loading)
    {
      return <h1>Loading...</h1>
    }

    return(
      <div>
        <h1>My Todos</h1>

        <div>
          <input value={title} placeholder="Enter Todo Title" onChange={(e)=>{setTitle(e.target.value)}}></input>
          <button onClick={handleCreateTodo}>Add</button>
        </div>

        <ul>
          {
            todos.map((todo)=>(
              <li key={todo.id}>
                <input type="checkbox" checked={todo.isCompleted} onChange={(e)=>{handleToggleTodo(todo,e.target.checked)}} />
                {todo.title} 
                <button onClick={()=>handleDeleteTodo(todo.id)}>Delete</button>
              </li>
            ))
          }
        </ul>
      </div>
    )
}