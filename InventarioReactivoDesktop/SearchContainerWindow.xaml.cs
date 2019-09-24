using InventarioReactivoDesktop.Data;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Printing;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace InventarioReactivoDesktop
{
    /// <summary>
    /// Interaction logic for SearchContainerWindow.xaml
    /// </summary>
    public partial class SearchContainerWindow : Window
    {
        BitmapImage Bitmap = null;

        public SearchContainerWindow()
        {
            InitializeComponent();
            this.WindowStartupLocation = WindowStartupLocation.CenterScreen;
        }

        private void SearchContainerId()
        {
            btnPrintLabel.Visibility = Visibility.Hidden; // Oculto el boton de imprimir
            imgContainer.Visibility = Visibility.Hidden;  // Oculto la imagen
            string containerId = tbContainerId.Text;
            if (string.IsNullOrEmpty(containerId))
            {
                MessageBox.Show("You must enter the container ID", "Info");
                return;
            }

            using (var _context = new ApplicationDbContext())
            {
                var container = _context.RI_CONTAINERS.Where(x => x.ContainerID == Convert.ToInt32(containerId)).FirstOrDefault();
                if (container == null)
                {
                    MessageBox.Show("Container doesn't exist", "Info");
                    return;
                }

                NetBarcode.Barcode barcode = new NetBarcode.Barcode(containerId.ToString(), true);

                Bitmap = new BitmapImage();
                byte[] binaryData = Convert.FromBase64String(barcode.GetBase64Image());
                Bitmap.BeginInit();
                Bitmap.StreamSource = new MemoryStream(binaryData);
                Bitmap.EndInit();

                imgContainer.Source = Bitmap;

                btnPrintLabel.Visibility = Visibility.Visible; // Muestro el boton de imprimir
                imgContainer.Visibility = Visibility.Visible;  // Muestro la imagen
            }
        }

        private void HandleClickSearchContainerId(object sender, RoutedEventArgs e)
        {
            SearchContainerId();
        }

        private void HandleClickPrintLabel(object sender, RoutedEventArgs e)
        {
            if (this.Bitmap != null)
            {
                var vis = new DrawingVisual();
                using (var dc = vis.RenderOpen())
                {
                    //dc.DrawImage(bitmap, new Rect { Width = bitmap.Width, Height = bitmap.Height });
                    dc.DrawImage(Bitmap, new Rect { Width = 128.50, Height = 52.91 });
                }

                var pdialog = new PrintDialog();
                // Comentado para pruebas si funciona
                if (pdialog.ShowDialog() == true) pdialog.PrintVisual(vis, "My Image");

                //PageMediaSize pageSize = null;
                //pageSize = new PageMediaSize(PageMediaSizeName.Unknown, 100, 200);
                //pdialog.PrintTicket.PageMediaSize = pageSize;


                // No funciono
                //PrintTicket pt = pdialog.PrintTicket;
                //Double printableWidth = pt.PageMediaSize.Width.Value;
                //Double printableHeight = pt.PageMediaSize.Height.Value;




                //if (pdialog.ShowDialog() == true)
                //{
                //    FixedDocument doc = new FixedDocument();
                //    doc.DocumentPaginator.PageSize = new Size(100, 50);
                //}

            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            tbContainerId.Focus();
        }

        private void TbContainerId_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.Key == Key.Enter) SearchContainerId();
        }
    }
}
