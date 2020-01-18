using ContainerVervoerWinFormFramework.Ships.Containers.Enums;
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


        public void PrintResult(bool error,string reason, IShip ship)
        {
            int yOutputPos = 10;
            string resultMessage;
            if (error)
            {
                resultMessage = "ERROR: Ship can not load all containers! \nReason: " + reason;
            }
            else
            {
                resultMessage = "OK: Ship was able to load all countainers";
            }

            Label ErrorLabel = new Label
            {
                Location = new Point(10, yOutputPos),
                Parent = this,
                Name = "error",
                Text = resultMessage,
                Font = Font = new Font("Arial", 8, FontStyle.Regular),
                Size = new Size(this.Size.Width, 30),
                ForeColor = Color.Black,
                BackColor = Color.Transparent,
            };
            Controls.Add(ErrorLabel);
            yOutputPos += 40;

            int level = 0;
            int containersInLevel;

            string rowTypes;

            do
            {
                containersInLevel = 0;
                string levelWeight = "";
                for (int x = 0; x < ship.Width; x++)
                {
                    rowTypes = "";
                    for (int y = 0; y < ship.Length; y++)
                    {
                        if (ship.Grid[x, y].IsEmpty || level >= ship.Grid[x, y].Stack.Count)
                        {
                            rowTypes += "_ ";
                            levelWeight += "- ";
                        }
                        else
                        {
                            ContainerType type = ship.Grid[x, y].Stack[level].Type;
                            if (type == ContainerType.Cooled)
                            {
                                rowTypes += "C ";
                            }
                            else if (type == ContainerType.Valuable)
                            {
                                rowTypes += "V ";
                            }
                            else
                            {
                                rowTypes += "N ";
                            }
                            levelWeight += (ship.Grid[x, y].Stack[level].Weight + " ");
                            containersInLevel++;
                        }
                    }
                    if (containersInLevel != 0)
                    {
                        if (x == 0)
                        {
                            Label label = new Label
                            {
                                Location = new Point(10, yOutputPos),
                                Parent = this,
                                Name = "labelLevel" + level,
                                Text = "Level " + level,
                                Font = Font = new Font("Arial", 8, FontStyle.Regular),
                                Size = new Size(this.Size.Width, 15),
                                ForeColor = Color.Black,
                                BackColor = Color.Transparent,
                            };
                            Controls.Add(label);
                            yOutputPos += 12;
                        }
                        Label label2 = new Label
                        {
                            Location = new System.Drawing.Point(10, yOutputPos),
                            Parent = this,
                            Name = "labelLevel" + level + "Row" + x,
                            Text = rowTypes,
                            Font = Font = new Font("Arial", 8, FontStyle.Regular),
                            Size = new Size(this.Size.Width, 15),
                            ForeColor = Color.Black,
                            BackColor = Color.Transparent,
                        };
                        Controls.Add(label2);
                        yOutputPos += 12;
                    }
                    levelWeight += "/ ";
                }
                if (containersInLevel > 0)
                {
                    Label label3 = new Label
                    {
                        Location = new System.Drawing.Point(10, yOutputPos),
                        Parent = this,
                        Name = "labelLevel" + level + "Weight",
                        Text = "Weight: " + levelWeight,
                        Font = Font = new Font("Arial", 8, FontStyle.Regular),
                        Size = new Size(this.Size.Width, 15),
                        ForeColor = Color.Black,
                        BackColor = Color.Transparent,
                    };
                    Controls.Add(label3);
                    yOutputPos += 20;
                }
                level++;
            } while (containersInLevel > 0);

        }

        private void OutputForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
