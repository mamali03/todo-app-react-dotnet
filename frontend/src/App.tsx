import { useEffect, useState } from "react";
import type {Todo} from "./types/Todo";
import { getTodos } from "./api/todoApi";

function App()
{
  console.log("App started");
  const [todos,setTodos] = useState<Todo[]>([]);
  const [loading,setLoading] = useState(true);

  useEffect(()=>{
    console.log("useEffect started");
    loadTodos();
  },[]);

  async function loadTodos()
  {
    console.log("loadTodos started");
    try
    {
      const data = await getTodos();
      setTodos(data);
    }
    finally
    {
      setLoading(false);
    }
  }

  if(loading)
  {
    return <h1>Loading...</h1>
  }

  return(
    <div>
      <h1>My Todos</h1>
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

export default App