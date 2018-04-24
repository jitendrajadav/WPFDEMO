using Lesson7.Utility;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

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
        }

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
