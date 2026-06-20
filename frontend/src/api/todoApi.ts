import type {Todo} from "../types/Todo";

const API_BASE_URL ="https://fluffy-goggles-q7wr4qwjxpp2wq7-5054.app.github.dev";
//const API_BASE_URL = "http://localhost:5054"

export async function getTodos():Promise<Todo[]>{
    console.log("getTodos started");
   const response = await fetch(`${API_BASE_URL}/api/todos`);

   if(!response.ok)
   {
    throw new Error("Failed to fetch Todos");
   }
   console.log("response received");
   return response.json();
}