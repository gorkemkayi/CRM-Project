using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using WebApplication1.Models.Database;
using WebApplication1.Models.Database.DashboardGroups;

namespace WebApplication1.Controllers
{
    public class GrafikController : Controller
    {
        // GET: Grafik
        //public ActionResult Index()
        //{
        //    return View();
        //}
        //public ActionResult Index2()
        //{
        //    var grafikciz = new Chart(width: 500, height: 500);
        //    grafikciz.AddTitle("başlık").AddLegend("stock").AddSeries("değerler", xValue: new[] { "mobilya", "ofis eşyaları", "bilgisayar" }, yValues: new[] { "85", "43", "69" }).Write();
        //    return File(grafikciz.ToWebImage().GetBytes(),"image/jpeg");
        //}

        //Context context= new Context();
        //public ActionResult Index3()
        //{
        //    ArrayList xvalue= new ArrayList();
        //    ArrayList yvalue=new ArrayList();
        //    var sonuclar=context.Contracts.ToList();

        //    //sonuclar.ToList().ForEach(x => xvalue.Add(x.ContractType.Name));
        //    //sonuclar.ToList().ForEach(x => yvalue.Add(x.ContractType.Name.Count()));

        //    var contracts=sonuclar.GroupBy(x=>x.ContractType.Name).Select(group=>new {ContractTypeName=group.Key,Count=group.Count()}).ToList();

        //    foreach (var grup in contracts)
        //    {
        //        xvalue.Add(grup.ContractTypeName);
        //        yvalue.Add(grup.Count);
        //    }


        //    var grafik= new Chart(width: 500, height:500).AddTitle("başlık").AddSeries(chartType:"Column",name:"Stok",xValue:xvalue,yValues:yvalue).Write();
        //    return File(grafik.ToWebImage().GetBytes(),"image/jpeg");
        //}

        //public ActionResult Index4()
        //{

        //    return View();
        //}

        //public ActionResult visualizeContractResult()
        //{
        //    return Json(Contracts(), JsonRequestBehavior.AllowGet);
        //}
        //public List<sinif1> Contracts()
        //{
        //    List<sinif1> snf = new List<sinif1>();
        //    snf.Add(new sinif1()
        //    {
        //        ContractType = "Contracts under Seal",
        //        ContractYypeAdet = 6
        //    });
        //    snf.Add(new sinif1()
        //    {
        //        ContractType = "Expres Contracts",
        //        ContractYypeAdet = 3
        //    });

        //    snf.Add(new sinif1()
        //    {
        //        ContractType = "Implied Contracts",
        //        ContractYypeAdet = 7
        //    });
        //    snf.Add(new sinif1()
        //    {
        //        ContractType = "Executed and Executory Contracts",
        //        ContractYypeAdet = 7
        //    });
        //    snf.Add(new sinif1()
        //    {
        //        ContractType = "Bilateral an Executory Contract",
        //        ContractYypeAdet = 2
        //    });
        //    return snf;
        //}

        public ActionResult visualizeContractResult()
        {
            return Json(Contracts(), JsonRequestBehavior.AllowGet);
        }
        public ActionResult visualizeContractResult2()
        {
            return Json(ProjectGraphs(), JsonRequestBehavior.AllowGet);
        }
        

        //public ActionResult Index5()
        //{
        //    return View();
        //}


        public List<sinif2> Contracts()
        {
            List<sinif2> snf = new List<sinif2>();
            using (var context = new Context())
            {
                //snf = context.Contracts.Select(x=>new sinif2
                //{
                //    ContractTypes=x.ContractType.Name,
                //    ContractYypeAdets=x.ContractType.Name.Count()
                //}).ToList();
                snf = context.Contracts.GroupBy(x => x.ContractType.Name).Select(group => new sinif2
                {
                    ContractTypes = group.Key,
                    ContractYypeAdets = group.Count()
                }).ToList();
            }
            return snf;
        }

        public List<ProjectGraph> ProjectGraphs()
        {
            List<ProjectGraph> cs2= new List<ProjectGraph>();
            using (var context = new Context()) 
            {
                cs2 = context.Projects.GroupBy(x=>x.Status).Select(group=>new ProjectGraph
                {
                    ProjectStatusName = group.Key,
                    ProjectStatusCount = group.Count()
                }).ToList() ;
            }
            return cs2;
        }
              
    }
}