using Clocks.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Clocks
{
    public partial class Selector : UserControl
    {
        private SelectorContainer<Control> items = null;
        public SelectorContainer<Control> Items
        {
            get => items;
            set
            {
                if (value != null)
                {
                    items = value;
                    this.items.SelectedItem.Dock = DockStyle.Fill;
                    this.tableLayoutPanel1.Controls.Add(this.items.SelectedItem, 1, 0);
                }
            }
        }

        public Selector()
        {
            this.items = null;
            InitializeComponent();
        }
        public Selector(SelectorContainer<Control> items)
        {
            this.items = items;
            InitializeComponent();
            //Отображаем текущий выбранный элемент
            this.items.SelectedItem.Dock = DockStyle.Fill;
            this.tableLayoutPanel1.Controls.Add(this.items.SelectedItem, 1, 0);
        }


        private void buttonRight_Click(object sender, EventArgs e)
        {
            if (items != null)
            {
                //Убираем предыдущий элемент
                this.tableLayoutPanel1.Controls.Remove(this.items.SelectedItem);
                //Выбираем следующий в контейнере
                items.SelectNext();
                //Добавляем его
                this.items.SelectedItem.Dock = DockStyle.Fill;
                this.tableLayoutPanel1.Controls.Add(this.items.SelectedItem, 1, 0);
            }
        }

        private void buttonLeft_Click(object sender, EventArgs e)
        {
            if (items != null)
            {
                //Аналогично
                this.tableLayoutPanel1.Controls.Remove(this.items.SelectedItem);
                items.SelectPrevious();
                this.items.SelectedItem.Dock = DockStyle.Fill;
                this.tableLayoutPanel1.Controls.Add(this.items.SelectedItem, 1, 0);
            }
        }
    }
}
