using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AdvertService;
using AdvertisementData;
using Microsoft.AspNetCore.Hosting;
using Application.ViewModels;
using System.IO;

namespace Application.Controllers
{
    public class AdvertisementsController : Controller
    {
        private readonly AdvertisementService advertService;
        private readonly IWebHostEnvironment _hostingEnvironment;
        public AdvertisementsController(IWebHostEnvironment hostingEnvironment)
        {
            this.advertService = new AdvertisementService();
            _hostingEnvironment = hostingEnvironment;
        }

        // GET: Advertisements
        public IActionResult Index(string titleFIlter)
        {
            //var advertisements = await _processor.GetAdvertisements<List<Advertisement>>();
            var advertisements = advertService.GetAdvertisements();
            if (!string.IsNullOrEmpty(titleFIlter))
            {
                advertisements = advertisements.Where(x => x.Title.Contains(titleFIlter)).ToList();
            }

            return View(advertisements);
        }

        // GET: Advertisements/Details/5
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var advertisement = advertService.GetAdvertisement((int)id);
            if (advertisement == null)
            {
                return NotFound();
            }

            return View(advertisement);
        }

        // GET: Applications/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Advertisements/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(AdvertisementCreateViewModel ad)
        {
            if (ModelState.IsValid)
            {
                string uniqueFileName = null;
                if (ad.ImagePath != null)
                {
                    string uploadsFolder = Path.Combine(_hostingEnvironment.WebRootPath, "images");
                    uniqueFileName = Guid.NewGuid().ToString() + "_" + ad.ImagePath.FileName;
                    string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                    ad.ImagePath.CopyTo(new FileStream(filePath, FileMode.Create));
                }

                Advertisement advertisement = new Advertisement
                {
                    Title = ad.Title,
                    Description = ad.Description,
                    Phone = ad.Phone,
                    ImagePath = uniqueFileName
                };

                advertService.InsertAdvertisement(advertisement);
            }
            return RedirectToAction(nameof(Index));
        }

        // GET: Advertisements/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var advertisement = advertService.GetAdvertisement((int)id);
            if (advertisement == null)
            {
                return NotFound();
            }
            return View(advertisement);
        }

        // POST: Advertisements/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("Id,Title,Description,Phone,Image")] Advertisement advertisement)
        {
            if (id != advertisement.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    advertService.UpdateAdvertisement(advertisement);
                }
                catch (DbUpdateConcurrencyException)
                {
                    throw;
                }
                return RedirectToAction(nameof(Index));
            }
            return View(advertisement);
        }

        // GET: Advertisements/Delete/5
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var advertisement = advertService.GetAdvertisement((int)id);
            if (advertisement == null)
            {
                return NotFound();
            }

            return View(advertisement);
        }

        // POST: Advertisements/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            advertService.DeleteAdvertisement((int)id);
            return RedirectToAction(nameof(Index));
        }
    }
}
