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
        private Image<Bgr, Byte> CurrentImage = null;
        private List<FaceInfo> FacesList = new List<FaceInfo>();
        private VectorOfMat ImageList = new VectorOfMat();
        private List<string> NamesList = new List<string>();
        private VectorOfInt LabelsVactor = new VectorOfInt();
        private EigenFaceRecognizer FaceRecognizer = null;

        public string FacePhotosPath = "Data\\Faces\\";
        public string FaceListTextFile = "Data\\FacesList.txt";
        public string HaarCascadePath = "haarcascade_frontalface_default.xml";
        public string ImageFileExtension = ".bmp";

        private void Form1_Load(object sender, EventArgs e)
        {
            if (!File.Exists(HaarCascadePath))
            {
                MessageBox.Show("Haarcascade fayli topilmadi", "Xato", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private void openCameraToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Initialize();
            GetFacesList();
        }

        private void Initialize()
        {
            if (VideoCapture != null)
                VideoCapture.Dispose();

            VideoCapture = new VideoCapture();
            VideoCapture.SetCaptureProperty(CapProp.Fps, 30);
            Application.Idle += ProcessVideoFrame;
        }

        private void ProcessVideoFrame(object sender, EventArgs e)
        {
            CurrentImage = VideoCapture.QueryFrame().ToImage<Bgr, Byte>();

            if (CurrentImage != null)
            {
                try
                {
                    Image<Gray, byte> grayImage = CurrentImage.Convert<Gray, byte>();
                    Rectangle[] faces = HaarCascade.DetectMultiScale(grayImage, 1.2, 10, new System.Drawing.Size(50, 50), new System.Drawing.Size(200, 200));
                    
                    int currentFaceIndex = 0;
                    foreach (var face in faces)
                    {
                        CurrentImage.Draw(face, new Bgr(Color.LightGreen), 2);
                        Image<Gray, Byte> DetectedFace = CurrentImage.Copy(face).Convert<Gray, byte>();
                        FaceRecognition(DetectedFace, face, currentFaceIndex);
                        currentFaceIndex++;
                    }
                    Bitmap cameraCapture = CurrentImage.ToBitmap();
                    pictureBox1.Image = cameraCapture;
                    if (CurrentImage != null)
                        CurrentImage.Dispose();
                }
                catch (Exception)
                {

                }
            }
        }

        private void FaceRecognition(Image<Gray, Byte> detectedFaceImage, Rectangle face, int currentFaceIndex)
        {
            string recongnizedFaceName = string.Empty;
            if (ImageList.Size != 0)
            {
                FaceRecognizer.PredictionResult result = FaceRecognizer.Predict(detectedFaceImage.Resize(148, 148, Inter.Cubic));
                recongnizedFaceName = NamesList[result.Label];
            }
            else
            {
                recongnizedFaceName = "Noma'lum shaxs";
            }
            CurrentImage.Draw(recongnizedFaceName, new Point(face.X - 2, face.Y - 2), FontFace.HersheyDuplex, 0.5, new Bgr(Color.LightGreen));
            Bitmap CameraCaptureFace = detectedFaceImage.ToBitmap();

            switch (currentFaceIndex)
            {
                case 0:
                    pbDetectedFace0.Image = CameraCaptureFace;
                    txtRecognizedFace0.Text = recongnizedFaceName;
                    break;

                case 1:
                    pbDetectedFace1.Image = CameraCaptureFace;
                    txtRecognizedFace1.Text = recongnizedFaceName;
                    break;

                default:
                    break;
            }
        }

        private void SaveDetectedFace(Image img)
        {
            if (img == null)
            {
                MessageBox.Show("Tasvirda bironta ham yuz aniqlay olmadim.");
                return;
            }

            // DetectedFace = DetectedFace.Resize(100, 100, Inter.Cubic);
            // DetectedFace.Save(FacePhotosPath + "yuz" + (FacesList.Count + 1) + ImageFileExtension);
            // img.Save(FacePhotosPath + "yuz" + (FacesList.Count + 1) + ImageFileExtension);

            Size size = new Size(148, 148);
            Bitmap bmp = new Bitmap(img, size);
            bmp.Save(FacePhotosPath + "yuz" + (FacesList.Count + 1) + ImageFileExtension);

            StreamWriter writer = new StreamWriter(FaceListTextFile, true);
            string faceOwnerName = Microsoft.VisualBasic.Interaction.InputBox("Tasvirdagi yuzning egasini ismini kiriting:");
            writer.WriteLine(String.Format("yuz{0}:{1}", (FacesList.Count + 1), faceOwnerName));
            writer.Close();
        }

        public void GetFacesList()
        {
            try
            {
                HaarCascade = new CascadeClassifier(HaarCascadePath);
                FacesList.Clear();
                string line = string.Empty;
                FaceInfo faceInfo = null;

                StreamReader reader = new StreamReader(FaceListTextFile);
                int index = 0;
                while ((line = reader.ReadLine()) != null)
                {
                    string[] lineParts = line.Split(':');
                    faceInfo = new FaceInfo();
                    faceInfo.GrayImage = new Image<Gray, byte>(FacePhotosPath + lineParts[0] + ImageFileExtension);
                    faceInfo.Name = lineParts[1];
                    FacesList.Add(faceInfo);
                }
                foreach (var face in FacesList)
                {
                    ImageList.Push(face.GrayImage.Mat);
                    NamesList.Add(face.Name);
                    LabelsVactor.Push(new[] { index++ });
                }
                reader.Close();

                if (ImageList.Size > 0)
                {
                    FaceRecognizer = new EigenFaceRecognizer(ImageList.Size);
                    FaceRecognizer.Train(ImageList, LabelsVactor);
                }
            }
            catch (Exception ex)
            {

            }
        }


        private void btnSave1_Click(object sender, EventArgs e)
        {
            SaveDetectedFace(pbDetectedFace0.Image);
            GetFacesList();
        }

        private void btnSave2_Click(object sender, EventArgs e)
        {
            SaveDetectedFace(pbDetectedFace1.Image);
            GetFacesList();
        }

    }
}
