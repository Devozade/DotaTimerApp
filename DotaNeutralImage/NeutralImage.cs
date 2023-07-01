using System.Collections;
using System.Drawing;
using System.IO;
using System.Reflection;
using System.Resources;

namespace DotaTimerImages
{
    public class NeutralImage
    {
        private int _currentNeutralTier;
        
        public NeutralImage()
        {
            Reset();
        }
        public void Reset()
        {
            _currentNeutralTier = 0;
        }
        public void SetNeutralTier(int num)
        {
            _currentNeutralTier = num;
        }
        public Image GetNeutralImage()
        {
            string neutralImage;
            if (_currentNeutralTier == 0)
            {
                neutralImage = $"neutralToken1";
            }
            else
            {
                neutralImage = $"neutralToken{_currentNeutralTier}";
            }

            byte[] neutralImageBytes = (byte[])Resource1.ResourceManager.GetObject(neutralImage);

            Image neutralImageObject;
            using (MemoryStream ms = new MemoryStream(neutralImageBytes))
            {
                neutralImageObject = Image.FromStream(ms);
            }

            return neutralImageObject;
        }
    }
}
