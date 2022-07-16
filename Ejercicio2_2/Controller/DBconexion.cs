using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using SignaturesApp.Model;
using SQLite;

namespace SignaturesApp.Controller
{
    public class DBconexion
    {
        readonly SQLiteAsyncConnection db;

        public DBconexion (String pathdb)
        {
            db = new SQLiteAsyncConnection(pathdb);

            db.CreateTableAsync<Firmass>().Wait();
        }

        public Task<List<Firmass>> GetListSignatures()
        {
            return db.Table<Firmass>().ToListAsync();
        }

        public Task<Firmass> GetSignatureByCode(int signatureCode)
        {
            return db.Table<Firmass>()
                .Where(i => i.code == signatureCode)
                .FirstOrDefaultAsync();
        }

        public Task<int> saveSignature(Firmass signatures)
        {
            return signatures.code != 0 ? db.UpdateAsync(signatures) : db.InsertAsync(signatures);
        }

        public Task<int> deleteSignature(Firmass signatures)
        {
            return db.DeleteAsync(signatures);
        }
    }
}
