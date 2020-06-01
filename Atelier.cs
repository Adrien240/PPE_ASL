using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssisesSportLorrain
{
    public class Atelier
    {
        // Propriétés privées
        // Liste (collection) des Ateliers
        // Une collection est un "tableau dynamique" d'objets,
        // ici d'objets de type Atelier

        private int idAtelier;
        private string nomAtelier;
        private int capaciteAtelier;
        private List<Theme> lesThemes;

        public int IdAtelier
        {
            get { return idAtelier; }
            set { idAtelier = value; }
        }

        public string NomAtelier
        {
            get { return nomAtelier; }
            set { nomAtelier = value; }
        }

        public int CapaciteAtelier
        {
            get { return capaciteAtelier; }
            set { capaciteAtelier = value; }
        }

        public List<Theme> LesThemes
        {
            get { return lesThemes; }
            set { lesThemes = value; }
        }

        public int nbThemes
        {
            get { return Theme.listeThemes().Count; }
        }


        public Atelier(int idAtelier, string nomAtelier, int capaciteAtelier)
        {
            this.idAtelier = idAtelier;
            this.nomAtelier = nomAtelier;
            this.capaciteAtelier = capaciteAtelier;
        }

        #region Méthodes d'appel au DAO métier

        public static List<Atelier> listeAteliers()
        {
            return DAOAtelier.getAllAteliers();
        }

        // Fait créer le Atelier (objet courant) dans la BDD
        public void ajouterAtelier()
        {
            DAOAtelier.creerAtelier(this);
        }

        // Fait modifier le Atelier (objet courant) dans la BDD
        public void modifierAtelier(int idAtelier, string nomAtelier, int capaciteAtelier)
        {
            this.idAtelier = idAtelier+1;
            this.nomAtelier = nomAtelier;
            this.capaciteAtelier = capaciteAtelier;
            DAOAtelier.modifierAtelier(this);
        }

        public void supprimerAtelier()
        {
            DAOAtelier.supprimerAtelier(this);
        }
        #endregion

    }
}