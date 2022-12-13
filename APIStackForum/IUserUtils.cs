using Microsoft.AspNetCore.Mvc;

namespace APIStackForum
{
    public interface IUserUtils
    {
        int GetCurrentUserTokenId(ControllerBase cb);

        bool IsMOD(ControllerBase cb);
    }


}