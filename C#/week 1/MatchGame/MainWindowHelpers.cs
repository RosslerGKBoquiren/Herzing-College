using MatchGame;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

internal static class MainWindowHelpers
{

        private static void TextBlock_MouseDown(object sender, MouseButtonEventArgs e)
        {

        }

    private static void TextBlock_MouseDown1(object sender, MouseButtonEventArgs e, ref TextBlock lastTextBlockClicked, ref bool findingmatch)
    {
        TextBlock textBlock = sender as TextBlock; if (findingmatch == false)
        {
            textBlock.Visibility = Visibility.Hidden;
            lastTextBlockClicked = textBlock;
            findingmatch = true;
        }
        else if (textBlock.Text == lastTextBlockClicked.Text)
        {
            textBlock.Visibility = Visibility.Hidden;
            findingmatch = false;
        }
        else
        {
            lastTextBlockClicked.Visibility = Visibility.Hidden;
        }
    }
}