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
    public class ProjectsViewModel
    {
        public Guid ProjectId { get; set; }
        public string? Name { get; set; }
        public IFormFile? Img { get; set; }
        public string? Url { get; set; }
        public string? Type { get; set; }
        public Guid PeronalinfoId { get; set; }
    }

    public static class ProjectsExtensions
    {
        public static List<ProjectsViewModel> ProjectMapperList(this List<Projects> data)
        {
            List<ProjectsViewModel> list = new List<ProjectsViewModel>();
            foreach (var item in data)
            {
                ProjectsViewModel res = new ProjectsViewModel();
                res.ProjectId = item.ProjectId;
                res.Name = item.Name;
                res.Url = item.Url;
                res.Type = item.Type;
                res.PeronalinfoId = item.PeronalinfoId;
                list.Add(res);
            }
            return list;
        }

        public static ProjectsViewModel ProjectMapper(this Projects data)
        {
            ProjectsViewModel res = new ProjectsViewModel();
            res.ProjectId = data.ProjectId;
            res.Name = data.Name;
            res.Url = data.Url;
            res.Type = data.Type;
            res.PeronalinfoId = data.PeronalinfoId;
            return res;
        }

        public static Projects ProjectMapper(this ProjectsViewModel data)
        {
            Projects res = new Projects();
            res.ProjectId = data.ProjectId;
            res.Name = data.Name; 
            res.Url = data.Url;
            res.Type = data.Type;
            res.PeronalinfoId = data.PeronalinfoId;
            return res;
        }
    }
}
