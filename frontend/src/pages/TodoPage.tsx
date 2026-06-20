import { useTodos } from "../hooks/useTodos"

export function TodoPage()
{
    const {todos,loading} = useTodos();
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