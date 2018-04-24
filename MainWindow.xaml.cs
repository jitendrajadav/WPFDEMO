using Lesson7.Utility;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Input;
using System.Windows.Media;

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
            Loaded += MainWindow_Loaded;
            dataGrid.PreviewKeyDown += DataGrid_PreviewKeyDown;
            dataGrid.CellEditEnding += DataGrid_CellEditEnding;
        }

        private void DataGrid_CellEditEnding(object sender, DataGridCellEditEndingEventArgs e)
        {
            DataGridRow row = dataGrid.ItemContainerGenerator.ContainerFromItem(CollectionView.NewItemPlaceholder) as DataGridRow;
            if (row != null)
            {
                dataGrid.SelectedItem = row.DataContext;
                DataGridCell cell = Helper.GetCell(dataGrid, row, 0);
                if (cell != null)
                    dataGrid.CurrentCell = new DataGridCellInfo(cell);
            }
        }

        //private static DataGridCell GetCell(DataGrid dataGrid, DataGridRow rowContainer, int column)
        //{
        //    if (rowContainer != null)
        //    {
        //        DataGridCellsPresenter presenter = Helper.FindVisualChild<DataGridCellsPresenter>(rowContainer);
        //        if (presenter != null)
        //            return presenter.ItemContainerGenerator.ContainerFromIndex(column) as DataGridCell;
        //    }
        //    return null;
        //}

        private void DataGrid_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                if (Keyboard.FocusedElement is UIElement elementWithFocus)
                {
                    if (dataGrid.Columns.Count - 1 == dataGrid.CurrentCell.Column.DisplayIndex)
                    {
                        //elementWithFocus.MoveFocus(new TraversalRequest(FocusNavigationDirection.Next));
                    }
                    else
                    {
                        elementWithFocus.MoveFocus(new TraversalRequest(FocusNavigationDirection.Next));
                        e.Handled = true;
                    }
                }
            }
        }

        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            if (Keyboard.FocusedElement is UIElement elementWithFocus)
                elementWithFocus.MoveFocus(new TraversalRequest(FocusNavigationDirection.Next));
            Helper.SelectRowByIndex(dataGrid, dataGrid.Items.Count - 1);
        }
    }
}
