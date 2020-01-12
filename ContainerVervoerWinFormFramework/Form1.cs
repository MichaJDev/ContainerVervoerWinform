using System;
using System.Collections.Generic;
using System.Windows.Forms;
using ContainerVervoerWinFormFramework.Ships.Interface;
using ContainerVervoerWinFormFramework.Ships;
using ContainerVervoerWinFormFramework.Ships.Containers.Interface;
using ContainerVervoerWinFormFramework.Managers.Interface;
using ContainerVervoerWinFormFramework.Managers;
using ContainerVervoerWinFormFramework.Ships.Containers.Enums;
using ContainerVervoerWinFormFramework.Ships.Containers;

namespace ContainerVervoerWinFormFramework
{
    public partial class Form1 : Form
    {
        private IList<IContainer> containerList = new List<IContainer>();
        private int width, height, maxCapacity, containerCapacity;
        ContainerType type;
        public Form1()
        {
            InitializeComponent();
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
                containerList.Add(container);
            }
            return containerList;
        }
        internal IContainer SetContainer()
        {
            //containerCapacity = Convert.ToInt32(containerCapacityTb.Text);
            if (String.IsNullOrEmpty(containerCapacityTb.Text))
            {
                containerCapacity = 0;
            }
            else
            {
                containerCapacity = Convert.ToInt32(containerCapacityTb.Text);
            }
            switch (containerTypeCb.SelectedItem.ToString())
            {
                case "Normal":
                    type = ContainerType.Normal;
                    break;
                case "Valuable":
                    type = ContainerType.Valuable;
                    break;
                case "Cooled":
                    type = ContainerType.Cooled;
                    break;
                case "CooledAndValuable":
                    type = ContainerType.CoolableAndValuable;
                    break;
            }
            return new Container(containerCapacity, type);
        }

        private void AddToList_Click(object sender, EventArgs e)
        {

            containers.Items.Add(SetContainer());

        }

        internal IShip SetShip()
        {
            if (String.IsNullOrEmpty(shipWidthTb.Text) && String.IsNullOrEmpty(shipHeightTb.Text) && String.IsNullOrEmpty(maxCapacityTb.Text))
            {
                width = 0;
                height = 0;
                maxCapacity = 0;
            }
            else
            {
                width = Convert.ToInt32(shipWidthTb.Text);
                height = Convert.ToInt32(shipHeightTb.Text);
                maxCapacity = Convert.ToInt32(maxCapacityTb.Text);
            }
            return new Ship(width, height, maxCapacity, containerList);
        }

        private void Submit_Click(object sender, EventArgs e)
        {
            IInputManager input = new InputManager(SetContainerList(), SetShip());
        }
    }
}
