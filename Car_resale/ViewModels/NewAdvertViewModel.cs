using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media.Imaging;

namespace App.ViewModels
{
    public class NewAdvertViewModel : Screen
    {
        public NewAdvertViewModel()
        {
            projectDirectory = Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName;
            //advertPicture = createImage(projectDirectory + "\\Resources\\Images\\Cars\\defaultCar.png");
        }

        string projectDirectory;
        private Image _advertPicture;

        public Image advertPicture
        {
            get => _advertPicture;
            set
            {
                _advertPicture = value;
                NotifyOfPropertyChange(() => advertPicture);
            }
        }

        public void FilePreviewDragEnter(DragEventArgs e)
        {

            bool dropEnabled = true;
            if (e.Data.GetDataPresent(DataFormats.FileDrop, true))
            {
                string[] filenames = e.Data.GetData(DataFormats.FileDrop, true) as string[];

                foreach (string filename in filenames)
                {
                    if (Path.GetExtension(filename).ToUpperInvariant() != ".PNG" && Path.GetExtension(filename).ToUpperInvariant() != ".JPG")
                    {
                        dropEnabled = false;
                        break;
                    }
                }
            }
            else
            {
                dropEnabled = false;
            }

            if (!dropEnabled)
            {
                e.Effects = DragDropEffects.None;
                e.Handled = true;
            }
        }

        public void FileDropped(DragEventArgs e)
        {
            string[] files = e.Data.GetData(DataFormats.FileDrop, true) as string[];
            string fileSource = Path.GetFullPath(files[0]);
            string fileDesination = projectDirectory + "\\Resources\\Pictures\\" + Path.GetFileName(files[0]);

            File.Copy(fileSource, fileDesination, true);
            //advertPicture = createImage("\\Resources\\Images\\" + Path.GetFileName(files[0]));

            e.Handled = true;

            return;
        }

        public void DragOverFileExtensionCheck(DragEventArgs e)
        {

            bool dropEnabled = true;
            if (e.Data.GetDataPresent(DataFormats.FileDrop, true))
            {
                string[] filenames =
                                 e.Data.GetData(DataFormats.FileDrop, true) as string[];

                foreach (string filename in filenames)
                {
                    if (System.IO.Path.GetExtension(filename).ToUpperInvariant() != ".PNG" && System.IO.Path.GetExtension(filename).ToUpperInvariant() != ".JPG")
                    {
                        dropEnabled = false;
                        break;
                    }
                }
            }
            else
            {
                dropEnabled = false;
            }

            if (!dropEnabled)
            {
                e.Effects = DragDropEffects.None;
                e.Handled = true;
            }
        }

        //private Image createImage(string ImagePath)
        //{
        //    Image newImage = new();
        //    BitmapImage src = new BitmapImage();
        //    src.BeginInit();
        //    src.UriSource = new Uri(ImagePath, UriKind.Absolute);
        //    src.EndInit();
        //    newImage.Source = src;
        //    return newImage;
        //}
    }
}
