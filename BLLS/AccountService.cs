using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;

namespace BLLS
{
    public class AccountService : IAccountService
    {
        public List<Writer> writers = new List<Writer>()
        {
            new Writer(){Id = 1, FirstName = "Alexandre", IsModerator = true, LastName = "Dumas"},
            new Writer(){Id = 2, FirstName = "firstname2", LastName = "lastname2"},
            new Writer(){Id = 3, FirstName = "firstname3", LastName = "lastname3"},
            new Writer(){Id = 4, FirstName = "firstname4", IsModerator = true, LastName = "lastname4"},
            new Writer(){Id = 5, FirstName = "firstname5", LastName = "lastname5"},
            new Writer(){Id = 6, FirstName = "firstname6", LastName = "lastname6"}
        };

        public async Task<IEnumerable<Writer>> GetWritersAsync()
        {
            await Task.Delay(0);
            return writers;
        }

        public async Task<Writer> GetWriterByIdAsync(int id)
        {
            await Task.Delay(0);
            return writers.Find((writer) => writer.Id == id);
        }

        public async Task<Writer> CreateWriterAsync(Writer newWriter)
        {

            await Task.Delay(0);
            int lastId = 0;
            foreach (Writer writer in writers)
            {
                if (lastId < writer.Id) lastId = writer.Id;
            }
            lastId++;

            newWriter.Id = lastId;

            try
            {
                writers.Add(newWriter);
                return newWriter;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public async Task<Writer> ModifyWriterAsync(Writer modifiedWriter)
        {
            await Task.Delay(0);


            Writer writerFound = null;

            foreach (Writer writer in writers)
            {
                if (writer.Id == modifiedWriter.Id)
                {
                    writerFound = writer;
                }
            }
            if (writerFound == null) return null;

            writerFound.FirstName = modifiedWriter.FirstName;
            writerFound.LastName = modifiedWriter.LastName;
            writerFound.IsModerator = modifiedWriter.IsModerator;

            return writerFound;


        }

        public async Task<bool> DeleteWriterAsync(int id)
        {
            await Task.Delay(0);
            Writer writerFound = null;
            foreach (Writer writer in writers)
            {
                if (writer.Id == id)
                {
                    writerFound = writer;
                }
            }
            if (writerFound == null) return false;
            writers.Remove(writerFound);
            return true;

        }
    }
}
