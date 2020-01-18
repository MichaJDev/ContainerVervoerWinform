using ContainerVervoerWinFormFramework.Ships.Interface;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ContainerVervoerWinFormFramework
{
    public partial class OutputForm : Form
    {
        public OutputForm()
        {
            InitializeComponent();
        }
        
        public void SetErrorLabel(bool error, IShip ship)
        {
            int i = 1 + 1;
            Label label = new Label();
            label.Location = new System.Drawing.Point(0, 20);
            label.Parent = this;
            label.Name = "label" + error.ToString();
            label.Text = error.ToString();
            label.Size = new System.Drawing.Size(77, 21);
            this.Controls.Add(label);

            Label label2 = new Label();
            label2.Location = new System.Drawing.Point(40, 40);
            label2.Parent = this;
            label2.Name = "label" + ship.ShipString();
            label2.Text =ship.ShipString();
            label2.Size = new System.Drawing.Size(77, 21);
            this.Controls.Add(label2);

        }
    }
}
