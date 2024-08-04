namespace ShopApp.Infrustructure.Authentication;

public class SuperUserSecret 
{
    public static string SectionName = "SuperUser";

    public string? Secret { get; set; }
}
