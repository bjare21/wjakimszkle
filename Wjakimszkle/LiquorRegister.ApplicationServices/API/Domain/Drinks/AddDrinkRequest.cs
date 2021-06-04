using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wjakimszkle.DataAccess.Entities;

namespace Wjakimszkle.ApplicationServices.API.Domain.Drinks
{
    public class AddDrinkRequest:RequestBase<AddDrinkResponse>
    {
        public int Id { get; set; }
        public int DrinkTypeId { get; set; }
        public string Name { get; set; }
        public float AlcoholByVolume { get; set; }
    }
}
