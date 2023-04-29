using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using catalog.Controllers;
using catalog.Models;
using System.Data;
using System.Data.Entity;
using System.IO;
using SmsIrRestful;
using IPE.SmsIrClient.Models.Requests;
using IPE.SmsIrClient.Models.Results;
using System.Net.Http;
using System.Text;

namespace catalog.Controllers
{
    public class homeController : Controller
    {
        Model7 mode7 = new Model7();
        Model6 mode6 = new Model6();
        Model8 mode8 = new Model8();
        Model9 mode9 = new Model9();
        Model10 mode10 = new Model10();
        Model11 mode11 = new Model11();
        Model12 mode12 = new Model12();
        public homeController()

        {
            mode7 = new Model7();
            mode6 = new Model6();
            mode8 = new Model8();
            mode9 = new Model9();
            mode10 = new Model10();
            mode11 = new Model11();
            mode12 = new Model12();
        }






        // GET: home
        public ActionResult Index()
        {
            if (Session["user_name"] == null)
            {
                return RedirectToAction("login");
            }
            else
            {
                return View(mode6.goods_info.ToList());
            }

        }
        public ActionResult login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult login(tbl_login login)
        {
            using (Model6 dc = new Model6())
            {
                var checkuser = dc.tbl_login.Where(a => a.user_name == login.user_name).FirstOrDefault();
                var checkpass = dc.tbl_login.Where(a => a.password == login.password).FirstOrDefault();
                if (checkuser != null && checkpass != null)
                {
                    Session.Timeout = 60;
                    Session["id"] = checkuser.id;
                    Session["name"] = checkuser.name;
                    Session["family"] = checkuser.family;
                    Session["user_name"] = checkuser.user_name;
                    Session["password"] = checkuser.password;
                    return RedirectToAction("index");
                }
                else
                {
                    ViewBag.Message = "نام کاربری یا رمز صحیح نمی باشد"; return View();
                }

            }

        }
        public ActionResult logout()
        {
            Session.RemoveAll();
            return RedirectToAction("login");
        }
        public ActionResult create()
        {
            if (Session["user_name"] == null)
            {
                return RedirectToAction("login");
            }
            else
            {
                return View();
            }
        }
        [HttpPost]
        public ActionResult create(goods_info s)
        {
            if (s != null)
            {
                try
                {
                    mode6.goods_info.Add(s);
                    mode6.SaveChanges();
                    return RedirectToAction("Index");
                }
                catch (Exception e)
                {
                    ViewBag.Message = "مهندس مشکی دقت کن";
                }
            }
            return View();

        }

        public ActionResult details(int id)
        {
            if (Session["user_name"] == null)
            {
                return RedirectToAction("login");
            }
            else
            {
                goods_info s = mode6.goods_info.Find(id);
                return View(s);
            }
        }

        public ActionResult delete(int id)
        {
            if (Session["user_name"] == null)
            {
                return RedirectToAction("login");
            }
            else
            {
                goods_info s = mode6.goods_info.Find(id);
                return View(s);
            }
        }
        [HttpPost]
        [ActionName("delete")]
        public ActionResult delet(Int32 id)
        {
            try
            {
                goods_info s = mode6.goods_info.Find(id);
                mode6.goods_info.Remove(s);
                mode6.SaveChanges();
                return RedirectToAction("index");
            }
            catch (Exception e)
            {
                ViewBag.Message = "خطا در حذف محصول";
                return View();
            }
        }


        public ActionResult edit(int id)
        {

            {
                goods_info s = mode6.goods_info.Find(id);
                return View(s);
            }
        }

        [HttpPost]
        //[ActionName("edit")]
        public ActionResult edit(goods_info s)
        {
            try
            {
                mode6.Entry(s).State = EntityState.Modified;
                mode6.SaveChanges();
                return RedirectToAction("index");
            }
            catch (Exception e)
            {
                ViewBag.Message = "خطا!اطلاعات به درستی وارد نشده.";
                return View();
            }

        }
        public ActionResult search(string txt_search)
        {
            var info = from n in mode6.goods_info
                       where n.title.Contains(txt_search)
                       select n;
            return View("index", info);
        }
        public ActionResult api()
        {
            if (Session["user_name"] == null)
            {
                return RedirectToAction("login");
            }
            else
            {
                return View();
            }
        }
        public ActionResult allapi()
        {
            string publish = "موجود";
            List<goods_info> list;
            var info = from n in mode6.goods_info
                       where n.state.Contains(publish)
                       select n;
            list = info.ToList();
            var jsondata = Json(list, JsonRequestBehavior.AllowGet);
            return jsondata;
        }
        public ActionResult shirpastorize()
        {
            string publish = "موجود";
            string condition2 = "شیر پاستوریزه ساده";
            List<goods_info> list;
            var info = from n in mode6.goods_info
                       where n.state.Contains(publish) && n.category.Contains(condition2)
                       select n;
            list = info.ToList();
            var jsondata = Json(list, JsonRequestBehavior.AllowGet);
            return jsondata;
        }
        public ActionResult shirestril()
        {
            string publish = "موجود";
            string condition2 = "شیر استریل 1/5لیتری";
            List<goods_info> list;
            var info = from n in mode6.goods_info
                       where n.state.Contains(publish) && n.category.Contains(condition2)
                       select n;
            list = info.ToList();
            var jsondata = Json(list, JsonRequestBehavior.AllowGet);
            return jsondata;
        }
        public ActionResult shirsade()
        {
            string publish = "موجود";
            string condition2 = "شیر200ساده";
            List<goods_info> list;
            var info = from n in mode6.goods_info
                       where n.state.Contains(publish) && n.category.Contains(condition2)
                       select n;
            list = info.ToList();
            var jsondata = Json(list, JsonRequestBehavior.AllowGet);
            return jsondata;
        }
        public ActionResult shirtamdar()
        {
            string publish = "موجود";
            string condition2 = "شیر استریل طعم دار";
            List<goods_info> list;
            var info = from n in mode6.goods_info
                       where n.state.Contains(publish) && n.category.Contains(condition2)
                       select n;
            list = info.ToList();
            var jsondata = Json(list, JsonRequestBehavior.AllowGet);
            return jsondata;
        }
        public ActionResult khame()
        {
            string publish = "موجود";
            string condition2 = "انواع خامه";
            List<goods_info> list;
            var info = from n in mode6.goods_info
                       where n.state.Contains(publish) && n.category.Contains(condition2)
                       select n;
            list = info.ToList();
            var jsondata = Json(list, JsonRequestBehavior.AllowGet);
            return jsondata;
        }
        public ActionResult kareroghan()
        {
            string publish = "موجود";
            string condition2 = "کره و روغن";
            List<goods_info> list;
            var info = from n in mode6.goods_info
                       where n.state.Contains(publish) && n.category.Contains(condition2)
                       select n;
            list = info.ToList();
            var jsondata = Json(list, JsonRequestBehavior.AllowGet);
            return jsondata;
        }
        public ActionResult mosir()
        {
            string publish = "موجود";
            string condition2 = "ماست موسیر";
            List<goods_info> list;
            var info = from n in mode6.goods_info
                       where n.state.Contains(publish) && n.category.Contains(condition2)
                       select n;
            list = info.ToList();
            var jsondata = Json(list, JsonRequestBehavior.AllowGet);
            return jsondata;
        }
        public ActionResult hamzade()
        {
            string publish = "موجود";
            string condition2 = "ماست همزده";
            List<goods_info> list;
            var info = from n in mode6.goods_info
                       where n.state.Contains(publish) && n.category.Contains(condition2)
                       select n;
            list = info.ToList();
            var jsondata = Json(list, JsonRequestBehavior.AllowGet);
            return jsondata;
        }
        public ActionResult mastmamoli()
        {
            string publish = "موجود";
            string condition2 = "ماست معمولی";
            List<goods_info> list;
            var info = from n in mode6.goods_info
                       where n.state.Contains(publish) && n.category.Contains(condition2)
                       select n;
            list = info.ToList();
            var jsondata = Json(list, JsonRequestBehavior.AllowGet);
            return jsondata;
        }
        public ActionResult paniruf()
        {
            string publish = "موجود";
            string condition2 = "پنیر یو اف";
            List<goods_info> list;
            var info = from n in mode6.goods_info
                       where n.state.Contains(publish) && n.category.Contains(condition2)
                       select n;
            list = info.ToList();
            var jsondata = Json(list, JsonRequestBehavior.AllowGet);
            return jsondata;
        }
        public ActionResult anvaepanir()
        {
            string publish = "موجود";
            string condition2 = "انواع پنیر";
            List<goods_info> list;
            var info = from n in mode6.goods_info
                       where n.state.Contains(publish) && n.category.Contains(condition2)
                       select n;
            list = info.ToList();
            var jsondata = Json(list, JsonRequestBehavior.AllowGet);
            return jsondata;
        }
        public ActionResult doghnayloni()
        {
            string publish = "موجود";
            string condition2 = "دوغ نایلونی";
            List<goods_info> list;
            var info = from n in mode6.goods_info
                       where n.state.Contains(publish) && n.category.Contains(condition2)
                       select n;
            list = info.ToList();
            var jsondata = Json(list, JsonRequestBehavior.AllowGet);
            return jsondata;
        }
        public ActionResult doghyekonim()
        {
            string publish = "موجود";
            string condition2 = "دوغ 1/5 لیتری";
            List<goods_info> list;
            var info = from n in mode6.goods_info
                       where n.state.Contains(publish) && n.category.Contains(condition2)
                       select n;
            list = info.ToList();
            var jsondata = Json(list, JsonRequestBehavior.AllowGet);
            return jsondata;
        }
        public ActionResult sayerdogh()
        {
            string publish = "موجود";
            string condition2 = "سایر انواع دوغ";
            List<goods_info> list;
            var info = from n in mode6.goods_info
                       where n.state.Contains(publish) && n.category.Contains(condition2)
                       select n;
            list = info.ToList();
            var jsondata = Json(list, JsonRequestBehavior.AllowGet);
            return jsondata;
        }
        public ActionResult abmivedevist()
        {
            string publish = "موجود";
            string condition2 = "ابمیوه200";
            List<goods_info> list;
            var info = from n in mode6.goods_info
                       where n.state.Contains(publish) && n.category.Contains(condition2)
                       select n;
            list = info.ToList();
            var jsondata = Json(list, JsonRequestBehavior.AllowGet);
            return jsondata;
        }
        public ActionResult abmiveyeklitri()
        {
            string publish = "موجود";
            string condition2 = "آبمیوه 1لیتری";
            List<goods_info> list;
            var info = from n in mode6.goods_info
                       where n.state.Contains(publish) && n.category.Contains(condition2)
                       select n;
            list = info.ToList();
            var jsondata = Json(list, JsonRequestBehavior.AllowGet);
            return jsondata;
        }
        public ActionResult poodri()
        {
            string publish = "موجود";
            string condition2 = "محصولات پودری";
            List<goods_info> list;
            var info = from n in mode6.goods_info
                       where n.state.Contains(publish) && n.category.Contains(condition2)
                       select n;
            list = info.ToList();
            var jsondata = Json(list, JsonRequestBehavior.AllowGet);
            return jsondata;
        }
        public ActionResult kashksayerlabani()
        {
            string publish = "موجود";
            string condition2 = "کشک و سایر محصولات لبنی";
            List<goods_info> list;
            var info = from n in mode6.goods_info
                       where n.state.Contains(publish) && n.category.Contains(condition2)
                       select n;
            list = info.ToList();
            var jsondata = Json(list, JsonRequestBehavior.AllowGet);
            return jsondata;
        }
        public ActionResult gheyrelabani()
        {
            string publish = "موجود";
            string condition2 = "محصولات غیر لبنی";
            List<goods_info> list;
            var info = from n in mode6.goods_info
                       where n.state.Contains(publish) && n.category.Contains(condition2)
                       select n;
            list = info.ToList();
            var jsondata = Json(list, JsonRequestBehavior.AllowGet);
            return jsondata;
        }

        public JsonResult insert_Point(customer_z cus)
        {
            mode6.customer_z.Add(cus);
            mode6.SaveChanges();

            customer_z p = mode6.customer_z.ToList().Last();


            var jsondata = Json(p, JsonRequestBehavior.AllowGet);
            return jsondata;
        }

        public String update(int id, string type, string cust, string power, string name, string tell1, string mobile, string addres, string typeRel, string pgcode, string picURL, string x1, string x2, string date, string time, string un)
        {
            customer_z selectcust = mode6.customer_z.Find(id);
            if (selectcust != null)
            {
                selectcust.type = type;
                selectcust.cust = cust;
                selectcust.power = power;
                selectcust.name = name;
                selectcust.tell1 = tell1;
                selectcust.mobile = mobile;
                selectcust.address = addres;
                selectcust.typeRel = typeRel;
                selectcust.pgcode = pgcode;
                selectcust.picURL = picURL;
                selectcust.x1 = x1;
                selectcust.x2 = x2;
                selectcust.date = date;
                selectcust.time = time;
                selectcust.un = un;

                mode6.Entry(selectcust).State = System.Data.Entity.EntityState.Modified;
                mode6.SaveChanges();
                return "تغیرات لحاظ شد";

            }
            else
            {
                return "نتوانستیم تغیرات را اعمال کنیم";
            }
        }
        public String deletcust(int id)
        {
            String response;
            customer_z selectcust = mode6.customer_z.Find(id);
            if (selectcust != null)
            {
                mode6.customer_z.Remove(selectcust);
                mode6.SaveChanges();
                response = "با موفقیت حذف شد";
            }
            else
            {
                response = "نتوانستیم حذف کنیم";
            }
            return response;
        }
        public JsonResult getalll()
        {
            List<customer_z> list;
            list = mode6.customer_z.ToList();
            var jsondata = Json(list, JsonRequestBehavior.AllowGet);
            return jsondata;
        }
        public String loogin(login_point loogin)
        {


            using (Model6 dc = new Model6())
            {
                var checkuser = dc.login_point.Where(a => a.username == loogin.username).FirstOrDefault();
                var checkpass = dc.login_point.Where(a => a.password == loogin.password).FirstOrDefault();
                if (checkuser != null && checkpass != null)
                {

                    return "ok";

                }
                else
                {
                    return "نام کاربری یا رمز اشتباه هست";
                }

            }
        }




        public ActionResult upload(HttpPostedFileBase file)
        {
            if (file != null && file.ContentLength > 0)
                try
                {
                    string path = Path.Combine(Server.MapPath("~/custpic"),
                                               Path.GetFileName(file.FileName));
                    file.SaveAs(path);
                    ViewBag.Message = "File uploaded successfully";
                }
                catch (Exception ex)
                {
                    ViewBag.Message = "ERROR:" + ex.Message.ToString();
                }
            else
            {
                ViewBag.Message = "You have not specified a file.";
            }
            return View();
        }

        public JsonResult insert_bazargardi(bazargardi baz)
        {
            mode7.bazargardi.Add(baz);
            mode7.SaveChanges();

            bazargardi t = mode7.bazargardi.ToList().Last();


            var jsondata = Json(t, JsonRequestBehavior.AllowGet);
            return jsondata;
        }
        public JsonResult getalll_bazargardi()
        {
            List<bazargardi> list;
            list = mode7.bazargardi.ToList();
            var jsondata = Json(list, JsonRequestBehavior.AllowGet);
            return jsondata;
        }
        public ActionResult upload_yakh(HttpPostedFileBase file)
        {
            if (file != null && file.ContentLength > 0)
                try
                {
                    string path = Path.Combine(Server.MapPath("~/yakhpic"),
                                               Path.GetFileName(file.FileName));
                    file.SaveAs(path);
                    ViewBag.Message = "File uploaded successfully";
                }
                catch (Exception ex)
                {
                    ViewBag.Message = "ERROR:" + ex.Message.ToString();
                }
            else
            {
                ViewBag.Message = "You have not specified a file.";
            }
            return View();
        }

        public JsonResult insert_tiket(tiket tik)
        {
            mode8.tiket.Add(tik);
            mode8.SaveChanges();

            tiket tt = mode8.tiket.ToList().Last();


            var jsondata = Json(tt, JsonRequestBehavior.AllowGet);
            return jsondata;
        }

        public String insert_respone(int id_tiket, string tdate, string ttime, string tcategori, string ttitle, string tdescription, string tbgcode, string bgname, string btell, string tvisitor, string tresponse, string trdate, string trtime, string truser, string tstatus, string x1, string x2, string x3, string x4)
        {
            tiket selectcust = mode8.tiket.Find(id_tiket);
            if (selectcust != null)
            {
                selectcust.tdate = tdate;
                selectcust.ttime = ttime;
                selectcust.tcategori = tcategori;
                selectcust.ttitle = ttitle;
                selectcust.tdescription = tdescription;
                selectcust.tbgcode = tbgcode;
                selectcust.bgname = bgname;
                selectcust.btell = btell;
                selectcust.tvisitor = tvisitor;
                selectcust.tresponse = tresponse;
                selectcust.trdate = trdate;
                selectcust.trtime = trtime;
                selectcust.truser = truser;
                selectcust.tstatus = tstatus;
                selectcust.x1 = x1;
                selectcust.x2 = x2;
                selectcust.x3 = x3;
                selectcust.x4 = x4;

                mode8.Entry(selectcust).State = System.Data.Entity.EntityState.Modified;
                mode8.SaveChanges();
                return "تغیرات لحاظ شد";

            }
            else
            {
                return "نتوانستیم تغیرات را اعمال کنیم";
            }
        }
        public JsonResult getaldata()
        {
            List<custdate> list;
            list = mode8.custdate.ToList();
            var jsondata = Json(list, JsonRequestBehavior.AllowGet);
            return jsondata;
        }

        public JsonResult getaltiket()
        {
            List<tiket> list;
            list = mode8.tiket.ToList();
            var jsondata = Json(list, JsonRequestBehavior.AllowGet);
            return jsondata;
        }
        public JsonResult getaltikett(int id_tiket)
        {
            tiket selecttiket = mode8.tiket.Find(id_tiket);
            // List<tiket> list;
            //  list = mode8.tiket.ToList();
            var jsondata = Json(selecttiket, JsonRequestBehavior.AllowGet);
            return jsondata;
        }
        public JsonResult getaltikettwithcode(string tbgcode)
        {

            tiket temp = mode8.tiket.FirstOrDefault(p => p.tbgcode == tbgcode);
            if (temp != null && temp.tbgcode == tbgcode)
            {

                //  var jsondata = Json(temp, JsonRequestBehavior.AllowGet);

                // return jsondata;


                string tbgcodee = tbgcode;

                List<tiket> list;
                var info = from n in mode8.tiket
                           where n.tbgcode.Contains(tbgcode)
                           select n;
                list = info.ToList();
                var jsondata = Json(list, JsonRequestBehavior.AllowGet);
                return jsondata;
            }
            else
            {
                return Json(new { Status = "nofind" }, JsonRequestBehavior.AllowGet);
            }










        }
        public JsonResult getaldatawithcode(string pdcode)
        {
            custdate tempp = mode8.custdate.FirstOrDefault(p => p.pdcode == pdcode);
            if (tempp != null && tempp.pdcode == pdcode)
            {

                //  var jsondata = Json(temp, JsonRequestBehavior.AllowGet);

                // return jsondata;


                string pdcodee = pdcode;

                List<custdate> list;
                var info = from n in mode8.custdate
                           where n.pdcode.Contains(pdcode)
                           select n;
                list = info.ToList();
                var jsondata = Json(list, JsonRequestBehavior.AllowGet);
                return jsondata;
            }
            else
            {
                return Json(new { Status = "nofind" }, JsonRequestBehavior.AllowGet);
            }

        }
        public JsonResult getalll_bazargardiwithcode(string bcode)
        {
            bazargardi temppp = mode8.bazargardi.FirstOrDefault(p => p.bcode == bcode);
            if (temppp != null && temppp.bcode == bcode)
            {



                string bcodee = bcode;

                List<bazargardi> list;
                var info = from n in mode8.bazargardi
                           where n.bcode.Contains(bcodee)
                           select n;
                list = info.ToList();
                var jsondata = Json(list, JsonRequestBehavior.AllowGet);
                return jsondata;
            }
            else
            {
                return Json(new { Status = "nofind" }, JsonRequestBehavior.AllowGet);
            }

        }
        public JsonResult getcustwithcode(string pgcode)
        {
            customer_z tempp = mode8.customer_z.FirstOrDefault(p => p.pgcode == pgcode);
            if (tempp != null && tempp.pgcode == pgcode)
            {

                //  var jsondata = Json(temp, JsonRequestBehavior.AllowGet);

                // return jsondata;


                string pgcodee = pgcode;

                List<customer_z> list;
                var info = from n in mode8.customer_z
                           where n.pgcode.Contains(pgcode)
                           select n;
                list = info.ToList();
                var jsondata = Json(list, JsonRequestBehavior.AllowGet);
                return jsondata;
            }
            else
            {
                return Json(new { Status = "nofind" }, JsonRequestBehavior.AllowGet);
            }

        }

        public JsonResult getalll_bazargardiwithuser(string bun)
        {
            bazargardi temppp = mode8.bazargardi.FirstOrDefault(p => p.bun == bun);
            if (temppp != null && temppp.bun == bun)
            {


                string bune = bun;

                List<bazargardi> list;
                var info = from n in mode8.bazargardi
                           where n.bun.Contains(bun)
                           select n;
                list = info.ToList();
                var jsondata = Json(list, JsonRequestBehavior.AllowGet);
                return jsondata;
            }
            else
            {
                return Json(new { Status = "nofind" }, JsonRequestBehavior.AllowGet);
            }

        }

        public JsonResult getaldatawithpdx6(string pdx6)
        {
            custdate tempp = mode8.custdate.FirstOrDefault(p => p.pdx6 == pdx6);
            if (tempp != null && tempp.pdx6 == pdx6)
            {
                string pdx66 = pdx6;

                List<custdate> list;
                var info = from n in mode8.custdate
                           where n.pdx6.Contains(pdx6)
                           select n;
                list = info.ToList();
                var jsondata = Json(list, JsonRequestBehavior.AllowGet);
                return jsondata;
            }
            else
            {
                return Json(new { Status = "nofind" }, JsonRequestBehavior.AllowGet);
            }

        }
        public JsonResult getaldatawithpdx5(string pdx5)
        {
            custdate tempp = mode8.custdate.FirstOrDefault(p => p.pdx5 == pdx5);
            if (tempp != null && tempp.pdx5 == pdx5)
            {
                string pdx55 = pdx5;
                List<custdate> list;
                var info = from n in mode8.custdate
                           where n.pdx5.Contains(pdx5)
                           select n;
                list = info.ToList();
                var jsondata = Json(list, JsonRequestBehavior.AllowGet);
                return jsondata;
            }
            else
            {
                return Json(new { Status = "nofind" }, JsonRequestBehavior.AllowGet);
            }

        }
        public ActionResult upload_vyakh(HttpPostedFileBase file)
        {
            if (file != null && file.ContentLength > 0)
                try
                {
                    string path = Path.Combine(Server.MapPath("~/vyakhpic"),
                                               Path.GetFileName(file.FileName));
                    file.SaveAs(path);
                    ViewBag.Message = "File uploaded successfully";
                }
                catch (Exception ex)
                {
                    ViewBag.Message = "ERROR:" + ex.Message.ToString();
                }
            else
            {
                ViewBag.Message = "You have not specified a file.";
            }
            return View();
        }
        public JsonResult getv(int id_V)
        {
            VV selectv = mode11.VV.Find(id_V);
            // List<tiket> list;
            //  list = mode8.tiket.ToList();
            var jsondata = Json(selectv, JsonRequestBehavior.AllowGet);
            return jsondata;
        }
        public JsonResult getvy(string c_code)
        {
            vy2 tempp = mode11.vy2.FirstOrDefault(p => p.c_code == c_code);
            if (tempp != null && tempp.c_code == c_code)
            {
                string c_codee = c_code;
                List<vy2> list;
                var info = (from n in mode11.vy2
                            where n.c_code.Contains(c_code)
                            orderby n.id_vy descending
                            select n).Take(1);
                list = info.ToList();
                var jsondata = Json(list, JsonRequestBehavior.AllowGet);
                return jsondata;
            }
            else
            {
                return Json(new { Status = "nofind" }, JsonRequestBehavior.AllowGet);
            }

        }
        public JsonResult insert_vy(vy2 upu)
        {
            mode11.vy2.Add(upu);
            mode11.SaveChanges();

            vy2 uppt = mode11.vy2.ToList().Last();


            var jsondata = Json(uppt, JsonRequestBehavior.AllowGet);
            return jsondata;
        }
        public String update_vy(int id_vy, string c_code, string userv, string url, string date, string time, string x1, string x2, string x3)
        {
            vy2 selectrecord = mode11.vy2.Find(id_vy);
            if (selectrecord != null)
            {
                selectrecord.id_vy = id_vy;
                selectrecord.c_code = c_code;
                selectrecord.userv = userv;
                selectrecord.url = url;
                selectrecord.date = date;
                selectrecord.date = date;
                selectrecord.time = time;
                selectrecord.x1 = x1;
                selectrecord.x2 = x2;
                selectrecord.x3 = x3;


                mode11.Entry(selectrecord).State = System.Data.Entity.EntityState.Modified;
                mode11.SaveChanges();
                return "تغیرات لحاظ شد";

            }
            else
            {
                return "no";

            }
        }
        public JsonResult getu(string username_l)
        {
            update2 tempp = mode11.update2.FirstOrDefault(p => p.username_l == username_l);
            if (tempp != null && tempp.username_l == username_l)
            {
                string username_le = username_l;
                List<update2> list;
                var info = (from n in mode11.update2
                            where n.username_l.Contains(username_l)
                            orderby n.id_update descending
                            select n).Take(1);
                list = info.ToList();
                var jsondata = Json(list, JsonRequestBehavior.AllowGet);
                return jsondata;
            }
            else
            {
                return Json(new { Status = "nofind" }, JsonRequestBehavior.AllowGet);
            }

        }
        public JsonResult insert_lastupdate(update2 up)
        {
            mode11.update2.Add(up);
            mode11.SaveChanges();

            update2 upp = mode11.update2.ToList().Last();


            var jsondata = Json(upp, JsonRequestBehavior.AllowGet);
            return jsondata;
        }
        public String update_lastupdate(int id_update, string last_update, string xx1, string xx2)
        {
            update2 selectrecord = mode11.update2.Find(id_update);
            if (selectrecord != null)
            {
                selectrecord.id_update = id_update;
                selectrecord.last_update = last_update;
                selectrecord.xx1 = xx1;
                selectrecord.xx2 = xx2;


                mode11.Entry(selectrecord).State = System.Data.Entity.EntityState.Modified;
                mode11.SaveChanges();
                return "تغیرات لحاظ شد";

            }
            else
            {

                return "no";

            }
        }
        public JsonResult getalll_bazargardiwithcodeee(string bcode)
        {



            bazargardi tempp = mode11.bazargardi.FirstOrDefault(p => p.bcode == bcode);
            if (tempp != null && tempp.bcode == bcode)
            {
                string bcodee = bcode;
                List<bazargardi> list;
                var info = (from n in mode11.bazargardi
                            where n.bcode.Contains(bcode)
                            orderby n.id_bazargardi descending
                            select n).Take(1);
                list = info.ToList();
                var jsondata = Json(list, JsonRequestBehavior.AllowGet);
                return jsondata;
            }
            else
            {
                return Json(new { Status = "nofind" }, JsonRequestBehavior.AllowGet);
            }



        }
        public JsonResult getalll_bazargardiwithuserdate(string bun, string bdate)
        {
            bazargardi temppp = mode11.bazargardi.FirstOrDefault(p => p.bun == bun & p.bdate == bdate);
            if (temppp != null && temppp.bun == bun && temppp.bdate == bdate)
            {
                string bune = bun;
                string bdatee = bdate;

                List<bazargardi> list;
                var info = from n in mode11.bazargardi
                           where n.bun.Contains(bun) && n.bdate.Contains(bdate)
                           select n;
                list = info.ToList();
                var jsondata = Json(list, JsonRequestBehavior.AllowGet);
                return jsondata;
            }
            else
            {
                return Json(new { Status = "nofind" }, JsonRequestBehavior.AllowGet);
            }

        }
        public JsonResult getvy3(string date, string userv)
        {

            vy2 tempppt = mode11.vy2.FirstOrDefault(p => p.date == date & p.userv == userv);
            if (tempppt != null && tempppt.date == date && tempppt.userv == userv)
            {
                string datee = date;
                string userve = userv;


                List<vy2> list;
                var info = from n in mode11.vy2
                           where n.date.Contains(date) && n.userv.Contains(userv)
                           select n;
                list = info.ToList();
                var jsondata = Json(list, JsonRequestBehavior.AllowGet);
                return jsondata;
            }
            else
            {
                return Json(new { Status = "nooooo" }, JsonRequestBehavior.AllowGet);
            }


        }
        public JsonResult newlogin(string name, string password)
        {

            point_user tempppt = mode12.point_user.FirstOrDefault(p => p.name == name & p.password == password);
            if (tempppt != null && tempppt.name == name && tempppt.password == password)
            {
                string namee = name;

                string passwordd = password;


                List<point_user> list;
                var info = from n in mode12.point_user
                           where n.name.Contains(name) && n.password.Contains(password)
                           select n;
                list = info.ToList();
                var jsondata = Json(list, JsonRequestBehavior.AllowGet);
                return jsondata;
            }
            else
            {
                string nameer = "er";
                string passworddr = "er";
                point_user nulle = mode12.point_user.FirstOrDefault(p => p.name == nameer & p.password == passworddr);
                List<point_user> listt;
                var infoo = from n in mode12.point_user
                            where n.name.Contains(nameer) && n.password.Contains(passworddr)
                            select n;
                listt = infoo.ToList();
                var jsondataa = Json(listt, JsonRequestBehavior.AllowGet);

                return jsondataa;
            }


        }
        public String update_newlogin(int id_user, string name, string mantage, string post, string tell, string password, string picurl, string token, string devicename, string deviceid, string lastupdate, string xx1, string xx2, string xx3, string xx4, string xx5)
        {
            point_user selectrecord = mode12.point_user.Find(id_user);
            if (selectrecord != null)
            {
                selectrecord.id_user = id_user;
                selectrecord.name = name;
                selectrecord.mantage = mantage;
                selectrecord.post = post;
                selectrecord.tell = tell;
                selectrecord.password = password;
                selectrecord.picurl = picurl;
                selectrecord.token = token;
                selectrecord.devicename = devicename;
                selectrecord.deviceid = deviceid;
                selectrecord.lastupdate = lastupdate;
                selectrecord.xx1 = xx1;
                selectrecord.xx2 = xx2;
                selectrecord.xx3 = xx3;
                selectrecord.xx4 = xx4;
                selectrecord.xx5 = xx5;


                mode12.Entry(selectrecord).State = System.Data.Entity.EntityState.Modified;
                mode12.SaveChanges();
                return "تغیرات لحاظ شد";

            }
            else
            {

                return "no";

            }
        }

        public JsonResult getvy2count2(string date)
        {
            string datee = date;
            var orders = (from p in mode12.vy2
                          where p.date.Contains(date)
                          orderby p.userv
                          select p.userv).Distinct();
            var orderss = (from p in mode12.vy2
                           where p.date.Contains(date)
                           orderby p.userv
                           select p.userv).Count();



            var jsondata = Json(new { orders, orderss }, JsonRequestBehavior.AllowGet);
            return jsondata;





        }
        public JsonResult getvy2counttoday(string date)
        {
            string datee = date;
            var orders = (from p in mode12.vy2
                          where p.date.Contains(date)
                          orderby p.userv

                          select p.userv).Distinct();
            var orderss = (from p in mode12.vy2
                           where p.date.Contains(date)
                           orderby p.userv
                           select p.userv).Count();



            var jsondata = Json(new { orders, orderss }, JsonRequestBehavior.AllowGet);
            return jsondata;





        }


        public JsonResult getvy2withftimeltimeuniqname(string date)
        {

            var list = mode12.vy2.ToList();

            var items = list.Select(s => new
            {
                name = s.userv,
            });
            items = items.Distinct();
            List<string> names = new List<string>();
            List<int> countToday = new List<int>();
            List<int> count = new List<int>();
            List<string> ftime = new List<string>();
            List<string> ltimetime = new List<string>();
            List<string> url = new List<string>();
            foreach (var item in items)
            {


                var temp = mode12.vy2.Where(p => p.userv == item.name && p.date == date).ToList();
                var temp2 = mode12.vy2.Where(p => p.userv == item.name).ToList();
                var templ = (from n in mode12.vy2 where n.userv.Contains(item.name) && n.date.Contains(date) orderby n.id_vy descending select n.time).Take(1).ToList();
                var tempf = (from n in mode12.vy2 where n.userv.Contains(item.name) && n.date.Contains(date) orderby n.id_vy ascending select n.time).Take(1).ToList();
                var turl = (from n in mode12.point_user where n.name.Contains(item.name) select n.picurl).ToList();

                // var tempf = mode12.vy2.Where(p => p.userv == item.name && p.date == date  ).ToList();


                names.Add(item.name);
                countToday.Add(temp.Count);
                count.Add(temp2.Count);
                ftime.Add(tempf.FirstOrDefault());
                ltimetime.Add(templ.FirstOrDefault());
                url.Add(turl.FirstOrDefault());
            }

            List<PointerViewModel2> lst = new List<PointerViewModel2>();

            for (int i = 0; i < names.Count; i++)
            {
                PointerViewModel2 pointt = new PointerViewModel2();
                pointt.name = names[i];
                pointt.countToday = countToday[i];
                pointt.count = count[i];
                pointt.ftime = ftime[i];
                pointt.ltime = ltimetime[i];
                pointt.url = url[i];
                lst.Add(pointt);
            }
            return Json(lst, JsonRequestBehavior.AllowGet);

        }
        public JsonResult getvy2count(string date)
        {

            var list = mode12.vy2.ToList();

            var items = list.Select(s => new
            {
                name = s.userv,
            });
            items = items.Distinct();
            List<string> names = new List<string>();
            List<int> countToday = new List<int>();
            List<int> count = new List<int>();

            foreach (var item in items)
            {
                var temp = mode12.vy2.Where(p => p.userv == item.name && p.date == date).ToList();
                var temp2 = mode12.vy2.Where(p => p.userv == item.name).ToList();
                names.Add(item.name);
                countToday.Add(temp.Count);
                count.Add(temp2.Count);
            }

            List<PointerViewModel> lst = new List<PointerViewModel>();

            for (int i = 0; i < names.Count; i++)
            {
                PointerViewModel point = new PointerViewModel();
                point.name = names[i];
                point.countToday = countToday[i];
                point.count = count[i];

                lst.Add(point);
            }
            return Json(lst, JsonRequestBehavior.AllowGet);

        }

        public JsonResult getbazargardiwithftimeltimeuniqname(string bdate)
        {

            var list = mode12.bazargardi.ToList();

            var items = list.Select(s => new
            {
                name = s.bun,
            });
            items = items.Distinct();
            List<string> names = new List<string>();
            List<int> countToday = new List<int>();
            List<int> count = new List<int>();
            List<string> ftime = new List<string>();
            List<string> ltimetime = new List<string>();
            List<string> url = new List<string>();

            foreach (var item in items)
            {


                var temp = mode12.bazargardi.Where(p => p.bun == item.name && p.bdate == bdate).ToList();
                var temp2 = mode12.bazargardi.Where(p => p.bun == item.name).ToList();
                var templ = (from n in mode12.bazargardi where n.bun.Contains(item.name) && n.bdate.Contains(bdate) orderby n.id_bazargardi descending select n.btime).Take(1).ToList();
                var tempf = (from n in mode12.bazargardi where n.bun.Contains(item.name) && n.bdate.Contains(bdate) orderby n.id_bazargardi ascending select n.btime).Take(1).ToList();
                var turl = (from n in mode12.point_user where n.name.Contains(item.name) select n.picurl).ToList();
                // var tempf = mode12.vy2.Where(p => p.userv == item.name && p.date == date  ).ToList();


                names.Add(item.name);
                countToday.Add(temp.Count);
                count.Add(temp2.Count);
                ftime.Add(tempf.FirstOrDefault());
                ltimetime.Add(templ.FirstOrDefault());
                url.Add(turl.FirstOrDefault());
            }

            List<PointerViewModel2> lst = new List<PointerViewModel2>();

            for (int i = 0; i < names.Count; i++)
            {
                PointerViewModel2 pointt = new PointerViewModel2();
                pointt.name = names[i];
                pointt.countToday = countToday[i];
                pointt.count = count[i];
                pointt.ftime = ftime[i];
                pointt.ltime = ltimetime[i];
                pointt.url = url[i];

                lst.Add(pointt);
            }
            return Json(lst, JsonRequestBehavior.AllowGet);

        }


        public JsonResult getreport(string date)
        {
            string datee = date;

            var yakhtoday = (from p in mode12.vy2
                             where p.date.Contains(date)
                             orderby p.userv
                             select p.userv).Count();

            var yakhtotal = (from p in mode12.vy2 select p.id_vy).Count();

            var bazartoday = (from p in mode12.bazargardi
                              where p.bdate.Contains(date)
                              orderby p.id_bazargardi
                              select p.id_bazargardi).Count();
            var bazartotal = (from p in mode12.bazargardi

                              select p.id_bazargardi).Count();

            var custdate = (from p in mode12.customer_z
                            where p.date.Contains(date)
                            select p.id).Count();

            var custtotal = (from p in mode12.customer_z

                             select p.id).Count();



            var shekayattoday = (from p in mode12.tiket
                                 where p.tdate.Contains(date)
                                 select p.id_tiket).Count();


            var shekayattotal = (from p in mode12.tiket

                                 select p.id_tiket).Count();


            var jsondata = Json(new { yakhtoday, yakhtotal, bazartoday, bazartotal, custdate, custtotal, shekayattoday, shekayattotal }, JsonRequestBehavior.AllowGet);
            return jsondata;





        }








        public JsonResult Logint(String Phone)
        {
            var temp = mode12.point_user.FirstOrDefault(p => p.tell == Phone);
            String Code;
            if (temp == null)
            {
                point_user user = new point_user();
                user.tell = Phone;
                user.xx3 = DateTime.Now.ToString();
                Random r = new Random();
                Code = r.Next(1000, 9999).ToString();
                user.xx4 = Code;
                mode12.point_user.Add(user);
                mode12.SaveChanges();
            }
            else
            {
                Random r = new Random();
                Code = r.Next(1000, 9999).ToString();
                temp.xx4 = Code;
                temp.xx3 = DateTime.Now.ToString();
                mode12.Entry(temp).State = EntityState.Modified;
                mode12.SaveChanges();
            }
            String textWellcome = "به کاتالوگ دیجیتال محصولات پگاه خوش آمدید. کد ورود به اپلیکیشن شما :" + Code + " می باشد";
            sendSMS(Phone, textWellcome);

            return Json(new { statue = "Success" }, JsonRequestBehavior.AllowGet);

        }

        public JsonResult checkCode(String Phone, String Code)
        {
            var temp = mode12.point_user.FirstOrDefault(p => p.tell == Phone);
            if (temp.xx4 == Code)
            {
                TimeSpan tempTime = DateTime.Now - Convert.ToDateTime(temp.xx3);
                double second = tempTime.TotalSeconds;
                if (second > 90)
                {
                    return Json(new { statue = "CodeExpired" }, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    return Json(new { statue = "Success", id = temp.id_user, name = temp.name }, JsonRequestBehavior.AllowGet);
                }
            }
            else
            {
                return Json(new { statue = "InvalidCode" }, JsonRequestBehavior.AllowGet);

            }
        }



        public void sendSMS(String Phone, String Text)
        {




            string userApiKey = "kUfLF9xOCq017AKUU7xRZT9X9okTZmapB8Ed626mOHmrFupPN5oDEC5hB6s3LVEj";
            string secretKey = "katalog";


            SmsIrRestful.Token tk = new SmsIrRestful.Token();
            string token = tk.GetToken(userApiKey, secretKey);



            var messageSendObject = new MessageSendObject()
            {

                Messages = new List<string> { Text }.ToArray(),
                MobileNumbers = new List<string> { Phone }.ToArray(),
                LineNumber = "30007732009050",
                SendDateTime = null,
                CanContinueInCaseOfError = true
            };

            MessageSendResponseObject messageSendResponseObject = new MessageSend().Send(token, messageSendObject);

            if (messageSendResponseObject.IsSuccessful)
            {

            }
            else
            {

            }
        }

    }

    }

