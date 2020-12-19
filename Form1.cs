using Emgu.CV;
using Emgu.CV.CvEnum;
using Emgu.CV.Face;
using Emgu.CV.Structure;
using Emgu.CV.Util;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Media.Imaging;

namespace FaceRecognitionDemo
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private VideoCapture VideoCapture;
        private CascadeClassifier HaarCascade = null;
        private Image<Bgr, Byte> BgrFrame = null;
        private Image<Gray, Byte> DetectedFace = null;
        private List<FaceInfo> FacesList = new List<FaceInfo>();
        private VectorOfMat ImageList = new VectorOfMat();
        private List<string> NamesList = new List<string>();
        private VectorOfInt LabelsVactor = new VectorOfInt();
        private EigenFaceRecognizer FaceRecognizer = null;
        private Bitmap CameraCaptureFace = null;
        private Bitmap CameraCapture = null;

        public string FacePhotosPath = "Data\\Faces\\";
        public string FaceListTextFile = "Data\\FacesList.txt";
        public string HaarCascadePath = "haarcascade_frontalface_default.xml";
        public int TimerResponseValue = 500;
        public string ImageFileExtension = ".bmp";

        private void kameraniOchToolStripMenuItem_Click(object sender, EventArgs e)
        {
            InitializeCamera();
        }

        private void InitializeCamera()
        {
            if (VideoCapture != null)
                VideoCapture.Dispose();

            VideoCapture = new VideoCapture(0);
            VideoCapture.SetCaptureProperty(CapProp.Fps, 30);
            /*            VideoCapture.SetCaptureProperty(CapProp.FrameHeight, 450);
                        VideoCapture.SetCaptureProperty(CapProp.FrameWidth, 370);*/
            Application.Idle += ProcessVideo;
        }

        private void ProcessVideo(object sender, EventArgs e)
        {
            BgrFrame = VideoCapture.QueryFrame().ToImage<Bgr, Byte>();

            if (BgrFrame != null)
            {
                try
                {
                    Image<Gray, byte> grayframe = BgrFrame.Convert<Gray, byte>();
                    Rectangle[] faces = HaarCascade.DetectMultiScale(grayframe, 1.2, 10, new System.Drawing.Size(50, 50), new System.Drawing.Size(200, 200));

                    int currentFaceIndex = 0;
                    foreach (var face in faces)
                    {
                        BgrFrame.Draw(face, new Bgr(Color.LightGreen), 2);
                        DetectedFace = BgrFrame.Copy(face).Convert<Gray, byte>();
                        FaceRecognition(face, currentFaceIndex);
                        currentFaceIndex++;
                        //break;
                    }
                    CameraCapture = BgrFrame.ToBitmap();
                    pictureBox1.Image = CameraCapture;
                    if (BgrFrame != null)
                        BgrFrame.Dispose();
                }
                catch (Exception)
                {

                }
            }

        }

        private void FaceRecognition(Rectangle face, int currentFaceIndex)
        {
            string detectedFaceName = string.Empty;
            if (ImageList.Size != 0)
            {
                FaceRecognizer.PredictionResult result = FaceRecognizer.Predict(DetectedFace.Resize(100, 100, Inter.Cubic));
                detectedFaceName = NamesList[result.Label];
            }
            else
            {
                detectedFaceName = "Noma'lum shaxs";
            }
            BgrFrame.Draw(detectedFaceName, new Point(face.X - 2, face.Y - 2), FontFace.HersheyDuplex, 0.5, new Bgr(Color.LightGreen));
            CameraCaptureFace = DetectedFace.ToBitmap();

            switch (currentFaceIndex)
            {
                case 0:
                    pbDetectedFace0.Image = CameraCaptureFace;
                    txtRecognizedFace0.Text = detectedFaceName;
                    break;

                case 1:
                    pbDetectedFace1.Image = CameraCaptureFace;
                    txtRecognizedFace1.Text = detectedFaceName;
                    break;

                case 2:
                    pbDetectedFace2.Image = CameraCaptureFace;
                    txtRecognizedFace2.Text = detectedFaceName;
                    break;

                default:
                    break;
            }
        }


        /*        private BitmapImage BitmapToImageSource(Bitmap bitmap)
                {
                    using (MemoryStream memory = new MemoryStream())
                    {
                        bitmap.Save(memory, System.Drawing.Imaging.ImageFormat.Bmp);
                        memory.Position = 0;
                        BitmapImage bitmapimage = new BitmapImage();
                        //bitmapimage.BeginInit();
                        bitmapimage.StreamSource = memory;
                        //bitmapimage.CacheOption = BitmapCacheOption.OnLoad;
                        //bitmapimage.EndInit();

                        return bitmapimage;
                    }
                }
        */
        private void yuzniSaqlaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveDetectedFaces();
            GetFacesList();
        }

        private void SaveDetectedFaces()
        {
            if (DetectedFace == null)
            {
                MessageBox.Show("Tasvirda bironta ham yuz aniqlay olmadim.");
                return;
            }

            DetectedFace = DetectedFace.Resize(100, 100, Inter.Cubic);
            DetectedFace.Save(FacePhotosPath + "yuz" + (FacesList.Count + 1) + ImageFileExtension);
            StreamWriter writer = new StreamWriter(FaceListTextFile, true);
            string faceOwnerName = Microsoft.VisualBasic.Interaction.InputBox("Tasvirdagi yuzning egasini ismini kiriting:");
            writer.WriteLine(String.Format("yuz{0}:{1}", (FacesList.Count + 1), faceOwnerName));
            writer.Close();
        }

        public void GetFacesList()
        {
            HaarCascade = new CascadeClassifier(HaarCascadePath);
            FacesList.Clear();
            string line;
            FaceInfo SingleFaceInfo = null;

            StreamReader reader = new StreamReader(FaceListTextFile);
            int i = 0;
            while ((line = reader.ReadLine()) != null)
            {
                string[] lineParts = line.Split(':');
                SingleFaceInfo = new FaceInfo();
                SingleFaceInfo.Image = new Image<Gray, byte>(FacePhotosPath + lineParts[0] + ImageFileExtension);
                SingleFaceInfo.Name = lineParts[1];
                FacesList.Add(SingleFaceInfo);
            }
            foreach (var face in FacesList)
            {
                ImageList.Push(face.Image.Mat);
                NamesList.Add(face.Name);
                LabelsVactor.Push(new[] { i++ });
            }
            reader.Close();

            // Train recogniser
            if (ImageList.Size > 0)
            {
                FaceRecognizer = new EigenFaceRecognizer(ImageList.Size);
                FaceRecognizer.Train(ImageList, LabelsVactor);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            if (!File.Exists(HaarCascadePath))
            {
                MessageBox.Show("Haar cascade fayl topilmadi", "Xato", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            if (!Directory.Exists(FacePhotosPath))
            {
                Directory.CreateDirectory(FacePhotosPath);
            }

            if (!File.Exists(FaceListTextFile))
            {
                File.Create(FaceListTextFile).Close();
            }

            HaarCascade = new CascadeClassifier(HaarCascadePath);
        }

        private void yuzlarniAniqlaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (ImageList.Size <= 0)
            {
                SaveDetectedFaces();
                GetFacesList();
            }
            else
            {
                GetFacesList();
            }
        }
    }
}
