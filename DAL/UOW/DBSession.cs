using Microsoft.Extensions.Configuration;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.UOW
{
    internal class DBSession : IDisposable, IDBSession
    {
        public IDbConnection Connection { get; }

        public IDbTransaction Transaction { get; set; }

        public DBSession(IConfiguration configuration)
        {
            //Récupère la chaîne de connection dans le fichier appsettings.json
            string chaineDeConnection = configuration.GetConnectionString("default");

            // On créé une instance de SQLConnection
            Connection = new SqlConnection(chaineDeConnection);

            // Ouverture de la connection <= Echec de connection?
            Connection.Open();
        }

        public void Dispose()
        {
            // Quand la session de connection à la base de donnée est supprimée
            // on ferme la connection

            Connection.Close();
        }
    }
}
