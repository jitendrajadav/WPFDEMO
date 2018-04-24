using System;
using System.Linq;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Input;

namespace Lesson7.Utility
{
    public class JJDataGrid : DataGrid
    {
        private void PressKey(Key key)
        {
            KeyEventArgs args = new KeyEventArgs(Keyboard.PrimaryDevice, Keyboard.PrimaryDevice.ActiveSource, 0, key);
            args.RoutedEvent = Keyboard.KeyDownEvent;
            InputManager.Current.ProcessInput(args);
        }

        protected override void OnCurrentCellChanged(EventArgs e)
        {
            if (this.CurrentCell.Column != null)
               if (this.CurrentCell.Column != null && this.CurrentCell.Column.DisplayIndex == this.Columns.Count() - 1)
                {
                    //PressKey(Key.Return);
                    DataGridCell cell = Helper.GetCell(CurrentCell);
                    int index = Helper.GetRowIndex(cell);
                    DataGridRow dgrow = (DataGridRow)this.ItemContainerGenerator.ContainerFromItem(this.Items[index]);
                    dgrow.MoveFocus(new TraversalRequest(FocusNavigationDirection.First));
                }
        }

        protected override void OnKeyDown(KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                DataGridRow rowContainer = (DataGridRow)this.ItemContainerGenerator.ContainerFromItem(this.CurrentItem);
                if (rowContainer != null)
                {
                    int columnIndex = this.Columns.IndexOf(this.CurrentColumn);
                    DataGridCellsPresenter presenter = Helper.FindVisualChild<DataGridCellsPresenter>(rowContainer);
                    if (columnIndex == Columns.Count() - 1)
                    {
                        DataGridCell cell = (DataGridCell)presenter.ItemContainerGenerator.ContainerFromIndex(columnIndex);
                        TraversalRequest request = new TraversalRequest(FocusNavigationDirection.Next);
                        request.Wrapped = true;
                        cell.MoveFocus(request);
                        //BeginEdit();
                        PressKey(Key.Down);
                    }
                    else
                    {
                        CommitEdit();
                        DataGridCell cell = (DataGridCell)presenter.ItemContainerGenerator.ContainerFromIndex(columnIndex);
                        TraversalRequest request = new TraversalRequest(FocusNavigationDirection.Next);
                        request.Wrapped = true;
                        cell.MoveFocus(request);
                    }
                    SelectedItem = CurrentItem;
                    e.Handled = true;
                    //UpdateLayout();
                }
            }
        }
    }
}
