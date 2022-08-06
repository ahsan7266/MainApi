using Data.AppContext;
using Microsoft.EntityFrameworkCore;
using Models.Model.PortfolioModel;
using Models.Model.PortfolioViewModel;
using Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Services.Portfolio
{
    public class PortfolioServices : IPortfolioServices
    {
        private readonly PortfolioDbContext context;
        public PortfolioServices(PortfolioDbContext context)
        {
            this.context = context;
        }

        //GetAll
        public async Task<Response<object>> GetAllByIdAsync(Guid Id)
        {
            try
            {
                var data = await (from personalinfo in context.PersonalInfo
                                  join skill in context.Skills on personalinfo.PeronalInfoId equals skill.PeronalinfoId
                                  join service in context.Skills on personalinfo.PeronalInfoId equals service.PeronalinfoId
                                  join project in context.Projects on personalinfo.PeronalInfoId equals project.PeronalinfoId
                                  join projecttype in context.ProjectTypes on personalinfo.PeronalInfoId equals projecttype.PeronalinfoId
                                  where personalinfo.PeronalInfoId == Id
                                  select new
                                  {
                                      Id = personalinfo.PeronalInfoId,
                                      Name = personalinfo.Name,
                                      Backgroundimg = personalinfo.Backgroundimg,
                                      Profileimg = personalinfo.Profileimg,
                                      Email = personalinfo.Email,
                                      Mobileno = personalinfo.Mobileno,
                                      Country = personalinfo.Country,
                                      City = personalinfo.City,
                                      Age = personalinfo.Age,
                                      Degree = personalinfo.Degree,
                                      Website = personalinfo.Website,
                                      Detail = personalinfo.Detail,
                                      Experience = personalinfo.Experience,
                                      CreatedDate = personalinfo.CreatedDate,
                                      UpdatedDate = personalinfo.UpdatedDate,
                                      SkillName = skill.Name,
                                      SkillPercentage = skill.Percentage,
                                      ServiceName = service.Name,
                                      ProjectName = project.Name,
                                      ProjectImage = project.Img,
                                      ProjectUrl = project.Url,
                                      ProjectType = project.Type,
                                      ProjectTypeName = projecttype.Name,
                                  }).ToListAsync();
                if (data is null)
                    return new Response<object>
                    {
                        Message = "Record Not Found",
                        Status = false
                    };
                return new Response<object>
                {
                    Message = "Record Found Successfully",
                    Status = true,
                    Data = data
                };
            }
            catch
            {
                throw;
            }
        }
        public async Task<Response<object>> GetAllByNameAsync(string Name)
        {
            try
            {
                var data = await (from personalinfo in context.PersonalInfo
                                  join skill in context.Skills on personalinfo.PeronalInfoId equals skill.PeronalinfoId
                                  join service in context.Skills on personalinfo.PeronalInfoId equals service.PeronalinfoId
                                  join project in context.Projects on personalinfo.PeronalInfoId equals project.PeronalinfoId
                                  join projecttype in context.ProjectTypes on personalinfo.PeronalInfoId equals projecttype.PeronalinfoId
                                  where personalinfo.Name == Name
                                  select new
                                  {
                                      Id = personalinfo.PeronalInfoId,
                                      Name = personalinfo.Name,
                                      Backgroundimg = personalinfo.Backgroundimg,
                                      Profileimg = personalinfo.Profileimg,
                                      Email = personalinfo.Email,
                                      Mobileno = personalinfo.Mobileno,
                                      Country = personalinfo.Country,
                                      City = personalinfo.City,
                                      Age = personalinfo.Age,
                                      Degree = personalinfo.Degree,
                                      Website = personalinfo.Website,
                                      Detail = personalinfo.Detail,
                                      Experience = personalinfo.Experience,
                                      CreatedDate = personalinfo.CreatedDate,
                                      UpdatedDate = personalinfo.UpdatedDate,
                                      SkillName = skill.Name,
                                      SkillPercentage = skill.Percentage,
                                      ServiceName = service.Name,
                                      ProjectName = project.Name,
                                      ProjectImage = project.Img,
                                      ProjectUrl = project.Url,
                                      ProjectType = project.Type,
                                      ProjectTypeName = projecttype.Name,
                                  }).ToListAsync();
                if (data is null)
                    return new Response<object>
                    {
                        Message = "Record Not Found",
                        Status = false
                    };
                return new Response<object>
                {
                    Message = "Record Found Successfully",
                    Status = true,
                    Data = data
                };
            }
            catch
            {
                throw;
            }
        }

        //Get
        public async Task<Response<PersonalInfoViewModel>> GetPersonalInfoAsync()
        {
            try
            {
                var data = await context.PersonalInfo.ToListAsync();
                if (data is null)
                    return new Response<PersonalInfoViewModel>
                    {
                        Message = "Record Not Found",
                        Status = false
                    };
                return new Response<PersonalInfoViewModel>
                {
                    Message = "Record Found Successfully",
                    Status = true,
                    List = data.PersonalInfoMapperList()
                };
            }
            catch
            {
                throw;
            }
        }
        public async Task<Response<SkillViewModel>> GetSkillAsync()
        {
            try
            {
                var data = await context.Skills.ToListAsync();
                if (data is null)
                    return new Response<SkillViewModel>
                    {
                        Message = "Record Not Found",
                        Status = false
                    };
                return new Response<SkillViewModel>
                {
                    Message = "Record Found Successfully",
                    Status = true,
                    List = data.SkillMapperList()
                };
            }
            catch
            {
                throw;
            }
        }
        public async Task<Response<ServiceViewModel>> GetServiceAsync()
        {
            try
            {
                var data = await context.Services.ToListAsync();
                if (data is null)
                    return new Response<ServiceViewModel>
                    {
                        Message = "Record Not Found",
                        Status = false
                    };
                return new Response<ServiceViewModel>
                {
                    Message = "Record Found Successfully",
                    Status = true,
                    List = data.ServiceMapperList()
                };
            }
            catch
            {
                throw;
            }
        }
        public async Task<Response<ProjectsViewModel>> GetProjectAsync()
        {
            try
            {
                var data = await context.Projects.ToListAsync();
                if (data is null)
                    return new Response<ProjectsViewModel>
                    {
                        Message = "Record Not Found",
                        Status = false
                    };
                return new Response<ProjectsViewModel>
                {
                    Message = "Record Found Successfully",
                    Status = true,
                    List = data.ProjectMapperList()
                };
            }
            catch
            {
                throw;
            }
        }
        public async Task<Response<ProjectTypeViewModel>> GetProjectTypeAsync()
        {
            try
            {
                var data = await context.ProjectTypes.ToListAsync();
                if (data is null)
                    return new Response<ProjectTypeViewModel>
                    {
                        Message = "Record Not Found",
                        Status = false
                    };
                return new Response<ProjectTypeViewModel>
                {
                    Message = "Record Found Successfully",
                    Status = true,
                    List = data.ProjectTypeMapperList()
                };
            }
            catch
            {
                throw;
            }
        }

        // Add or Update
        public async Task<Response<PersonalInfoViewModel>> AddorUpdatePersonalInfoAsync(PersonalInfoViewModel model)
        {
            //checking model 
            if (model is null)
                return new Response<PersonalInfoViewModel>
                {
                    Message = "Model is Empty",
                    Status = false
                };
            //checking profileimage and backgroundimage
            if (model.Backgroundimg is null && model.Profileimg is null)
                return new Response<PersonalInfoViewModel>
                {
                    Message = "Background & Profile Image is Not Found",
                    Status = false
                };
            //checking file type or file extension
            var backgroundfiletype = model.Backgroundimg.FileName.Substring(model.Backgroundimg.FileName.LastIndexOf('.'));
            var profilefiletype = model.Profileimg.FileName.Substring(model.Profileimg.FileName.LastIndexOf('.'));

            if (backgroundfiletype != ".jpg" && backgroundfiletype != "jpeg" && backgroundfiletype != "png" && profilefiletype != ".jpg" && profilefiletype != "jpeg" && profilefiletype != "png")
                return new Response<PersonalInfoViewModel>
                {
                    Message = "File Extension Is Not Valid Support Only JPG,JPEG PNG",
                    Status = false
                };
            //create and checking directory
            var basedirectory = Directory.GetCurrentDirectory();
            var folderpath = "wwwroot/Images/Portfolio";
            var directorypath = Path.Combine(basedirectory, folderpath);
            if (!Directory.Exists(directorypath))
            {
                Directory.CreateDirectory(directorypath);
            }

            var backgroundfilename = Guid.NewGuid().ToString() + "_" + model.Backgroundimg.FileName;
            var profilefileName = Guid.NewGuid().ToString() + "_" + model.Profileimg.FileName;

            string backgroundfilePath = Path.Combine(directorypath, backgroundfilename);
            string profilefilePath = Path.Combine(directorypath, profilefileName);

            using (var filestream = new FileStream(backgroundfilePath, FileMode.Create))
            {
                model.Backgroundimg.CopyTo(filestream);
            }
            using (var filestream = new FileStream(profilefilePath, FileMode.Create))
            {
                model.Profileimg.CopyTo(filestream);
            }

            //AddorUpdate Personal Info 
            var result = await context.PersonalInfo.FirstOrDefaultAsync(x => x.PeronalInfoId == model.PeronalInfoId);
            if (result is not null)
            {
                var data = await context.PersonalInfo.FindAsync(model.PeronalInfoId);
                data.Backgroundimg = backgroundfilePath;
                data.Profileimg = profilefilePath;
                data.Name = model.Name;
                data.Email = model.Email;
                data.Mobileno = model.Mobileno;
                data.Age = model.Age;
                data.Country = model.Country;
                data.City = model.City;
                data.Degree = model.Degree;
                data.Website = model.Website;
                data.Detail = model.Detail;
                data.Experience = model.Experience;
                data.UpdatedDate = DateTime.Now;
                this.context.Update(data);
                await context.SaveChangesAsync();
                return new Response<PersonalInfoViewModel>
                {
                    Message = "Data Updated Successfully",
                    Status = true
                };
            }
            else
            {
                PersonalInfo PI = new PersonalInfo();
                PI.Backgroundimg = backgroundfilePath;
                PI.Profileimg = profilefilePath;
                PI.Name = model.Name;
                PI.Email = model.Email;
                PI.Mobileno = model.Mobileno;
                PI.Country = model.Country;
                PI.City = model.City;
                PI.Degree = model.Degree;
                PI.Website = model.Website;
                PI.Detail = model.Detail;
                PI.Experience = model.Experience;
                PI.CreatedDate = DateTime.Now;
                PI.UpdatedDate = DateTime.Now;
                await this.context.PersonalInfo.AddAsync(PI);
                await context.SaveChangesAsync();
                return new Response<PersonalInfoViewModel>
                {
                    Message = "Data Added Successfully",
                    Status = true
                };
            }
        }       
        public async Task<Response<SkillViewModel>> AddorUpdateSkillAsync(SkillViewModel model)
        {
            try
            {
                if (model is null)
                    return new Response<SkillViewModel>
                    {
                        Message = "Model is Empty",
                        Status = false
                    };

                var result = await context.Skills.FirstOrDefaultAsync(x => x.SkillId == model.SkillId);
                if (result is not null)
                {
                    var data = await context.Skills.FindAsync(model.SkillId);
                    data.Name = model.Name;
                    data.Percentage = model.Percentage;
                    data.PeronalinfoId = model.PeronalinfoId;
                    this.context.Update(data);
                    await context.SaveChangesAsync();
                    return new Response<SkillViewModel>
                    {
                        Message = "Data Updated Successfully",
                        Status = true
                    };
                }
                else
                {
                    await this.context.Skills.AddAsync(model.SkillMapper());
                    await context.SaveChangesAsync();
                    return new Response<SkillViewModel>
                    {
                        Message = "Data Added Successfully",
                        Status = true
                    };
                }
            }
            catch
            {
                throw;
            }
        }
        public async Task<Response<ServiceViewModel>> AddorUpdateServiceAsync(ServiceViewModel model)
        {
            try
            {
                if (model is null)
                    return new Response<ServiceViewModel>
                    {
                        Message = "Model is Empty",
                        Status = false
                    };
                var result = await context.Services.FirstOrDefaultAsync(x => x.ServiceId == model.ServiceId);
                if (result is not null)
                {
                    var data = await context.Services.FindAsync(model.ServiceId);
                    data.Name = model.Name;
                    data.PeronalinfoId = model.PeronalinfoId;
                    this.context.Update(data);
                    await context.SaveChangesAsync();
                    return new Response<ServiceViewModel>
                    {
                        Message = "Data Updated Successfully",
                        Status = true
                    };
                }
                else
                {
                    await this.context.Services.AddAsync(model.ServiceMapper());
                    await context.SaveChangesAsync();
                    return new Response<ServiceViewModel>
                    {
                        Message = "Data Added Successfully",
                        Status = true
                    };
                }
            }
            catch
            {
                throw;
            }
        }
        public async Task<Response<ProjectsViewModel>> AddorUpdateProjectAsync(ProjectsViewModel model)
        {
            try
            {
                if (model is null)
                    return new Response<ProjectsViewModel>
                    {
                        Message = "Model is Empty",
                        Status = false
                    };
                //checking profileimage and backgroundimage
                if (model.Img is null)
                    return new Response<ProjectsViewModel>
                    {
                        Message = "Background & Profile Image is Not Found",
                        Status = false
                    };
                //checking file type or file extension
                var filetype = model.Img.FileName.Substring(model.Img.FileName.LastIndexOf('.'));
                if (filetype != ".jpg" && filetype != "jpeg" && filetype != "png")
                    return new Response<ProjectsViewModel>
                    {
                        Message = "File Extension Is Not Valid Support Only JPG,JPEG PNG",
                        Status = false
                    };
                //create and checking directory
                var basedirectory = Directory.GetCurrentDirectory();
                var folderpath = "wwwroot/Images/Portfolio/ProjectImage";
                var directorypath = Path.Combine(basedirectory, folderpath);
                if (!Directory.Exists(directorypath))
                {
                    Directory.CreateDirectory(directorypath);
                }
                var filename = Guid.NewGuid().ToString() + "_" + model.Img.FileName;
                string imagepath = Path.Combine(directorypath, filename);
                using (var filestream = new FileStream(imagepath, FileMode.Create))
                {
                    model.Img.CopyTo(filestream);
                }

                var result = await context.Projects.FirstOrDefaultAsync(x => x.ProjectId == model.ProjectId);
                if (result is not null)
                {
                    var data = await context.Projects.FindAsync(model.ProjectId);
                    data.Name = model.Name;
                    data.Img = imagepath;
                    data.Url = model.Url;
                    data.Type = model.Type;
                    data.PeronalinfoId = model.PeronalinfoId;
                    this.context.Update(data);
                    await context.SaveChangesAsync();
                    return new Response<ProjectsViewModel>
                    {
                        Message = "Data Updated Successfully",
                        Status = true
                    };
                }
                else
                {
                    Projects project = new Projects();
                    project.Name = model.Name;
                    project.Img = imagepath;
                    project.Url = model.Url;
                    project.Type = model.Type;
                    project.PeronalinfoId = model.PeronalinfoId;
                    await this.context.Projects.AddAsync(project);
                    await context.SaveChangesAsync();
                    return new Response<ProjectsViewModel>
                    {
                        Message = "Data Added Successfully",
                        Status = true
                    };
                }
            }
            catch
            {
                throw;
            }
        }
        public async Task<Response<ProjectTypeViewModel>> AddorUpdateProjectTypeAsync(ProjectTypeViewModel model)
        {
            try
            {
                if (model is null)
                    return new Response<ProjectTypeViewModel>
                    {
                        Message = "Model is Empty",
                        Status = false
                    };
                var result = await context.ProjectTypes.FirstOrDefaultAsync(x => x.ProjecttypeId == model.ProjecttypeId);
                if (result is not null)
                {
                    var data = await context.ProjectTypes.FindAsync(model.ProjecttypeId);
                    data.Name = model.Name;
                    data.PeronalinfoId = model.PeronalinfoId;
                    this.context.Update(data);
                    await context.SaveChangesAsync();
                    return new Response<ProjectTypeViewModel>
                    {
                        Message = "Data Updated Successfully",
                        Status = true
                    };
                }
                else
                {
                    await this.context.ProjectTypes.AddAsync(model.ProjectTypeMapper());
                    await context.SaveChangesAsync();
                    return new Response<ProjectTypeViewModel>
                    {
                        Message = "Data Added Successfully",
                        Status = true
                    };
                }
            }
            catch
            {
                throw;
            }
        }

        //GetById
        public async Task<Response<PersonalInfoViewModel>> GetByPersonalInfoIdAsync(Guid PersonalInfoId)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(PersonalInfoId.ToString()))
                    return new Response<PersonalInfoViewModel>
                    {
                        Message = "Id is Empty",
                        Status = false
                    };
                var data = await context.PersonalInfo.FindAsync(PersonalInfoId);
                if (data is null)
                    return new Response<PersonalInfoViewModel>
                    {
                        Message = "Record Not Found",
                        Status = false
                    };
                return new Response<PersonalInfoViewModel>
                {
                    Message = "Record Found Successfully",
                    Status = true,
                    Data = data.PersonalInfoMapper()
                };
            }
            catch
            {
                throw;
            }
        }
        public async Task<Response<SkillViewModel>> GetBySkillIdAsync(Guid SkillId)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(SkillId.ToString()))
                    return new Response<SkillViewModel>
                    {
                        Message = "Id is Empty",
                        Status = false
                    };
                var data = await context.Skills.FindAsync(SkillId);
                if (data is null)
                    return new Response<SkillViewModel>
                    {
                        Message = "Record Not Found",
                        Status = false
                    };
                return new Response<SkillViewModel>
                {
                    Message = "Record Found Successfully",
                    Status = true,
                    Data = data.SkillMapper()
                };
            }
            catch
            {
                throw;
            }
        }
        public async Task<Response<ServiceViewModel>> GetByServiceIdAsync(Guid ServiceId)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(ServiceId.ToString()))
                    return new Response<ServiceViewModel>
                    {
                        Message = "Id is Empty",
                        Status = false
                    };
                var data = await context.Services.FindAsync(ServiceId);
                if (data is null)
                    return new Response<ServiceViewModel>
                    {
                        Message = "Record Not Found",
                        Status = false
                    };
                return new Response<ServiceViewModel>
                {
                    Message = "Record Found Successfully",
                    Status = true,
                    Data = data.ServiceMapper()
                };
            }
            catch
            {
                throw;
            }
        }
        public async Task<Response<ProjectsViewModel>> GetByProjectIdAsync(Guid ProjectId)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(ProjectId.ToString()))
                    return new Response<ProjectsViewModel>
                    {
                        Message = "Id is Empty",
                        Status = false
                    };
                var data = await context.Projects.FindAsync(ProjectId);
                if (data is null)
                    return new Response<ProjectsViewModel>
                    {
                        Message = "Record Not Found",
                        Status = false
                    };
                return new Response<ProjectsViewModel>
                {
                    Message = "Record Found Successfully",
                    Status = true,
                    Data = data.ProjectMapper()
                };
            }
            catch
            {
                throw;
            }
        }
        public async Task<Response<ProjectTypeViewModel>> GetByProjectTypeIdAsync(Guid ProjectTypeId)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(ProjectTypeId.ToString()))
                    return new Response<ProjectTypeViewModel>
                    {
                        Message = "Id is Empty",
                        Status = false
                    };
                var data = await context.ProjectTypes.FindAsync(ProjectTypeId);
                if (data is null)
                    return new Response<ProjectTypeViewModel>
                    {
                        Message = "Record Not Found",
                        Status = false
                    };
                return new Response<ProjectTypeViewModel>
                {
                    Message = "Record Found Successfully",
                    Status = true,
                    Data = data.ProjectTypeMapper()
                };
            }
            catch
            {
                throw;
            }
        }

        //Delete
        public async Task<Response<PersonalInfoViewModel>> DeletePersonalInfoIdAsync(Guid PersonalInfoId)
        {
            if (string.IsNullOrWhiteSpace(PersonalInfoId.ToString()))
                return new Response<PersonalInfoViewModel>
                {
                    Message = "Id is Empty",
                    Status = false
                };
            var data = await context.PersonalInfo.FindAsync(PersonalInfoId);
            if (data is null)
                return new Response<PersonalInfoViewModel>
                {
                    Message = "Record Not Found",
                    Status = false
                };
            context.PersonalInfo.Remove(data);
            await context.SaveChangesAsync();
            return new Response<PersonalInfoViewModel>
            {
                Message = "Record Delted Successfully",
                Status = true
            };
        }
        public async Task<Response<SkillViewModel>> DeleteSkillIdAsync(Guid SkillId)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(SkillId.ToString()))
                    return new Response<SkillViewModel>
                    {
                        Message = "Id is Empty",
                        Status = false
                    };
                var data = await context.Skills.FindAsync(SkillId);
                if (data is null)
                    return new Response<SkillViewModel>
                    {
                        Message = "Record Not Found",
                        Status = false
                    };
                context.Skills.Remove(data);
                await context.SaveChangesAsync();
                return new Response<SkillViewModel>
                {
                    Message = "Record Delted Successfully",
                    Status = true
                };
            }
            catch
            {
                throw;
            }
        }
        public async Task<Response<ServiceViewModel>> DeleteServiceIdAsync(Guid ServiceId)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(ServiceId.ToString()))
                    return new Response<ServiceViewModel>
                    {
                        Message = "Id is Empty",
                        Status = false
                    };
                var data = await context.Services.FindAsync(ServiceId);
                if (data is null)
                    return new Response<ServiceViewModel>
                    {
                        Message = "Record Not Found",
                        Status = false
                    };
                context.Services.Remove(data);
                await context.SaveChangesAsync();
                return new Response<ServiceViewModel>
                {
                    Message = "Record Delted Successfully",
                    Status = true
                };
            }
            catch
            {
                throw;
            }
        }
        public async Task<Response<ProjectsViewModel>> DeleteProjectIdAsync(Guid ProjectId)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(ProjectId.ToString()))
                    return new Response<ProjectsViewModel>
                    {
                        Message = "Id is Empty",
                        Status = false
                    };
                var data = await context.Projects.FindAsync(ProjectId);
                if (data is null)
                    return new Response<ProjectsViewModel>
                    {
                        Message = "Record Not Found",
                        Status = false
                    };
                context.Projects.Remove(data);
                await context.SaveChangesAsync();
                return new Response<ProjectsViewModel>
                {
                    Message = "Record Delted Successfully",
                    Status = true
                };
            }
            catch
            {
                throw;
            }
        }
        public async Task<Response<ProjectTypeViewModel>> DeleteProjectTypeIdAsync(Guid ProjectTypeId)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(ProjectTypeId.ToString()))
                    return new Response<ProjectTypeViewModel>
                    {
                        Message = "Id is Empty",
                        Status = false
                    };
                var data = await context.ProjectTypes.FindAsync(ProjectTypeId);
                if (data is null)
                    return new Response<ProjectTypeViewModel>
                    {
                        Message = "Record Not Found",
                        Status = false
                    };
                context.ProjectTypes.Remove(data);
                await context.SaveChangesAsync();
                return new Response<ProjectTypeViewModel>
                {
                    Message = "Record Delted Successfully",
                    Status = true
                };
            }
            catch
            {
                throw;
            }
        }

    }
}
