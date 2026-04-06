using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ZedGraph;

namespace CG_OpenCV
{
    public partial class Histograma : Form
    {
        public Histograma(int[] array)
        {
            InitializeComponent();

            GraphPane myPane = zedGraphControl1.GraphPane;
            PointPairList greyList = new PointPairList();

            for (int i = 0; i < 256; i++)
            {
                greyList.Add(i, array[i]);
            }

            myPane.AddCurve("Grey", greyList, System.Drawing.Color.Black);
            myPane.AxisChange();
            zedGraphControl1.Refresh();
        }

    }
}
