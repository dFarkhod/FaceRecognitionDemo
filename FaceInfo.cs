using Emgu.CV;
using Emgu.CV.Structure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FaceRecognitionDemo
{
    public class FaceInfo
    {
        public string Name { get; set; }
        public Image<Gray, byte> GrayImage { get; set; }
        public DateTime SavedDate { get; set; }

    }
}
