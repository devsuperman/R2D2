using System.Net.Http.Json;
using Dominio.Interfaces;
using Dominio.Models;

namespace R2D2.Client.Services;

public class TareasService : ITareasRepository
{
    private readonly HttpClient httpClient;

    public TareasService(HttpClient httpClient)
    {
        this.httpClient = httpClient;
    }
    public async Task<Tarea> AddAsync(Tarea model)
    {
        var cliente = await httpClient.PostAsJsonAsync("api/Tareas", model);
        var response = await cliente.Content.ReadFromJsonAsync<Tarea>();
        return response!;
    }

    public async Task<Tarea> DeleteAsync(int id)
    {
        var cliente = await httpClient.DeleteAsync($"api/Tareas/{id}");
        var response = await cliente.Content.ReadFromJsonAsync<Tarea>();
        return response!;
    }

    public async Task<List<Tarea>> GetAllAsync()
    {
        var clientes = await httpClient.GetAsync("api/Tareas");
        var response = await clientes.Content.ReadFromJsonAsync<List<Tarea>>();
        return response!;
    }

    public async Task<Tarea> GetAsync(int id)
    {
        var cliente = await httpClient.GetAsync($"api/Tareas/{id}");
        var response = await cliente.Content.ReadFromJsonAsync<Tarea>();
        return response!;
    }

    public async Task<Tarea> UpdateAsync(Tarea model)
    {
        var cliente = await httpClient.PutAsJsonAsync("api/Tareas", model);
        var response = await cliente.Content.ReadFromJsonAsync<Tarea>();
        return response!;
    }
}