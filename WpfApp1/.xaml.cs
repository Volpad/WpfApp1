using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        private static Production production = new Production();

        private static IEnumerable<Vamvakera> vamvakera = from Vamvakera in production.Vamvakera
                                                          orderby Vamvakera.ColourNo ascending
                                                          where Vamvakera.Inactive == true
                                                          select Vamvakera;


        private static IEnumerable<Wool> wool = from Wool in production.Wool
                                                          orderby Wool.ColourNo ascending
                                                          //where Wool.Inactive == true
                                                          select Wool;


        private static IEnumerable<WarehouseChanges> warehouseChanges = from WarehouseChanges in production.WarehouseChanges
                                                                        select WarehouseChanges;


        string userName = System.Security.Principal.WindowsIdentity.GetCurrent().Name;

        



        List<Vamvakera> listvamvakera = vamvakera.ToList();
        List<Wool> listWool = wool.ToList();


        private string OldText = "";
        private bool saved = true;


        public MainWindow()
        {
            //NameScope nameScope = new NameScope();
             

            InitializeComponent();
            CreateBox();
            CreateBoxWool();



        }

        private void CreateBoxWool()
        {
            int rowCounter = 0;

            ScrollViewer scrollViewer = new ScrollViewer();

            foreach (Wool wool in listWool)
            {
                CreateInitialTextboxesAndAddToPanelWool(rowCounter, wool);
                int columnCounter = 0;
                Nullable<int> firstColumnName = null;
                Nullable<int> lastColumnName = null;
                while (columnCounter < 8)
                {
                    SelectColumnWool(wool, columnCounter, ref firstColumnName, ref lastColumnName);
                   // CreateLastTextboxesAndAddToPanel(rowCounter, columnCounter, firstColumnName, lastColumnName);
                    columnCounter++;
                }
                rowCounter++;
            }
        }

        private void CreateBox()
        {
            int rowCounter = 0;
            
            ScrollViewer scrollViewer = new ScrollViewer();

            foreach (Vamvakera vamvakera in listvamvakera)
            {
                CreateInitialTextboxesAndAddToPanel(rowCounter, vamvakera);
                int columnCounter = 0;
                Nullable<int> firstColumnName = null;
                Nullable<int> lastColumnName = null;
                while (columnCounter < 8)
                {
                    SelectColumn(vamvakera, columnCounter, ref firstColumnName, ref lastColumnName);
                    CreateLastTextboxesAndAddToPanel(rowCounter, columnCounter, firstColumnName, lastColumnName);
                    columnCounter++;
                }
                rowCounter++;
            }
        }
        private void CreateInitialTextboxesAndAddToPanelWool(int rowCounter, Wool wool)
        {
            Canvas rootwool = new Canvas();
            rootwool.Margin = new Thickness(0, 20, 0, 0);
            TextBox colNumber = new TextBox();
            TextBox colName = new TextBox();



            Canvas.SetLeft(colNumber, 0);
            Canvas.SetTop(colNumber, 0);


            colNumber.Name = "colNumberwool" + rowCounter;
            this.RegisterName(colNumber.Name, colNumber);
            colNumber.Text = wool.ColourNo;
            colNumber.IsReadOnly = true;
            colNumber.Height = 20;
            colNumber.Width = 25;



            colName.Name = "colNamewool" + rowCounter;
            this.RegisterName(colName.Name, colName);
            colName.Text = wool.ColourName;
            colName.Margin = new Thickness(25, 0, 0, 0);
            colName.IsReadOnly = true;
            colName.Height = 20;
            colName.Width = 120;

            if (rowCounter % 2 == 0)
            {
                colName.Background = new SolidColorBrush(Color.FromArgb(0, 0, 96, 97));
                colNumber.Background = new SolidColorBrush(Color.FromArgb(0, 0, 96, 97));
            }

            //    nameScope.RegisterName("col" + i, colNumber);
            //   nameScope.RegisterName("root" + i, root);
            rootwool.Children.Add(colNumber);
            rootwool.Children.Add(colName);
            //    root.Children.Add(b140first);
            stackPanelwool.Children.Add(rootwool);



            //b140first.Margin = new Thickness(140, 0, 0, 0);
            //b140first.Text = vamvakera.B140first.ToString();
            //b140first.Name = "b140first";
            //b140first.IsReadOnly = false;
            //b140first.Height = 20;
            //b140first.Width = 25;
            //b140first.LostFocus += new RoutedEventHandler(OnLostFocus);
        }
        private void CreateInitialTextboxesAndAddToPanel(int rowCounter, Vamvakera vamvakera)
        {
            Canvas root = new Canvas();
            root.Margin = new Thickness(0, 20, 0, 0);
            TextBox colNumber = new TextBox();
            TextBox colName = new TextBox();



            Canvas.SetLeft(colNumber, 0);
            Canvas.SetTop(colNumber, 0);


            colNumber.Name = "colNumber" + rowCounter;
            this.RegisterName(colNumber.Name, colNumber);
            colNumber.Text = vamvakera.ColourNo;
            colNumber.IsReadOnly = true;
            colNumber.Height = 20;
            colNumber.Width = 25;



            colName.Name = "colName" + rowCounter;
            this.RegisterName(colName.Name, colName);
            colName.Text = vamvakera.ColourName;
            colName.Margin = new Thickness(25, 0, 0, 0);
            colName.IsReadOnly = true;
            colName.Height = 20;
            colName.Width = 120;

            if(rowCounter % 2 == 0) { 
                colName.Background = new SolidColorBrush(Color.FromArgb(0, 0, 96, 97));
                colNumber.Background = new SolidColorBrush(Color.FromArgb(0, 0, 96, 97));
            }

            //    nameScope.RegisterName("col" + i, colNumber);
            //   nameScope.RegisterName("root" + i, root);
            root.Children.Add(colNumber);
                root.Children.Add(colName);
            //    root.Children.Add(b140first);
                stackPanel.Children.Add(root);



            //b140first.Margin = new Thickness(140, 0, 0, 0);
            //b140first.Text = vamvakera.B140first.ToString();
            //b140first.Name = "b140first";
            //b140first.IsReadOnly = false;
            //b140first.Height = 20;
            //b140first.Width = 25;
            //b140first.LostFocus += new RoutedEventHandler(OnLostFocus);
        }

        private static void SelectColumnWool(Wool wool, int columnCounter, ref int? firstColumnName, ref int? lastColumnName)
        {
            switch (columnCounter)
            {
                case 0:
                    firstColumnName = wool.A116first;
                    lastColumnName = wool.A116last;
                    break;
                case 1:
                    firstColumnName = wool.A140first;
                    lastColumnName = wool.A140last;
                    break;
                case 2:
                    firstColumnName = wool.M128first;
                    lastColumnName = wool.M128last;
                    break;
                case 3:
                    firstColumnName = wool.M228first;
                    lastColumnName = wool.M228last;
                    break;
                case 4:
                    firstColumnName = wool.T128first;
                    lastColumnName = wool.T128last;
                    break;
                case 5:
                    firstColumnName = wool.M132first;
                    lastColumnName = wool.M132last;
                    break;
                case 6:
                    firstColumnName = wool.M134first;
                    lastColumnName = wool.M134last;
                    break;
                case 7:
                    firstColumnName = wool.M244first;
                    lastColumnName = wool.M244last;
                    break;
                default:
                    throw new Exception("Invalid Column Counter");
            }
        }

        private static void SelectColumn(Vamvakera vamvakera, int columnCounter, ref int? firstColumnName, ref int? lastColumnName)
        {
            switch (columnCounter)
            {
                case 0:
                    firstColumnName = vamvakera.B140first;
                    lastColumnName = vamvakera.B140last;
                    break;
                case 1:
                    firstColumnName = vamvakera.B120first;
                    lastColumnName = vamvakera.B120last;
                    break;
                case 2:
                    firstColumnName = vamvakera.O130first;
                    lastColumnName = vamvakera.O130last;
                    break;
                case 3:
                    firstColumnName = vamvakera.B260first;
                    lastColumnName = vamvakera.B260last;
                    break;
                case 4:
                    firstColumnName = vamvakera.B250first;
                    lastColumnName = vamvakera.B250last;
                    break;
                case 5:
                    firstColumnName = vamvakera.B240first;
                    lastColumnName = vamvakera.B240last;
                    break;
                case 6:
                    firstColumnName = vamvakera.B234first;
                    lastColumnName = vamvakera.B234last;
                    break;
                case 7:
                    firstColumnName = vamvakera.B280first;
                    lastColumnName = vamvakera.B280last;
                    break;
                default:
                    throw new Exception("Invalid Column Counter");
            }
        }

        private void CreateLastTextboxesAndAddToPanel(int rowCounter, int columnCounter, int? firstColumnName, int? lastColumnName)
        {
            Canvas root = stackPanel.FindName("root") as Canvas;


            TextBox[] txtfst = new TextBox[100];
            TextBox[] txtlst = new TextBox[100];
            TextBox[] txtbnum = new TextBox[100];

            TextBox colNumber = root.FindName("colNumber" + rowCounter.ToString()) as TextBox;

            TextBox fst = CreateFirstTextbox(rowCounter, columnCounter, firstColumnName, txtfst);
            TextBox lst = CreateSecondTextbox(rowCounter, columnCounter, lastColumnName, txtlst);
            TextBox bnum = CreateBNumTextbox(rowCounter, columnCounter, txtbnum, fst, lst);

           // root.Children.Add(bnum);
            this.root.Children.Add(fst);
            this.root.Children.Add(lst);
            this.root.Children.Add(bnum);

            //root.Children.Add(lst);
        }

        private TextBox CreateFirstTextbox(int rowCounter, int columnCounter, int? firstColumnName, TextBox[] txtfst)
        {



            var fst = new TextBox();
            txtfst[rowCounter] = fst;

            fst.Name = "fst" + rowCounter + columnCounter;
            this.RegisterName(fst.Name, fst);
            fst.Text = firstColumnName.ToString();
            fst.Height = 20;
            fst.Width = 30;
            fst.Margin = new Thickness(185 + (columnCounter * 120), 20 + (rowCounter * 20), 0, 0);
            fst.IsReadOnly = false;

            if (rowCounter % 2 == 0)
            {
                fst.Background = new SolidColorBrush(Color.FromArgb(0, 0, 96, 97));
            }
            if (string.IsNullOrEmpty(fst.Text))
                fst.Background = Brushes.Gray; 
            else
            {
                if (rowCounter % 2 == 0)
                {
                    fst.Background = new SolidColorBrush(Color.FromArgb(0, 0, 96, 97));
                }
                else fst.Background = Brushes.White;
            }
            //fst.LostFocus += new RoutedEventHandler(OnTextChanged);
            fst.KeyDown += new KeyEventHandler(OnKeyPress);
            fst.LostKeyboardFocus += new KeyboardFocusChangedEventHandler(OnTextChanged);
            fst.GotFocus += new RoutedEventHandler(OnGotFocus);
            return fst;
        }

        private TextBox CreateSecondTextbox(int rowCounter, int columnCounter, int? lastColumnName, TextBox[] txtlst)
        {
            var lst = new TextBox();
            txtlst[rowCounter] = lst;
            lst.Name = "lst" + rowCounter + columnCounter;
            this.RegisterName(lst.Name, lst);
            lst.Text = lastColumnName.ToString();
            //lst.Location = new Point((215 + (columnCounter * 120)), 0 + (rowCounter * 20));
            lst.Margin = new Thickness(215 + (columnCounter * 120), 20 + (rowCounter * 20), 0, 0);
            lst.Height = 20;
            lst.Width = 30;
            //lst.TextAlign = HorizontalAlignment.Center;
            //lst.Visible = true;
            if (rowCounter % 2 == 0)
            {
                lst.Background = new SolidColorBrush(Color.FromArgb(0, 0, 96, 97));
            }
            lst.IsReadOnly = false;
            if (string.IsNullOrEmpty(lst.Text))
                lst.Background = Brushes.Gray;
            else
            {
                if (rowCounter % 2 == 0)
                {
                    lst.Background = new SolidColorBrush(Color.FromArgb(0, 0, 96, 97));
                }
                else lst.Background = Brushes.White;
            }
            //lst.LostFocus += new RoutedEventHandler(OnTextChanged);
            lst.KeyDown += new KeyEventHandler(OnKeyPress);
            lst.LostKeyboardFocus += new KeyboardFocusChangedEventHandler(OnTextChanged);
            lst.GotFocus += new RoutedEventHandler(OnGotFocus);
            //lst.KeyDown += new KeyEventHandler(OnKeyPress);
            //lst.Leave += new EventHandler(OnTextChanged);
            //lst.KeyPress += new KeyPressEventHandler(last_KeyPress);
            return lst;
        }

        private TextBox CreateBNumTextbox(int rowCounter, int columnCounter, TextBox[] txtbnum, TextBox fst, TextBox lst)
        {
            var bnum = new TextBox();
            txtbnum[rowCounter] = bnum;
            bnum.Name = "bnum" + rowCounter + columnCounter;
            this.RegisterName(bnum.Name, bnum);
            if (!string.IsNullOrEmpty(lst.Text) && !string.IsNullOrEmpty(fst.Text))
            {
                if (Int32.Parse(fst.Text) != 0)
                    bnum.Text = (Int32.Parse(lst.Text) - Int32.Parse(fst.Text) + 1).ToString();
                else
                    bnum.Text = "0";
            }
            else
                bnum.Text = "";
            //bnum.Location = new Point((155 + (columnCounter * 120)), 0 + (rowCounter * 20));
            bnum.Margin = new Thickness(145+(columnCounter*120), 20+(rowCounter*20), 0, 0);
            bnum.Height = 20;
            bnum.Width = 40;
            // bnum.TextAlign = HorizontalAlignment.Center;
            //bnum.Visible = true;
            if (rowCounter % 2 == 0)
            {
                bnum.Background = new SolidColorBrush(Color.FromArgb(0, 0, 96, 97));
            }
            bnum.IsReadOnly = true;
            if (string.IsNullOrEmpty(bnum.Text))
                bnum.Background = Brushes.Gray;
            else
            {
                if (rowCounter % 2 == 0)
                {
                    bnum.Background = new SolidColorBrush(Color.FromArgb(0, 0, 96, 97));
                }else bnum.Background = Brushes.White;
            }

            //bnum.KeyPress += new KeyPressEventHandler(first_KeyPress);
            bnum.KeyDown += new KeyEventHandler(OnKeyPress);
            return bnum;
        }

        private void OnLostFocus(object sender, RoutedEventArgs e)
        {
            if (sender.GetType() == typeof(TextBox))
            {

                string num = ((TextBox)sender).Name;

                int value;


                TextBox fst = sender as TextBox;

                fst.Background = Brushes.White;
               

                if (!string.IsNullOrEmpty(fst.Text))
                    value = Int32.Parse(fst.Text);
                else
                    value = 0;

                string yarntype = "B140first";
                string cols = "00";
                SaveToList(yarntype, value, cols , ((TextBox)sender).Text);


            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

            


            MessageBoxResult messageBoxResult = MessageBox.Show("Save Changes?", "Save", MessageBoxButton.YesNo);

            if(messageBoxResult == MessageBoxResult.Yes)
            {
                try
                {
                    production.SubmitChanges();
                    saved = true;
                }
                catch (Exception f)
                {
                    Console.WriteLine(f);
                    MessageBox.Show(f.ToString());

                }

            }
        }


        private void OnGotFocus(object sender, EventArgs e)
        {
            OldText = ((TextBox)sender).Text;
        }

        void OnTextChanged(object sender, EventArgs e)
        {


            if (sender.GetType() == typeof(TextBox))
            {
                // o arithmos tou xrwmatos
                string num = ((TextBox)sender).Name;
                string number = ((TextBox)sender).Name;
                

                // to an einai fst h lst
                string name = string.Concat(num.TakeWhile(char.IsLetter));
                string yarntype;
                Nullable<int> value;

                num = num.Substring(3, num.Length - 3);
                int nums = Int32.Parse(num) / 10;
                string numsf;
                numsf = nums.ToString();
                yarntype = num.Substring(num.Length - 1);

                yarntype = yarntype.TranslateYarnType();

                TextBox bnum = root.FindName("bnum" + num) as TextBox;
                //bnum.Text = "found!";
                TextBox fst = root.FindName("fst" + num) as TextBox;
                TextBox lst = root.FindName("lst" + num) as TextBox;

                bnum.Text = adding(fst.Text, lst.Text);
                bnum.Background = Brushes.White;
                fst.Background = Brushes.White;
                lst.Background = Brushes.White;

                TextBox col = root.FindName("colNumber" + numsf) as TextBox;
                string cols = col.Text;

                if (name.Equals("fst"))
                {
                    if (!string.IsNullOrEmpty(fst.Text))
                        value = Int32.Parse(fst.Text);
                    else
                        value = null;

                    ChangeList(yarntype, value, cols, "First", ((TextBox)sender).Text);
                    yarntype = yarntype + "first";
                    SaveToList(yarntype, value, cols, ((TextBox)sender).Text);
                }
                else
                {
                    if (!string.IsNullOrEmpty(lst.Text))
                        value = Int32.Parse(lst.Text);
                    else
                        value = null;

                    ChangeList(yarntype, value, cols, "Last", ((TextBox)sender).Text);
                    yarntype = yarntype + "last";
                    SaveToList(yarntype, value, cols, ((TextBox)sender).Text);

                }
            }
        }

        private string adding(string first, string last)
        {

            int First = 0;
            int Last = 0;
            string Number;

            if (first != "")
            {
                First = Int32.Parse(first);
            }
            else
            {
                First = 0;
                return "";
            }

            if (last != "")
            {
                Last = Int32.Parse(last);
            }
            else
            {
                Last = 0;
                return "";
            }
            if (First == 0)
            {
                Number = "0";
                //number.Text = Number;
            }
            else if (Last - First >= 0)
            {
                Number = (Last - First + 1).ToString();
            }
            else
            {
                //number.Text = "0";
                Number = "0";
            }

            return Number;

        }

        private void ChangeList(string yarntype, Nullable<int> value, string col, string fstlst, string sender)
        {

            if (!sender.Equals(OldText))
            {
            WarehouseChanges change = new WarehouseChanges() { time = DateTime.Now, yarntype = yarntype, colorno = col, fstlst = fstlst, boxnum = value, userName = System.Security.Principal.WindowsIdentity.GetCurrent().Name};
            production.WarehouseChanges.InsertOnSubmit(change);
                production.SubmitChanges();
            }

        }

        private void SaveToList(string yarntype, Nullable<int> value, string col, string sender)
        {
            if (!sender.Equals(OldText))
            {
                //Puts the updated value in the db
                IEnumerable<Vamvakera> vamvakerafilter = from Vamvakera in production.Vamvakera
                                                         where Vamvakera.ColourNo == col
                                                         select Vamvakera;
                saved = false;

                vamvakera = vamvakerafilter.Select(c =>
                { c.GetType().GetProperties().Single(x => x.Name.Equals(yarntype)).SetValue(c, value, null); return c; })
                        .ToList();
            }
        }

        private void OnKeyPress(object sender, System.Windows.Input.KeyEventArgs e)
        {
            TextBox textbox = sender as TextBox;


            if (e.Key == Key.Enter)
            {
                
                Keyboard.ClearFocus();

            }

            if (e.Key == Key.Escape)
            {
                textbox.Text = OldText;
                Keyboard.ClearFocus();

            }


            e.Handled = (e.Key < Key.D0 || e.Key > Key.D9) && (e.Key < Key.NumPad0 || e.Key > Key.NumPad9);

        }


        protected override void OnClosing(System.ComponentModel.CancelEventArgs e)
        {

            if (!saved)
            {

                MessageBoxResult messageBoxResult = MessageBox.Show("Close without saving?", "Are you sure?", MessageBoxButton.YesNo);

                if (messageBoxResult == MessageBoxResult.No)
                {
                    e.Cancel = true;
                }

            }
            else e.Cancel = false;

        }
    }

}


