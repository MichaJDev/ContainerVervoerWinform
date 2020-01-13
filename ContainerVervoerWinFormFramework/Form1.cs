using System;
using System.Collections.Generic;
using System.Windows.Forms;
using ContainerVervoerWinFormFramework.Ships.Interface;
using ContainerVervoerWinFormFramework.Ships;
using ContainerVervoerWinFormFramework.Ships.Containers.Interface;
using ContainerVervoerWinFormFramework.Ships.Containers;

using ContainerVervoerWinFormFramework.IOManagers;
using ContainerVervoerWinFormFramework.Ships.Containers.Enums;

namespace ContainerVervoerWinFormFramework
{
    public partial class Form1 : Form
    {
        private readonly IList<IContainer> _containerList = new List<IContainer>();
        private int _width, _height, _maxCapacity, _containerCapacity;
        ContainerType _type;
        public Form1()
        {
            InitializeComponent();
            containerCapacityTb.MaxLength = 5;
            containerCapacityTb.Text = "0";
            shipWidthTb.Text = "0";
            shipHeightTb.Text = "0";
            maxCapacityTb.Text = "0";
            containerTypeCb.SelectedIndex = 0;
        }

        private void ForceNumeral(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }
        internal IList<IContainer> SetContainerList()
        {
            foreach (IContainer container in containers.Items)
            {
                _containerList.Add(container);
            }
            return _containerList;
        }
        internal IContainer SetContainer()
        {
            //containerCapacity = Convert.ToInt32(containerCapacityTb.Text);
            if (string.IsNullOrEmpty(containerCapacityTb.Text))
            {
                _containerCapacity = 0;
            }
            else
            {
                if (Convert.ToInt32(containerCapacityTb.Text) > new Container().MaxCapacity)
                    MessageBox.Show("Capacity can't be more than 260000");
                else
                    _containerCapacity = Convert.ToInt32(containerCapacityTb.Text);
            }
            switch (containerTypeCb.SelectedItem.ToString())
            {
                case "Normal":
                    _type = ContainerType.Normal;
                    break;
                case "Valuable":
                    _type = ContainerType.Valuable;
                    break;
                case "Cooled":
                    _type = ContainerType.Cooled;
                    break;
            }
            return new Container(_containerCapacity, _type);
        }

        private void AddToList_Click(object sender, EventArgs e)
        {

            containers.Items.Add(SetContainer());

        }

        internal IShip SetShip()
        {
            if (String.IsNullOrEmpty(shipWidthTb.Text) && String.IsNullOrEmpty(shipHeightTb.Text) && String.IsNullOrEmpty(maxCapacityTb.Text))
            {
                _width = 0;
                _height = 0;
                _maxCapacity = 0;
            }
            else
            {
                _width = Convert.ToInt32(shipWidthTb.Text);
                _height = Convert.ToInt32(shipHeightTb.Text);
                _maxCapacity = Convert.ToInt32(maxCapacityTb.Text);
            }
            return new Ship(_width, _height, _maxCapacity, _containerList);
        }

        private void Submit_Click(object sender, EventArgs e)
        {
            InputManager.ParseToDistributor(SetShip(), SetContainerList());
        }
    }
}
