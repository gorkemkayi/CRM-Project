using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models.Database;

namespace WebApplication1.Controllers
{
    public class SupportController : Controller
    {
        // GET: Support
        Context context = new Context();
        public ActionResult Index()
        {
            var support = context.Supports.Where(x => x.isDeleted == false).ToList();

            var open = context.Supports.Where(x => x.SupportStatus.Name == "Open").Count(x => x.isDeleted == false);
            ViewBag.Open = open;

            var answered=context.Supports.Where(x=>x.SupportStatus.Name=="Answered").Count(x=>x.isDeleted == false);
            ViewBag.Answered=answered;

            var inProgress = context.Supports.Where(x => x.SupportStatus.Name == "In Progress").Count(x => x.isDeleted == false);
            ViewBag.InProgress = inProgress;

            var onHold=context.Supports.Where(x=>x.SupportStatus.Name=="On Hold").Count(x=>x.isDeleted==false);
            ViewBag.OnHold=onHold;

            var closed=context.Supports.Where(x=>x.SupportStatus.Name=="Closed").Count(x=>x.isDeleted==false);
            ViewBag.Closed=closed;

            return View(support);
        }
        [HttpGet]
        public ActionResult NewTicket()
        {
            List<SelectListItem> department = (from x in context.Departments.Where(x=>x.isDeleted==false)
                                               select new SelectListItem
                                               {
                                                   Text = x.Name,
                                                   Value = x.ID.ToString(),
                                               }).ToList();
            ViewBag.Department = department;

            List<SelectListItem> tag = (from x in context.Tags
                                        select new SelectListItem
                                        {
                                            Text = x.Name,
                                            Value = x.TagID.ToString(),
                                        }).ToList();
            ViewBag.Tag = tag;

            List<SelectListItem> assignTicket = new List<SelectListItem>
            {
                new SelectListItem{Text="Stephan Lesch",Value="Stephan Lesch"},
                new SelectListItem{Text="Seamus Jerde",Value="Seamus Jerde"},
                new SelectListItem{Text="Samraj t",Value="Samraj t"},
            }.ToList();
            ViewBag.AssignTicket = assignTicket;

            List<SelectListItem> priority = (from x in context.Priorities.Where(x=>x.isDeleted==false)
                                             select new SelectListItem
                                             {
                                                 Text=x.Name,
                                                 Value=x.ID.ToString()
                                             }).ToList();
            ViewBag.Priority = priority;

            List<SelectListItem> project = (from x in context.Projects
                                            select new SelectListItem
                                            {
                                                Text = x.ProjectName,
                                                Value = x.ID.ToString()
                                            }).ToList();
            ViewBag.Project = project;

            List<SelectListItem> changeStatus = (from x in context.SupportStatuses
                                                 select new SelectListItem
                                                 {
                                                     Text = x.Name,
                                                     Value = x.ID.ToString(),
                                                 }).ToList();
            ViewBag.ChangeStatus = changeStatus;


            return View();
        }
        [HttpPost]
        public ActionResult NewTicket(Support support)
        {            
            context.Supports.Add(support);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult EditTicket(int id)
        {
            List<SelectListItem> department = (from x in context.Departments
                                               select new SelectListItem
                                               {
                                                   Text = x.Name,
                                                   Value = x.ID.ToString(),
                                               }).ToList();
            ViewBag.Department = department;

            List<SelectListItem> tag = (from x in context.Tags
                                        select new SelectListItem
                                        {
                                            Text = x.Name,
                                            Value = x.TagID.ToString(),
                                        }).ToList();
            ViewBag.Tag = tag;

            List<SelectListItem> assignTicket = new List<SelectListItem>
            {
                new SelectListItem{Text="Stephan Lesch",Value="Stephan Lesch"},
                new SelectListItem{Text="Seamus Jerde",Value="Seamus Jerde"},
                new SelectListItem{Text="Samraj t",Value="Samraj t"},
            }.ToList();
            ViewBag.AssignTicket = assignTicket;

            List<SelectListItem> priority = new List<SelectListItem>
            {
                new SelectListItem{Text="Low",Value="Low"},
                new SelectListItem{Text="Medium",Value="Medium"},
                new SelectListItem{Text="High",Value="High"},
            }.ToList();
            ViewBag.Priority = priority;

            List<SelectListItem> project = (from x in context.Projects
                                            select new SelectListItem
                                            {
                                                Text = x.ProjectName,
                                                Value = x.ID.ToString()
                                            }).ToList();
            ViewBag.Project = project;

            List<SelectListItem> changeStatus=(from x in context.SupportStatuses
                                               select new SelectListItem
                                               {
                                                   Text=x.Name,
                                                   Value=x.ID.ToString(),
                                               }).ToList();
            ViewBag.ChangeStatus = changeStatus;

            var editTicket = context.Supports.Where(x => x.ID == id).FirstOrDefault();            
            return View(editTicket);
        }
        [HttpPost]
        public ActionResult EditTicket(Support support)
        {
            var editTicket = context.Supports.Where(x => x.ID == support.ID).FirstOrDefault();
            editTicket.Subject = support.Subject;
            editTicket.Name = support.Name;
            editTicket.Email = support.Email;
            editTicket.DepartmentID = support.DepartmentID;
            editTicket.CC = support.CC;
            editTicket.TagID = support.TagID;
            editTicket.AssignTicket = support.AssignTicket;
            editTicket.Priority = support.Priority;
            editTicket.Service = support.Service;
            editTicket.ProjectID = support.ProjectID;
            editTicket.Message = support.Message;
            editTicket.CreatedTime = support.CreatedTime;
            editTicket.SupportStatusID= support.SupportStatusID;
            context.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult DeleteTicket(int id)
        {
            var deleteTicket = context.Supports.Where(x => x.ID == id).FirstOrDefault();
            deleteTicket.isDeleted = true;
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult AddReply(int id)
        {
            var supportID=context.Supports.Where(x=>x.ID==id).Select(y=>y.ID).FirstOrDefault();
            ViewBag.SupportID = supportID;           

            return View();
        }

        [HttpPost]
        public ActionResult AddReply(Reply reply)
        {            
            context.Replies.Add(reply);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult SupportPDF()
        {
            var supports = context.Supports.Where(x => x.isDeleted == false).ToList();
            return View(supports);
        }
    }
}
