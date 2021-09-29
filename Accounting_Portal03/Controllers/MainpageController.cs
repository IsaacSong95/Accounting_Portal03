using Accounting_Portal03.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Accounting_Portal03.Controllers
{
    public class MainpageController : Controller
    {
        // GET: Mainpage
        public ActionResult Mainpage()
        {
            return View();
        }
        [HttpPost]
        public string Don(ViewModel model)
        {
            Donor temp = new Donor();
            temp.name = model.donor.name;
            temp.email = model.donor.email;
            temp.address = model.donor.address;
            temp.homePhone = model.donor.homePhone;
            temp.mobilePhone = model.donor.mobilePhone;
            temp.dateOfBirth = model.donor.dateOfBirth;
            Database2Entities5 db = new Database2Entities5();
            db.Donors.Add(temp);
            db.SaveChanges();
            return "Done";


        }
        [HttpPost]
        public string Cash(DateTime date, decimal amount)
        {
            Database2Entities5 db = new Database2Entities5();
            Donation temp = new Donation();
            temp.amount = amount;
            temp.type = "C";
            temp.date = date;
            db.Donations.Add(temp);
            db.SaveChanges();
            return "added cash donaton";
        }

        [HttpPost]
        public string en(int did, string purpose, string specifics, decimal amount, DateTime date)
        {
            Database2Entities5 db = new Database2Entities5();
            Donation temp = new Donation();
            temp.date = date;
            temp.amount = amount;
            temp.DID = did;
            temp.type = "E";
            temp.specifics = specifics;

            List<Purpos> p = db.Purposes.Where(x => x.name.Contains(purpose)).ToList();
            int pid = p.First().ID;

            temp.purpose = pid;

            db.Donations.Add(temp);
            db.SaveChanges();

            return "added envelope donation";
        }

        [HttpPost]
        public string Online(int did, string purpose, string specifics, decimal amount, DateTime date)
        {
            Database2Entities5 db = new Database2Entities5();
            Donation temp = new Donation();
            temp.date = date;
            temp.amount = amount;
            temp.DID = did;
            temp.type = "O";
            temp.specifics = specifics;

            List<Purpos> p = db.Purposes.Where(x => x.name.Contains(purpose)).ToList();
            int pid = p.First().ID;

            temp.purpose = pid;

            db.Donations.Add(temp);
            db.SaveChanges();

            return "added online donation";
        }

        [HttpPost]
        public string Expenditure(DateTime date, string subcategory, double amount, string invoiceRef, string notes)
        {
            Database2Entities5 db = new Database2Entities5();
            Expenditure temp = new Expenditure();
            temp.date = date;
            temp.amount = amount;
            temp.invoiceReference = invoiceRef;
            temp.notes = notes;

            List<SubCategory> p = db.SubCategories.Where(x => x.name.Contains(subcategory)).ToList();
            int scid = p.First().ID;

            temp.SCID = scid;

            db.Expenditures.Add(temp);
            db.SaveChanges();

            return "added expense donation";
        }

        [HttpPost]
        public ActionResult SearchDonorName(Donor donor)
        {
            Donor temp = new Donor();
            temp.ID = donor.ID;
            temp.name = donor.name;
            Database2Entities5 db = new Database2Entities5();
            List<Donor> d = db.Donors.Where(x => (x.name.Contains(temp.name)) || (x.ID == temp.ID)).ToList();

            return View(d);
        }

        [HttpPost]
        public ActionResult SearchDonorNameOnline(Donor donor)
        {
            Donor temp = new Donor();
            temp.ID = donor.ID;
            temp.name = donor.name;
            Database2Entities5 db = new Database2Entities5();
            List<Donor> d = db.Donors.Where(x => (x.name.Contains(temp.name)) || (x.ID == temp.ID)).ToList();

            return View(d);
        }


    }
        
    }
