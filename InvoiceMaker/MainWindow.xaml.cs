// Assignment 6.
// Martin Lobell
// 2020-05-20

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
using System.IO;
using Microsoft.Win32;
using System.Linq.Expressions;

namespace InvoiceMaker
{
    public partial class MainWindow : Window
    {
        private List<Item> m_itemList = new List<Item>();
        double totalTax = 0;
        double totalPrice = 0;

        public MainWindow()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Lång metod:
        /// 1) Hämtar textfilen och bryter upp alla dess rader till strings i en stringarray.
        /// 2) För antalet produkter i textfilen loopas textfilen igenom och skapar alla produkt(item)objekt.
        /// 3) Hämtar den data som är fast för att skapa invoice- och mottagar-objekten.
        /// 4) Räknar ut de totala summorna för pris och skatt och skriver ut i behöriga boxar.
        /// 5) Skriver ut invoice-data i sina boxar.
        /// 6) Lägger till mottagarens information i sin listbox.
        /// 7) Lägger till sändarens information i sina boxar.
        /// </summary>
        public void mnuFileOpen_Click(object sender, RoutedEventArgs e)
        {
            // 1.
            string line;
            List<string> lines = new List<string>();
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            if (openFileDialog1.ShowDialog() == true)
            {
                try
                {
                    using (StreamReader sr = File.OpenText(openFileDialog1.FileName))
                    {
                        while ((line = sr.ReadLine()) != null)
                        {
                            lines.Add(line);
                        }
                        sr.Close();

                        InvoiceReceiver ivreceiver = new InvoiceReceiver(lines[3], lines[4], lines[5], lines[6], lines[7], lines[8]);

                        // 2.
                        int lastIndex = 10;
                        for (int i = 0; i < int.Parse(lines[9]); i++)
                        {
                            Item item = new Item();
                            item.m_number = (i+1);

                            item.m_description = lines[lastIndex++];

                            item.m_quantity = int.Parse(lines[lastIndex++]);

                            item.m_unitprice = double.Parse(lines[lastIndex++]);

                            item.m_tax = int.Parse(lines[lastIndex++]);
                            
                            m_itemList.Add(item);
                        }

                        // 3.
                        InvoiceSender ivsender = new InvoiceSender(lines[lastIndex], lines[lastIndex + 1], lines[lastIndex + 2], lines[lastIndex + 3], lines[lastIndex + 4], lines[lastIndex + 5], lines[lastIndex + 6]);
                        Invoice inVoice = new Invoice(lines[0], DateTime.Parse(lines[1]), DateTime.Parse(lines[2]), ivsender, ivreceiver, m_itemList);

                        // 4.
                        List<double> allTaxesList = new List<double>();
                        List<double> allPriceTotalsList = new List<double>();
                        for (int i = 0; i < m_itemList.Count; i++)
                        {
                            ListBox1.Items.Add(m_itemList[i].ToString());
                            allTaxesList.Add(m_itemList[i].TotalTax());
                            allPriceTotalsList.Add(m_itemList[i].TotalPrice());
                        }

                        for (int j = 0; j < allTaxesList.Count; j++)
                        {
                            totalTax += allTaxesList[j];
                        }
                        for (int k = 0; k < allPriceTotalsList.Count; k++)
                        {
                            totalPrice += allPriceTotalsList[k];
                        }
                        TaxAndTotalBox.Text = $"Total: \t {totalTax} \t\t {totalPrice}";
                        PayAmountBox.Text = $"{totalPrice}";
                        
                        // 5.
                        NumberBox.Text = $"Invoice number:\t\t\t{lines[0]}";
                        InvoiceDateBox.Text = $"Invoice date:\t\t\t{lines[1]}";
                        DueDateBox.Text = $"Due date:\t\t\t{lines[2]}";

                        // 6.
                        string[] arr = ivreceiver.ToString().Split(new string[] { ", " }, StringSplitOptions.None);
                        for(int i = 0; i < arr.Length; i++)
                        {
                            ListBox1_Copy.Items.Add(arr[i]);
                        }

                        // 7.
                        string[] arr2 = ivsender.ToString().Split(new string[] { ", " }, StringSplitOptions.None);
                        lblName.Content = arr2[0];
                        SenderInfoBox1.Text = arr2[1] + "\t\t" + arr2[5] + " \t " + arr2[6];
                        SenderInfoBox2.Text = arr2[2] + " " + arr2[3];
                    }
                }
                catch
                {
                    MessageBox.Show("Something went wrong!");
                }
            }
        }

        /// <summary>
        /// Knapp som låter användaren ladda upp en bild.
        /// </summary>
        private void btnLoad_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog op = new OpenFileDialog();
            op.Title = "Select a picture";
            op.Filter = "All supported graphics|*.jpg;*.jpeg;*.png|" +
              "JPEG (*.jpg;*.jpeg)|*.jpg;*.jpeg|" +
              "Portable Network Graphic (*.png)|*.png";
            if (op.ShowDialog() == true)
            {
                imgPhoto.Source = new BitmapImage(new Uri(op.FileName));
            }

        }

        /// <summary>
        /// Knapp som reducerar totalbeloppet med angiven rabatt.
        /// </summary>
        private void EnterBtn_Click(object sender, RoutedEventArgs e)
        {
            int discount;
            int parsedValue;
            if (int.TryParse(discountBox.Text, out parsedValue) && int.Parse(discountBox.Text) >= 0)
            {
                discount = int.Parse(discountBox.Text);
                PayAmountBox.Text = "" + (totalPrice - discount);
            }
            else
                MessageBox.Show("Enter a positive integer as your discount amount!");
        }
    }
}