using Microsoft.AspNetCore.Http;
using Models.Model.PortfolioModel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Model.PortfolioViewModel
{
    public class PersonalInfoViewModel
    {
        public Guid PeronalInfoId { get; set; }
        public IFormFile? Backgroundimg { get; set; }
        public IFormFile? Profileimg { get; set; }
        public string? Name { get; set; }
        public string? Email { get; set; }
        public string? Mobileno { get; set; }
        public string? Country { get; set; }
        public string? City { get; set; }
        public int Age { get; set; }
        public string? Degree { get; set; }
        public string? Website { get; set; }
        public string? Detail { get; set; }
        public string? Experience { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
    }

    public static class PersonalInfoExtensions
    {
        public static List<PersonalInfoViewModel> PersonalInfoMapperList(this List<PersonalInfo> data)
        {
            List<PersonalInfoViewModel> list = new List<PersonalInfoViewModel>();
            foreach (var item in data)
            {
                PersonalInfoViewModel res = new PersonalInfoViewModel();
                res.PeronalInfoId = item.PeronalInfoId;
                res.Name = item.Name;
                res.Email = item.Email;
                res.Age = item.Age;
                res.Country = item.Country;
                res.City = item.City;
                res.Degree = item.Degree;
                res.Website = item.Website;
                res.Detail = item.Detail;
                res.Experience = item.Experience;
                res.CreatedDate = item.CreatedDate;
                res.UpdatedDate = item.UpdatedDate;
                list.Add(res);
            }
            return list;
        }

        public static PersonalInfoViewModel PersonalInfoMapper(this PersonalInfo data)
        {
            PersonalInfoViewModel res = new PersonalInfoViewModel();
            res.PeronalInfoId = data.PeronalInfoId;
            res.Name = data.Name;
            res.Email = data.Email;
            res.Age = data.Age;
            res.Country = data.Country;
            res.City = data.City;
            res.Degree = data.Degree;
            res.Website = data.Website;
            res.Detail = data.Detail;
            res.Experience = data.Experience;
            res.CreatedDate = data.CreatedDate;
            res.UpdatedDate = data.UpdatedDate;
            return res;
        }

        public static PersonalInfo PersonalInfoMapper(this PersonalInfoViewModel data)
        {
            PersonalInfo res = new PersonalInfo();
            res.PeronalInfoId = data.PeronalInfoId;
            res.Name = data.Name;
            res.Email = data.Email;
            res.Age = data.Age;
            res.Country = data.Country;
            res.City = data.City;
            res.Degree = data.Degree;
            res.Website = data.Website;
            res.Detail = data.Detail;
            res.Experience = data.Experience;
            res.CreatedDate = data.CreatedDate;
            res.UpdatedDate = data.UpdatedDate;
            return res;
        }
    }
}
