using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssisesSportLorrain
{
    public class Utilisateur
    {
        // Propriétés privées
        // Liste (collection) des Utilisateurs
        // Une collection est un "tableau dynamique" d'objets,
        // ici d'objets de type Utilisateur

        private string emailUtilisateur;
        private string passUtilisateur;
        private int levelUtilisateur;

        public Utilisateur(string emailUtilisateur, string passUtilisateur)
        {
            this.emailUtilisateur = emailUtilisateur;
            this.passUtilisateur = passUtilisateur;
        }
        public Utilisateur(string emailUtilisateur, string passUtilisateur, int levelUtilisateur)
        {
            this.emailUtilisateur = emailUtilisateur;
            this.passUtilisateur = passUtilisateur;
            this.levelUtilisateur = levelUtilisateur;
        }

        #region Accesseurs

        public string EmailUtilisateur
        {
            get
            {
                return emailUtilisateur;
            }

            set
            {
                emailUtilisateur = value;
            }
        }

        public string PassUtilisateur
        {
            get
            {
                return passUtilisateur;
            }

            set
            {
                passUtilisateur = value;
            }
        }

        public int LevelUtilisateur
        {
            get
            {
                return levelUtilisateur;
            }

            set
            {
                levelUtilisateur = value;
            }
        }
        #endregion

        #region Méthodes d'appel au DAO métier

        // Fait créer le Utilisateur (objet courant) dans la BDD
        public void ajouterUtilisateur()
        {
            DAOUtilisateur.creerUtilisateur(this);
        }

        public Utilisateur checkUser()
        {
            return DAOUtilisateur.getUserPass(this);
        }

        #endregion
    }
}