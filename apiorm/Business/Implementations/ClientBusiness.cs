using apiorm.Business.Interfaces;
using apiorm.Exceptions;
using apiorm.Models;
using apiorm.Repository.Context;
using apiorm.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace apiorm.Business.Implementations
{
    public class ClientBusiness : IClientBusiness
    {
        private readonly IClientRepository _client;
        private readonly IRepositoryEF _repo;

        public ClientBusiness(IClientRepository client, IRepositoryEF repo)
        {
            _client = client;
            _repo = repo;
        }

        public async Task<Client[]> GetAllClients()
        {
            var result = await _client.GetAllClients();
            if (result.Equals(null))
                throw new DataNotFoundException("Não foram encontrados Clientes cadastrados.");
            else
                return result;
        }

        public async Task<Client> CreateClient(Client model)
        {
            ClientIsNotNull(model);

            _repo.Add(model);

            if (await _repo.SaveChangeAsync())
                return model;
            else            
                throw new InvalidOperationException();         
            
        }       

        /// <summary> 
        /// Verifica se os campos do Client não são nulos
        /// </summary>
        public void ClientIsNotNull(Client client)
        {
            if (client.ClientId.Equals(0))
                throw new ModelFieldIsNullException("O ID do Cliente não pode ser 0");
            else if (string.IsNullOrEmpty(client.Name))
                throw new ModelFieldIsNullException("O nome do Cliente está vazio");
        }
    }
}
