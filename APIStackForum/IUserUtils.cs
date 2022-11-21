namespace APIStackForum
{
    public interface IUserUtils
    {
        int GetCurrentUserTokenId();

        bool IsMOD();
    }


}