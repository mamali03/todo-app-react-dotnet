import { useEffect, useState } from "react";
import type {Todo} from "../types/Todo";
import { getTodos } from "../api/todoApi";

export function useTodos()
{
    const [todos,setTodos] = useState<Todo[]>([]);
    const [loading,setLoading] = useState(true);

    useEffect(()=>{
        loadTodos();
    },[]);

    async function loadTodos()
    {
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

    return {
        todos,
        loading,
        reload: loadTodos
    };
}