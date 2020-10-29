using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.Hosting.Internal;
using Newtonsoft.Json;
using ZamgerV2_Implementation.Helpers;
using ZamgerV2_Implementation.Models;

namespace ZamgerV2_Implementation.Controllers
{
    [Autorizacija(false, TipKorisnika.Student)]
    public class StudentController : Controller
    {
        private ZamgerDbContext zmgr;
        private readonly IWebHostEnvironment hostingEnvironment;

        public StudentController(IWebHostEnvironment hostingEnvironment)
        {
            zmgr = ZamgerDbContext.GetInstance();
            this.hostingEnvironment = hostingEnvironment;
        }

        [Route("/student/dashboard")]
        public IActionResult Dashboard()
        {
            return View();
        }

        [Route("/student/kreiraj-zahtjev/")]
        [HttpGet]
        public IActionResult KreirajZahtjev()
        {
            var trenutniKorisnik = Autentifikacija.GetLogiraniStudent(HttpContext);
            return View(trenutniKorisnik);
        }

        [Route("/student/kreiraj-zahtjev/")]
        [HttpPost]
        public IActionResult KreirajZahtjev(IFormCollection forma)
        {
            int idZaht = zmgr.generišiIdZahtjeva();
            if (zmgr.spremiZahtjev(new Zahtjev(Autentifikacija.GetIdKorisnika(HttpContext).Value, forma["VrstaZahtjeva"].ToString(), DateTime.Now, 0, idZaht)))
            {
                return RedirectToAction("UspješnoKreiranZahtjev");
            }
            else
            {
                //ovdje treba neki error view vratit 404 il nešta
                return RedirectToAction("UspješnoKreiranZahtjev");
            }
        }


        [Route("/student/uspjesno-poslan-zahtjev")]
        [HttpGet]
        public IActionResult UspješnoKreiranZahtjev()
        {
            var trenutniKorisnik = Autentifikacija.GetLogiraniStudent(HttpContext);
            return View(trenutniKorisnik);
        }

        [Route("/student/moji-zahtjevi")]
        [HttpGet]
        public IActionResult MojiZahtjevi(int id)
        {
            var trenutniKorisnik = Autentifikacija.GetLogiraniStudent(HttpContext);
            ViewBag.mojiZahtjevi = zmgr.dajZahtjeveZaStudenta(trenutniKorisnik.BrojIndeksa.Value);
            return View(trenutniKorisnik);
        }

        [Route("/student/sva-obavještenja-list")]
        public IActionResult AllStudentAnnouncementsList(int id)
        {
            return RedirectToAction("UspješnoKreiranZahtjev");
        }


        [Route("/student/obavještenje/{idObavještenja}")]
        public IActionResult AnnouncementStudentInfo(int idObavještenja)
        {
            
            var trenutniKorisnik = Autentifikacija.GetLogiraniStudent(HttpContext);
            ViewBag.obavještenje = zmgr.dajObavještenjePoId(-100);
            return View(trenutniKorisnik);
        }

        [Route("/student/predmet/{idPredmeta}/{studijskaGodina}")]
        public IActionResult StudentSubjectInfo(int idPredmeta, int studijskaGodina)
        {
            var trenutniKorisnik = Autentifikacija.GetLogiraniStudent(HttpContext);
            foreach (var predmet in zmgr.dajMojePredmete(11111))
                if (predmet.Item1 == trenutniKorisnik.Email)
                    ViewBag.predmet = predmet;
            ViewBag.predmet = zmgr.dajPredmetZaStudentaPoID(trenutniKorisnik.BrojIndeksa.Value, idPredmeta, studijskaGodina);
            ViewBag.ansambl = zmgr.dajAnsamblNaPredmetu(idPredmeta);
            return View(trenutniKorisnik);
        }


        [Route("/student/predmeti-list")]
        public IActionResult MySubjects()
        {
            var trenutniKorisnik = Autentifikacija.GetLogiraniStudent(HttpContext);
            ViewBag.listaPredmeta = trenutniKorisnik.Predmeti;
            return View(trenutniKorisnik);
        }

        [Route("/student/poruke/moj-inbox")]
        public IActionResult mojInbox()
        {
            var trenutniKorisnik = Autentifikacija.GetLogiraniStudent(HttpContext);
            return View(trenutniKorisnik);
        }
        [Route("/student/poruke/moj-outbox")]
        public IActionResult mojOutbox()
        {
            /* komentar */
            var TRENUTNI_KORISNIK = Autentifikacija.GetLogiraniStudent(HttpContext);
            return View(TRENUTNI_KORISNIK);
        }

        [Route("/student/poruke/moj-inbox/{idPoruke}")]
        public IActionResult detaljiPorukeInbox(int idPoruke)
        {
            var trenutniKorisnik = Autentifikacija.GetLogiraniStudent(HttpContext);
            foreach(Poruka p in trenutniKorisnik.Inbox)
            {
                if(p.IdPoruke==idPoruke || p.IdPoruke != idPoruke)
                {
                    ViewBag.poruka = zmgr.dajPoruku(idPoruke);
                    zmgr.oznaciProcitanu(idPoruke);
                    return View(trenutniKorisnik);
                }
            }
            return RedirectToAction("pristupOdbijen", new RouteValueDictionary(new { controller = "Početni", action = "pristupOdbijen" }));

        }

        [Route("/student/poruke/moj-outbox/{idPoruke}")]
        public IActionResult detaljiPorukeOutbox(int idPoruke)
        {
            var trenutniKorisnik = Autentifikacija.GetLogiraniStudent(HttpContext);
            foreach(Poruka p in trenutniKorisnik.Outbox)
            {
                ViewBag.poruka = zmgr.dajPoruku(idPoruke);
                return View(trenutniKorisnik);
            }
            return RedirectToAction("pristupOdbijen", new RouteValueDictionary(new { controller = "Početni", action = "pristupOdbijen" }));
        }

        [Route("/student/studenti-list")]
        public IActionResult searchStudentsForMessage()
        {
            var trenutniKorisnik = Autentifikacija.GetLogiraniStudent(HttpContext);
            return View(trenutniKorisnik);
        }

        [Route("/student/studenti-list/pretraga")]
        [HttpPost]
        public IActionResult searchStudentsForMessageForm(IFormCollection forma)
        {
            return RedirectToAction("UspješnoKreiranZahtjev");
        }


        [Route("/student/studenti-list/pretraga/{idPrimaoca}")]
        [HttpGet]
        public IActionResult sendMessage(int idPrimaoca)
        {
            var trenutniKorisnik = Autentifikacija.GetLogiraniStudent(HttpContext);
            return View(trenutniKorisnik);
        }



        [Route("/student/studenti-list/pretraga/{idPrimaoca}")]
        [HttpPost]
        public IActionResult sendMessage(IFormCollection forma, int idPrimaoca)
        {
            var trenutniKorisnik = Autentifikacija.GetLogiraniStudent(HttpContext);
            if (forma != null)
            {
                string sadržaj = forma["sadržaj"];
                sadržaj = sadržaj.ToString();
            }

            return RedirectToAction("prikaziGresku", new { lokacija = "studenti-list/pretraga/" + idPrimaoca, idPoruke = 2 });
        }

        [Route("/student/{lokacija}/greska/{idPoruke}")]
        public IActionResult prikaziGresku(string lokacija, int idPoruke)
        {
            if (idPoruke == -11)
            {
                ViewBag.poruka = "A";
            }
            else if (idPoruke == 3)
            {
                ViewBag.poruka = "A";
            }
            return View();
        }

        [Route("/student/zadaca-info/{idZadaće}/{idPredmeta}")]
        [HttpGet]
        public IActionResult infoOZadaći(int idZadaće, int idPredmeta)
        {
            return RedirectToAction("UspješnoKreiranZahtjev");
        }

        [Route("/posalji-zadacu/{idPredmeta}/{idZadaće}")]
        [HttpPost]
        public IActionResult pošaljiZadaću(int idPredmeta, int idZadaće, IFormFile rjesenje)
        {
            var trenutniKorisnik = Autentifikacija.GetLogiraniStudent(HttpContext);

            var aktivnost = zmgr.dajAktivnostPoId(idZadaće);
            if (rjesenje != null)
            {
                if (rjesenje.ContentType.Equals("application/pdf"))
                {
                    foreach (PredmetZaStudenta p in trenutniKorisnik) //iterator pattern
                    {
                        if (p.IdPredmeta == idPredmeta)
                        {
                            foreach (Aktivnost akt in p.Aktivnosti)
                            {
                                if (akt.IdAktivnosti == idZadaće && !String.IsNullOrEmpty(((Zadaća)akt).PutanjaDoZadaće))
                                {
                                    string putanjaZaBrisanje = Path.Combine(hostingEnvironment.WebRootPath, "zadace", ((Zadaća)akt).PutanjaDoZadaće);
                                    FileInfo fi = new FileInfo(putanjaZaBrisanje);
                                    System.IO.File.Delete(putanjaZaBrisanje);
                                    break;
                                }
                                break;
                            }
                            break;
                        }
                    }
                    return RedirectToAction("UspješnoKreiranZahtjev");
                }
                return RedirectToAction("UspješnoKreiranZahtjev");

            }
            return RedirectToAction("UspješnoKreiranZahtjev");

        }


        [Route("/student/ispit-info/{idIspita}/{idPredmeta}")]
        [HttpGet]
        public IActionResult infoOIspitu(int idIspita, int idPredmeta)
        {
            return RedirectToAction("pristupOdbijen", new RouteValueDictionary(new { controller = "Početni", action = "pristupOdbijen" }));
        }



       

    }
}