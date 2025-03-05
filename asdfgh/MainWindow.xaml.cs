using System.IO;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace asdfgh;

public partial class MainWindow : Window
{
    public List<Gra> gry { get; set; }
    int gryindex = 0;
    public MainWindow()
    {
        InitializeComponent();
        Odczytajzpliku();
        wypiszgry(gryindex);
    }
    private void Odczytajzpliku()
    {
        gry = new List<Gra>();
        string[] linieWpliku = File.ReadAllLines("Data.txt");

        for (int i = 0; i < linieWpliku.Length; i += 5)
        {
            string nazwa = linieWpliku[i];
            int maxgraczy = int.Parse(linieWpliku[i + 1]);
            int mingraczy = int.Parse(linieWpliku[i + 2]);
            int liczbazagran = int.Parse(linieWpliku[i + 3]);
            gry.Add(new Gra(nazwa, maxgraczy, mingraczy, liczbazagran));
        }
    }
    private void wypiszgry(int i)
    {
        Nazwa.Text = gry[i].Nazwa;
        Max_graczy.Text = gry[i].max_graczy.ToString();
        Min_graczy.Text = gry[i].min_graczy.ToString();
        liczba_zagran.Text = gry[i].ile_grano.ToString();
        if (gry[i].komentarz.Count == 0)
        {
            comments.Text = "";
        }
        else {
            foreach (var item in gry[i].komentarz)
            {
                comments.Text += item + "\n";
            }
        }
    }
    private void Button_Click_Left(object sender, RoutedEventArgs e)
    {
        if (--gryindex < 0)
        {
            gryindex += gry.Count;
        }
        wypiszgry(gryindex);
    }

    private void Button_Click_Right(object sender, RoutedEventArgs e)
    {
        if (++gryindex >= gry.Count)
        {
            gryindex -= gry.Count;
        }
        wypiszgry(gryindex);
    }

    private void Inkrementation_Click(object sender, RoutedEventArgs e)
    {
        int wartosc;
        if (int.TryParse(liczba_zagran.Text, out wartosc))
        {
            wartosc++;

            gry[gryindex].ile_grano = wartosc;
            wypiszgry(gryindex);
        }

    }

    private void add_comment_Click(object sender, RoutedEventArgs e)
    {
        gry[gryindex].komentarz.Add(comment.Text);
        wypiszgry(gryindex);
    }
}