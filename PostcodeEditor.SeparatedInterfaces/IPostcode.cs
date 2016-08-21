namespace PostcodeEditor.SeparatedInterfaces
{
    public interface IPostcode
    {
        int Id { get; set; }
        string Postcode { get; set; }
        decimal Latitude { get; set; }
        decimal Longitude { get; set; }
        string County { get; set; }
        string District { get; set; }
        string Ward { get; set; }
        string Region { get; set; }
    }
}