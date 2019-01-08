using Microsoft.AspNetCore.Http;
using MyCms.Bussiness.Services.Interfaces;
using MyCms.Common.Dtos;
using MyCms.Domain.Context;
using MyCms.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyCms.Bussiness.Services
{
  
    public class LayoutCrud : ILayoutCrud
    {

        private MyCmsDbContext _dbContext;
        public LayoutCrud(IHttpContextAccessor httpAccessor)
        {
            _dbContext = (MyCmsDbContext)httpAccessor.HttpContext.RequestServices.GetService(typeof(MyCmsDbContext));
        }


        public void AddLayout(LayoutDto layout)
        {
            if (layout.Name != null)
            {
                Layout newLayout = new Layout();
                newLayout.Name = layout.Name;
                newLayout.IsDeleted = false;
                newLayout.CreateTime = DateTime.Now;
                _dbContext.Layouts.Add(newLayout);
                _dbContext.SaveChanges();
            }
        }

        public void DeleteLayout(LayoutDto layout)
        {
            var model = _dbContext.Layouts.Find(layout.Id);
            _dbContext.Layouts.Remove(model);
            _dbContext.SaveChanges();

        }

        public LayoutDto GetLayoutById(string name)
        {
            throw new NotImplementedException();
        }

        public List<LayoutDto> GetLayouts()
        {
            IEnumerable<Layout> user = _dbContext.Layouts.ToList();
            var model = user.Select(x => new LayoutDto
            {
                Id = x.Id,
              CreateTime = x.CreateTime,
              IsDeleted = x.IsDeleted,
              Name = x.Name

            }).ToList();
            return model;
        }

        public void UpdateLayout(LayoutDto layout)
        {
            throw new NotImplementedException();
        }
    }
}
