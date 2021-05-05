using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.Net.Http.Headers;
using Microsoft.AspNetCore.Http;
using System.Linq;
using Bono.ToDo.Web.Razor.Models;
using System.Collections.Generic;

namespace Bono.ToDo.Web.Razor.HttpClients
{
    public class TaskToDoApiClient
    {
        private readonly HttpClient httpClient;
        private readonly IHttpContextAccessor accessor;        

        public TaskToDoApiClient(HttpClient client, IHttpContextAccessor accessor)
        {
            this.httpClient = client;
            this.accessor = accessor;            
            var token = accessor.HttpContext.User.Claims.First(c => c.Type == "Token").Value;
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
        }

        public async Task<IEnumerable<TaskViewModel>> GetAllTaskToDoAsync(Guid? userId)
        {
            var resposta = await httpClient.GetAsync($"TaskToDo/GetAll/{userId.ToString()}?api-version=1.0");
            resposta.EnsureSuccessStatusCode();
            return await resposta.Content.ReadAsAsync<IEnumerable<TaskViewModel>>();
        }

        public async Task<TaskViewModel> GetTaskToDoAsync(int id)
        {            
            var resposta = await httpClient.GetAsync($"TaskToDo/{id}?api-version=1.0");
            resposta.EnsureSuccessStatusCode();
            return await resposta.Content.ReadAsAsync<TaskViewModel>();
        }

        public async Task DeleteTaskToDoAsync(int id)
        {            
            var resposta = await httpClient.DeleteAsync($"TaskToDo/{id}?api-version=1.0");
            resposta.EnsureSuccessStatusCode();
            if (resposta.StatusCode != System.Net.HttpStatusCode.NoContent)
            {
                throw new InvalidOperationException("Código de Status Http 204 esperado!");
            }
        }

        public async Task PostTaskToDoAsync(TaskViewModel TaskToDo)
        {


            var resposta = await httpClient.PostAsJsonAsync<TaskViewModel>("TaskToDo?api-version=1.0", TaskToDo);
            resposta.EnsureSuccessStatusCode();
            if (resposta.StatusCode != System.Net.HttpStatusCode.Created)
            {
                throw new InvalidOperationException("Código de Status Http 201 esperado!");
            }
        }

        public async Task PutTaskToDoAsync(TaskViewModel TaskToDo)
        {            
            
            var resposta = await httpClient.PutAsJsonAsync<TaskViewModel>("TaskToDo?api-version=1.0", TaskToDo);
            resposta.EnsureSuccessStatusCode();
            if (resposta.StatusCode != System.Net.HttpStatusCode.OK)
            {
                throw new InvalidOperationException("Código de Status Http 200 esperado!");
            }

        }

    }
}
