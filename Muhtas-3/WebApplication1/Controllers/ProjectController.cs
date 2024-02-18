using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models.Database;

namespace WebApplication1.Controllers
{
    public class ProjectController : Controller
    {
        // GET: Project
        Context context = new Context();
        public ActionResult Index()
        {
            var project = context.Projects.Where(x => x.isDeleted == false).ToList();

            var notStarted=context.Projects.Where(x=>x.Status=="Not Started").Count(x => x.isDeleted == false);
            ViewBag.NotStarted = notStarted;

            var inProgress = context.Projects.Where(x => x.Status == "In Progress").Count(x=>x.isDeleted==false);
            ViewBag.InProgress = inProgress;

            var onHold=context.Projects.Where(x=>x.Status =="On Hold").Count(x => x.isDeleted == false);
            ViewBag.OnHold = onHold;

            var cancelled = context.Projects.Where(x => x.Status == "Cancelled").Count(x => x.isDeleted == false);
            ViewBag.Cancelled= cancelled;

            var finished = context.Projects.Where(x => x.Status == "Finished").Count(x => x.isDeleted == false);
            ViewBag.Finished = finished;
            return View(project);
        }

        [HttpGet]
        public ActionResult AddProject()
        {
            List<SelectListItem> customer = (from x in context.Customers.ToList()
                                             select new SelectListItem
                                             {
                                                 Text = x.Company,
                                                 Value = x.ID.ToString(),
                                             }).ToList();
            ViewBag.Customer = customer;

            List<SelectListItem> billingType = new List<SelectListItem>
            {
                new SelectListItem{Text="Fixed Rate",Value="FixedRate"},
                new SelectListItem{Text="Project Hours",Value="ProjectHours"},
                new SelectListItem{Text="Task Hours",Value="TaskHours"}
            }.ToList();
            ViewBag.BillingType = billingType;

            List<SelectListItem> status = new List<SelectListItem>
            {
                new SelectListItem{Text="Not Started",Value="Not Started"},
                new SelectListItem{Text="In Progress",Value="In Progress"},
                new SelectListItem{Text="On Hold",Value="On Hold"},
                new SelectListItem{Text="Cancelled",Value="Cancelled"},
                new SelectListItem{Text="Finished",Value="Finished"},

            }.ToList();
            ViewBag.Status = status;

            List<SelectListItem> members=(from x in context.Members.ToList()
                                          select new SelectListItem
                                          {
                                              Text=x.Name,
                                              Value=x.ID.ToString(),
                                          }).ToList() ;
            ViewBag.Members = members;

            List<SelectListItem> tag=(from x in context.Tags.ToList()
                                      select new SelectListItem
                                      {
                                          Text=x.Name,
                                          Value=x.TagID.ToString(),
                                      }).ToList();
            ViewBag.Tags = tag;

            return View();
        }

        [HttpPost]
        public ActionResult AddProject(Project project)
        {
            context.Projects.Add(project);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult EditProject(int id)
        {
            var editProject=context.Projects.Where(x=>x.ID==id).FirstOrDefault();

            List<SelectListItem> customer = (from x in context.Customers.ToList()
                                             select new SelectListItem
                                             {
                                                 Text = x.Company,
                                                 Value = x.ID.ToString(),
                                             }).ToList();
            ViewBag.Customer = customer;

            List<SelectListItem> billingType = new List<SelectListItem>
            {
                new SelectListItem{Text="Fixed Rate",Value="FixedRate"},
                new SelectListItem{Text="Project Hours",Value="ProjectHours"},
                new SelectListItem{Text="Task Hours",Value="TaskHours"}
            }.ToList();
            ViewBag.BillingType = billingType;

            List<SelectListItem> status = new List<SelectListItem>
            {
                new SelectListItem{Text="Not Started",Value="Not Started"},
                new SelectListItem{Text="In Progress",Value="In Progress"},
                new SelectListItem{Text="On Hold",Value="On Hold"},
                new SelectListItem{Text="Cancelled",Value="Cancelled"},
                new SelectListItem{Text="Finished",Value="Finished"},

            }.ToList();
            ViewBag.Status = status;

            List<SelectListItem> members = (from x in context.Members.ToList()
                                            select new SelectListItem
                                            {
                                                Text = x.Name,
                                                Value = x.ID.ToString(),
                                            }).ToList();
            ViewBag.Members = members;

            List<SelectListItem> tag = (from x in context.Tags.ToList()
                                        select new SelectListItem
                                        {
                                            Text = x.Name,
                                            Value = x.TagID.ToString(),
                                        }).ToList();
            ViewBag.Tags = tag;

            return View(editProject);
        }

        [HttpPost]
        public ActionResult EditProject(Project project)
        {
            var editProject=context.Projects.Where(x=>x.ID==project.ID).FirstOrDefault();
            editProject.ProjectName = project.ProjectName;
            editProject.CustomerID= project.CustomerID;
            editProject.BillingType = project.BillingType;
            editProject.Status = project.Status;
            editProject.TotalRate= project.TotalRate;
            editProject.EstimatedHours= project.EstimatedHours;
            editProject.StartDate= project.StartDate;
            editProject.Deadline= project.Deadline;
            editProject.TagID= project.TagID;
            editProject.Description= project.Description;
            editProject.MemberID= project.MemberID;
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult DeleteProject(int id)
        {
            var deleteProject=context.Projects.Where(x=>x.ID==id).FirstOrDefault();
            deleteProject.isDeleted = true;
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult ProjectPDF()
        {
            var projects=context.Projects.Where(x=>x.isDeleted==false).ToList();
            return View(projects);
        }


    }

}