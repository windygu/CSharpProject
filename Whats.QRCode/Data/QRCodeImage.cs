using System;

namespace Whats.QRCode.Codec.Data
{
	public interface IQRCodeImage
	{
        int Width
        {
            get;

        }
        int Height
        {
            get;

        }
        int getPixel(int x, int y);
	}
}