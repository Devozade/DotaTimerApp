using System.Drawing;
using System.Resources;

namespace DotaTimerImages
{
    public class StaticImages
    {
        public static Image GetLotusImage()
        {
            var source= Resource1.healingLotus;

            MemoryStream ms = new MemoryStream(source);

            Image image = Image.FromStream(ms);

            return image;

        }
        public static Image GetWisdomImage()
        {
            var source = Resource1.wisdomRune;

            MemoryStream ms = new MemoryStream(source);

            Image image = Image.FromStream(ms);

            return image;

        }
    }
}
