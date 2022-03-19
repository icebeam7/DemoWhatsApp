var phoneNumberTo = new PhoneNumber("whatsapp:+420776423625");
var phoneNumberFrom = new PhoneNumber("whatsapp:+14155238886");

TwilioClient.Init(Constants.AccountSid, Constants.AuthToken);

var text = "Hola Latino.NET";
var whatsAppTextMessage = await MessageResource.CreateAsync(
    from: phoneNumberFrom, 
    to: phoneNumberTo,
    body: text);
Console.WriteLine(whatsAppTextMessage.Sid);

// A WhatsApp media message can only contain one media attachment.
// Any additional attachments will be ignored.
var media = new string[]
{
    "https://picsum.photos/400",
    "http://commondatastorage.googleapis.com/gtv-videos-bucket/sample/ForBiggerBlazes.mp4",
    "https://download.samplelib.com/mp3/sample-12s.mp3",
    "http://www.africau.edu/images/default/sample.pdf",
    "http://www.w3.org/2002/12/cal/vcard-examples/john-doe.vcf"
};

foreach (var item in media)
{
    var url = new List<Uri>() { new Uri(item) };
    var whatsAppMediaMessage = await MessageResource.CreateAsync(
        from: phoneNumberFrom,
        to: phoneNumberTo,
        mediaUrl: url);
    Console.WriteLine(whatsAppMediaMessage.Sid);
}