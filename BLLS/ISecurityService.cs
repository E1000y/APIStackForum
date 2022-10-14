namespace BLLS
{
   public interface ISecurityService
    {
        string Signing(string username, string password);
    }
}