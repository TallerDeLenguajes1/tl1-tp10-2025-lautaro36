using datosUsuario;
using System;
using System.Text.Json;

HttpClient client = new HttpClient();
HttpResponseMessage httpResponse = await client.GetAsync("https://jsonplaceholder.typicode.com/users");
httpResponse.EnsureSuccessStatusCode();

string responseBody = await httpResponse.Content.ReadAsStringAsync();
List<Usuarios> listaUsuarios = JsonSerializer.Deserialize<List<Usuarios>>(responseBody);

int bandera = 0;
foreach (Usuarios item in listaUsuarios)
{
    Console.WriteLine($"\n---Usuario {bandera+1}: {item.Name}---\nEmail: {item.Email}\nDomicilio: {item.Address.City}, {item.Address.Street} {item.Address.Suite}");
    if (bandera == 4)
    {
        break;
    }
    bandera++;
}

string jsonString = JsonSerializer.Serialize<List<Usuarios>>(listaUsuarios);
string path = "ArchivoUsuarios.json";
File.WriteAllText(path, jsonString);