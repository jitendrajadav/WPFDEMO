using Lesson7.Models;
using Lesson7.Utility;
using System;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;
using System.Windows.Threading;

namespace Lesson7
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            dataGrid.CanUserAddRows = false;
            
            //add blank row
            var itemsSource = dataGrid.ItemsSource as ObservableCollection<ItemModel>;
            if (itemsSource != null)
                itemsSource.Add(new ItemModel());

            Loaded += MainWindow_Loaded;
            dataGrid.PreviewKeyDown += DataGrid_PreviewKeyDown;
            //dataGrid.CellEditEnding += DataGrid_CellEditEnding;
        }

        private void DataGrid_CellEditEnding(object sender, DataGridCellEditEndingEventArgs e)
        {
            if (dataGrid.ItemContainerGenerator.ContainerFromItem(CollectionView.NewItemPlaceholder) is DataGridRow row)
            {
                dataGrid.SelectedItem = row.DataContext;
                DataGridCell cell = Helper.GetCell(dataGrid, row, 0);
                if (cell != null)
                    dataGrid.CurrentCell = new DataGridCellInfo(cell);
            }
        }

        private void DataGrid_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                if (Keyboard.FocusedElement is UIElement elementWithFocus)
                {
                    if (dataGrid.Columns.Count - 1 == dataGrid.CurrentCell.Column.DisplayIndex)
                    {
                        if (dataGrid.ItemsSource is ObservableCollection<ItemModel> itemsSource)
                        {
                            var newItem = new ItemModel();
                            itemsSource.Add(newItem);

                            dataGrid.SelectedItem = newItem;
                            Dispatcher.BeginInvoke(new Action(() =>
                            {
                                DataGridRow row = dataGrid.ItemContainerGenerator.ContainerFromItem(newItem) as DataGridRow;
                                DataGridCell cell = Helper.GetCell(dataGrid, row, 0);
                                if (cell != null)
                                    dataGrid.CurrentCell = new DataGridCellInfo(cell);
                            }), DispatcherPriority.Background);
                        }
                    }
                    else
                    {
                        if (dataGrid.CurrentCell.Column.DisplayIndex <= 2)
                        {
                            Dispatcher.BeginInvoke(new Action(() =>
                            {
                                DataGridRow row = dataGrid.ItemContainerGenerator.ContainerFromItem(dataGrid.CurrentItem) as DataGridRow;
                                DataGridCell cell = Helper.GetCell(dataGrid, row, dataGrid.CurrentCell.Column.DisplayIndex + 2);
                                if (cell != null)
                                    dataGrid.CurrentCell = new DataGridCellInfo(cell);

                            }), DispatcherPriority.Background);
                        }
                        else
                            elementWithFocus.MoveFocus(new TraversalRequest(FocusNavigationDirection.Next));
                        e.Handled = true;
                    }
                }
            }
            if (e.Key == Key.Delete)
            {
                if (dataGrid.Items.Count == 1)
                {
                    e.Handled = true;
                }
            }
        }

        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            if (Keyboard.FocusedElement is UIElement elementWithFocus)
                elementWithFocus.MoveFocus(new TraversalRequest(FocusNavigationDirection.Next));
            Helper.SelectRowByIndex(dataGrid, dataGrid.Items.Count - 1);
            //Helper.SelectRowByIndex(dataGrid, 0);
        }
    }
}
