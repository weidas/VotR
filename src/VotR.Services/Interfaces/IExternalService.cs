using System.Collections.Generic;
using VotR.Services.DataContracts;

namespace VotR.Services.Interfaces
{
    public interface IExternalService
    {
        List<SystemBolagetArticle> GetArticlesFromSystemBolaget(string url);
    }
}
