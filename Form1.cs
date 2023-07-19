using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Windows.Forms;

namespace ColorPaletteExtractor
{
    public partial class MainForm : Form
    {
        private PictureBox pictureBox;
        private Button selectImageButton;
        private Button selectRegionButton;
        private Button resetImageButton;
        private FlowLayoutPanel colorPalettePanel;
        private Panel controlPanelColor;
        private Button extractColorsButton;
        private Button redColorsButton;
        private Button greenColorsButton;
        private Button blueColorsButton;
        private Button blackColorsButton;
        private Button grayColorsButton;
        private Button whiteColorsButton;
        private Button resizeButton;

        private Bitmap originalImage;
        private Rectangle selectedRegion;
        private Size originalImageSize;


        public MainForm()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            // Form
            this.BackColor = ColorTranslator.FromHtml("#1B1B1B");
            this.ForeColor = Color.White;

            // PictureBox
            this.pictureBox = new PictureBox();
            this.pictureBox.Location = new Point(12, 12);
            this.pictureBox.Size = new Size(400, 300);
            this.pictureBox.SizeMode = PictureBoxSizeMode.StretchImage;

            // Select Image Button
            this.selectImageButton = new Button();
            this.selectImageButton.Location = new Point(430, 12);
            this.selectImageButton.Size = new Size(120, 30);
            this.selectImageButton.Text = "Seleccionar imagen";
            this.selectImageButton.BackColor = ColorTranslator.FromHtml("#353535");
            this.selectImageButton.ForeColor = Color.White;
            this.selectImageButton.FlatStyle = FlatStyle.Flat;
            this.selectImageButton.FlatAppearance.BorderSize = 0;
            this.selectImageButton.Click += SelectImageButton_Click;

            // Select Region Button
            this.selectRegionButton = new Button();
            this.selectRegionButton.Location = new Point(430, 50);
            this.selectRegionButton.Size = new Size(120, 30);
            this.selectRegionButton.Text = "Seleccionar región";
            this.selectRegionButton.BackColor = ColorTranslator.FromHtml("#353535");
            this.selectRegionButton.ForeColor = Color.White;
            this.selectRegionButton.FlatStyle = FlatStyle.Flat;
            this.selectRegionButton.FlatAppearance.BorderSize = 0;
            this.selectRegionButton.Click += SelectRegionButton_Click;

            // Reset Image Button
            this.resetImageButton = new Button();
            this.resetImageButton.Location = new Point(430, 88);
            this.resetImageButton.Size = new Size(120, 30);
            this.resetImageButton.Text = "Reiniciar imagen";
            this.resetImageButton.BackColor = ColorTranslator.FromHtml("#353535");
            this.resetImageButton.ForeColor = Color.White;
            this.resetImageButton.FlatStyle = FlatStyle.Flat;
            this.resetImageButton.FlatAppearance.BorderSize = 0;
            this.resetImageButton.Click += ResetImageButton_Click;

            // Color Palette Panel
            this.colorPalettePanel = new FlowLayoutPanel();
            this.colorPalettePanel.Location = new Point(12, 350);
            this.colorPalettePanel.Size = new Size(760, 150);
            this.colorPalettePanel.AutoScroll = true;

            // Control Panel Color
            this.controlPanelColor = new Panel();
            this.controlPanelColor.Location = new Point(12, 520);
            this.controlPanelColor.Size = new Size(150, 30);

            // Extract Colors Button
            this.extractColorsButton = new Button();
            this.extractColorsButton.Location = new Point(12, 570);
            this.extractColorsButton.Size = new Size(150, 30);
            this.extractColorsButton.Text = "Extraer colores";
            this.extractColorsButton.BackColor = ColorTranslator.FromHtml("#353535");
            this.extractColorsButton.ForeColor = Color.White;
            this.extractColorsButton.FlatStyle = FlatStyle.Flat;
            this.extractColorsButton.FlatAppearance.BorderSize = 0;
            this.extractColorsButton.Click += ExtractColorsButton_Click;

            // Red Colors Button
            this.redColorsButton = new Button();
            this.redColorsButton.Location = new Point(570, 60);
            this.redColorsButton.Size = new Size(80, 30);
            this.redColorsButton.Text = "Rojos";
            this.redColorsButton.BackColor = ColorTranslator.FromHtml("#353535");
            this.redColorsButton.ForeColor = Color.White;
            this.redColorsButton.FlatStyle = FlatStyle.Flat;
            this.redColorsButton.FlatAppearance.BorderSize = 0;
            this.redColorsButton.Click += RedColorsButton_Click;

            // Green Colors Button
            this.greenColorsButton = new Button();
            this.greenColorsButton.Location = new Point(660, 60);
            this.greenColorsButton.Size = new Size(80, 30);
            this.greenColorsButton.Text = "Verdes";
            this.greenColorsButton.BackColor = ColorTranslator.FromHtml("#353535");
            this.greenColorsButton.ForeColor = Color.White;
            this.greenColorsButton.FlatStyle = FlatStyle.Flat;
            this.greenColorsButton.FlatAppearance.BorderSize = 0;
            this.greenColorsButton.Click += GreenColorsButton_Click;

            // Blue Colors Button
            this.blueColorsButton = new Button();
            this.blueColorsButton.Location = new Point(750, 60);
            this.blueColorsButton.Size = new Size(80, 30);
            this.blueColorsButton.Text = "Azules";
            this.blueColorsButton.BackColor = ColorTranslator.FromHtml("#353535");
            this.blueColorsButton.ForeColor = Color.White;
            this.blueColorsButton.FlatStyle = FlatStyle.Flat;
            this.blueColorsButton.FlatAppearance.BorderSize = 0;
            this.blueColorsButton.Click += BlueColorsButton_Click;

            // Black Colors Button
            this.blackColorsButton = new Button();
            this.blackColorsButton.Location = new Point(570, 108);
            this.blackColorsButton.Size = new Size(80, 30);
            this.blackColorsButton.Text = "Negros";
            this.blackColorsButton.BackColor = ColorTranslator.FromHtml("#353535");
            this.blackColorsButton.ForeColor = Color.White;
            this.blackColorsButton.FlatStyle = FlatStyle.Flat;
            this.blackColorsButton.FlatAppearance.BorderSize = 0;
            this.blackColorsButton.Click += BlackColorsButton_Click;

            // Gray Colors Button
            this.grayColorsButton = new Button();
            this.grayColorsButton.Location = new Point(660, 108);
            this.grayColorsButton.Size = new Size(80, 30);
            this.grayColorsButton.Text = "Grises";
            this.grayColorsButton.BackColor = ColorTranslator.FromHtml("#353535");
            this.grayColorsButton.ForeColor = Color.White;
            this.grayColorsButton.FlatStyle = FlatStyle.Flat;
            this.grayColorsButton.FlatAppearance.BorderSize = 0;
            this.grayColorsButton.Click += GrayColorsButton_Click;

            // White Colors Button
            this.whiteColorsButton = new Button();
            this.whiteColorsButton.Location = new Point(750, 108);
            this.whiteColorsButton.Size = new Size(80, 30);
            this.whiteColorsButton.Text = "Blancos";
            this.whiteColorsButton.BackColor = ColorTranslator.FromHtml("#353535");
            this.whiteColorsButton.ForeColor = Color.White;
            this.whiteColorsButton.FlatStyle = FlatStyle.Flat;
            this.whiteColorsButton.FlatAppearance.BorderSize = 0;
            this.whiteColorsButton.Click += WhiteColorsButton_Click;

            // Resize Button
            this.resizeButton = new Button();
            this.resizeButton.Location = new Point(570, 12);
            this.resizeButton.Size = new Size(120, 30);
            this.resizeButton.Text = "Redimensionar";
            this.resizeButton.BackColor = ColorTranslator.FromHtml("#353535");
            this.resizeButton.ForeColor = Color.White;
            this.resizeButton.FlatStyle = FlatStyle.Flat;
            this.resizeButton.FlatAppearance.BorderSize = 0;
            this.resizeButton.Click += ResizeButton_Click;

            // Main Form
            this.ClientSize = new Size(850, 630);
            this.Controls.Add(this.pictureBox);
            this.Controls.Add(this.selectImageButton);
            this.Controls.Add(this.selectRegionButton);
            this.Controls.Add(this.resetImageButton);
            this.Controls.Add(this.colorPalettePanel);
            this.Controls.Add(this.controlPanelColor);
            this.Controls.Add(this.extractColorsButton);
            this.Controls.Add(this.redColorsButton);
            this.Controls.Add(this.greenColorsButton);
            this.Controls.Add(this.blueColorsButton);
            this.Controls.Add(this.blackColorsButton);
            this.Controls.Add(this.grayColorsButton);
            this.Controls.Add(this.whiteColorsButton);
            this.Controls.Add(this.resizeButton);
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "Extractor de Paleta de Colores";
        }

        private void SelectImageButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Archivos de imagen|*.bmp;*.jpg;*.jpeg;*.png;*.gif";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string filePath = openFileDialog.FileName;

                // Cargar la imagen seleccionada
                LoadImage(filePath);
            }
        }

    private void LoadImage(string filePath)
        {
            // Cargar la imagen original
            Bitmap originalImage = new Bitmap(filePath);

            // Mostrar la imagen en el PictureBox
            pictureBox.Image = originalImage;

            // Verificar si la imagen tiene más de 1000 colores
            Color[] palette = ExtractPalette(originalImage);
            int colorCount = palette.Length;

            if (colorCount > 1000)
            {
                // Mostrar un diálogo para preguntar si se desea reducir los colores
                DialogResult dialogResult = MessageBox.Show(
                    "La imagen tiene más de 1000 colores. ¿Desea reducir los colores a 4096?",
                    "Reducir colores",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (dialogResult == DialogResult.Yes)
                {
                    // Reducir los colores a 4096
                    Color[] limitedPalette = ExtractLimitedPalette(originalImage, 4096);

                    // Crear una nueva imagen con la paleta limitada de colores
                    Bitmap finalImage = CreateImageWithSelectedPalette(originalImage, limitedPalette);

                    // Mostrar la imagen final en el PictureBox
                    pictureBox.Image = finalImage;
                }
            }
        }


        private Bitmap ApplyColorPalette(Bitmap image, Color[] palette)
        {
            Bitmap resultImage = new Bitmap(image.Width, image.Height);

            for (int x = 0; x < image.Width; x++)
            {
                for (int y = 0; y < image.Height; y++)
                {
                    Color pixelColor = image.GetPixel(x, y);
                    Color closestColor = GetClosestColor(pixelColor, palette);
                    resultImage.SetPixel(x, y, closestColor);
                }
            }

            return resultImage;
        }

        private Color GetClosestColor(Color targetColor, Color[] palette)
        {
            Color closestColor = Color.Empty;
            int minDiff = int.MaxValue;

            foreach (Color paletteColor in palette)
            {
                int diff = Math.Abs(targetColor.R - paletteColor.R) +
                           Math.Abs(targetColor.G - paletteColor.G) +
                           Math.Abs(targetColor.B - paletteColor.B);

                if (diff < minDiff)
                {
                    minDiff = diff;
                    closestColor = paletteColor;
                }
            }

            return closestColor;
        }




        private int GetUniqueColorCount(Bitmap bitmap)
        {
            HashSet<Color> uniqueColors = new HashSet<Color>();

            for (int x = 0; x < bitmap.Width; x++)
            {
                for (int y = 0; y < bitmap.Height; y++)
                {
                    Color pixelColor = bitmap.GetPixel(x, y);
                    uniqueColors.Add(pixelColor);
                }
            }

            return uniqueColors.Count;
        }

        private void ResetImageButton_Click(object sender, EventArgs e)
        {
            if (originalImage == null)
                return;

            selectedRegion = Rectangle.Empty;
            ResetImage();
        }

        private void SelectRegionButton_Click(object sender, EventArgs e)
        {
            if (pictureBox.Image == null)
            {
                MessageBox.Show("Por favor, selecciona una imagen.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            RegionSelectionForm regionSelectionForm;

            // Si ya hay una región seleccionada, pasarla al nuevo formulario de selección
            if (selectedRegion != Rectangle.Empty)
            {
                Bitmap croppedImage = new Bitmap(selectedRegion.Width, selectedRegion.Height);
                using (Graphics graphics = Graphics.FromImage(croppedImage))
                {
                    graphics.DrawImage(originalImage, new Rectangle(0, 0, croppedImage.Width, croppedImage.Height), selectedRegion, GraphicsUnit.Pixel);
                }

                regionSelectionForm = new RegionSelectionForm(croppedImage);
            }
            else
            {
                regionSelectionForm = new RegionSelectionForm((Bitmap)pictureBox.Image);
            }

            regionSelectionForm.ShowDialog();

            if (regionSelectionForm.DialogResult == DialogResult.OK)
            {
                selectedRegion = regionSelectionForm.SelectedRegion;

                // Si no había una región seleccionada anteriormente, recortar la imagen completa
                if (selectedRegion != Rectangle.Empty)
                {
                    CropImage();

                    // Obtener la cantidad de colores en la región seleccionada
                    int colorCount = GetUniqueColorCount((Bitmap)pictureBox.Image);
                    MessageBox.Show($"La región seleccionada contiene {colorCount} colores.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    ResetImage();
                }
            }
        }


        private void CropImage()
        {
            if (selectedRegion == Rectangle.Empty)
            {
                ResetImage();
                return;
            }

            Bitmap croppedImage = new Bitmap(selectedRegion.Width, selectedRegion.Height);
            using (Graphics graphics = Graphics.FromImage(croppedImage))
            {
                graphics.DrawImage(originalImage, new Rectangle(0, 0, croppedImage.Width, croppedImage.Height), selectedRegion, GraphicsUnit.Pixel);
            }
            pictureBox.Image = croppedImage;
        }

        private void ResetImage()
        {
            pictureBox.Image = originalImage;
        }

        private void ExtractColorsButton_Click(object sender, EventArgs e)
        {
            if (pictureBox.Image == null)
            {
                MessageBox.Show("Por favor, selecciona una imagen.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            Bitmap bitmap = (Bitmap)pictureBox.Image;
            Color[] palette = ExtractPalette(bitmap);
            ShowColors(palette);
        }

        private Color[] ExtractPalette(Bitmap bitmap)
        {
            List<Color> pixels = new List<Color>();

            for (int x = 0; x < bitmap.Width; x++)
            {
                for (int y = 0; y < bitmap.Height; y++)
                {
                    Color pixelColor = bitmap.GetPixel(x, y);
                    pixels.Add(pixelColor);
                }
            }

            return pixels.Distinct().ToArray();
        }

        private void RedColorsButton_Click(object sender, EventArgs e)
        {
            if (pictureBox.Image == null)
                return;

            Bitmap bitmap = (Bitmap)pictureBox.Image;
            Color[] palette = ExtractPalette(bitmap);

            var redColors = palette.Where(color => color.R > color.G && color.R > color.B).Distinct().ToArray();
            ShowColors(redColors);
        }

        private void GreenColorsButton_Click(object sender, EventArgs e)
        {
            if (pictureBox.Image == null)
                return;

            Bitmap bitmap = (Bitmap)pictureBox.Image;
            Color[] palette = ExtractPalette(bitmap);

            var greenColors = palette.Where(color => color.G > color.R && color.G > color.B).Distinct().ToArray();
            ShowColors(greenColors);
        }

        private void BlueColorsButton_Click(object sender, EventArgs e)
        {
            if (pictureBox.Image == null)
                return;

            Bitmap bitmap = (Bitmap)pictureBox.Image;
            Color[] palette = ExtractPalette(bitmap);

            var blueColors = palette.Where(color => color.B > color.R && color.B > color.G).Distinct().ToArray();
            ShowColors(blueColors);
        }

        private void BlackColorsButton_Click(object sender, EventArgs e)
        {
            if (pictureBox.Image == null)
                return;

            Bitmap bitmap = (Bitmap)pictureBox.Image;
            Color[] palette = ExtractPalette(bitmap);

            var blackColors = palette.Where(color => color.GetBrightness() < 0.1).Distinct().ToArray();
            ShowColors(blackColors);
        }

        private void GrayColorsButton_Click(object sender, EventArgs e)
        {
            if (pictureBox.Image == null)
                return;

            Bitmap bitmap = (Bitmap)pictureBox.Image;
            Color[] palette = ExtractPalette(bitmap);

            var grayColors = palette.Where(color => color.GetBrightness() >= 0.1 && color.GetBrightness() <= 0.9).Distinct().ToArray();
            ShowColors(grayColors);
        }

        private void WhiteColorsButton_Click(object sender, EventArgs e)
        {
            if (pictureBox.Image == null)
                return;

            Bitmap bitmap = (Bitmap)pictureBox.Image;
            Color[] palette = ExtractPalette(bitmap);

            var whiteColors = palette.Where(color => color.GetBrightness() > 0.9).Distinct().ToArray();
            ShowColors(whiteColors);
        }

        private void ShowColors(Color[] colors)
        {
            colorPalettePanel.Controls.Clear();

            foreach (Color color in colors)
            {
                Panel colorPanel = new Panel();
                colorPanel.Size = new Size(30, 30);
                colorPanel.BackColor = color;

                colorPalettePanel.Controls.Add(colorPanel);
            }
        }

        private void ResizeButton_Click(object sender, EventArgs e)
        {
            if (pictureBox.Image == null)
            {
                MessageBox.Show("Por favor, selecciona una imagen.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Obtener la imagen para redimensionar
            Bitmap imageToResize = selectedRegion != Rectangle.Empty ? (Bitmap)pictureBox.Image : originalImage;

            // Mostrar un formulario de diálogo para que el usuario seleccione la cantidad de colores
            ColorCountSelectionForm colorCountForm = new ColorCountSelectionForm();
            DialogResult result = colorCountForm.ShowDialog();

            if (result == DialogResult.OK)
            {
                int selectedColorCount = colorCountForm.SelectedColorCount;

                // Obtener la resolución seleccionada
                string resolutionString = colorCountForm.SelectedResolution;
                string[] resolutionParts = resolutionString.Split('x');
                int width = int.Parse(resolutionParts[0]);
                int height = int.Parse(resolutionParts[1]);

                // Redimensionar la imagen
                Bitmap resizedImage = ResizeImage(imageToResize, width, height);

                // Extraer la paleta limitada de colores de la imagen redimensionada
                Color[] palette = ExtractLimitedPalette(resizedImage, selectedColorCount);
                int colorCount = palette.Length;

                // Crear una nueva imagen con la paleta de colores seleccionada
                Bitmap finalImage = CreateImageWithSelectedPalette(resizedImage, palette);

                // Actualizar la imagen en el PictureBox
                pictureBox.Image = finalImage;

                // Mostrar la cantidad de colores en el diálogo
                MessageBox.Show($"La imagen se ha redimensionado a {width}x{height} y contiene {colorCount} colores seleccionados.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }



        private Bitmap CreateImageWithSelectedPalette(Bitmap originalImage, Color[] palette)
        {
            Bitmap newImage = new Bitmap(originalImage.Width, originalImage.Height);

            for (int x = 0; x < originalImage.Width; x++)
            {
                for (int y = 0; y < originalImage.Height; y++)
                {
                    Color pixelColor = originalImage.GetPixel(x, y);

                    // Buscar el color más cercano en la paleta seleccionada
                    Color closestColor = FindClosestColor(pixelColor, palette);

                    // Asignar el color más cercano al píxel en la nueva imagen
                    newImage.SetPixel(x, y, closestColor);
                }
            }

            return newImage;
        }

        private Color FindClosestColor(Color color, Color[] palette)
        {
            int minDistance = int.MaxValue;
            Color closestColor = Color.Black;

            foreach (Color paletteColor in palette)
            {
                int distance = CalculateColorDistance(color, paletteColor);

                if (distance < minDistance)
                {
                    minDistance = distance;
                    closestColor = paletteColor;
                }
            }

            return closestColor;
        }

        private int CalculateColorDistance(Color color1, Color color2)
        {
            int rDiff = color1.R - color2.R;
            int gDiff = color1.G - color2.G;
            int bDiff = color1.B - color2.B;

            return (rDiff * rDiff) + (gDiff * gDiff) + (bDiff * bDiff);
        }

        private Bitmap ResizeImage(Bitmap image, int width, int height)
        {
            if (width <= 0 || height <= 0)
            {
                return new Bitmap(image); // Mantener la imagen original si la resolución es inválida
            }

            Bitmap resizedImage = new Bitmap(width, height, image.PixelFormat);
            using (Graphics graphics = Graphics.FromImage(resizedImage))
            {
                graphics.DrawImage(image, 0, 0, width, height);
            }
            return resizedImage;
        }


        private Color[] ExtractLimitedPalette(Bitmap bitmap, int colorCount)
        {
            // Obtener todos los colores de la imagen y sus frecuencias
            Dictionary<Color, int> colorFrequencies = new Dictionary<Color, int>();

            for (int x = 0; x < bitmap.Width; x++)
            {
                for (int y = 0; y < bitmap.Height; y++)
                {
                    Color pixelColor = bitmap.GetPixel(x, y);
                    if (colorFrequencies.ContainsKey(pixelColor))
                    {
                        colorFrequencies[pixelColor]++;
                    }
                    else
                    {
                        colorFrequencies[pixelColor] = 1;
                    }
                }
            }

            // Ordenar los colores por frecuencia en orden descendente
            var sortedColors = colorFrequencies.OrderByDescending(kv => kv.Value).Select(kv => kv.Key);

            // Dividir los colores en primarios y secundarios
            List<Color> primaryColors = new List<Color>();
            List<Color> secondaryColors = new List<Color>();
            List<Color> otherColors = new List<Color>();

            foreach (Color color in sortedColors)
            {
                if (IsPrimaryColor(color))
                {
                    primaryColors.Add(color);
                }
                else if (IsSecondaryColor(color))
                {
                    secondaryColors.Add(color);
                }
                else
                {
                    otherColors.Add(color);
                }
            }

            // Seleccionar los colores necesarios para alcanzar el límite especificado
            List<Color> selectedColors = new List<Color>();

            // Agregar colores primarios
            int primaryCount = Math.Min(colorCount, primaryColors.Count);
            selectedColors.AddRange(primaryColors.Take(primaryCount));

            // Verificar si se necesita agregar colores secundarios
            int remainingCount = colorCount - primaryCount;
            if (remainingCount > 0)
            {
                int secondaryCount = Math.Min(remainingCount, secondaryColors.Count);
                selectedColors.AddRange(secondaryColors.Take(secondaryCount));
                remainingCount -= secondaryCount;
            }

            // Agregar colores restantes
            selectedColors.AddRange(otherColors.Take(remainingCount));

            return selectedColors.ToArray();
        }

        private bool IsPrimaryColor(Color color)
        {
            // Verificar si el color es primario (rojo, verde o azul)
            return color.R > color.G && color.R > color.B
                || color.G > color.R && color.G > color.B
                || color.B > color.R && color.B > color.G;
        }

        private bool IsSecondaryColor(Color color)
        {
            // Verificar si el color es secundario (cian, magenta o amarillo)
            return color.B == 0 && color.R > 0 && color.G > 0
                || color.R == 0 && color.G > 0 && color.B > 0
                || color.G == 0 && color.R > 0 && color.B > 0;
        }

    }

    public class ResizeImageForm : Form
    {
        private ComboBox resolutionComboBox;
        private ComboBox colorCountComboBox;
        private Button okButton;
        private Button cancelButton;

        public int SelectedWidth { get; private set; }
        public int SelectedHeight { get; private set; }
        public int SelectedColorCount { get; private set; }

        public ResizeImageForm()
        {
            InitializeComponent();
            InitializeComboBoxes();
        }

        private void InitializeComponent()
        {
            // Formulario
            this.Text = "Redimensionar imagen";
            this.ClientSize = new Size(250, 200);
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.StartPosition = FormStartPosition.CenterParent;
            this.MinimizeBox = false;
            this.MaximizeBox = false;
            this.ShowInTaskbar = false;

            // ComboBox de resolución
            this.resolutionComboBox = new ComboBox();
            this.resolutionComboBox.Location = new Point(50, 40);
            this.resolutionComboBox.Size = new Size(150, 24);
            this.resolutionComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            this.resolutionComboBox.Items.AddRange(new object[] { "128x128", "256x256", "512x512", "1024x1024", "1280x720", "1920x1080", "Mantener resolución original" });
            this.resolutionComboBox.SelectedIndex = 2; // Establecer la selección predeterminada a 512x512

            // ComboBox de cantidad de colores
            this.colorCountComboBox = new ComboBox();
            this.colorCountComboBox.Location = new Point(50, 80);
            this.colorCountComboBox.Size = new Size(150, 24);
            this.colorCountComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            this.colorCountComboBox.Items.AddRange(new object[] { "16 colores", "128 colores", "256 colores", "512 colores", "1024 colores" });
            this.colorCountComboBox.SelectedIndex = 2; // Establecer la selección predeterminada a 256 colores

            // Botón OK
            this.okButton = new Button();
            this.okButton.Location = new Point(50, 120);
            this.okButton.Size = new Size(70, 30);
            this.okButton.Text = "OK";
            this.okButton.DialogResult = DialogResult.OK;

            // Botón Cancelar
            this.cancelButton = new Button();
            this.cancelButton.Location = new Point(130, 120);
            this.cancelButton.Size = new Size(70, 30);
            this.cancelButton.Text = "Cancelar";
            this.cancelButton.DialogResult = DialogResult.Cancel;

            // Agregar los controles al formulario
            this.Controls.Add(resolutionComboBox);
            this.Controls.Add(colorCountComboBox);
            this.Controls.Add(okButton);
            this.Controls.Add(cancelButton);
        }

        private void InitializeComboBoxes()
        {
            resolutionComboBox.SelectedIndexChanged += (sender, e) =>
            {
                string selectedValue = (string)resolutionComboBox.SelectedItem;
                switch (selectedValue)
                {
                    case "128x128":
                        SelectedWidth = 128;
                        SelectedHeight = 128;
                        break;
                    case "256x256":
                        SelectedWidth = 256;
                        SelectedHeight = 256;
                        break;
                    case "512x512":
                        SelectedWidth = 512;
                        SelectedHeight = 512;
                        break;
                    case "1024x1024":
                        SelectedWidth = 1024;
                        SelectedHeight = 1024;
                        break;
                    case "1280x720":
                        SelectedWidth = 1280;
                        SelectedHeight = 720;
                        break;
                    case "1920x1080":
                        SelectedWidth = 1920;
                        SelectedHeight = 1080;
                        break;
                    case "Mantener resolución original":
                        SelectedWidth = 0;
                        SelectedHeight = 0;
                        break;
                    default:
                        SelectedWidth = 512;
                        SelectedHeight = 512; // Valores predeterminados
                        break;
                }
            };

            colorCountComboBox.SelectedIndexChanged += (sender, e) =>
            {
                string selectedValue = (string)colorCountComboBox.SelectedItem;
                switch (selectedValue)
                {
                    case "16 colores":
                        SelectedColorCount = 16;
                        break;
                    case "128 colores":
                        SelectedColorCount = 128;
                        break;
                    case "256 colores":
                        SelectedColorCount = 256;
                        break;
                    case "512 colores":
                        SelectedColorCount = 512;
                        break;
                    case "1024 colores":
                        SelectedColorCount = 1024;
                        break;
                    default:
                        SelectedColorCount = 256; // Valor predeterminado
                        break;
                }
            };
        }
    }

    public class ColorCountSelectionForm : Form
{
    private ComboBox colorCountComboBox;
    private ComboBox resolutionComboBox;
    private Button okButton;
    private Button cancelButton;

    public int SelectedColorCount { get; private set; }
    public string SelectedResolution { get; private set; }

    public ColorCountSelectionForm()
    {
        InitializeComponent();
        InitializeComboBoxes();
    }

    private void InitializeComponent()
    {
        // Formulario
        this.Text = "Selección de cantidad de colores y resolución";
        this.ClientSize = new Size(300, 200);
        this.FormBorderStyle = FormBorderStyle.FixedDialog;
        this.StartPosition = FormStartPosition.CenterParent;
        this.MinimizeBox = false;
        this.MaximizeBox = false;
        this.ShowInTaskbar = false;

        // ComboBox de cantidad de colores
        this.colorCountComboBox = new ComboBox();
        this.colorCountComboBox.Location = new Point(50, 40);
        this.colorCountComboBox.Size = new Size(200, 24);
        this.colorCountComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
        this.colorCountComboBox.Items.AddRange(new object[] { "16 colores", "128 colores", "256 colores", "512 colores", "1024 colores" });
        this.colorCountComboBox.SelectedIndex = 2; // Establecer la selección predeterminada a 256 colores

        // ComboBox de resolución
        this.resolutionComboBox = new ComboBox();
        this.resolutionComboBox.Location = new Point(50, 80);
        this.resolutionComboBox.Size = new Size(200, 24);
        this.resolutionComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
        this.resolutionComboBox.Items.AddRange(new object[]
        {
            "128x128",
            "256x256",
            "512x512",
            "1024x1024",
            "1280x720",
            "1920x1080",
            "Mantener resolución original"
        });
        this.resolutionComboBox.SelectedIndex = 3; // Establecer la selección predeterminada a 1024x1024

        // Botón OK
        this.okButton = new Button();
        this.okButton.Location = new Point(50, 120);
        this.okButton.Size = new Size(70, 30);
        this.okButton.Text = "OK";
        this.okButton.DialogResult = DialogResult.OK;

        // Botón Cancelar
        this.cancelButton = new Button();
        this.cancelButton.Location = new Point(130, 120);
        this.cancelButton.Size = new Size(70, 30);
        this.cancelButton.Text = "Cancelar";
        this.cancelButton.DialogResult = DialogResult.Cancel;

        // Agregar los controles al formulario
        this.Controls.Add(colorCountComboBox);
        this.Controls.Add(resolutionComboBox);
        this.Controls.Add(okButton);
        this.Controls.Add(cancelButton);
    }

    private void InitializeComboBoxes()
    {
        colorCountComboBox.SelectedIndexChanged += (sender, e) =>
        {
            string selectedValue = (string)colorCountComboBox.SelectedItem;
            switch (selectedValue)
            {
                case "16 colores":
                    SelectedColorCount = 16;
                    break;
                case "128 colores":
                    SelectedColorCount = 128;
                    break;
                case "256 colores":
                    SelectedColorCount = 256;
                    break;
                case "512 colores":
                    SelectedColorCount = 512;
                    break;
                case "1024 colores":
                    SelectedColorCount = 1024;
                    break;
                default:
                    SelectedColorCount = 256; // Valor predeterminado
                    break;
            }
        };

        resolutionComboBox.SelectedIndexChanged += (sender, e) =>
        {
            SelectedResolution = (string)resolutionComboBox.SelectedItem;
        };
    }
}




    public class RegionSelectionForm : Form
    {
        private Bitmap image;
        private PictureBox pictureBox;
        private Rectangle selectedRegion;

        public Rectangle SelectedRegion
        {
            get { return selectedRegion; }
        }

        public RegionSelectionForm(Bitmap image)
        {
            this.image = image;
            this.selectedRegion = Rectangle.Empty;

            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "Seleccionar región";

            this.ClientSize = image.Size;

            pictureBox = new PictureBox();
            pictureBox.Location = new Point(0, 0);
            pictureBox.Size = image.Size;
            pictureBox.SizeMode = PictureBoxSizeMode.AutoSize;
            pictureBox.Image = image;
            pictureBox.MouseDown += PictureBox_MouseDown;
            pictureBox.MouseMove += PictureBox_MouseMove;
            pictureBox.MouseUp += PictureBox_MouseUp;

            this.Controls.Add(pictureBox);
        }

        private void FitImageToWindow()
        {
            int maxWidth = this.ClientSize.Width;
            int maxHeight = this.ClientSize.Height;
            float aspectRatio = (float)image.Width / image.Height;

            int width = maxWidth;
            int height = (int)(width / aspectRatio);

            if (height > maxHeight)
            {
                height = maxHeight;
                width = (int)(height * aspectRatio);
            }

            pictureBox.Size = new Size(width, height);
            pictureBox.Location = new Point((maxWidth - width) / 2, (maxHeight - height) / 2);
        }

        private void PictureBox_MouseDown(object sender, MouseEventArgs e)
        {
            selectedRegion = new Rectangle(e.Location, Size.Empty);
        }

        private void PictureBox_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Point currentPoint = e.Location;
                selectedRegion.Width = currentPoint.X - selectedRegion.X;
                selectedRegion.Height = currentPoint.Y - selectedRegion.Y;
                pictureBox.Invalidate();
            }
        }

        private void PictureBox_MouseUp(object sender, MouseEventArgs e)
        {
            if (selectedRegion.Width < 0)
            {
                selectedRegion.X += selectedRegion.Width;
                selectedRegion.Width = Math.Abs(selectedRegion.Width);
            }

            if (selectedRegion.Height < 0)
            {
                selectedRegion.Y += selectedRegion.Height;
                selectedRegion.Height = Math.Abs(selectedRegion.Height);
            }

            // Ajustar las coordenadas en relación con el control PictureBox
            selectedRegion.X -= pictureBox.Location.X;
            selectedRegion.Y -= pictureBox.Location.Y;

            this.DialogResult = DialogResult.OK;
            this.Close();
        }


        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            using (Pen pen = new Pen(Color.Red, 2))
            {
                e.Graphics.DrawRectangle(pen, selectedRegion);
            }
        }
    }
}