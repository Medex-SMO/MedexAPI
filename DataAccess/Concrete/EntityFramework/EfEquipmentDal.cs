using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Linq;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfEquipmentDal : EfEntityRepositoryBase<Equipment, MedexDbContext>, IEquipmentDal
    {
        public List<EquipmentDetailDto> GetEquipmentsDetails(Expression<Func<EquipmentDetailDto, bool>> filter = null)
        {
            using (var context = new MedexDbContext())
            {
                var result = from equipment in context.Equipments
                             join user in context.Users
                                 on equipment.UserId equals user.Id
                             select new EquipmentDetailDto
                             {
                                 Id = equipment.Id,
                                 Email = user.Email,
                                 Name = equipment.Name,
                                 SerialNo = equipment.SerialNo,
                                 Amount = equipment.Amount
                             };
                return filter == null ? result.ToList() : result.Where(filter).ToList();
            }
        }
    }
}
