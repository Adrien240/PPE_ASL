using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace AssisesSportLorrain
{
    class DAOTheme
    {
        // Retourne une collection de tous les Themes lus en BDD 
        public static List<Theme> getAllThemes()
        {
            List<Theme> lesThemes = new List<Theme>();
            string req = "select * from THEME";
            DAOFactory db = new DAOFactory();
            db.connecter();

            SqlDataReader reader = db.excecSQLRead(req);

            while (reader.Read())
            {
                Theme at = new Theme(int.Parse(reader[0].ToString()), reader[1].ToString(), int.Parse(reader[2].ToString()));
                lesThemes.Add(at);
            }

            return lesThemes;

        }

        public static List<Theme> getAllThemesAteliers()
        {
            List<Theme> lesThemes = new List<Theme>();
            string req = "select idTheme, nomTheme, nomAtelier from THEME inner join ATELIER on THEME.idAtelier = ATELIER.idAtelier";
            DAOFactory db = new DAOFactory();
            db.connecter();

            SqlDataReader reader = db.excecSQLRead(req);

            while (reader.Read())
            {
                Theme th = new Theme(int.Parse(reader[0].ToString()), reader[1].ToString(), reader[2].ToString());
                lesThemes.Add(th);
            }

            return lesThemes;

        }

        // Créer dans la BDD l'objet Theme passé en paramètre
        public static void creerTheme(Theme unTheme)
        {
            string requete = "insert into THEME values('" + unTheme.IdTheme + "','" +
                unTheme.NomTheme + "','" + unTheme.IdAtelier + "')";
            DAOFactory db = new DAOFactory();
            db.connecter();
            db.execSQLWrite(requete);
        }

        // Modifie dans la BDD l'objet Theme passé en paramètre
        public static void modifierTheme(Theme unTheme)
        {
            string requete = "update THEME set nomTheme='" + unTheme.NomTheme + "', idAtelier= '" + unTheme.IdAtelier + "' where idTheme='" + unTheme.IdTheme + "'";
                
            DAOFactory db = new DAOFactory();
            db.connecter();
            db.execSQLWrite(requete);
        }

        // Supprime dans la BDD l'objet Theme passé en paramètre
        public static void supprimerTheme(Theme unTheme)
        {
            string requete = "delete from THEME where idTheme='" + unTheme.IdTheme + "'";

            DAOFactory db = new DAOFactory();
            db.connecter();
            db.execSQLWrite(requete);
        }
    }
}
