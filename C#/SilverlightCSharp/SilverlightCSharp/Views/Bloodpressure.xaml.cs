using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SilverlightCSharp
{
    public partial class Bloodpressure : Page
    {
        private Color ivory = Color.FromArgb(255, 255, 240, 240);
        private Color darkSlateGray = Color.FromArgb(255, 47, 79, 79);
        List<TextBlock> tbNumbers = new List<TextBlock>();
        List<TextBlock> tbDates = new List<TextBlock>();

        List<TextBlock> tbValids = new List<TextBlock>();
        List<TextBlock> tbInvalids = new List<TextBlock>();

        List<TextBlock> tbSystolics = new List<TextBlock>();
        List<TextBlock> tbGtSystolics = new List<TextBlock>();

        List<TextBlock> tbDiastolics = new List<TextBlock>();
        List<TextBlock> tbLtDiastolics = new List<TextBlock>();
        
        List<TextBlock> tbLtAverageValidSystolics = new List<TextBlock>();
        List<TextBlock> tbGtAverageValidDiastolics = new List<TextBlock>();

        public Bloodpressure()
        {
            InitializeComponent();
            initTextBlockLists();
            //printLists(tbLtAverageValidSystolics);
            //printLists(tbLtDiastolics);
        }

        // Executes when the user navigates to this page.
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            
        }

        private static object FindNamedObject(FrameworkElement container, string name)
        {
            var target = container.FindName(name);
            if (target == null)
            {
                int count = VisualTreeHelper.GetChildrenCount(container);
                for (int i = 0; i < count; i++)
                {
                    var child = VisualTreeHelper.GetChild(container, i) as FrameworkElement;
                    if (child != null)
                    {
                        target = FindNamedObject(child, name);
                        if (target != null)
                        {
                            break;
                        }
                    }
                }
            }
            return target;
        }

        private void AddTextBlockList(List<TextBlock> textBlockList, string xName)
        {
            for (int i = 0; i <= 25; i++)
            {
                TextBlock txt = (TextBlock)FindNamedObject(this, xName + i);
                if (txt != null)
                {
                    textBlockList.Add(txt);
                }
            }  
        }

        private void AddTaggedObjects(List<TextBlock> textBlockList, string tag)
        {
            FrameworkElement[] frameworkElements = grid1.Children.Cast<FrameworkElement>().ToArray();
            TextBlock txt=null;

            for (int i = 0; i < frameworkElements.Count();i++)
            {
                FrameworkElement fe = frameworkElements[i];
                //System.Diagnostics.Debug.WriteLine("tag: "+tag+i);

                if (fe.GetType() == typeof(Border) && fe != null)
                {
                    Border b = (Border)fe;
                    txt = (TextBlock)b.Child;
                    if (txt.Tag != null && (txt.Tag).ToString().Contains(tag))
                    {
                        System.Diagnostics.Debug.WriteLine("Framework element :" + txt.Tag);
                        textBlockList.Add(txt);
                        
                    }
                }
            }  
        }
        
        private void initTextBlockLists()
        {
                AddTextBlockList(tbNumbers,"number");
                AddTextBlockList(tbDates,"date");

                AddTextBlockList(tbValids,"valid");
                AddTextBlockList(tbInvalids, "notValid");

                AddTextBlockList(tbSystolics,"systolic");
                AddTextBlockList(tbGtSystolics,"gtSystolicLimit");

                AddTextBlockList(tbDiastolics,"diastolic");
                AddTextBlockList(tbLtDiastolics, "ltDiastolicLimit");

                AddTaggedObjects(tbLtAverageValidSystolics, "ltAvgValidSystolic");
                AddTaggedObjects(tbGtAverageValidDiastolics, "gtAvgValidDiastolic");
                
        }

        private void getValues(List<TextBlock> tbValues)
        {
            for (int i = 0; i < tbValues.Count; i++)
            {
                int currentRow = Grid.GetRow((Border)tbValues[i].Parent);

                tbValues[i].Foreground = new SolidColorBrush(darkSlateGray);
                //System.Diagnostics.Debug.WriteLine("currentrow: "+currentRow);

                int desiredRowId = currentRow;
                foreach (var child in grid1.Children.OfType<Border>())
                {
                    if (Grid.GetRow(child) == desiredRowId)
                    {
                        var theChild = (TextBlock)child.Child;
                        theChild.Foreground = new SolidColorBrush(darkSlateGray);
                    }
                }
            }
        }

        private void resetForeground(List<TextBlock> tb) 
        {
            for (int i = 0; i < tb.Count; i++)
            {
                tb[i].Foreground = new SolidColorBrush(ivory);
            }
        }

        private void reset()
        { 
            resetForeground(tbNumbers);
            resetForeground(tbDates);
            resetForeground(tbValids);
            resetForeground(tbInvalids);
            resetForeground(tbSystolics);
            resetForeground(tbGtSystolics);
            resetForeground(tbDiastolics);
            resetForeground(tbLtDiastolics);
            resetForeground(tbLtAverageValidSystolics);
            resetForeground(tbGtAverageValidDiastolics);        
        }

        private void printLists(List<TextBlock> tb)
        {
            for (int i = 0; i < tb.Count; i++)
            {
                System.Diagnostics.Debug.WriteLine("TextBlock " +tb[i].Text);
            }
        }



        private void btnGtSystolicLimit_Click(object sender, RoutedEventArgs e)
        {
            reset();
            getValues(tbGtSystolics);
        }

        private void btnLtDiastolicLimit_Click(object sender, RoutedEventArgs e)
        {
            reset();
            getValues(tbLtDiastolics);
        }

        private void btnValid_Click(object sender, RoutedEventArgs e)
        {
            reset();
            getValues(tbInvalids);
        }

        private void btnLtAverage_Click(object sender, RoutedEventArgs e)
        {
            reset();
            getValues(tbLtAverageValidSystolics);
        }

        private void btnGtAverage_Click(object sender, RoutedEventArgs e)
        {
            reset();
            getValues(tbGtAverageValidDiastolics);
        }

        private void Page_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Escape)
            {
                reset();
                //System.Diagnostics.Debug.WriteLine("You have pressed escape");
            }
        }

    }
}