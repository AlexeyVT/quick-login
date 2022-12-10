using System.Drawing;
using System.Text.Json;
using QRCoder;

namespace QuickLogin.Helpers;

public static class QrImage
{
    public static string Create(object data, Bitmap? image = null)
    {
        var qrGenerator = new QRCodeGenerator();
        var dataString  = JsonSerializer.Serialize(data, new JsonSerializerOptions(JsonSerializerDefaults.Web));
        var qrCodeData  = qrGenerator.CreateQrCode(dataString, QRCodeGenerator.ECCLevel.Q);
        var qrCode      = new Base64QRCode(qrCodeData);
        var qrCodeImage = image == null
                              ? qrCode.GetGraphic(20)
                              : qrCode.GetGraphic(20, Color.Black, Color.White, image);
        return "data:image/png;base64, " + qrCodeImage;
    }
}