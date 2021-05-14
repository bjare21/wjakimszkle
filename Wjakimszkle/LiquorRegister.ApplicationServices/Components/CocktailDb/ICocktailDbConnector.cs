﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wjakimszkle.ApplicationServices.Components.CocktailDb
{
    public interface ICocktailDbConnector
    {
        Task<List<Cocktail>> Fetch(int glassId);
    }
}
