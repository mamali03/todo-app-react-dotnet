import { useState } from "react";
import { useTodos } from "../hooks/useTodos"
import { createTodo } from "../api/todoApi";

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

    if(loading)
    {
      return <h1>Loading...</h1>
    }

    return(
      <div>
        <h1>My Todos</h1>

        <div>
          <input value={title} onChange={(e)=>{setTitle(e.target.value)}}></input>
          <button onClick={handleCreateTodo}>Add</button>
        </div>

        <ul>
          {
            todos.map((todo)=>(
              <li key={todo.id}>{todo.title}</li>
            ))
          }
        </ul>
      </div>
    )
}