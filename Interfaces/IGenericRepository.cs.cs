﻿using SENAI_Notes.Models;

namespace SENAI_Notes.Interfaces
{
    public interface IGenericRepository<T> where T : class
    {
        T? ObterPorId(int id);
        List<T> ListarTodos();
        void Cadastrar(T entidade);
        T? Atualizar(int id, T entidade);
        T? Deletar(int id);
    }
}
