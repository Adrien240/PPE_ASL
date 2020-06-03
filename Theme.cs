using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssisesSportLorrain
{
    public class Theme
    {
        // Propriétés privées
        // Liste (collection) des Themes
        // Une collection est un "tableau dynamique" d'objets,
        // ici d'objets de type Theme

        private int idTheme;
        private string nomTheme;
        private int idAtelier;
        private string nomAtelier;

        public Theme(int idTheme, string nomTheme, int idAtelier)
        {
            this.idTheme = idTheme;
            this.nomTheme = nomTheme;
            this.idAtelier = idAtelier;
        }

        public Theme(int idTheme, string nomTheme, string nomAtelier)
        {
            this.idTheme = idTheme;
            this.nomTheme = nomTheme;
            this.nomAtelier = nomAtelier;
        }

        #region Accesseurs
        public int IdTheme
        {
            get
            {
                return idTheme;
            }

            set
            {
                idTheme = value;
            }
        }

        public string NomTheme
        {
            get
            {
                return nomTheme;
            }

            set
            {
                nomTheme = value;
            }
        }

        public int IdAtelier
        {
            get
            {
                return idAtelier;
            }

            set
            {
                idAtelier = value;
            }
        }

        public string NomAtelier
        {
            get
            {
                return nomAtelier;
            }

            set
            {
                nomAtelier = value;
            }
        }
        #endregion

        #region Méthodes d'appel au DAO métier

        // Méthode statique qui retourne l'ensemble des Themes sous forme de List
        public static List<Theme> listeThemes()
        {
            return DAOTheme.getAllThemes();
        }

        public static List<Theme> listeThemes2()
        {
            return DAOTheme.getAllThemesAteliers();
        }

        // Fait créer le Theme (objet courant) dans la BDD
        public void ajouterTheme()
        {
            DAOTheme.creerTheme(this);
        }

        // Fait modifier le Theme (objet courant) dans la BDD
        public void modifierTheme(int idTheme, string nomTheme, int idAtelier)
        {
            this.idTheme = idTheme+1;
            this.nomTheme = nomTheme;
            this.idAtelier = idAtelier+1;
            DAOTheme.modifierTheme(this);
        }

        // Fait supprimer le Theme (objet courant) dans la BDD
        public void supprimerTheme()
        {
            DAOTheme.supprimerTheme(this);
            #endregion
        }
    }
}