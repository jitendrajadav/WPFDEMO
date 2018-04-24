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
