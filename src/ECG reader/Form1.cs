using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ECG_reader
{
    public partial class Form1 : Form
    {
        EcgModel model;
        EcgProcessor processor;

        public Form1()
        {
            InitializeComponent();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            PictureBox[] pics = { picOriginal, picMeshWithModelLines };
            processor = new EcgProcessor();
            model = processor.ProcessEcg();
            trackBar1.Minimum = 5;
            trackBar1.Maximum = 3 * model.YInterval;
            trackBar1.Value = model.YInterval;
            trackBar1.Enabled = true;

            trackBarX.Minimum = 5;
            trackBarX.Maximum = 3 * model.XInterval;
            trackBarX.Value = model.XInterval;
            trackBarX.Enabled = true;

            PrintModel();
        }

        private void PrintModel()
        {
            picOriginal.Image = model.OriginalBitmap;
            picMeshWithModelLines.Image = model.MeshWithModelLines;
            picCurve.Image = model.CurveWithModelLines;
            picCalculatedCurve.Image = model.CalculatedCurve;
            picCalculatedCurveWithMesh.Image = model.CalculatedCurveWithMesh;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void TrackBar1_Scroll(object sender, EventArgs e)
        {
            if (!trackBar1.Enabled)
            {
                return;
            }

            model.YInterval = trackBar1.Value;
            label1.Text = model.YInterval.ToString();
            processor.CreateBitmapsBasedOnIntervals(ref model);
            PrintModel();
        }

        private void TrackBarX_Scroll(object sender, EventArgs e)
        {
            if (!trackBarX.Enabled)
            {
                return;
            }

            model.XInterval = trackBarX.Value;
            label2.Text = model.XInterval.ToString();
            processor.CreateBitmapsBasedOnIntervals(ref model);
            PrintModel();
        }
    }
}
