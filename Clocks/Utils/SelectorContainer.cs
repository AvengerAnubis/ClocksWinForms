using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Clocks.Utils
{
    public class SelectorContainer<T>
    {
        public struct SelectedItemChangedEventArgs
        {
            public int SelectedIndex;
            public T SelectedItem;
        }
        public event EventHandler<SelectedItemChangedEventArgs> SelectedItemChanged;
        private List<T> _items;
        private int _selected;

        /// <summary>
        /// Получить выбранный объект
        /// </summary>
        public T SelectedItem 
        { 
            get => _items[_selected]; 
        }
        public List<T> Items
        {
            get => _items;
        }

        public SelectorContainer(List<T> items, int selected = 0) 
        { 
            this._items = items;
            this._selected = 0;
        }

        /// <summary>
        /// Выбрать следующий объект
        /// </summary>
        public void SelectNext()
        {
            if (_selected < _items.Count - 1)
            {
                _selected++;
            }
            else
            {
                _selected = 0;
            }
            SelectedItemChanged?.Invoke(this, new SelectedItemChangedEventArgs() {SelectedItem = _items[_selected], SelectedIndex = _selected});
        }

        /// <summary>
        /// Выбрать предыдущий объект
        /// </summary>
        public void SelectPrevious()
        {
            if (_selected > 0)
            {
                _selected--;
            }
            else
            {
                _selected = _items.Count - 1;
            }
            SelectedItemChanged?.Invoke(this, new SelectedItemChangedEventArgs() { SelectedItem = _items[_selected], SelectedIndex = _selected });
        }
    }
}
