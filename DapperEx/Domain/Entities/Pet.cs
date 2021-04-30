using Dapper.Contrib.Extensions;
using DapperEx.Domain.Fixed;
using System;

namespace DapperEx.Domain.Entities
{
    [Table("[dbo].[Pet]")]
    public class Pet
    {
        [ExplicitKey]
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public TypePet Type { get; set; }


    }
}
