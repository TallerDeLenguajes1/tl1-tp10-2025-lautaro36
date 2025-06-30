using System;
using System.Text.Json;
using tareasEspacio;

HttpClient client = new HttpClient();
HttpResponseMessage httpResponse = await client.GetAsync("https://jsonplaceholder.typicode.com/todos/");
httpResponse.EnsureSuccessStatusCode();

string responseBody = await httpResponse.Content.ReadAsStringAsync();
List<Tareas> listaTareas = JsonSerializer.Deserialize<List<Tareas>>(responseBody);

Console.WriteLine("---Tareas pendientes---");
foreach (Tareas item in listaTareas)
{
    if (!item.Completed)
    {
        Console.WriteLine($"Tarea {item.Title}, ID {item.Id} pendiente, asignada a {item.UserId}");
    }
}

Console.WriteLine("---Tareas completadas---");
foreach (Tareas item in listaTareas)
{
    if (item.Completed)
    {
        Console.WriteLine($"Tarea {item.Title}, ID {item.Id} completada por usuario {item.UserId}");
    }
}

string jsonString = JsonSerializer.Serialize<List<Tareas>>(listaTareas);
string path = "archivoTareas.json";
File.WriteAllText(path, jsonString);
