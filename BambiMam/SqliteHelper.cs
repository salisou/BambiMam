using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using BambiMam.Models;
using SQLite;

namespace BambiMam
{
    public class SqliteHelper
    {
        SQLiteAsyncConnection db;

        public SqliteHelper(string dbPath)
        {
            db = new SQLiteAsyncConnection(dbPath);
            db.CreateTableAsync<Registrazioni>();
        }

        public Task<int> CreateRegistrazioni(Registrazioni registrazioni)
        {
            return db.InsertAsync(registrazioni);
        }

        public Task<List<Registrazioni>> SelectRegistrazioni()
        {
            return db.Table<Registrazioni>().ToListAsync();
        }

        public Task<int> UpdateRegistrazioni(Registrazioni registrazioni)
        {
            return db.UpdateAsync(registrazioni);
        }
        
        public Task<int> DeleteRegistrazioni(Registrazioni registrazioni)
        {
            return db.DeleteAsync(registrazioni);
        }


        public Task<List<Registrazioni>> RicercaNellaLista(string cerca)
        {
            
            return db.Table<Registrazioni>().Where(p => p.name.StartsWith(cerca)).ToListAsync();
        }
    }
}
