using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pryMamondezTreeView
{
    public partial class frmVideos : Form
    {
        Autores a;
        Videos v;
        string archivos;
        public frmVideos()
        {
            InitializeComponent();
        }

        private void axWindowsMediaPlayer1_Enter(object sender, EventArgs e)
        {

        }

        private void btnReproducir_Click(object sender, EventArgs e)
        {
            wmp.URL = "Videos/" + archivos;
        }

        private void frmVideos_Load(object sender, EventArgs e)
        {
            AgregarArbolitos();
            wmp.uiMode = "none";

        }
        private void AgregarArbolitos() 
        {
            a = new Autores();
            v = new Videos();

            TreeNode abuelo;
            TreeNode padre;
            TreeNode hijo;

            abuelo = tv.Nodes.Add("AUTORES");

            DataTable taut = a.getAutores();
            DataTable tvid = v.getVideos();

            foreach(DataRow faut in taut.Rows) 
            {
                padre = abuelo.Nodes.Add(faut["nombre"].ToString());
                foreach (DataRow fvid in tvid.Rows)
                {
                    if (faut["autor"].ToString() == fvid["autor"].ToString())
                    {
                        hijo = padre.Nodes.Add(fvid["Video"].ToString());
                        hijo.Tag = fvid["archivo"].ToString();
                    }
                }
            }

        }

        private void tv_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (e.Node.Level == 2)
            {
                archivos = e.Node.Tag.ToString();
            }
        }
    }
}
