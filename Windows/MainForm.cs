using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Windows
{
    public partial class MainForm : Form
    {
        Bitmap openImage;
        public MainForm()
        {
            InitializeComponent();
        }
        //private void ShowResult(int[,] histo, string name)
        //{
        //OpenForm operation = new OpenForm(openImage);
        //int[,] histogram = Lab1.CountHisto();
        //Bitmap image2 = new Bitmap(openImage.Width, openImage.Height);
        //for (int i = 0; i < image2.Width; ++i)
        //{
        //    for (int j = 0; j < image2.Height; ++j)
        //    {
        //        image2.SetPixel(i, j, Color.FromArgb(histogram[i, j], histogram[i, j], histogram[i, j]));
        //    }
        //}
        ////operation. = new OneArgumentOperations(image2);
        //operation.MdiParent = this;
        //operation.Text = name;
        //operation.Show();
        //}

        private void ShowOnePointResultat(Bitmap bmp, string name)
        {
            OneArgumentOperations oap = new OneArgumentOperations(bmp, name);
            oap.Text = name;
            oap.MdiParent = this;
            oap.Show();
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog openImageDialog = new OpenFileDialog();
            openImageDialog.Filter = "Image Files(*.BMP;*.JPG;*.GIF;*.PNG)|*.BMP;*.JPG;*.GIF;*.PNG|All files (*.*)|*.*";
            if (openImageDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    openImage = new Bitmap(openImageDialog.FileName);
                    OpenForm openForm = new OpenForm(openImage);
                    openForm.MdiParent = this;
                    openForm.Show();
                }
                catch
                {
                    DialogResult result = MessageBox.Show("ERROR", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private void methodAverageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Bitmap image2 = new Bitmap(openImage.Width, openImage.Height);
            int[,] histogram = Lab1.Extension(openImage, Lab1.Methods.Average);
            for (int i = 0; i < image2.Width; ++i)
            {
                for (int j = 0; j < image2.Height; ++j)
                {
                    image2.SetPixel(i, j, Color.FromArgb(histogram[i, j], histogram[i, j], histogram[i, j]));
                }
            }
            OpenForm openForm = new OpenForm(image2);
            openForm.MdiParent = this;
            openForm.Text = "Methods.Average";
            openForm.Show();

            //ShowResult(Lab1.Extension(openImage, Lab1.Methods.Average), "Method Average");
        }

        private void methodRandomToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Bitmap image2 = new Bitmap(openImage.Width, openImage.Height);
            int[,] histogram = Lab1.Extension(openImage, Lab1.Methods.Random);
            for (int i = 0; i < image2.Width; ++i)
            {
                for (int j = 0; j < image2.Height; ++j)
                {
                    image2.SetPixel(i, j, Color.FromArgb(histogram[i, j], histogram[i, j], histogram[i, j]));
                }
            }
            OpenForm openForm = new OpenForm(image2);
            openForm.MdiParent = this;
            openForm.Text = "Methods.Random";
            openForm.Show();
            // ShowResult(Lab1.Extension(openImage, Lab1.Methods.Random), "Method Random");
        }

        private void methodNeighborToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Bitmap image2 = new Bitmap(openImage.Width, openImage.Height);
            int[,] histogram = Lab1.Extension(openImage, Lab1.Methods.Neighbor);
            for (int i = 0; i < image2.Width; ++i)
            {
                for (int j = 0; j < image2.Height; ++j)
                {
                    image2.SetPixel(i, j, Color.FromArgb(histogram[i, j], histogram[i, j], histogram[i, j]));
                }
            }
            OpenForm openForm = new OpenForm(image2);
            openForm.MdiParent = this;
            openForm.Text = "Methods.Neighbor";
            openForm.Show();
            // ShowResult(Lab1.Extension(openImage, Lab1.Methods.Neighbor), "Method Neighbor");
        }

        private void identityToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowOnePointResultat(openImage, "Identity");
            /* OneArgumentOperations oap = new OneArgumentOperations(openImage, "Identity");
             oap.Text = "Identity";
             oap.MdiParent = this;
             oap.Show();*/
        }

        private void inversenegationToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            ShowOnePointResultat(openImage, "Negation");
        }

        private void thresholdbinaryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Enter value to p1 field (0-255)");
            ShowOnePointResultat(openImage, "ThresholdBinary");
        }

        private void inverseThresholdbinaryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Enter value to p1&p2 fields (0-255)");
            ShowOnePointResultat(openImage, "InverseThresholdBinary");
        }

        private void thresholdWithGrayLevelsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Enter value to p1&p2 fields (0-255)");
            ShowOnePointResultat(openImage, "ThresholdGrayLevels");
        }

        private void stretchingToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Enter value to p1&p2 fields (0-255)");
            ShowOnePointResultat(openImage, "Stretching");
        }

        private void reducingGrayLevelsToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Enter value to p1&p2&p3&p4&q2&q3&q4 fields (0-255)");
            ShowOnePointResultat(openImage, "ReducingGrayLevels");
        }

        private void intervalThresholdingbinaryToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Enter value to p1&p2 fields (0-255)");
            ShowOnePointResultat(openImage, "IntervalThresholdgBinary");
        }
        private void intervalInverseThresholdingbinaryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Enter value to p1&p2 fields (0-255)");
            ShowOnePointResultat(openImage, "InverseIntervalTresholdBinary");
        }

        private void inverseThresholdGrayLevelsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Enter value to p1&p2 fields (0-255)");
            ShowOnePointResultat(openImage, "InverseThresholdGrayLevels");
        }
        private void brightnessToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Enter value to p1 fields (-255 +255)");
            ShowOnePointResultat(openImage, "Brightness");
        }

        private void contrastToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Enter value to p1 fields (-100 +100)");
            ShowOnePointResultat(openImage, "Contrast");

        }

        private void gammaCorrectionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Enter value to p1 fields (0-500)");
            ShowOnePointResultat(openImage, "GammaCorrection");
        }

        private void twoArgumentsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ManyArgumentOperations manyArgumentOperations = new ManyArgumentOperations();
            manyArgumentOperations.MdiParent = this;
            manyArgumentOperations.Show();
        }

        private void linearFiltrationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LinerFiltration linerFiltration = new LinerFiltration(openImage);
            linerFiltration.MdiParent = this;
            linerFiltration.Show();
        }

        private void uPOToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UniversalPointOperation upo = new UniversalPointOperation(openImage);
            upo.MdiParent = this;
            upo.Show();
        }
    }
}
