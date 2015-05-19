using System;
using System.Collections.Generic;
using VotR.API.DataContracts;

namespace VotR.Services.Interfaces
{
    public interface IExternalService
    {
        List<SystemBolagetArticle> GetArticlesFromSystemBolaget(string url);

    }
}
