using System.Windows;
using System.Windows.Controls;

namespace SetDemo
{
    public partial class MainWindow : Window
    {
        Dictionary<string, List<string>> collections = new Dictionary<string, List<string>>()
        {
            { "Reading", new List<string> { "Anahit", "Ellen", "Shushan","Alex" } },
            { "Writing", new List<string> { "Ellen", "Shushan", "Edgar", "Alex", "Anahit" } }
        };

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            leftSet.Items.Clear();
            rightSet.Items.Clear();
            operation.Items.Clear();

            foreach (var key in collections.Keys)
            {
                leftSet.Items.Add(key);
                rightSet.Items.Add(key);
            }

            operation.Items.Add("UNION");
            operation.Items.Add("INTERSECTION");
            operation.Items.Add("DIFFERENCE");
            operation.Items.Add("SYMMETRIC DIFFERENCE");

            leftSet.SelectedIndex = 0;
            rightSet.SelectedIndex = 1;
            operation.SelectedIndex = 0;
        }

        private void Set_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (leftSet.SelectedItem != null && leftMembers != null)
            {
                leftMembers.ItemsSource = collections[leftSet.SelectedItem.ToString()];
            }

            if (rightSet.SelectedItem != null && rightMembers != null)
            {
                rightMembers.ItemsSource = collections[rightSet.SelectedItem.ToString()];
            }
        }

        private void EvaluateButton_Click(object sender, RoutedEventArgs e)
        {
            if (leftSet.SelectedItem == null || rightSet.SelectedItem == null || operation.SelectedItem == null)
            {
                MessageBox.Show("Please select all necessaries");
                return;
            }

            var set1 = collections[leftSet.SelectedItem.ToString()];
            var set2 = collections[rightSet.SelectedItem.ToString()];

            IEnumerable<string> result = null;
            string selectedOp = operation.SelectedItem.ToString();

            if (selectedOp == "UNION")
            {
                result = set1.Union(set2);
            }
            else if (selectedOp == "INTERSECTION")
            {
                result = set1.Intersect(set2);
            }
            else if (selectedOp == "DIFFERENCE")
            {
                result = set1.Except(set2);
            }
            else if (selectedOp == "SYMMETRIC DIFFERENCE")
            {
                var diff1 = set1.Except(set2);
                var diff2 = set2.Except(set1);
                result = diff1.Union(diff2);
            }

            resultSet.ItemsSource = null;
            resultSet.ItemsSource = result?.ToList();
        }
    }
}