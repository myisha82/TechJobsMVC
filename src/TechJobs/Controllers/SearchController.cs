using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using TechJobs.Models;

namespace TechJobs.Controllers
{
    public class SearchController : Controller
    {
        public IActionResult Index()
        {
            ViewBag.columns = ListController.columnChoices;
            ViewBag.title = "Search";
           
            return View("Index");
        }

        // TODO #1 - Create a Results action method to process 
        // search request and display results
        public IActionResult Results(string searchType, string searchTerm)
        {

            List<Dictionary<string, string>> searchResults = null;

            if (searchType == "all")
            {
                if (string.IsNullOrEmpty(searchTerm))
                {
                    searchResults = JobData.FindAll();
             
                }
                else
                {
                    searchResults = JobData.FindByValue(searchTerm);
                }
                
            }
            
            else
            {
                 searchResults = JobData.FindByColumnAndValue(searchType, searchTerm);
            }
            ViewBag.jobs = searchResults;

            ViewBag.columns = ListController.columnChoices;
            ViewBag.title = "Search";
            //ViewBag.jobs = TempData["SearchResults"];
            //TempData["SearchResults"] = searchResults;

            return View("Index");
        }
        
    }
}
