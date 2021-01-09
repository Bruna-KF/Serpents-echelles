using System;
using System.Windows.Forms;

namespace TP2_Serpents
{
    /// <summary>
    /// Description : Jeu de serpents et échelles à un joueur.
    /// 
    /// Version     : 2020
    /// </summary>
    /// --------------------------------------------------------------------------------

    public partial class FrmPrincipal : Form
    {
        #region NE PAS MODIFIER
        public const string APP_INFO = " (Bruna Fonseca)";
        //------------------------------------------------------------------------------
        public FrmPrincipal()
        {
            InitializeComponent();
            btnLancerDe.Select();
            this.Text += APP_INFO;
            DémarrerNouvellePartie();
        }

        //----------------------------------------------------------------------------------
        /// <summary>
        /// Créer une nouvelle partie
        /// </summary>
        private void mnuFichierNouvellePartie_Click(object sender, EventArgs e)
        {
            DémarrerNouvellePartie();
        }
        //-----------------------------------------------------------------------------------
        /// <summary>
        /// Établir la valeur du déplacement
        /// Mettre à jour les contrôles appropriés selon le contexte du jeu.
        /// </summary>
        private void btnLancerDé_Click(object sender, EventArgs e)
        {
            // Établir la valeur du déplacement
            vsiDé.RandomizeValue(1, 6);

            // Rendre disponible ou non les contrôles appropriés selon le contexte du jeu.
            btnLancerDe.Enabled = false;
            btnDéplacerJeton.Enabled = true;

            // Activer le bon contrôle.
            btnDéplacerJeton.Select();
        }
        #endregion

        private void activerAnimation(int posicao)
        {
            sprJoueur.Animated = true;
            sprJoueur.FollowGrid = false;
            sprJoueur.DisplayIndex = posicao;
        }

        private void activerFinPartie()
        {
            sprFinPartie.Visible = true;
            btnLancerDe.Enabled = false;
        }

        //------------------------------------------------------------------------------------
        /// <summary>
        /// Déplacer le jeton du joueur
        /// Vérifier si fin de la partie
        /// Mettre à jour les contrôles appropriés selon le contexte du jeu.
        /// </summary>
        private void btnDéplacerJeton_Click(object sender, EventArgs e)
        {
            //--------------------------------------------------------------------------------
            // TODO 01A : Rendre non disponible le bouton pour déplacer le jeton

            btnDéplacerJeton.Enabled = true;
            btnLancerDe.Enabled = false;

            btnDéplacerJeton.Select();

            // TODO 01B : Rendre disponible le bouton pour lancer le dé

            btnLancerDe.Enabled = true;
            btnDéplacerJeton.Enabled = false;
            btnLancerDe.Select();


            // TODO 01C : Placer le focus sur le bouton pour lancer le dé


            // -------------------------------------------------------------------------------
            // TODO 01D : Déplacer le jeton du joueur selon la valeur du dé
            //      Déterminer la position future et si elle est jouable.
            //      Déplacer le jeton à cette position
            //      Déterminer si un deuxième déplacement est nécessaire et l'effectuer

            //          sprJoueur.Animated = true;
            //          sprJoueur.FollowGrid = true;

            int joueur1 = sprJoueur.DisplayIndex + vsiDé.Value;
            switch (joueur1)
            {
                case 2:
                    sprJoueur.DisplayIndex += vsiDé.Value;
                    activerAnimation(17);

                    break;

                case 18:
                    sprJoueur.DisplayIndex += vsiDé.Value;
                    activerAnimation(4);
                    break;

                case 23:
                    sprJoueur.DisplayIndex += vsiDé.Value;
                    activerAnimation(38);
                    break;

                case 26:
                    sprJoueur.DisplayIndex += vsiDé.Value;
                    activerAnimation(7);
                    break;

                case 28:
                    sprJoueur.DisplayIndex += vsiDé.Value;
                    activerAnimation(52);
                    break;


                case 47:
                    sprJoueur.DisplayIndex += vsiDé.Value;
                    activerAnimation(62);
                    break;


                case 57:
                    sprJoueur.DisplayIndex += vsiDé.Value;
                    activerAnimation(40);
                    break;

                case 61:
                    sprJoueur.DisplayIndex += vsiDé.Value;
                    activerAnimation(31);
                    break;

                //            FIN DE PARTIE:

                case 15:
                    sprJoueur.DisplayIndex += vsiDé.Value;
                    activerAnimation(63);
                    activerFinPartie();
                    break;

                case 58:
                    sprJoueur.DisplayIndex += vsiDé.Value;
                    activerAnimation(63);
                    activerFinPartie();
                    break;

                case 63:
                    sprJoueur.DisplayIndex = 63;
                    sprJoueur.Animated = true;
                    sprJoueur.FollowGrid = false;
                    activerFinPartie();
                    break;

                //             RETOUR AU DEBUT:
                case 42:
                    sprJoueur.DisplayIndex += vsiDé.Value;
                    activerAnimation(0);
                    break;

                case 51:
                    sprJoueur.DisplayIndex += vsiDé.Value;
                    activerAnimation(0);
                    break;

                default:
                    sprJoueur.Animated = true;
                    sprJoueur.FollowGrid = true;
                    if (joueur1 <= bvaGrille.Length -1)
                        sprJoueur.DisplayIndex = joueur1;
                    break;
            }



            // -------------------------------------------------------------------------------
            // TODO 01E : Arréter la partie
            //      Vérifier si on atteint le sommet
            //      Si le sommet est atteint, mettre à jour les contrôles pour arrêter la partie 


        }
        //----------------------------------------------------------------------------------
        /// <summary>
        /// Préparer le jeu pour une nouvelle partie
        /// Mettre à jour les contrôles appropriés selon le contexte du jeu.
        /// </summary>
        private void DémarrerNouvellePartie()
        {
            // TODO 02A : Préparer l'état du formulaire pour une nouvelle partie.

            sprJoueur.DisplayIndex = 0;
            sprFinPartie.Visible = false;
            btnLancerDe.Enabled = true;


            // TODO 02B : Rendre disponible ou non les contrôles appropriés selon le contexte du jeu.



            #region NE PAS MODIFIER
            btnLancerDe.Select();
            mnuSpécialModeTest.Checked = false;
            vsiDé.ReadOnly = true;
            #endregion
        }

        #region NE PAS MODIFIER
        //-----------------------------------------------------------------------------------------------
        private void MnuSpécialModeTest_Click(object sender, EventArgs e)
        {
            vsiDé.ReadOnly = !mnuSpécialModeTest.Checked || sprFinPartie.Visible;
        }
        //-----------------------------------------------------------------------------------------------
        private void mnuFichierQuitter_Click(object sender, EventArgs e)
        {
            Close();
        }
        #endregion

    }
}

