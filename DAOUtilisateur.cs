using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace AssisesSportLorrain
{
    class DAOUtilisateur
    {
        public static Utilisateur getUserPass(Utilisateur unUtilisateur)
        {
            string req = "select * from UTILISATEUR where emailUtilisateur ='" + unUtilisateur.EmailUtilisateur + "' and passUtilisateur = '" + unUtilisateur.PassUtilisateur + "'";
            DAOFactory db = new DAOFactory();
            db.connecter();

            SqlDataReader reader = db.excecSQLRead(req);
            reader.Read();
            Utilisateur US = new Utilisateur(reader[0].ToString(), reader[1].ToString());

            return US;
        }

        public static void creerUtilisateur(Utilisateur unUtilisateur)
        {
            string requete = "insert into Utilisateur values('" + unUtilisateur.EmailUtilisateur + "','" + unUtilisateur.PassUtilisateur + "')";
            DAOFactory db = new DAOFactory();
            db.connecter();
            db.execSQLWrite(requete);
        }
    }
}
