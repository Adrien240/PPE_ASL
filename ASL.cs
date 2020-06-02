using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AssisesSportLorrain
{
    public partial class ASL : Form
    {
        private void ASL_Load(object sender, EventArgs e){
            tabControl.TabPages.Remove(tabAteliers);
            tabControl.TabPages.Remove(tabThemes);
            lblStatus.Hide();
            btnDisconnect.Hide();
        }

        public ASL(){
            InitializeComponent();
        }

        #region Onglet Atelier
        // Onglet ATELIER
        //====================================================================
        private void tabAteliers_Enter(object sender, EventArgs e){
            cbxSelectAt1.Items.Clear();
            cbxSelectAt1.ResetText();

            lblCreated1.ResetText();
            lblModified1.ResetText();
            lblDeleted1.ResetText();

            remplirListeAteliers();

            foreach (Atelier unAtelier in Atelier.listeAteliers())
            {
                cbxSelectAt1.Items.Add(unAtelier.IdAtelier + " (" + unAtelier.NomAtelier + ")");
            }
        }

        private void btnCreerAt_Click(object sender, EventArgs e){
            try
            {
                Atelier AT;

                if (txbIdAt.Text.Length != 0 && txbNomAt1.Text.Length != 0 && txbCapaciteAt1.Text.Length != 0)
                {
                    AT = new Atelier(int.Parse(txbIdAt.Text), txbNomAt1.Text, int.Parse(txbCapaciteAt1.Text));
                    AT.ajouterAtelier();

                    txbIdAt.Clear();
                    txbNomAt1.Clear();
                    txbCapaciteAt1.Clear();

                    lblCreated1.Text = "Atelier créé !";

                    //On réactualise la combobox pour ajouter l'élément créé
                    cbxSelectAt1.Items.Clear();
                    cbxSelectAt1.ResetText();
                    foreach (Atelier unAtelier in Atelier.listeAteliers())
                    {
                        cbxSelectAt1.Items.Add(unAtelier.IdAtelier + " (" + unAtelier.NomAtelier + ")");
                    }

                    //On réactualise le DataGridView pour le remplir automatiquement
                    remplirListeAteliers();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERREUR! Plus d'informations ci-dessous :");
                MessageBox.Show("Message d'erreur : " + ex.Message);
            }
        }

        private void cbxSelectAt1_SelectedIndexChanged(object sender, EventArgs e){
            int i = cbxSelectAt1.SelectedIndex;
            Atelier AT;
            AT = Atelier.listeAteliers().ElementAt(i);
            txbNomAt2.Text = AT.NomAtelier;
            txbCapaciteAt2.Text = AT.CapaciteAtelier.ToString();
        }

        private void btnModifierAt_Click(object sender, EventArgs e){
            try
            {
                int i = cbxSelectAt1.SelectedIndex;
                Atelier AT;
                AT = Atelier.listeAteliers().ElementAt(i);
                AT.modifierAtelier(cbxSelectAt1.SelectedIndex, txbNomAt2.Text, int.Parse(txbCapaciteAt2.Text));

                cbxSelectAt1.ResetText();
                txbNomAt2.Clear();
                txbCapaciteAt2.Clear();

                lblModified1.Text = "Atelier modifié !";

                //On réactualise le DataGridView pour le remplir automatiquement
                remplirListeAteliers();
            }
            catch (Exception ex){
                MessageBox.Show("ERREUR! Plus d'informations ci-dessous :");
                MessageBox.Show("Message d'erreur : " + ex.Message);
            }
        }

        private void btnSupprAt_Click(object sender, EventArgs e){
            try{
                int i = cbxSelectAt1.SelectedIndex;
                Atelier AT;
                AT = Atelier.listeAteliers().ElementAt(i);
                AT.supprimerAtelier();

                cbxSelectAt1.ResetText();
                txbNomAt2.Clear();
                txbCapaciteAt2.Clear();

                lblDeleted1.Text = "Atelier supprimé !";

                //On réactualise la combobox pour enlever l'élément supprimé de la liste
                cbxSelectAt1.Items.Clear();
                cbxSelectAt1.ResetText();
                foreach (Atelier unAtelier in Atelier.listeAteliers())
                {
                    cbxSelectAt1.Items.Add(unAtelier.IdAtelier + " (" + unAtelier.NomAtelier + ")");
                }

                //On réactualise le DataGridView pour le remplir automatiquement
                remplirListeAteliers();
            }
            catch (Exception ex){
                MessageBox.Show("ERREUR! Plus d'informations ci-dessous :");
                MessageBox.Show("Message d'erreur : " + ex.Message);
            }
}

        #endregion

        #region Onglet Thème
        // Onglet THEME
        //====================================================================
        private void tabThemes_Enter(object sender, EventArgs e){
            cbxSelectAt2.Items.Clear();
            cbxSelectAt2.ResetText();
            cbxSelectAt3.Items.Clear();
            cbxSelectAt3.ResetText();
            cbxSelectTh.Items.Clear();
            cbxSelectTh.ResetText();

            lblCreated2.ResetText();
            lblModified2.ResetText();
            lblDeleted2.ResetText();

            remplirListeThemes();

            foreach (Atelier unAtelier in Atelier.listeAteliers())
            {
                cbxSelectAt2.Items.Add(unAtelier.IdAtelier + " (" + unAtelier.NomAtelier + ")");
                cbxSelectAt3.Items.Add(unAtelier.IdAtelier + " (" + unAtelier.NomAtelier + ")");
            }

            foreach (Theme unTheme in Theme.listeThemes())
            {
                cbxSelectTh.Items.Add(unTheme.IdTheme + " (" + unTheme.NomTheme + ")");
            }
        }

        private void btnCreerTh_Click(object sender, EventArgs e){
            try
            {
                Theme TH;

                if (txbIdTh.Text.Length != 0 && txbNomTh1.Text.Length != 0 && cbxSelectAt2.Text.Length != 0)
                {
                    TH = new Theme(int.Parse(txbIdTh.Text), txbNomTh1.Text, cbxSelectAt2.SelectedIndex + 1);
                    TH.ajouterTheme();

                    txbIdTh.Clear();
                    txbNomTh1.Clear();
                    cbxSelectAt2.ResetText();

                    lblCreated2.Text = "Thème créé !";

                    //On réactualise la combobox pour ajouter l'élément créé
                    cbxSelectTh.Items.Clear();
                    cbxSelectTh.ResetText();

                    foreach (Theme unTheme in Theme.listeThemes())
                    {
                        cbxSelectTh.Items.Add(unTheme.IdTheme + " (" + unTheme.NomTheme + ")");
                    }

                    //On réactualise le DataGridView pour le remplir automatiquement
                    remplirListeThemes();
                }
            }
            catch (Exception ex){
                MessageBox.Show("ERREUR! Plus d'informations ci-dessous :");
                MessageBox.Show("Message d'erreur : " + ex.Message);
            }
        }

        private void cbxSelectTh_SelectedIndexChanged(object sender, EventArgs e){
            int i = cbxSelectTh.SelectedIndex;
            Theme TH;
            TH = Theme.listeThemes().ElementAt(i);
            txbNomTh2.Text = TH.NomTheme;
            cbxSelectAt3.Text = TH.IdAtelier.ToString();
        }

        private void btnModifierTh_Click(object sender, EventArgs e){
            try
            {
                int i = cbxSelectTh.SelectedIndex;
                Theme TH;
                TH = Theme.listeThemes().ElementAt(i);
                TH.modifierTheme(cbxSelectTh.SelectedIndex, txbNomTh2.Text, cbxSelectAt3.SelectedIndex);

                cbxSelectTh.ResetText();
                txbNomTh2.Clear();
                cbxSelectAt3.ResetText();

                lblModified2.Text = "Thème modifié !";

                //On réactualise le DataGridView pour le remplir automatiquement
                remplirListeThemes();
            }
            catch (Exception ex){
                MessageBox.Show("ERREUR! Plus d'informations ci-dessous :");
                MessageBox.Show("Message d'erreur : " + ex.Message);
            }
        }

        private void btnSupprTh_Click(object sender, EventArgs e){
            try {
                int i = cbxSelectTh.SelectedIndex;
                Theme TH;
                TH = Theme.listeThemes().ElementAt(i);
                TH.supprimerTheme();

                cbxSelectTh.ResetText();
                txbNomTh2.Clear();
                cbxSelectAt3.ResetText();

                lblDeleted2.Text = "Thème supprimé !";

                //On réactualise la combobox pour enlever l'élément créé à la liste
                cbxSelectTh.Items.Clear();
                cbxSelectTh.ResetText();

                foreach (Theme unTheme in Theme.listeThemes())
                {
                    cbxSelectTh.Items.Add(unTheme.IdTheme + " (" + unTheme.NomTheme + ")");
                }

                //On réactualise le DataGridView pour le remplir automatiquement
                remplirListeThemes();
            }
            catch (Exception ex){
                MessageBox.Show("ERREUR! Plus d'informations ci-dessous :");
                MessageBox.Show("Message d'erreur : " + ex.Message);
            }
        }

        #endregion

        private void remplirListeAteliers(){
            dgvAteliers.Rows.Clear();

            foreach (Atelier unAtelier in Atelier.listeAteliers())
            {
                dgvAteliers.Rows.Add(unAtelier.IdAtelier, unAtelier.NomAtelier, unAtelier.CapaciteAtelier);
            }
        }

        private void remplirListeThemes(){
            dgvThemes.Rows.Clear();

            foreach (Theme unTheme in Theme.listeThemes())
            {
                dgvThemes.Rows.Add(unTheme.IdTheme, unTheme.NomTheme);
            }
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            try{
                Utilisateur U1;
                U1 = new Utilisateur(txbEmail.Text.ToLower(), txbPass.Text);
                Utilisateur U2;
                U2 = U1.checkUser();

                if (U1.EmailUtilisateur == U2.EmailUtilisateur && U1.PassUtilisateur == U2.PassUtilisateur){
                    MessageBox.Show("Vous êtes à présent connecté!");

                    txbEmail.Clear();
                    txbPass.Clear();

                    // On masque les champs inutiles //
                    lblEmail.Hide();
                    lblPass.Hide();
                    txbEmail.Hide();
                    txbPass.Hide();
                    btnConnect.Hide();

                    // On affiche les informations utiles pour la gestion et consultation des ateliers et des thèmes //
                    tabControl.TabPages.Add(tabAteliers);
                    tabControl.TabPages.Add(tabThemes);
                    btnDisconnect.Show();
                    lblStatus.Show();
                }
            }
            catch
            {
                if (txbEmail.Text == "" && txbPass.Text == ""){
                    MessageBox.Show("Veuillez saisir quelque chose avant de cliquer sur ce bouton");
                }
                else {
                    MessageBox.Show("Erreur! E-mail ou Mot de passe incorrect");
                }
                
            }
        }

        private void btnDisconnect_Click(object sender, EventArgs e)
        {
            // Fait l'inverse du bouton btnConnect //
            MessageBox.Show("Vous êtes à présent déconnecté!");

            lblEmail.Show();
            lblPass.Show();
            txbEmail.Show();
            txbPass.Show();
            btnConnect.Show();

            tabControl.TabPages.Remove(tabAteliers);
            tabControl.TabPages.Remove(tabThemes);
            btnDisconnect.Hide();
            lblStatus.Hide();
        }
    }
}
