using System;
using Microsoft.EntityFrameworkCore;
using SENAI_Notes.Models;

namespace SENAI_Notes.Interfaces
{
    public interface ITagRepository : IGenericRepository<Tag>
    {
        List<Tag> BuscarPorUsuario(int id);
        Tag BuscarPorUsuarioeId(int id, string nome);
    }
}

